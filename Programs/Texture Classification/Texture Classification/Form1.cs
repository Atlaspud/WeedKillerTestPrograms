using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using AForge;
using AForge.Video;
using AForge.Imaging;


namespace Texture_Classification
{
    public partial class Form1 : Form
    {
        List<TextureWindow> textureWindows;
        int WindowSize = 100;
        int BinSize = 1;
        Stopwatch stopwatch1;
        Stopwatch stopwatch2;
        List<Image<Bgr, Byte>> originalImages;
        List<Image<Gray, Byte>> binaryMasks;
        Image<Bgr, Byte> originalImage;
        Image<Gray, Byte> binaryMask;

        const int ImageHeight = 1200;
        const int ImageWidth = 1600;

        double FrameRate = 2.5;
        int BLOBSize = 120;
        int MorphologySize = 40;
        int BinaryThreshold = 20;
        long averageSpareTime;
        long averageProcessingTime;
        long averageAcquisitionTime;
        long averageSegmentationTime;
        long averageBLOBExtractionTime;
        long averageHoGTime;
        int frameCount;
        int leafCount;
        string log;
        string imageFolder;
        int frameTotal;
        bool useBLOBs = true;

        volatile bool stopThread;

        List<Dictionary<String, double[]>> histograms;

        public Form1()
        {
            InitializeComponent();
        }

        private unsafe void browseButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            browseButton.Enabled = true;
            // Browse for new folder
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                // Save the folder path
                imageFolder = openFolder.SelectedPath;

                // Find the total number of frames
                string[] files = Directory.GetFiles(imageFolder, "*.tif", SearchOption.AllDirectories);
                frameTotal = files.Length;
            }
            AppendTextBox(frameTotal + " total frames identified in " + "\"" + imageFolder + "\"." + Environment.NewLine);
            log += frameTotal + " total frames identified in " + "\"" + imageFolder + "\"." + Environment.NewLine;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
            browseButton.Enabled = false;

            textBox1.Text = "";
            log = "";

            frameCount = 0;
            leafCount = 0;
            averageAcquisitionTime = 0;
            averageSegmentationTime = 0;
            averageBLOBExtractionTime = 0;
            averageHoGTime = 0;
            averageProcessingTime = 0;

            originalImages = new List<Image<Bgr, Byte>>();
            binaryMasks = new List<Image<Gray, Byte>>();

            stopwatch1 = new Stopwatch();
            stopwatch2 = new Stopwatch();
            stopwatch1.Start();

            histograms = new List<Dictionary<String, double[]>>();
            stopThread = false;

