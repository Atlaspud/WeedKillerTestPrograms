using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Reflection; 
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using AForge;
using AForge.Imaging;
//using Excel = Microsoft.Office.Interop.Excel;

namespace Image_Processor_2._0
{
    public partial class Form1 : Form
    {
        // Image acquisition variables
        const int ImageWidth = 2048;
        const int ImageHeight = 1536;
        Image<Bgr, Byte> originalImage;
        string imageFolder;
        int frameTotal;
        int frameCount;
        int frameRate = 1;
        double PixelResolution = 5; // pixels per mm
        double MaximumSpeed = 500; // mm per second
        Rectangle ROI;

        // Image processing variables
        Gray BinaryThreshold = new Gray(17);
        int OpeningSize = 22;
        int BLOBSize = 122;
        int patchSize = 100;
        int binSize = 90;
        long timeDummy;
        StringBuilder log;
        long averageAcquisitionTime;
        long averageSegmentationTime;
        long averageFeatureExtractionTime;
        long averageProcessingTime;
        long averageBlobExtractionTime;
        long averageClassificationTime;
        double BhattacharyyaThreshold = 0.9950;
        List<double[]> leafHistograms;
        double[] SampleLantanaHistogram;
        int histogramCount;
        List<Weed> weeds;
        bool saveHistogramsFlag = false;
        int[] knownWeeds = new int[16] { 2, 3, 4, 5, 9, 10, 14, 15, 16, 19, 21, 22, 26, 27, 31, 33 };

        public Form1()
        {
            InitializeComponent();
            logoPictureBox.Image = Bitmap.FromFile(Environment.CurrentDirectory + "\\jcu.png");
            ROI = new Rectangle(0, 0, ImageWidth, ImageHeight);
            //ROI = new Rectangle(0, ((ImageHeight - (int)(MaximumSpeed / frameRate * ImageRatio)) / 2), ImageWidth, (int)(MaximumSpeed / frameRate * ImageRatio));
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            // Browse for new folder
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                // Save the folder path
                imageFolder = openFolder.SelectedPath;

                // Find the total number of frames
                string[] files = Directory.GetFiles(imageFolder, "*.jpg", SearchOption.AllDirectories);
                frameTotal = files.Length;
            }
            startButton.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Update button visibility
            pauseButton.Enabled = true;
            stopButton.Enabled = true;
            startButton.Enabled = false;
            nextFrameButton.Enabled = true;

            // Open string builder for log
            log = new StringBuilder();
            
            // Reset textbox
            statusTextBox.Text = "";

            // Start the counter
            timer1.Enabled = true;
            frameCount = 1;
            statusTextBox.AppendText(frameTotal + " frames identified in " + "\"" + imageFolder + "\".\n");
            log.AppendLine(frameTotal + " frames identified in " + "\"" + imageFolder + "\".");
            statusTextBox.AppendText(" \n");
            log.AppendLine("");
            log.AppendLine("Bhattacharyya Coefficients");

            // Create or work with histogram directory
            if (Directory.Exists(imageFolder + "\\Histograms\\bin" + binSize))
            {
                string[] fileNames = Directory.GetFiles(imageFolder + "\\Histograms\\bin" + binSize + "\\");
                if (fileNames.Length == 0)
                {
                    saveHistogramsFlag = true;
                }
                else
                {
                    // compute average histogram from every histogram in directory
                    SampleLantanaHistogram = new double[360 / binSize];
                    double[] orientations = new double[360 / binSize];
                    foreach (string fileName in fileNames)
                    {
                        var reader = new StreamReader(File.OpenRead(fileName));
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            SampleLantanaHistogram[Convert.ToInt32(values[0]) / binSize] += Convert.ToDouble(values[1]);
                        }
                        reader.Close();
                    }
                    // Save sample lantana histogram data to csv
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Orientation,Intensity");
                    for (int index = 0; index < SampleLantanaHistogram.Length; index++)
                    {
                        orientations[index] = index * binSize;
                        SampleLantanaHistogram[index] /= fileNames.Length;
                        sb.AppendLine(orientations[index] + "," + SampleLantanaHistogram[index]);
                    }
                    File.WriteAllText(imageFolder + "\\Histograms\\bin" + binSize + "SampleLantanaHistogram.csv", sb.ToString());
                    // Save sample lantana histogram plot
                    barChart.Series["Series1"].Points.DataBindXY(orientations, "Gradient Orientation", SampleLantanaHistogram, "Normalised Gradient Intensity");
                    if (saveCheckBox.Checked == true)
                    {
                        barChart.SaveImage(imageFolder + "\\SampleLantanaHistogram.png", ImageFormat.Png);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(imageFolder + "\\Histograms\\bin" + binSize);
                saveHistogramsFlag = true;
            }

            // Instantiate processing time variables
            averageAcquisitionTime = 0;
            averageSegmentationTime = 0;
            averageFeatureExtractionTime = 0;
            averageProcessingTime = 0;
            averageBlobExtractionTime = 0;
            averageClassificationTime = 0;

            leafHistograms = new List<double[]>();
            histogramCount = 0;
            weeds = new List<Weed>();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            // Pause or unpause the timer
            timer1.Enabled = !timer1.Enabled;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Update buttons
            startButton.Enabled = true;
            pauseButton.Enabled = false;

            // Close form
            this.Close();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Update buttons
            startButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;

            timer1.Enabled = false;
            frameCount = 1;
        }

