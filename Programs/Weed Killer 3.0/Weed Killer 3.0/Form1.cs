using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using AForge;
using AForge.Video;
using AForge.Imaging;
using TctecUSB = TctecUSB4.TctecUSB4;

namespace Weed_Killer_3._0
{
    public partial class Form1 : Form
    {
        // Global constants and variables
        const string DeviceIP = "1.1.1.2:10000";
        const int NumberOfSprayers = 2;
        const double PixelResolution = 5070; // pixels per m
        const double MaximumSpeed = 0.5; // m per second
        const double VehicleLength = 0.97;
        const int ImageWidth = 2048;
        const int ImageHeight = 1536;
        MJPEGStream stream;
        DateTime imageTime = new DateTime();
        Stopwatch stopwatch1 = new Stopwatch();
        Stopwatch stopwatch2 = new Stopwatch();
        public List<Weed> weeds;
        Gray binaryThreshold = new Gray(17);
        int blobSize = 122;
        int frameCount;
        int frameRate = 5;
        int openingSize = 22;
        Rectangle roi;
        DataCollection<DataPoint> autoblockData;
        const int PulsesPerRevolution = 12;
        const double WheelRadius = 0.164;
        const int BufferSize = 5;
        const int PeriodMSB = 5;
        const int PeriodLSB = 6;
        const int TerminatingByte = 192;
        const int EscapeByte = 219;
        const string port = "COM11";
        const int BaudRate = 115200;
        const Parity PARITY = Parity.None;
        const int DataBits = 8;
        const StopBits STOPBITS = StopBits.One;
        SerialPort serialPort;
        double distance = 0.0;
        double velocity1;
        double velocity2;
        DateTime time1;
        DateTime time2;
        double timeDelta;
        int count = 0;
        DataPoint targetData;
        int targetIndex = 0;
        double initialDistance = 0;
        double currentDistance = 0;
        double targetDistance = 0;
        int matchingIndex = 0;
        const double BhattacharyyaThreshold = 0.9950;
        double[] SampleLantanaHistogram;
        int binSize = 90;
        int patchSize = 100;
        int weedsFound;
        int weedsSprayed;
        double averageAcquisitionTime;
        double averageSegmentationTime;
        double averageBLOBExtractionTime;
        double averageFeatureExtractionTime;
        string directory;
        int runCount;
        List<Bitmap> originalFrames;
        List<Bitmap> processedFrames;
        string autoblockLog;
        string weedLog;
        string systemLog;
        int BLOBCount;