            frameCount = 0;
            Thread loopThread = new Thread(ThreadStart);
            loopThread.Start();

        }

        private void ThreadStart()
        {
            while (frameCount < frameTotal)
            {
                if (!stopThread)
                {
                    leafCount = 0;
                    averageSpareTime += stopwatch1.ElapsedMilliseconds;
                    stopwatch1.Restart();
                    stopwatch2.Restart();
                    AppendTextBox("Frame " + frameCount + " processed." + Environment.NewLine);
                    log += "Frame " + frameCount + " processed." + Environment.NewLine;

                    originalImage = new Image<Bgr, Byte>(imageFolder + "\\" + (frameCount) + ".tif");
                    if (displayOn.Checked == true)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            pictureBox1.Image = originalImage.ToBitmap();
                            pictureBox1.Update();
                        }));
                    }
                    if (saveImagesOn.Checked == true)
                    {
                        originalImage.Save(imageFolder + "\\" + (frameCount) + ".tif");
                    }
                    averageAcquisitionTime += stopwatch2.ElapsedMilliseconds;
                    stopwatch2.Restart();

                    binaryMask = Segmentation(originalImage);
                    if (displayOn.Checked)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            pictureBox2.Image = binaryMask.ToBitmap();
                            pictureBox2.Update();
                        }));
                    }
                    if (saveImagesOn.Checked)
                    {
                        binaryMask.Save(imageFolder + "\\mask" + frameCount + ".png");
                    }
                    averageSegmentationTime += stopwatch2.ElapsedMilliseconds;
                    stopwatch2.Restart();

                    //BLOB extraction
                    textureWindows = BLOBExtraction(binaryMask, originalImage.Convert<Gray, Byte>());
                    averageBLOBExtractionTime += stopwatch2.ElapsedMilliseconds;
                    stopwatch2.Restart();

                    //Histogram of Oriented Gradients
                    foreach (TextureWindow window in textureWindows)
                    {
                        Dictionary<String, double[]> histogram = calculateHistogram(window);
                        histograms.Add(histogram);
                        leafCount++;
                    }
                    averageHoGTime += stopwatch2.ElapsedMilliseconds;
                    stopwatch2.Restart();

                    frameCount++;
                    averageProcessingTime += stopwatch1.ElapsedMilliseconds;
                    stopwatch1.Restart();
                }
            }

            //Save normalised histogram csv
            String data = "Orientation";
            for (int i = 0; i < histograms.Count; i++)
            {
                data += ",Leaf " + i;
            }
            for (int i = 0; i < (360 / BinSize); i++)
            {
                data += "\n" + histograms[0]["orientation"][i];
                for (int j = 0; j < histograms.Count; j++)
                {
                    data += "," + histograms[j]["intensity"][i];
                }
            }
            System.IO.File.WriteAllText(imageFolder + "\\histogramData.csv", data);

            //Output times
            averageProcessingTime /= frameTotal;
            AppendTextBox("Average processing time: " + averageProcessingTime + " ms" + Environment.NewLine);
            log += "Average processing time: " + averageProcessingTime + " ms" + Environment.NewLine;
            averageSpareTime /= frameTotal;
            AppendTextBox("Average spare time: " + averageSpareTime + " ms" + Environment.NewLine);
            log += "Average spare time: " + averageSpareTime + " ms" + Environment.NewLine;
            averageAcquisitionTime /= frameTotal;
            AppendTextBox("Average acquisition time: " + averageAcquisitionTime + " ms" + Environment.NewLine);
            log += "Average acquisition time: " + averageAcquisitionTime + " ms" + Environment.NewLine;
            averageSegmentationTime /= frameTotal;
            AppendTextBox("Average segmentation time: " + averageSegmentationTime + " ms" + Environment.NewLine);
            log += "Average segmentation time: " + averageSegmentationTime + " ms" + Environment.NewLine;
            averageBLOBExtractionTime /= frameTotal;
            AppendTextBox("Average BLOB detection time: " + averageBLOBExtractionTime + " ms" + Environment.NewLine);
            log += "Average BLOB detection time: " + averageBLOBExtractionTime + " ms" + Environment.NewLine;
            averageHoGTime /= frameTotal;
            AppendTextBox("Average texture extraction time: " + averageHoGTime + " ms" + Environment.NewLine);
            log += "Average texture extraction time: " + averageHoGTime + " ms" + Environment.NewLine;
            System.IO.File.WriteAllText(imageFolder + "\\Log.txt", log);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopThread = true;
            startButton.Enabled = true;
            stopButton.Enabled = false;
            browseButton.Enabled = true;
        }

        delegate void AppendTextBoxCallback(string text);
        private void AppendTextBox(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                AppendTextBoxCallback d = new AppendTextBoxCallback(AppendTextBox);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.AppendText(text);
            }
        }

        public Image<Gray, Byte> Segmentation(Image<Bgr, Byte> input)
        {
            Image<Gray, Byte> output = new Image<Gray, Byte>(ImageWidth, ImageHeight);
            Image<Gray, Byte>[] channel = input.Split();
            output = channel[1] - channel[2];
            output._ThresholdBinary(new Gray(BinaryThreshold), new Gray(255));
            StructuringElementEx kernel = new StructuringElementEx(MorphologySize, MorphologySize, MorphologySize / 2, MorphologySize / 2, CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
            output._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_OPEN, 1);
            output._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_CLOSE, 1);
            return output;
        }

        public List<TextureWindow> BLOBExtraction(Image<Gray, Byte> binaryMask, Image<Gray, Byte> textureImage)
        {
            List<TextureWindow> windows = new List<TextureWindow>();
            textureImage._And(binaryMask);
            Bitmap image = binaryMask.ToBitmap();
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = false;
            blobCounter.ProcessImage(image);
            Rectangle[] blobs = blobCounter.GetObjectsRectangles();
            foreach (Rectangle blob in blobs)
            {
                if (blob.Height * blob.Width >= BLOBSize * BLOBSize)
                {
                    if (useBLOBs)
                    {
                        textureImage.ROI = blob;
                        binaryMask.ROI = blob;
                        windows.Add(new TextureWindow(textureImage.Copy(), binaryMask.Copy(), blob.X, blob.Y));
                        textureImage.Save(Environment.CurrentDirectory + "\\BLOB.tif");
                    }
                    else
                    {
                        textureImage.ROI = new Rectangle(blob.X + (blob.Width / 2 - WindowSize / 2), blob.Y + (blob.Height / 2 - WindowSize / 2), WindowSize, WindowSize);
                        windows.Add(new TextureWindow(textureImage.Copy(), binaryMask.Copy(), blob.X, blob.Y));
                        textureImage.Save(Environment.CurrentDirectory + "\\Window.tif");

                    }
                }
            }
            return windows;
        }

        public Dictionary<String,double[]> calculateHistogram(TextureWindow window)
        {
            // Calculate histogram of oriented gradient intensity
            Byte[, ,] mask = window.mask.Data;
            Image<Gray, float> dx = window.image.Sobel(1, 0, 3);
            Image<Gray, float> dy = window.image.Sobel(0, 1, 3);
            float[, ,] dxData = dx.Data;
            float[, ,] dyData = dy.Data;
            double[] intensities = new double[360 / BinSize];
            double[] orientations = new double[360 / BinSize];
            double orientation = 0;
            double intensity = 0;
            double totalIntensity = 0;

            for (int i = window.image.Height - 1; i >= 0; i--)
            {
                for (int j = window.image.Width - 1; j >= 0; j--)
                {
                    if (mask[i,j,0] == 255)
                    {
                        // Calculate gradient orientation and intensity at pixel (i,j)
                        orientation = Math.Atan2((double)dyData[i, j, 0], (double)(dxData[i, j, 0])) * 180.0 / Math.PI + 180.0;
                        intensity = Math.Sqrt(Math.Pow((double)dxData[i, j, 0], 2) + Math.Pow((double)dyData[i, j, 0], 2));

                        // Accumulate the total gradient intensity
                        totalIntensity += intensity;

                        // Accumulate orientation-specific gradient intensity
                        for (int k = 0; k < (360 / BinSize); k++)
                        {
                            orientations[k] = k * BinSize;
                            if (orientation < 0.0 || orientation > 360.0)
                            {
                                //Unacceptable orientation calculated
                            }
                            else if (orientation >= (double)(k * BinSize) && orientation < (double)((k + 1) * BinSize))
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
            }

            //Normalise histogram of oriented gradients
            Dictionary<String,double[]> leafHistogram = new Dictionary<String,double[]>(2)
            {
                { "intensity", new double[360 / BinSize] },
                { "orientation", new double[360 / BinSize] }
            };

            int maxIndex = Array.IndexOf(intensities, intensities.Max());
            for (int i = 0; i < (360 / BinSize); i++)
            {
                //Save orientation
                leafHistogram["orientation"][i] = orientations[i];

                //Perform intensity normalisation and rotation normalisation by circular-shift of orientation
                leafHistogram["intensity"][i] = intensities[(maxIndex + i) % (360 / BinSize)] / totalIntensity;
            }

            // Save normalised histogram plot and csv
            if (saveImagesOn.Checked == true)
            {
                this.BeginInvoke(new Action(() =>
                {
                    barChart.Series[0].Points.DataBindXY(leafHistogram["orientation"], "Gradient Orientation", leafHistogram["intensity"], "Normalised Gradient Intensity");
                    barChart.Size = new Size(1000, 500);
                    barChart.SaveImage(imageFolder + "\\histogram" + frameCount + ".png", ImageFormat.Png);
                }));
            }
            return leafHistogram;
        }

        private void frameRateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            FrameRate = frameRateTrackBar.Value / 2.0;
            frameRateLabel.Text = ((double)frameRateTrackBar.Value / 2.0).ToString("F1") + " fps";
        }

        private void blobSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            BLOBSize = blobSizeTrackBar.Value;
            blobSizeLabel.Text = blobSizeTrackBar.Value + " px";
        }

        private void binaryThresholdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            BinaryThreshold = binaryThresholdTrackBar.Value;
            binaryThresholdLabel.Text = binaryThresholdTrackBar.Value.ToString();
        }

        private void openingSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            MorphologySize = morphologySizeTrackBar.Value;
            morphologySizeLabel.Text = morphologySizeTrackBar.Value + " px";
        }

        private void windowSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            WindowSize = windowSizeTrackBar.Value;
            windowSizeLabel.Text = windowSizeTrackBar.Value + " px";
        }

        private void binSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            BinSize = binSizeTrackBar.Value;
            sampleSizeLabel.Text = binSizeTrackBar.Value.ToString();
        }

        private void windowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            windowSizeTrackBar.Enabled = true;
            useBLOBs = false;
        }

        private void BLOBRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            windowSizeTrackBar.Enabled = false;
            useBLOBs = true;
        }
    }

    public class TextureWindow
    {

        private Image<Gray, Byte> _image;
        public Image<Gray, Byte> image
        {
            get { return _image; }
            set { _image = value; }
        }

        private Image<Gray, Byte> _mask;
        public Image<Gray, Byte> mask
        {
            get { return _mask; }
            set { _mask = value; }
        }

        private double[] _data;
        public double[] data
        {
            get { return _data; }
            set { _data = value; }
        }

        private int _x;
        public int x
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }

        private double _mean;
        public double mean
        {
            get { return _mean; }
            set { _mean = value; }
        }

        private double _variance;
        public double variance
        {
            get { return _variance; }
            set { _variance = value; }
        }

        private double[] _textureSignature;
        public double[] textureSignature
        {
            get { return _textureSignature; }
            set { _textureSignature = value; }
        }

        public TextureWindow(Image<Gray, Byte> input, Image<Gray, Byte> mask, int X, int Y)
        {
            image = input;
            x = X;
            y = Y;
            this.mask = mask;
        }

        public void CalculateStatistics()
        {
            Byte[, ,] imageData = image.Data;
            data = new double[image.Height * image.Width];
            unsafe
            {
                fixed (Byte* inputPointer = imageData)
                {
                    for (int i = 0; i < image.Height * image.Width; i++)
                    {
                        data[i] = (double)*(inputPointer + i);
                    }
                }
            }
            mean = data.Average();
            variance = data.Sum(d => Math.Pow(d - mean, 2)) / data.Length;
        }

        public void calculateHoG()
        {

        }
    }
}