        private void nextFrameButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (frameCount <= frameTotal)
            {
                // Start timing process
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Image acquisition
                originalImage = new Image<Bgr, Byte>(imageFolder + "\\" + frameCount + ".jpg");
                originalImage.ROI = ROI;
                if (saveCheckBox.Checked == true)
                {
                    originalImage.Save(imageFolder + "\\" + frameCount + ".png");
                }
                if (displayCheckBox.Checked == true)
                {
                    pictureBox1.Image = originalImage.ToBitmap();
                }

                // Measure image acquisition time
                timeDummy = stopwatch.ElapsedMilliseconds;
                averageAcquisitionTime += timeDummy;

                // Image segmentation
                Image<Gray, Byte>[] channel = originalImage.Split();
                Image<Gray, Byte> grayImage = channel[1] - channel[2];
                if (displayCheckBox.Checked == true)
                {
                    pictureBox2.Image = grayImage.ToBitmap();
                }
                Image <Gray, Byte> segmentedImage = grayImage.ThresholdBinary(BinaryThreshold, new Gray(255));
                StructuringElementEx openingElement = new StructuringElementEx(OpeningSize * 2, OpeningSize * 2, OpeningSize, OpeningSize, CV_ELEMENT_SHAPE.CV_SHAPE_ELLIPSE);
                segmentedImage._MorphologyEx(openingElement, CV_MORPH_OP.CV_MOP_OPEN, 1);
                if (displayCheckBox.Checked == true)
                {
                    pictureBox3.Image = segmentedImage.ToBitmap();
                }
                if (saveCheckBox.Checked == true)
                {
                    segmentedImage.Save(imageFolder + "\\" + frameCount + ".png");
                }

                // Measure image segmentation time
                averageSegmentationTime += stopwatch.ElapsedMilliseconds - timeDummy;
                timeDummy = stopwatch.ElapsedMilliseconds;

                // BLOB extraction
                Bitmap clone = segmentedImage.ToBitmap();
                BlobCounter blobCounter = new BlobCounter();
                blobCounter.MinWidth = BLOBSize;
                blobCounter.MinHeight = BLOBSize;
                blobCounter.FilterBlobs = true;
                blobCounter.ProcessImage(clone);
                Blob[] blobs = blobCounter.GetObjectsInformation();

                // Measure BLOB extraction time
                statusTextBox.AppendText(blobs.Length + " leaves identified.\n");
                averageBlobExtractionTime += stopwatch.ElapsedMilliseconds - timeDummy;
                timeDummy = stopwatch.ElapsedMilliseconds;

                // Leaf image processing
                int leafCount = 1;
                Image<Gray, Byte> image = originalImage.Convert<Gray, Byte>();
                //image._And(segmentedImage);
                foreach (Blob blob in blobs)
                {
                    // Set ROI to texture patch
                    image.ROI = new Rectangle(blob.Rectangle.X + blob.Rectangle.Width / 2 - patchSize / 2, blob.Rectangle.Y + blob.Rectangle.Height / 2 - patchSize / 2, patchSize, patchSize);
                    //image.ROI = blob.Rectangle;
                    originalImage.ROI = new Rectangle((ROI.X + blob.Rectangle.X), (ROI.Y + blob.Rectangle.Y), blob.Rectangle.Width, blob.Rectangle.Height);
                    //originalImage.ROI = blob.Rectangle;
                    if (saveCheckBox.Checked == true)
                    {
                        image.Save(imageFolder + "\\" + frameCount + "-" + leafCount + "Gray.png");
                        originalImage.Save(imageFolder + "\\" + frameCount + "-" + leafCount + "Colour.png");
                    }
                    if (displayCheckBox.Checked == true)
                    {
                        pictureBox4.Image = originalImage.ToBitmap();
                    }
                    // Feature extraction
                    if (featureExtractionCheckBox.Checked == true)
                    {
                        // Calculate histogram of oriented gradient intensity
                        Image<Gray, float> dx = image.Sobel(1, 0, 3);
                        Image<Gray, float> dy = image.Sobel(0, 1, 3);
                        if (saveCheckBox.Checked == true)
                        {
                            dx.Save(imageFolder + "\\" + frameCount + "-" + leafCount + "sobelx.png");
                            dy.Save(imageFolder + "\\" + frameCount + "-" + leafCount + "sobely.png");
                        }
                        float[, ,] dxData = dx.Data;
                        float[, ,] dyData = dy.Data;
                        double[] intensities = new double[360 / binSize];
                        double[] orientations = new double[360 / binSize];
                        double orientation = 0;
                        double intensity = 0;
                        double totalIntensity = 0;
                        for (int i = patchSize - 1; i >= 0; i--)
                        {
                            for (int j = patchSize - 1; j >= 0; j--)
                            {
                                // Calculate gradient orientation and intensity at pixel (i,j)
                                orientation = Math.Atan2((double)dyData[i, j, 0], (double)(dxData[i, j, 0])) * 180.0 / Math.PI + 180.0;
                                intensity = Math.Sqrt(Math.Pow((double)dxData[i, j, 0],2) + Math.Pow((double)dyData[i, j, 0],2));
                                // Accumulate the total gradient intensity
                                totalIntensity += intensity;
                                // Accumulate orientation-specific gradient intensity
                                for (int k = 0; k < (360 / binSize); k++)
                                {
                                    orientations[k] = k * binSize;
                                    if (orientation < 0.0 || orientation > 360.0)
                                    {
                                        statusTextBox.AppendText("Unacceptable orientation calculated.\n");
                                    }
                                    else if (orientation >= (double)(k * binSize) && orientation < (double)((k + 1) * binSize))
                                    {
                                        intensities[k] += intensity;
                                        break;
                                    }
                                    else if (orientation == 360.0)
                                    {
                                        intensities[0] += intensity;
                                        break;
                                    }
                                }
                            }
                        }
                        leafHistograms.Add(new double[360 / binSize]);
                        int m = Array.IndexOf(intensities, intensities.Max());
                        for (int k = 0; k < (360 / binSize); k++)
                        {
                            // Perform intensity normalisation and rotation normalisation by circular-shift of orientation
                            leafHistograms[histogramCount][k] = intensities[(m + k) % (360 / binSize)] / totalIntensity;
                        }
                        // Save normalised histogram plot
                        if (saveCheckBox.Checked == true)
                        {
                            barChart.Series["Series1"].Points.DataBindXY(orientations, "Gradient Orientation", leafHistograms[histogramCount], "Normalised Gradient Intensity");
                            barChart.SaveImage(imageFolder + "\\" + frameCount + "-" + leafCount + "Histogram.png", ImageFormat.Png);
                        }
                        // Measure feature extraction time
                        averageFeatureExtractionTime += stopwatch.ElapsedMilliseconds - timeDummy;
                        timeDummy = stopwatch.ElapsedMilliseconds;
                        if(saveHistogramsFlag == true)
                        {
                            //if (knownWeeds.Contains(histogramCount))
                            //{
                                // Save histogram data to csv
                                StringBuilder sb = new StringBuilder();
                                sb.AppendLine("Orientation,Intensity");
                                for (int index = 0; index < leafHistograms[histogramCount].Length; index++)
                                {
                                    sb.AppendLine(orientations[index] + "," + leafHistograms[histogramCount][index]);
                                }
                                File.WriteAllText(imageFolder + "\\Histograms\\bin" + binSize + "\\" + histogramCount + ".csv", sb.ToString());
                            //}
                        }
                        else if(!saveHistogramsFlag && classificationCheckBox.Checked)
                        {
                            // Classification of histogram via matching with average lantana sample histogram
                            double bhattacharyyaCoefficient = new double();
                            for (int k = 0; k < (360 / binSize); k++)
                            {
                                bhattacharyyaCoefficient += Math.Sqrt(leafHistograms[histogramCount][k] * SampleLantanaHistogram[k]);
                            }
                            if (bhattacharyyaCoefficient >= BhattacharyyaThreshold)
                            {
                                // Leaf is Lantana Camara, for all intents and purposes
                                // Save leaf ROI to be dee-stroyed
                                weeds.Add(new Weed() { frame = frameCount, leaf = leafCount, histogram = leafHistograms[histogramCount], ROI = blob.Rectangle });
                                statusTextBox.AppendText("Leaf " + leafCount + " in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ") = Weed\n");
                            }
                            log.AppendLine(bhattacharyyaCoefficient.ToString());

                            // Measure classification time
                            averageClassificationTime += stopwatch.ElapsedMilliseconds - timeDummy;
                            timeDummy = stopwatch.ElapsedMilliseconds;
                        }
                        leafCount++;
                    }
                    histogramCount++;
                }
                // Measure total processing time
                stopwatch.Stop();
                averageProcessingTime += stopwatch.ElapsedMilliseconds;
                
                // Increment frame count and reset stopwatch
                frameCount++;
                stopwatch.Reset();
                if (frameByFrameCheckBox.Checked)
                {
                    timer1.Enabled = false;
                }
            }
            else
            {
                // Update buttons
                startButton.Enabled = true;
                pauseButton.Enabled = false;
                stopButton.Enabled = false;

                // Stop the timer
                timer1.Enabled = false;
                frameCount = 1;
                
                // Cross-classification via histogram matching using Excel
                if (crossClassificationCheckBox.Checked == true)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    double[] bhattacharyyaCoefficients = new double[leafHistograms.Count * (leafHistograms.Count + 1) / 2];
                    statusTextBox.AppendText("Bhattacharyya Coefficients:\n");
                    log.AppendLine("Bhattacharyya Coefficients:");
                    for (int x = 1; x < leafHistograms.Count; x++)
                    {
                        for (int y = 0; y < x; y++)
                        {
                            for (int k = 0; k < (360 / binSize); k++)
                            {
                                bhattacharyyaCoefficients[x*(x - 1)/2 + y] += Math.Sqrt(leafHistograms[x][k] * leafHistograms[y][k]);
                            }
                            statusTextBox.AppendText("B(" + (x + 1) + "," + (y + 1) + ") = " + bhattacharyyaCoefficients[x*(x - 1)/2 + y] + "\n");
                            log.AppendLine("B(" + (x + 1) + "," + (y + 1) + ") = " + bhattacharyyaCoefficients[x*(x - 1)/2 + y]);
                        }
                    }
                    /*// Save classification confusion matrix to Excel workbook
                    Excel.Application oXL;
                    Excel._Workbook oWB;
                    Excel._Worksheet oSheet;
                    Excel.Range oRng;
                    oXL = new Excel.Application();
                    oXL.Visible = false;
                    oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                    oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                    string[,] data = new string[leafHistograms.Count, leafHistograms.Count];
                    data[0, 0] = "1";
                    for (int x = 1; x < leafHistograms.Count; x++)
                    {
                        for (int y = 0; y <= x; y++)
                        {
                            if (x == y)
                            {
                                data[x, y] = "1";
                            }
                            else
                            {
                                data[x, y] = bhattacharyyaCoefficients[x * (x - 1) / 2 + y].ToString();
                                data[y, x] = bhattacharyyaCoefficients[x * (x - 1) / 2 + y].ToString();
                            }
                        }
                    }
                    int dividend = leafHistograms.Count;
                    string columnName = String.Empty;
                    int modulo;
                    while (dividend > 0)
                    {
                        modulo = (dividend - 1) % 26;
                        columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                        dividend = (int)((dividend - modulo) / 26);
                    }
                    oSheet.get_Range("A1", columnName + leafHistograms.Count.ToString()).Value2 = data;
                    oRng = oSheet.get_Range("A1", columnName + "1");
                    oRng.EntireColumn.AutoFit();
                    // delete columns
                    oRng = oSheet.get_Range("A1", "A34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("A1", "A34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("E1", "E34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("E1", "E34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("E1", "E34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("G1", "G34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("G1", "G34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("G1", "G34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("J1", "J34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("J1", "J34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("K1", "K34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("M1", "M34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("M1", "M34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("M1", "M34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("O1", "O34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("O1", "O34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("O1", "O34");
                    oRng.Delete();
                    oRng = oSheet.get_Range("P1", "P34");
                    oRng.Delete();
                    
                    if (File.Exists(imageFolder + "\\ConfusionMatrix" + binSize + ".xlsx"))
                    {
                        File.Delete(imageFolder + "\\ConfusionMatrix" + binSize + ".xlsx");
                    }
                    oWB.SaveAs(imageFolder + "\\ConfusionMatrix" + binSize + ".xlsx");
                    oXL.Quit();
                    */
                }