        public Form1()
        {
            InitializeComponent();
            logoPictureBox.Image = new Bitmap(Environment.CurrentDirectory + "\\jcu.png");
            roi = new Rectangle(0, ((ImageHeight - (int)(MaximumSpeed / frameRate * PixelResolution)) / 2), ImageWidth, (int)(MaximumSpeed / frameRate * PixelResolution));
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            directory = Environment.CurrentDirectory;
            string[] folders = Directory.GetDirectories(directory);
            foreach (string folder in folders)
            {
                if (folder == "bin")
                {
                    directory = Environment.CurrentDirectory + "\\bin\\Debug";
                    folders = Directory.GetDirectories(directory);
                    break;
                }
            }
            runCount = folders.Length + 1;
            Directory.CreateDirectory(directory + "\\" + runCount);
            systemLog = "Weed Killer 3.0 - " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + " - ";
            systemLog += DateTime.Now.TimeOfDay + Environment.NewLine;
            systemLog += "------------------------------" + Environment.NewLine;
            systemLog += "Feature extraction: " + featureExtractionCheckBox.Checked + Environment.NewLine;
            systemLog += "Frame rate: " + frameRate + " fps" + Environment.NewLine + "BLOB size: " + blobSize + " px" + Environment.NewLine;
            systemLog += "Binary threshold: " + binaryThreshold + Environment.NewLine + "Opening Size: " + openingSize + " px" + Environment.NewLine;
            systemLog += "BLOB processing: " + blobRadioButton.Checked + Environment.NewLine + "Patch Processing: " + patchRadioButton.Checked + Environment.NewLine;
            systemLog += "Bin size: " + binSize + Environment.NewLine + "------------------------------" + Environment.NewLine;
            originalFrames = new List<Bitmap>();
            processedFrames = new List<Bitmap>();
            SampleLantanaHistogram = new double[360 / binSize];
            if (File.Exists(directory + "\\bin" + binSize + "SampleLantanaHistogram.csv"))
            {
                var reader = new StreamReader(directory + "\\bin" + binSize + "SampleLantanaHistogram.csv");
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    SampleLantanaHistogram[Convert.ToInt32(values[0]) / binSize] = Convert.ToDouble(values[1]);
                }
                reader.Close();
                systemLog += DateTime.Now.TimeOfDay + ": Sample lantana histogram generated from .csv file." + Environment.NewLine;
            }
            else
            {
                Array.Clear(SampleLantanaHistogram, 0, (360 / binSize));
                systemLog += DateTime.Now.TimeOfDay + ": Empty sample lantana histogram generated." + Environment.NewLine;
            }
            startButton.Enabled = false;
            stopButton.Enabled = true;
            Thread autoblockThread = new Thread(new ThreadStart(newData));
            serialPort = new SerialPort(port, BaudRate, PARITY, DataBits, STOPBITS);
            stream = new MJPEGStream();
            stream.Source = "http://" + DeviceIP + "/cgi-bin/video.cgi?msubmenu=mjpg&profile=3&resolution=0&frate=" + frameRate + "&compression=1";
            stream.Login = "admin";
            stream.Password = "4321";
            Thread cameraThread = new Thread(newFrame);
            stream.Start();
            cameraThread.Start();
            systemLog += DateTime.Now.TimeOfDay + ": Camera stream started." + Environment.NewLine;
            stopwatch1.Restart();
            try
            {
                serialPort.Open();
                autoblockThread.Start();
                systemLog += DateTime.Now.TimeOfDay + ": Autoblock stream started." + Environment.NewLine;

            }
            catch (IOException)
            {
                AppendTextBox("Autoblock not configured.\n");
            }
            averageAcquisitionTime = 0;
            averageSegmentationTime = 0;
            averageBLOBExtractionTime = 0;
            averageFeatureExtractionTime = 0;
            autoblockData = new DataCollection<DataPoint>();
            distance = 0.0;
            count = 0;
            targetIndex = 0;
            initialDistance = 0;
            currentDistance = 0;
            targetDistance = 0;
            matchingIndex = 0;
            textBox1.Text = "";
            frameCount = 1;
            weeds = new List<Weed>();
            BLOBCount = 0;
            weedsFound = 0;
            weedsFoundLabel.Text = "Weeds found: " + weedsFound;
            weedsSprayed = 0;
            weedsSprayedLabel.Text = "Weeds sprayed: " + weedsSprayed;
            progressBar1.Value = 0;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            startButton.Enabled = true;
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.Dispose();
            if (stream.IsRunning)
            {
                stream.Stop();
            }
            averageAcquisitionTime /= frameCount;
            averageSegmentationTime /= frameCount;
            averageBLOBExtractionTime /= frameCount;
            averageFeatureExtractionTime /= frameCount;
            systemLog += "------------------------------" + Environment.NewLine;
            systemLog += "Frames processed: " + frameCount + Environment.NewLine;
            systemLog += "BLOBs identified: " + BLOBCount + Environment.NewLine;
            systemLog += "Weeds identified: " + weedsFound + Environment.NewLine;
            systemLog += "Weeds sprayed: " + weedsSprayed + Environment.NewLine;
            systemLog += "Distance travelled: " + distance + " m" + Environment.NewLine;
            double averageSpeed = 0;
            double maximumSpeed = 0;
            autoblockLog = "Time,Velocity,Distance" + Environment.NewLine;
            foreach (DataPoint data in autoblockData)
            {
                averageSpeed += data.velocity;
                if (data.velocity > maximumSpeed)
                {
                    maximumSpeed = data.velocity;
                }
                autoblockLog += data.time.TimeOfDay + "," + data.velocity + "," + data.distance + Environment.NewLine;
            }
            averageSpeed /= autoblockData.Count;
            systemLog += "Average vehicle speed: " + averageSpeed + " m/s" + Environment.NewLine;
            systemLog += "Maximum vehicle speed: " + maximumSpeed + " m/s" + Environment.NewLine;
            AppendTextBox("Average Acquisition Time = " + averageAcquisitionTime + " ms\n");
            systemLog += "Average acquisition time = " + averageAcquisitionTime + "ms" + Environment.NewLine;
            AppendTextBox("Average Segmentation Time = " + averageSegmentationTime + " ms\n");
            systemLog += "Average segmentation time = " + averageSegmentationTime + "ms" + Environment.NewLine;
            AppendTextBox("Average BLOB Extraction Time = " + averageBLOBExtractionTime + " ms\n");
            systemLog += "Average BLOB extraction time = " + averageBLOBExtractionTime + "ms" + Environment.NewLine;
            AppendTextBox("Average Feature Extraction Time = " + averageFeatureExtractionTime + " ms\n");
            systemLog += "Average feature extraction time = " + averageFeatureExtractionTime + "ms" + Environment.NewLine;
            AppendTextBox("Average Processing Time = " + (averageAcquisitionTime + averageSegmentationTime + averageBLOBExtractionTime + averageFeatureExtractionTime) + " ms\n");
            systemLog += "Average processing time = " + (averageAcquisitionTime + averageSegmentationTime + averageBLOBExtractionTime + averageFeatureExtractionTime) + "ms\n";
            System.IO.File.WriteAllText(directory + "\\" + runCount + "\\Log.txt", systemLog);
            weedLog = "Time,Frame,Distance,ROI,Spray Trigger,Bhattacharyya Coefficient" + Environment.NewLine;
            foreach (Weed weed in weeds)
            {
                weedLog += weed.time.TimeOfDay + "," + weed.frame + "," + weed.distance + ",";
                weedLog += "(" + weed.roi.X + "," + weed.roi.Y + "," + weed.roi.Width + "," + weed.roi.Height + "),";
                weedLog += weed.trigger + "," + weed.bhattacharyyaCoefficient + Environment.NewLine;
            }
            System.IO.File.WriteAllText(directory + "\\" + runCount + "\\Weed Log.txt", weedLog);
            System.IO.File.WriteAllText(directory + "\\" + runCount + "\\Autoblock Log.txt", autoblockLog);
            progressBar1.Maximum = originalFrames.Count + processedFrames.Count;
            for (int i = 0; i < originalFrames.Count; i++)
            {
                progressBar1.Value++;
                originalFrames[i].Save(directory + "\\" + runCount + "\\" + (i + 1) + "original.jpg");
            }
            for (int i = 0; i < processedFrames.Count; i++)
            {
                progressBar1.Value++;
                processedFrames[i].Save(directory + "\\" + runCount + "\\" + (i + 1) + "processed.jpg");
            }
        }

