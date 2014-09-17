using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
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
        int SampleSize = 5;
        Stopwatch stopwatch1;
        Stopwatch stopwatch2;
        List<Image<Bgr, Byte>> originalImages;
        List<Image<Gray, Byte>> binaryMasks;
        Image<Bgr, Byte> originalImage;
        Image<Gray, Byte> binaryMask;
        const int ImageHeight = 1024;
        const int ImageWidth = 1280;
        double FrameRate = 2.5;
        int BLOBSize = 120;
        int MorphologySize = 40;
        int BinaryThreshold = 20;
        long averageSpareTime;
        long averageProcessingTime;
        long averageAcquisitionTime;
        long averageSegmentationTime;
        long averageBLOBDetectionTime;
        long averageTextureExtractionTime;
        int frameCount;
        string log;
        string imageFolder;
        int frameTotal;

        public Form1()
        {
            InitializeComponent();
            logoPictureBox.Image = new Bitmap(Environment.CurrentDirectory + "\\jcu.png");
        }

        private unsafe void browseButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            browseButton.Enabled = true;
            saveButton.Enabled = false;
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
            saveButton.Enabled = false;

            textBox1.Text = "";
            log = "";
            progressBar1.Value = 0;

            frameCount = 0;
            averageAcquisitionTime = 0;
            averageSegmentationTime = 0;
            averageBLOBDetectionTime = 0;
            averageTextureExtractionTime = 0;
            averageProcessingTime = 0;

            originalImages = new List<Image<Bgr, Byte>>();
            binaryMasks = new List<Image<Gray, Byte>>();

            stopwatch1 = new Stopwatch();
            stopwatch2 = new Stopwatch();
            stopwatch1.Start();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (frameCount < frameTotal)
            {
                averageSpareTime += stopwatch1.ElapsedMilliseconds;
                stopwatch1.Restart();
                stopwatch2.Restart();
                AppendTextBox("Frame " + frameCount + ":" + Environment.NewLine);
                log += "Frame " + frameCount + ":" + Environment.NewLine;

                originalImage = new Image<Bgr, Byte>(imageFolder + "\\" + frameCount + ".tif");
                if (saveImagesOn.Checked == true)
                {
                    originalImages.Add(originalImage);
                }
                if (displayOn.Checked == true)
                {
                    pictureBox1.Image = originalImage.ToBitmap();
                }
                averageAcquisitionTime += stopwatch2.ElapsedMilliseconds;
                stopwatch2.Restart();

                if (segmentationOn.Checked)
                {
                    binaryMask = Segmentation(originalImage);
                    if (displayOn.Checked)
                    {
                        pictureBox2.Image = binaryMask.ToBitmap();
                    }
                    if (saveImagesOn.Checked)
                    {
                        binaryMasks.Add(binaryMask);
                    }
                    averageSegmentationTime += stopwatch2.ElapsedMilliseconds;
                    stopwatch2.Restart();
                }

                bool BLOBFlag = false;
                if (BLOBOn.Checked)
                {
                    BLOBFlag = BLOBDetection(binaryMask);
                    if (BLOBFlag)
                    {
                        AppendTextBox("Leaf found." + Environment.NewLine);
                        log += "Leaf found." + Environment.NewLine;
                    }
                    averageBLOBDetectionTime += stopwatch2.ElapsedMilliseconds;
                    stopwatch2.Restart();
                }

                if (textureOn.Checked)
                {
                    textureWindows = TextureExtraction(binaryMask, originalImage.Convert<Gray,Byte>());
                    AppendTextBox("Number of pertinent windows = " + textureWindows.Count + Environment.NewLine);
                    log += "Number of pertinent windows = " + textureWindows.Count + Environment.NewLine;
                    if (textureWindows.Count == 0 && BLOBFlag == true)
                    {
                        AppendTextBox("!!!!!!!!!!!!!!!!!" + Environment.NewLine);
                    }
                    if (textureWindows.Count != 0 && BLOBFlag == false)
                    {
                        AppendTextBox("!!!!!!!!!!!!!!!!!" + Environment.NewLine);
                    }
                    if (saveImagesOn.Checked)
                    {
                        for (int n = 0; n < textureWindows.Count; n++)
                        {
                            textureWindows[n].image.Save(imageFolder + "\\Texture Windows\\frame" + frameCount + "window" + n + ".tif");
                        }
                    }
                    averageTextureExtractionTime += stopwatch2.ElapsedMilliseconds;
                    stopwatch2.Restart();
                }

                bool lantanaFlag = false;
                if (classificationOn.Checked)
                {
                    lantanaFlag = Classification(textureWindows);
                    if (lantanaFlag)
                    {
                        AppendTextBox("Lantana found." + Environment.NewLine);
                        log += "Lantana found." + Environment.NewLine;
                    }
                }

                frameCount++;
                averageProcessingTime += stopwatch1.ElapsedMilliseconds;
                stopwatch1.Restart();
            }
            else
            {
                startButton.Enabled = true;
                stopButton.Enabled = false;
                saveButton.Enabled = true;
                browseButton.Enabled = true;
                timer1.Enabled = false;
                frameCount = 0;

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
                averageBLOBDetectionTime /= frameTotal;
                AppendTextBox("Average BLOB detection time: " + averageBLOBDetectionTime + " ms" + Environment.NewLine);
                log += "Average BLOB detection time: " + averageBLOBDetectionTime + " ms" + Environment.NewLine;
                averageTextureExtractionTime /= frameTotal;
                AppendTextBox("Average texture extraction time: " + averageTextureExtractionTime + " ms" + Environment.NewLine);
                log += "Average texture extraction time: " + averageTextureExtractionTime + " ms" + Environment.NewLine;
                System.IO.File.WriteAllText(imageFolder + "\\Log.txt", log);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            startButton.Enabled = true;
            stopButton.Enabled = false;
            browseButton.Enabled = true;
            saveButton.Enabled = false;
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

        public bool BLOBDetection(Image<Gray, Byte> input)
        {
            bool output = false;
            Bitmap image = input.ToBitmap();
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = false;
            blobCounter.ProcessImage(image);
            Rectangle[] blobs = blobCounter.GetObjectsRectangles();
            foreach (Rectangle blob in blobs)
            {
                if (blob.Height * blob.Width >= BLOBSize * BLOBSize)
                {
                    output = true;
                    break;
                }
            }
            return output;
        }

        public List<TextureWindow> TextureExtraction(Image<Gray, Byte> binaryMask, Image<Gray, Byte> image)
        {
            Byte[, ,] maskData = binaryMask.Data;
            //List<TextureWindow> windows = StaticWindowSelection(maskData, image);
            List<TextureWindow> windows = DynamicWindowSelection(maskData, image);
            /*
            List<double> means = new List<double>();
            List<double> variances = new List<double>();
            for (int n = 0; n < windows.Count; n++)
            {
                windows[n].CalculateStatistics();
                means.Add(windows[n].mean);
                variances.Add(windows[n].variance);
            }
            while (windows.Count > SampleSize)
            {
                Random random = new Random();
                int index = random.Next(windows.Count);
                windows.RemoveAt(index);
            }
            */
            
            return windows;
        }

        public List<TextureWindow> StaticWindowSelection(Byte[, ,] mask, Image<Gray, Byte> image)
        {
            List<TextureWindow> windows = new List<TextureWindow>();
            for (int i = 0; i < ImageHeight; i += WindowSize)
            {
                for (int j = 0; j < ImageWidth; j += WindowSize)
                {
                    bool blackFlag = false;
                    for (int row = i; row < i + WindowSize; row++)
                    {
                        for (int col = j; col < j + WindowSize; col++)
                        {
                            if (mask[row, col, 0] == 0)
                            {
                                blackFlag = true;
                                row = i + WindowSize;
                                col = j + WindowSize;
                            }
                        }
                    }
                    if (blackFlag == false)
                    {
                        image.ROI = new Rectangle(j, i, WindowSize, WindowSize);
                        windows.Add(new TextureWindow(image.Copy(), i, j));
                    }
                }
            }
            return windows;
        }

        private bool RestrictedStartingPoint(int i, int j, List<Tuple<int,int,int,int>> limits)
        {
            bool output = false;
            for (int n = 0; n < limits.Count; n++)
            {
                if (i >= limits[n].Item1 && i <= limits[n].Item2 && j >= limits[n].Item3 && j <= limits[n].Item4)
                {
                    output = true;
                }
            }
            return output;
        }

        public List<TextureWindow> DynamicWindowSelection(Byte[, ,] mask, Image<Gray, Byte> image)
        {
            List<TextureWindow> windows = new List<TextureWindow>();
            List<Tuple<int,int,int,int>> limits = new List<Tuple<int,int,int,int>>();
            for (int i = 0; i < ImageHeight - WindowSize; i += 1)
            {
                for (int j = 0; j < ImageWidth - WindowSize; j += 1)
                {
                    Byte upperLeft = mask[i, j, 0];
                    Byte upperRight = mask[i, j + WindowSize - 1, 0];
                    Byte lowerLeft = mask[i + WindowSize - 1, j, 0];
                    Byte lowerRight = mask[i + WindowSize - 1, j + WindowSize - 1, 0];
                    if (upperLeft != 0 && upperRight != 0 && lowerLeft != 0 && lowerRight != 0 && !RestrictedStartingPoint(i, j, limits))
                    {
                        image.ROI = new Rectangle(j, i, WindowSize, WindowSize);
                        windows.Add(new TextureWindow(image.Copy(), i, j));
                        limits.Add(new Tuple<int, int, int, int>(i - WindowSize, i + WindowSize - 1, j - WindowSize, j + WindowSize - 1));
                    }
                }
            }
            return windows;
        }

        public bool Classification(List<TextureWindow> textureWindows)
        {
            return false;
        }

        private void frameRateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            FrameRate = frameRateTrackBar.Value / 2.0;
            frameRateLabel.Text = ((double)frameRateTrackBar.Value / 2.0).ToString("F1") + " fps";
            timer1.Interval = (int)(1000 / FrameRate);
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = binaryMasks.Count;
            progressBar1.Value = 0;
            for (int i = 0; i < binaryMasks.Count; i++)
            {
                binaryMasks[i].Save(imageFolder + "\\" + i + "mask.png");
                progressBar1.Value++;
            }
        }

        private void windowSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            WindowSize = windowSizeTrackBar.Value;
            windowSizeLabel.Text = windowSizeTrackBar.Value + " px";
        }

        private void sampleSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SampleSize = sampleSizeTrackBar.Value;
            sampleSizeLabel.Text = sampleSizeTrackBar.Value.ToString();
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

        public TextureWindow(Image<Gray, Byte> input, int X, int Y)
        {
            image = input;
            x = X;
            y = Y;
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
    }
}