                // Write average image processing times
                statusTextBox.AppendText(" \n");
                statusTextBox.AppendText("Processing Times\n");
                log.AppendLine("");
                log.AppendLine("Processing Times");
                averageAcquisitionTime /= frameTotal;
                statusTextBox.AppendText("Average acquisition time: " + averageAcquisitionTime + " ms\n");
                log.AppendLine("Average acquisition time: " + averageAcquisitionTime + " ms");
                averageSegmentationTime /= frameTotal;
                statusTextBox.AppendText("Average segmentation time: " + averageSegmentationTime + " ms\n");
                log.AppendLine("Average segmentation time: " + averageSegmentationTime + " ms");
                averageFeatureExtractionTime /= frameTotal;
                statusTextBox.AppendText("Average feature extraction time: " + averageFeatureExtractionTime + " ms\n");
                log.AppendLine("Average feature extraction time: " + averageFeatureExtractionTime + " ms");
                averageBlobExtractionTime /= frameTotal;
                statusTextBox.AppendText("Average BLOB extraction time: " + averageBlobExtractionTime + " ms\n");
                log.AppendLine("Average BLOB extraction time: " + averageBlobExtractionTime + " ms");
                averageClassificationTime /= frameTotal;
                statusTextBox.AppendText("Average classification time: " + averageClassificationTime + " ms\n");
                log.AppendLine("Average classification time: " + averageClassificationTime + " ms");
                averageProcessingTime /= frameTotal;
                statusTextBox.AppendText("Average processing time: " + averageProcessingTime + " ms\n");
                log.AppendLine("Average processing time: " + averageProcessingTime + " ms");
                log.AppendLine("");