        private void newFrame()
        {
            stream.NewFrame += stream_NewFrame;
        }

        private void stream_NewFrame(object sender, AForge.Video.NewFrameEventArgs e)
        {
            // Image acquisition
            stopwatch2.Restart();
            imageTime = DateTime.Now;
            AppendTextBox("Frame " + frameCount + ": " + stopwatch1.ElapsedMilliseconds + " ms\n\n");
            systemLog += imageTime.TimeOfDay + ": Frame " + frameCount + " received after " + stopwatch1.ElapsedMilliseconds + " ms." + Environment.NewLine;
            Image<Bgr, Byte> originalImage = new Image<Bgr, Byte>(e.Frame);
            originalImage.ROI = roi;
            pictureBox1.Image = (Bitmap)originalImage.ToBitmap().Clone();
            originalFrames.Add(originalImage.ToBitmap());
            //AppendTextBox("Acquisition time = " + stopwatch2.ElapsedMilliseconds + " ms\n\n");
            averageAcquisitionTime += stopwatch2.ElapsedMilliseconds;
            stopwatch2.Restart();

            // Image segmentation
            Image<Gray, Byte>[] channel = originalImage.Split();
            Image<Gray, Byte> grayImage = channel[1] - channel[2];
            Image<Gray, Byte> binaryMaskImage = grayImage.ThresholdBinary(binaryThreshold, new Gray(255));
            StructuringElementEx openingElement = new StructuringElementEx(openingSize * 2, openingSize * 2, openingSize, openingSize, CV_ELEMENT_SHAPE.CV_SHAPE_ELLIPSE);
            binaryMaskImage._MorphologyEx(openingElement, CV_MORPH_OP.CV_MOP_OPEN, 1);
            //AppendTextBox("Segmentation time = " + stopwatch2.ElapsedMilliseconds + " ms\n\n");
            averageSegmentationTime += stopwatch2.ElapsedMilliseconds;
            systemLog += DateTime.Now.TimeOfDay + ": Frame " + frameCount + " segmented." + Environment.NewLine;
            stopwatch2.Restart();

            // BLOB analysis
            Bitmap clone = binaryMaskImage.ToBitmap();
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = blobSize;
            blobCounter.MinHeight = blobSize;
            blobCounter.FilterBlobs = true;
            blobCounter.ProcessImage(clone);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            //AppendTextBox("BLOB analysis time = " + stopwatch2.ElapsedMilliseconds + " ms\n\n");
            BLOBCount += blobs.Length;
            averageBLOBExtractionTime += stopwatch2.ElapsedMilliseconds;
            systemLog += DateTime.Now.TimeOfDay + ": " + blobs.Length + " BLOBs extracted from frame " + frameCount + Environment.NewLine;
            stopwatch2.Restart();

            // Feature extraction
            Rectangle[] sprayArea = new Rectangle[NumberOfSprayers];
            for (int i = 0; i < NumberOfSprayers; i++)
            {
                sprayArea[i] = new Rectangle(i * roi.Width / NumberOfSprayers, 0, roi.Width / NumberOfSprayers, roi.Height);
            }
            grayImage = originalImage.Convert<Gray, Byte>();
            if (blobRadioButton.Checked == true)
            {
                grayImage._And(binaryMaskImage);
            }
            pictureBox2.Image = grayImage.ToBitmap();
            processedFrames.Add(grayImage.ToBitmap());
            if (featureExtractionCheckBox.Checked == true)
            {
                if (blobs.Length != 0)
                {
                    foreach (Blob blob in blobs)
                    {
                        byte sprayTrigger = 0;
                        int featureHeight = 0;
                        int featureWidth = 0;
                        // BLOB or patch processing
                        if (blobRadioButton.Checked == true)
                        {
                            grayImage.ROI = blob.Rectangle;
                            featureHeight = blob.Rectangle.Height;
                            featureWidth = blob.Rectangle.Width;
                        }
                        else if (patchRadioButton.Checked == true)
                        {
                            grayImage.ROI = new Rectangle(blob.Rectangle.Width / 2 - patchSize / 2, blob.Rectangle.Height / 2 - patchSize / 2, patchSize, patchSize);
                            featureHeight = patchSize;
                            featureWidth = patchSize;
                        }                        
                        // Calculate histogram of oriented gradient intensity
                        Image<Gray, float> dx = grayImage.Sobel(1, 0, 3);
                        Image<Gray, float> dy = grayImage.Sobel(0, 1, 3);
                        float[, ,] dxData = dx.Data;
                        float[, ,] dyData = dy.Data;
                        double[] intensities = new double[360 / binSize];
                        double[] orientations = new double[360 / binSize];
                        double orientation = 0;
                        double intensity = 0;
                        double totalIntensity = 0;
                        for (int i = featureHeight - 1; i >= 0; i--)
                        {
                            for (int j = featureWidth - 1; j >= 0; j--)
                            {
                                // Calculate gradient orientation and intensity at pixel (i,j)
                                orientation = Math.Atan2((double)dyData[i, j, 0], (double)(dxData[i, j, 0])) * 180.0 / Math.PI + 180.0;
                                intensity = Math.Sqrt(Math.Pow((double)dxData[i, j, 0], 2) + Math.Pow((double)dyData[i, j, 0], 2));
                                // Accumulate the total gradient intensity
                                totalIntensity += intensity;
                                // Accumulate orientation-specific gradient intensity
                                for (int k = 0; k < (360 / binSize); k++)
                                {
                                    orientations[k] = k * binSize;
                                    if (orientation < 0.0 || orientation > 360.0)
                                    {
                                        AppendTextBox("Unacceptable orientation calculated.\n");
                                        break;
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
                        // Perform classification of histogram via matching with average lantana sample histogram
                        double bhattacharyyaCoefficient = new double();
                        for (int k = 0; k < (360 / binSize); k++)
                        {
                            intensities[k] /= totalIntensity;
                            bhattacharyyaCoefficient += Math.Sqrt(intensities[k] * SampleLantanaHistogram[k]);
                        }
                        if (bhattacharyyaCoefficient >= BhattacharyyaThreshold)
                        {
                            // Trigger sprayers based on blob location
                            for (int i = 0; i < NumberOfSprayers; i++)
                            {
                                if (blob.Rectangle.IntersectsWith(sprayArea[i]))
                                {
                                    sprayTrigger += (byte)(Math.Pow(2, i));
                                    break;
                                }
                            }
                            double distance = (ImageHeight - roi.Y - blob.Rectangle.Y - blob.Rectangle.Height / 2.0) / PixelResolution + VehicleLength;
                            weeds.Add(new Weed() { time = imageTime, frame = frameCount, roi = blob.Rectangle, histogram = intensities, bhattacharyyaCoefficient = bhattacharyyaCoefficient, distance = distance, trigger = sprayTrigger });
                            AppendTextBox("New weed found in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")\n");
                            systemLog += DateTime.Now.TimeOfDay + ": Weed " + weeds.Count + " identified in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")" + Environment.NewLine;
                            weedsFound++;
                            SetWeedsFoundLabel("Weeds found: " + weedsFound);
                            /*
                            if (weeds.Count == 0)
                            {
                                weeds.Add(new Weed() { time = imageTime, frame = frameCount, roi = blob.Rectangle, histogram = intensities, bhattacharyyaCoefficient = bhattacharyyaCoefficient, distance = distance, trigger = sprayTrigger });
                                AppendTextBox("New weed found in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")\n");
                                systemLog += DateTime.Now.TimeOfDay + ": Weed " + weeds.Count + " identified in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")" + Environment.NewLine;
                                weedsFound++;
                                SetWeedsFoundLabel("Weeds found: " + weedsFound);
                            }
                            else if (!blob.Rectangle.IntersectsWith(weeds[weeds.Count - 1].roi))
                            {
                                weeds.Add(new Weed() { time = imageTime, frame = frameCount, roi = blob.Rectangle, histogram = intensities, bhattacharyyaCoefficient = bhattacharyyaCoefficient, distance = distance, trigger = sprayTrigger });
                                AppendTextBox("New weed found in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")\n");
                                systemLog += DateTime.Now.TimeOfDay + ": Weed " + weeds.Count + " identified in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")" + Environment.NewLine;
                                weedsFound++;
                                SetWeedsFoundLabel("Weeds found: " + weedsFound);
                            }
                            */
                        }
                    }
                }
                systemLog += DateTime.Now.TimeOfDay + ": Feature extraction completed on frame " + frameCount + Environment.NewLine;
                //AppendTextBox("Feature extraction time = " + stopwatch2.ElapsedMilliseconds + " ms.\n");
                averageFeatureExtractionTime += stopwatch2.ElapsedMilliseconds;
            }
            else if (featureExtractionCheckBox.Checked == false)
            {
                if (blobs.Length != 0)
                {
                    foreach (Blob blob in blobs)
                    {
                        byte sprayTrigger = 0;
                        // Trigger sprayers based on blob location
                        for (int i = 0; i < NumberOfSprayers; i++)
                        {
                            if (blob.Rectangle.IntersectsWith(sprayArea[i]))
                            {
                                sprayTrigger += (byte)(Math.Pow(2, i));
                                break;
                            }
                        }
                        // Calculate distance to leaf
                        double distance = (ImageHeight - roi.Y - blob.Rectangle.Y - blob.Rectangle.Height / 2.0) / PixelResolution + VehicleLength;
                        
                        if (weeds.Count == 0)
                        {
                            weeds.Add(new Weed() { time = imageTime, frame = frameCount, roi = blob.Rectangle, distance = distance, trigger = sprayTrigger, bhattacharyyaCoefficient = 0 });
                            AppendTextBox("New weed found in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")\n");
                            systemLog += DateTime.Now.TimeOfDay + ": Weed " + weeds.Count + " identified in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")" + Environment.NewLine;
                            weedsFound++;
                            SetWeedsFoundLabel("Weeds found: " + weedsFound);
                        }
                        else if (!blob.Rectangle.IntersectsWith(weeds[weeds.Count - 1].roi) || (frameCount - 2) >= weeds[weeds.Count - 1].frame)
                        {
                            weeds.Add(new Weed() { time = imageTime, frame = frameCount, roi = blob.Rectangle, distance = distance, trigger = sprayTrigger, bhattacharyyaCoefficient = 0 });
                            AppendTextBox("New weed found in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")\n");
                            systemLog += DateTime.Now.TimeOfDay + ": Weed " + weeds.Count + " identified in frame " + frameCount + " at (" + blob.Rectangle.X + "," + blob.Rectangle.Y + ")" + Environment.NewLine;
                            weedsFound++;
                            SetWeedsFoundLabel("Weeds found: " + weedsFound);
                        }
                    }
                }
            }
            systemLog += DateTime.Now.TimeOfDay + ": Frame " + frameCount + " processing complete." + Environment.NewLine;
            frameCount++;
            stopwatch1.Restart();
        }
        
        private void newData()
        {
            serialPort.DataReceived += serialPort_DataReceived;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            if (!sp.IsOpen)
            {
                return;
            }
            int message = sp.ReadByte();
            if (message == TerminatingByte)
            {
                int[] payload = new int[8];
                int i = 0;
                if (!serialPort.IsOpen)
                {
                    return;
                }
                message = serialPort.ReadByte();
                string output = "" + message;
                while (message != TerminatingByte)
                {
                    if (message == EscapeByte)
                    {
                        if (!serialPort.IsOpen)
                        {
                            return;
                        }
                        message = serialPort.ReadByte();
                        switch (message)
                        {
                            case 220:
                                message = TerminatingByte;
                                break;
                            case 221:
                                message = EscapeByte;
                                break;
                        }
                    }
                    payload[i++] = message;
                    output += " " + message;
                    if (!serialPort.IsOpen)
                    {
                        return;
                    }
                    message = serialPort.ReadByte();
                }
                if (count == 0)
                {
                    time1 = DateTime.Now;
                    velocity1 = CalculateVelocity(payload[PeriodMSB], payload[PeriodLSB]);
                }
                else
                {
                    time2 = DateTime.Now;
                    velocity2 = CalculateVelocity(payload[PeriodMSB], payload[PeriodLSB]);
                    timeDelta = (double)(time2.Ticks - time1.Ticks) / 10000000.0;
                    distance += timeDelta * (velocity1 + velocity2) / 2.0;
                    time1 = time2;
                    velocity1 = velocity2;
                }
                autoblockData.Add(new DataPoint() { time = time1, velocity = velocity1, distance = distance });
                SetOdometerLabel("Odometer: " + distance.ToString("F2") + " m");
                SetSpeedometerLabel("Speedometer: " + velocity1.ToString("F2") + " m/s");
                if (velocity1 > MaximumSpeed)
                {
                    systemLog += DateTime.Now.TimeOfDay + ": Maximum speed exceeded." + Environment.NewLine;
                }
                if (weeds.Count != 0)
                {
                    int temporaryIndex = 0;
                    for (int j = targetIndex; j < weeds.Count; j++)
                    {
                        targetData = new DataPoint() { time = weeds[j].time, velocity = 0, distance = 0 };
                        for (int k = temporaryIndex; k < autoblockData.Count; k++)
                        {
                            if (autoblockData[k] == targetData)
                            {
                                matchingIndex = k;
                                break;
                            }
                        }
                        temporaryIndex = matchingIndex;
                        initialDistance = autoblockData[matchingIndex].distance;
                        currentDistance = distance;
                        targetDistance = weeds[j].distance;
                        if (Math.Abs((currentDistance - initialDistance) - targetDistance) <= 0.15)
                        {
                            TctecUSB4.TctecUSB4.setBits("FTXG3YUN", weeds[j].trigger, true); // Open solenoids
                            if (Convert.ToBoolean(weeds[j].trigger & 1))
                            {
                                sprayTrigger1.BackColor = Color.Red;
                                systemLog += DateTime.Now.TimeOfDay + ": Weed " + (j + 1) + " sprayed with sprayer 1." + Environment.NewLine;
                            }
                            if (Convert.ToBoolean(weeds[j].trigger >> 1))
                            {
                                sprayTrigger2.BackColor = Color.Red;
                                systemLog += DateTime.Now.TimeOfDay + ": Weed " + (j + 1) + " sprayed with sprayer 2." + Environment.NewLine;
                            }
                            
                            Thread.Sleep(50);
                            TctecUSB4.TctecUSB4.setBits("FTXG3YUN", weeds[j].trigger, false); // Close solenoids
                            sprayTrigger1.BackColor = Color.Green;
                            sprayTrigger2.BackColor = Color.Green;
                            weedsSprayed++;
                            SetWeedsSprayedLabel("Weeds sprayed: " + weedsSprayed);
                            targetIndex = j + 1;
                        }
                    }
                }
                count++;
            }
        }

        private static double CalculateVelocity(int msb, int lsb)
        {
            int period = msb * 256 + lsb;
            double velocity;
            if (period == 0)
            {
                velocity = 0.0;
            }
            else
            {
                velocity = 57600.0 / ((double)PulsesPerRevolution * (double)period) * (2.0 * Math.PI * WheelRadius);
            }
            return velocity;
        }
        private void frameRateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            frameRate = frameRateTrackBar.Value;
            frameRateValue.Text = frameRateTrackBar.Value + " fps";
            roi = new Rectangle(0, ((ImageHeight - (int)(MaximumSpeed / frameRate * PixelResolution)) / 2), ImageWidth, (int)(MaximumSpeed / frameRate * PixelResolution));
        }

        private void blobSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            blobSize = blobSizeTrackBar.Value;
            blobSizeValue.Text = blobSizeTrackBar.Value +" px";
        }