                // Write weed identification information
                if (saveHistogramsFlag == false)
                {
                    log.AppendLine("Identified Weeds");
                    //statusTextBox.AppendText(" \n");
                    //statusTextBox.AppendText("Identified Weeds\n");
                    int i = 0;
                    foreach (Weed weed in weeds)
                    {
                        i++;
                        //statusTextBox.AppendText(i + ": Leaf " + weed.leaf + " in frame " + weed.frame + " at (" + weed.ROI.X + "," + weed.ROI.Y + ").\n");
                        log.AppendLine(i + ": Leaf " + weed.leaf + " in frame " + weed.frame + " at (" + weed.ROI.X + "," + weed.ROI.Y + ").");
                    }
                }
                
                // Save and close text file
                File.WriteAllText(imageFolder + "\\Log.txt", log.ToString());
            }
            
        }

        private void frameRateBar_ValueChanged(object sender, EventArgs e)
        {
            // Update the timer interval matching the frame rate
            timer1.Interval = (int)(1000 / frameRateBar.Value);
            frameRate = frameRateBar.Value;
            frameRateValue.Text = frameRateBar.Value + " fps";

            // Update the image ROI based on the selected frame rate
            if (frameRateBar.Value == 1)
            {
                ROI = new Rectangle(0, 0, ImageWidth, ImageHeight);
            }
            else
            {
                ROI = new Rectangle(0, ((ImageHeight - (int)(MaximumSpeed / frameRate * PixelResolution)) / 2), ImageWidth, (int)(MaximumSpeed / frameRate * PixelResolution));
            }
        }

        private void binaryThresholdBar_ValueChanged(object sender, EventArgs e)
        {
            BinaryThreshold = new Gray(binaryThresholdBar.Value);
            binaryThresholdValue.Text = binaryThresholdBar.Value.ToString();
        }

        private void openingSizeBar_ValueChanged(object sender, EventArgs e)
        {
            OpeningSize = openingSizeBar.Value;
            openingSizeValue.Text = openingSizeBar.Value + " px";
        }

        private void patchSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            patchSize = patchSizeTrackBar.Value;
            patchSizeValue.Text = patchSizeTrackBar.Value + " px";
        }

        private void blobSizeBar_ValueChanged(object sender, EventArgs e)
        {
            BLOBSize = BLOBSizeBar.Value;
            blobSizeValue.Text = BLOBSizeBar.Value + " px";
        }
    }
    public class Weed
    {
        // Frame number field and property
        private int _frame;
        public int frame
        {
            get { return _frame; }
            set { _frame = value; }
        }

        // Leaf number (in frame) field and property
        private int _leaf;
        public int leaf
        {
            get { return _leaf; }
            set { _leaf = value; }
        }

        // Histogram of oriented gradient intensity
        private double[] _histogram;

        public double[] histogram
        {
            get { return _histogram; }
            set { _histogram = value; }
        }

        // Weed ROI rectangle within frame
        private Rectangle _ROI;
        public Rectangle ROI
        {
            get { return _ROI; }
            set { _ROI = value; }
        }
    }
}