        private void binaryThresholdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            binaryThreshold = new Gray(binaryThresholdTrackBar.Value);
            binaryThresholdValue.Text = binaryThresholdTrackBar.Value.ToString();
        }

        private void openingSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            openingSize = openingSizeTrackBar.Value;
            openingSizeValue.Text = openingSizeTrackBar.Value + " px";
        }

        private void patchSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            patchSize = patchSizeTrackBar.Value;
            patchSizeValue.Text = patchSizeTrackBar.Value + " px";
        }

        private void binSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            binSize = binSizeTrackBar.Value;
            binSizeValue.Text = binSizeTrackBar.Value.ToString();
            SampleLantanaHistogram = new double[360 / binSize];
            if (File.Exists(directory + "\\bin" + binSize + "SampleLantanaHistogram.csv"))
            {
                var reader = new StreamReader(directory + "\\bin" + binSize + "SampleLantanaHistogram.csv");
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    SampleLantanaHistogram[Convert.ToInt32(values[0]) / binSize] = Convert.ToDouble(values[1]);
                }
                reader.Close();
            }
            else
            {
                Array.Clear(SampleLantanaHistogram, 0, (360 / binSize));
            }
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

        delegate void SetSpeedometerLabelCallback(string text);
        private void SetSpeedometerLabel(string text)
        {
            if (this.speedometerLabel.InvokeRequired)
            {
                SetSpeedometerLabelCallback d = new SetSpeedometerLabelCallback(SetSpeedometerLabel);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.speedometerLabel.Text = text;
            }
        }

        delegate void SetOdometerLabelCallback(string text);
        private void SetOdometerLabel(string text)
        {
            if (this.odometerLabel.InvokeRequired)
            {
                SetOdometerLabelCallback d = new SetOdometerLabelCallback(SetOdometerLabel);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.odometerLabel.Text = text;
            }
        }

        delegate void SetWeedsFoundLabelCallback(string text);
        private void SetWeedsFoundLabel(string text)
        {
            if (this.weedsFoundLabel.InvokeRequired)
            {
                SetWeedsFoundLabelCallback d = new SetWeedsFoundLabelCallback(SetWeedsFoundLabel);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.weedsFoundLabel.Text = text;
            }
        }

        delegate void SetWeedsSprayedLabelCallback(string text);
        private void SetWeedsSprayedLabel(string text)
        {
            if (this.weedsSprayedLabel.InvokeRequired)
            {
                SetWeedsSprayedLabelCallback d = new SetWeedsSprayedLabelCallback(SetWeedsSprayedLabel);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.weedsSprayedLabel.Text = text;
            }
        }

        private void blobRadioButton_Click(object sender, EventArgs e)
        {
            blobRadioButton.Checked = true;
            patchRadioButton.Checked = false;
            patchSizeTrackBar.Enabled = false;
        }

        private void patchRadioButton_Click(object sender, EventArgs e)
        {
            blobRadioButton.Checked = false;
            patchRadioButton.Checked = true;
            patchSizeTrackBar.Enabled = true;
        }
    }

    public class Weed
    {
        // Time data field and property
        private DateTime _time;
        public DateTime time
        {
            get { return _time; }
            set { _time = value; }
        }

        // Frame number field and property
        private int _frame;
        public int frame
        {
            get { return _frame; }
            set { _frame = value; }
        }

        // Leaf ROI rectangle field and property
        private Rectangle _roi;
        public Rectangle roi
        {
            get { return _roi; }
            set { _roi = value; }
        }

        // Histogram of oriented gradient intensity field and property
        private double[] _histogram;
        public double[] histogram
        {
            get { return _histogram; }
            set { _histogram = value; }
        }

        private double _bhattacharyyaCoefficient;
        public double bhattacharyyaCoefficient
        {
            get { return _bhattacharyyaCoefficient; }
            set { _bhattacharyyaCoefficient = value; }
        }

        // Distance to weed (from sprayers location)
        private double _distance;
        public double distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        // Byte representing on/off trigger for weed sprayers
        private byte _trigger;
        public byte trigger
        {
            get { return _trigger; }
            set { _trigger = value; }
        }
    }

    public class DataPoint
    {
        // Time data field and property
        private DateTime _time;
        public DateTime time
        {
            get { return _time; }
            set { _time = value; }
        }

        // Velocity data field and property
        private double _velocity;
        public double velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        // Distance data field and property
        private double _distance;
        public double distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        // Equals override method
        public override bool Equals(System.Object obj)
        {
            // If parameter cannot be cast to DataPoint return false:
            DataPoint dp = obj as DataPoint;
            if ((object)dp == null)
            {
                return false;
            }

            // Return true if the time fields are within +-30ms
            return Math.Abs(dp.time.Ticks - time.Ticks) / 10000 <= 30;
        }

        public bool Equals(DataPoint dp)
        {
            // If parameter is null return false:
            if ((object)dp == null)
            {
                return false;
            }

            // Return true if the time fields are within +-30ms
            return Math.Abs(dp.time.Ticks - time.Ticks) / 10000 <= 30;
        }

        public static bool operator ==(DataPoint a, DataPoint b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the time fields are within +-30ms
            return Math.Abs(a.time.Ticks - b.time.Ticks) / 10000 <= 30;
        }

        public static bool operator !=(DataPoint a, DataPoint b)
        {
            // Return not equal to result
            return !(a == b);
        }

        public override int GetHashCode()
        {
            // Generate random hash code
            return (int)velocity * (int)distance;
        }
    }

    public class DataCollection<T> : Collection<T>
    {
        // Create new data event
        public event EventHandler NewData;

        // Firing method for new data event
        protected override void InsertItem(int index, T item)
        {
            if (null != NewData)
            {
                NewData(this, null);
            }
            base.InsertItem(index, item);
        }
    }
}