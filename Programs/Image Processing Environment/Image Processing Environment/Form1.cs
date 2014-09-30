using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using FlyCapture2Managed;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ManagedCuda;
using ManagedCuda.BasicTypes;
using ManagedCuda.VectorTypes;
//using AForge;
//using AForge.Video;
//using AForge.Imaging;


namespace Image_Processing_Environment
{
    public partial class Form1 : Form
    {
        const int ImageHeight = 1024;
        const int ImageWidth = 1280;
        double globalFrameRate = 3;
        int BLOBSize = 120;
        int OpeningSize = 40;
        int BinaryThreshold = 1;
        long averageSpareTime;
        long averageProcessingTime;
        long averageAcquisitionTime;
        long averageSegmentationTime;
        long averageBLOBDetectionTime;
        long averageControlUpdateTime;
        Stopwatch[] stopwatch1;
        Stopwatch[] stopwatch2;
        double[][] ReferenceHistogram = new double[3][] { new double[256], new double[256], new double[256] };
        int[] frameCount;
        double[] ShutterSpeed = new double[8];
        double[] Illuminance = new double[8];
        string log;
        List<Target> targets;
        ManagedGigECamera[] cameras;
        Dictionary<Tuple<int, int>, ManagedImage> originalImages;
        CameraProperty autoExposure = new CameraProperty(PropertyType.AutoExposure);
        CameraProperty brightness = new CameraProperty(PropertyType.Brightness);
        CameraProperty frameRate = new CameraProperty(PropertyType.FrameRate);
        CameraProperty gain = new CameraProperty(PropertyType.Gain);
        CameraProperty gamma = new CameraProperty(PropertyType.Gamma);
        CameraProperty hue = new CameraProperty(PropertyType.Hue);
        CameraProperty saturation = new CameraProperty(PropertyType.Saturation);
        CameraProperty sharpness = new CameraProperty(PropertyType.Sharpness);
        CameraProperty[] shutter = new CameraProperty[8];
        CameraProperty whiteBalance = new CameraProperty(PropertyType.WhiteBalance);
        static CudaKernel threshold;
        static CudaKernel morphology;
        static CudaContext context;
        Dictionary<string, Label> LabelDictionary;
        PictureBox[] PictureBoxArray = new PictureBox[8];
        PictureBox[] BorderArray = new PictureBox[8];

        public Form1()
        {
            InitializeComponent();
            InitializeCUDA();
            InitializeControls();
        }

        void InitializeCUDA()
        {
            context = new CudaContext();
            CUmodule module = context.LoadModule(@"C:\Users\Alex Olsen\Documents\Weed Killing Research Project\Image Processing System\Test Programs\Image Processing Environment\CUDA Kernels\Debug\threshold.ptx");
            threshold = new CudaKernel("_Z9thresholdPiiii", module, context);
            threshold.BlockDimensions = new dim3(32, 32);
            threshold.GridDimensions = new dim3(ImageWidth / 32, ImageHeight / 32);
            module = context.LoadModule(@"C:\Users\Alex Olsen\Documents\Weed Killing Research Project\Image Processing System\Test Programs\Image Processing Environment\CUDA Kernels\Debug\morphology.ptx");
            morphology = new CudaKernel("_Z10morphologyPiiiii", module, context);
            morphology.BlockDimensions = new dim3(32, 32);
            morphology.GridDimensions = new dim3(ImageWidth / 32, ImageHeight / 32);
        }

        void InitializeControls()
        {
            logoPictureBox.Image = new Bitmap(Environment.CurrentDirectory + "\\jcu.png");
            LabelDictionary = new Dictionary<string, Label>
            {
                {"FrameRate",frameRateLabel},
                {"ShutterSpeed",shutterSpeedLabel},
                {"Exposure",exposureLabel},
                {"Brightness",brightnessLabel},
                {"Gain",gainLabel},
                {"WhiteBalance",whiteBalanceLabel},
                {"Illuminance",illuminanceLabel},
            };
            string ReferenceHistogramFile = Environment.CurrentDirectory + "\\ReferenceHistogram.csv";
            var reader = new StreamReader(File.OpenRead(ReferenceHistogramFile));
            for (int i = 0; i < 256; i++)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');
                for (int n = 0; n < 3; n++)
                {
                    ReferenceHistogram[n][i] = Convert.ToDouble(values[n]);
                }
            }
            reader.Close();
            for (int n = 0; n < 8; n++)
            {
                PictureBoxArray[n] = new PictureBox();
                BorderArray[n] = new PictureBox();
                int x = n % 2 == 0 ? 316 : 507;
                int y = 6 + (int)Math.Floor((double)n / 2.0) * 154;
                PictureBoxArray[n].Location = new System.Drawing.Point(x, y);
                PictureBoxArray[n].Size = new System.Drawing.Size(185, 148);
                PictureBoxArray[n].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                PictureBoxArray[n].Visible = true;
                this.Controls.Add(PictureBoxArray[n]);
                BorderArray[n].Location = new System.Drawing.Point(x - 2, y - 2);
                BorderArray[n].Size = new System.Drawing.Size(189, 152);
                BorderArray[n].BackColor = Color.Yellow;
                BorderArray[n].Visible = false;
                this.Controls.Add(BorderArray[n]);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
            referenceButton.Enabled = true;

            textBox1.Text = "";
            log = "";
            targets = new List<Target>();
            originalImages = new Dictionary<Tuple<int, int>, ManagedImage>();

            ManagedBusManager busManager = new ManagedBusManager();
            CameraInfo[] cameraInformation = ManagedBusManager.DiscoverGigECameras();
            uint cameraCount = busManager.GetNumOfCameras();
            AppendTextBox(cameraCount + " cameras detected." + Environment.NewLine);
            if (cameraCount == 0)
            {
                AppendTextBox("Unable to find camera(s)." + Environment.NewLine);
                Application.Exit();
            }

            stopwatch1 = new Stopwatch[cameraCount];
            stopwatch2 = new Stopwatch[cameraCount];
            ManagedGigECamera[] sortedCameras = new ManagedGigECamera[cameraCount];
            frameCount = new int[cameraCount];
            cameras = new ManagedGigECamera[cameraCount];
            
            for (uint n = 0; n < cameras.Length; n++)
            {
                stopwatch1[n] = new Stopwatch();
                stopwatch2[n] = new Stopwatch();
                ManagedPGRGuid guid = busManager.GetCameraFromIndex(n);
                cameras[n] = new ManagedGigECamera();
                cameras[n].Connect(guid);
                GigEImageSettingsInfo imageSettingsInfo = cameras[n].GetGigEImageSettingsInfo();
                GigEImageSettings imageSettings = new GigEImageSettings();
                imageSettings.offsetX = 0;
                imageSettings.offsetY = 0;
                imageSettings.height = imageSettingsInfo.maxHeight;
                imageSettings.width = imageSettingsInfo.maxWidth;
                imageSettings.pixelFormat = PixelFormat.PixelFormatRaw8;
                cameras[n].SetGigEImageSettings(imageSettings);
                brightness.onOff = true;
                brightness.autoManualMode = true;
                brightness.absControl = true;
                cameras[n].SetProperty(brightness);
                autoExposure.onOff = true;
                autoExposure.autoManualMode = true;
                autoExposure.absControl = true;
                cameras[n].SetProperty(autoExposure);
                ShutterSpeed[n] = 100;
                shutter[n] = new CameraProperty(PropertyType.Shutter);
                shutter[n].onOff = true;
                shutter[n].autoManualMode = false;
                shutter[n].absControl = true;
                shutter[n].absValue = (float)ShutterSpeed[n];
                cameras[n].SetProperty(shutter[n]);
                gain.onOff = true;
                gain.autoManualMode = true;
                gain.absControl = true;
                cameras[n].SetProperty(gain);
                //cameras[n].WriteRegister(0x10A0, 0x82064096);
                cameras[n].WriteRegister(0x10A0, 0xC30000FF);
                frameRate.onOff = true;
                frameRate.autoManualMode = false;
                frameRate.absControl = true;
                frameRate.absValue = (float)globalFrameRate;
                cameras[n].SetProperty(frameRate);
                whiteBalance.onOff = true;
                whiteBalance.autoManualMode = true;
                cameras[n].SetProperty(whiteBalance);

                int serial = (int)cameras[n].GetCameraInfo().serialNumber;
                switch (serial)
                {
                    case 13421033:
                        sortedCameras[0] = cameras[n];
                        break;
                    case 13421041:
                        sortedCameras[1] = cameras[n];
                        break;
                    case 13421043:
                        sortedCameras[2] = cameras[n];
                        break;
                    case 13421046:
                        sortedCameras[3] = cameras[n];
                        break;
                    case 13421051:
                        sortedCameras[4] = cameras[n];
                        break;
                    case 13421053:
                        sortedCameras[5] = cameras[n];
                        break;
                    case 13421056:
                        sortedCameras[6] = cameras[n];
                        break;
                    case 13421057:
                        sortedCameras[7] = cameras[n];
                        break;
                    default:
                        AppendTextBox("Camera serials not enumerated correctly." + Environment.NewLine);
                        Application.Exit();
                        break;
                }
            }
            cameras = sortedCameras;
            averageSpareTime = 0;
            averageProcessingTime = 0;
            averageAcquisitionTime = 0;
            averageSegmentationTime = 0;
            averageBLOBDetectionTime = 0;
            averageControlUpdateTime = 0;

            Thread lightSensorThread = new Thread(lightSensorThreadStart);
            try
            {
                serialPort1.Open();
                lightSensorThread.Start();
            }
            catch
            {
                AppendTextBox("Unable to connect to Arduino, check connection to COM port." + Environment.NewLine);
                Application.Exit();
            }

            for (int n = 0; n < cameras.Length; n++)
            {
                cameras[n].EmbedCameraID(n);
                cameras[n].StartCapture(NewFrame);
                stopwatch1[n].Start();
            }
            AppendTextBox("Started receiving frames from cameras." + Environment.NewLine);
        }

        void NewFrame(ManagedImage rawImage)
        {
            DateTime timestamp = DateTime.Now;
            int n = rawImage.GetEmbeddedCameraID();
            stopwatch2[n].Restart();
            averageSpareTime += stopwatch1[n].ElapsedMilliseconds;
            stopwatch1[n].Restart();
            if (Thread.CurrentThread.Name != "Camera " + n + " Thread")
            {
                Thread.CurrentThread.Name = "Camera " + n + " Thread";
            }
            bool selected = false;
            this.BeginInvoke((MethodInvoker)delegate()
            {
                selected = cameraSelection.SelectedIndex == n;
            });
            ManagedImage convertedImage = new ManagedImage();
            Image<Gray, Byte> binaryMask = new Image<Gray, Byte>(ImageWidth, ImageHeight);
            rawImage.Convert(PixelFormat.PixelFormatBgr, convertedImage);
            if (saveImagesOn.Checked)
            {
                originalImages.Add(new Tuple<int, int>(frameCount[n], n), convertedImage);
            }
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(convertedImage.bitmap);
            if (displayOriginal.Checked)
            {
                PictureBoxArray[n].Image = image.ToBitmap();
            }
            if (histogramEqualizationOn.Checked)
            {
                image = HistogramEqualization(image, ReferenceHistogram);
            }
            averageAcquisitionTime += stopwatch2[n].ElapsedMilliseconds;
            stopwatch2[n].Restart();
            if (!segmentationOff.Checked)
            {
                binaryMask = Segmentation(image, "CPU");
                averageSegmentationTime += stopwatch2[n].ElapsedMilliseconds;
                stopwatch2[n].Restart();
                if (!BLOBOff.Checked)
                {
                    if (BLOBDetection(binaryMask))
                    {
                        targets.Add(new Target() { time = timestamp, camera = n, frame = frameCount[n] });
                        if (!selected) SetBorderColor(n, Color.Red, true);
                    }
                    else
                    {
                        if (!selected) SetBorderColor(n, Color.Yellow, false);
                    }
                    averageBLOBDetectionTime += stopwatch2[n].ElapsedMilliseconds;
                }
            }
            stopwatch2[n].Restart();
            if (displayProcessed.Checked)
            {
                PictureBoxArray[n].Image = binaryMask.ToBitmap();
            }
            if (selected)
            {
                frameRate = cameras[n].GetProperty(PropertyType.FrameRate);
                SetLabel("FrameRate",frameRate.absValue.ToString("F2") + " fps");
                SetLabel("ShutterSpeed", ShutterSpeed[n].ToString("F2") + " ms");
                autoExposure = cameras[n].GetProperty(PropertyType.AutoExposure);
                SetLabel("Exposure", autoExposure.absValue.ToString("F2") + " EV");
                brightness = cameras[n].GetProperty(PropertyType.Brightness);
                SetLabel("Brightness", brightness.absValue.ToString("F2") + " %");
                gain = cameras[n].GetProperty(PropertyType.Gain);
                SetLabel("Gain", gain.absValue.ToString("F2") + " dB");
                whiteBalance = cameras[n].GetProperty(PropertyType.WhiteBalance);
                SetLabel("WhiteBalance", whiteBalance.valueA + "-" + whiteBalance.valueB);
                SetLabel("Illuminance", Illuminance[n].ToString("F2") + " lux");
                SetBorderColor(n, Color.Yellow, true);
            }
            cameras[n].SetProperty(shutter[n]);
            frameCount[n]++;
            averageProcessingTime += stopwatch1[n].ElapsedMilliseconds;
            stopwatch1[n].Restart();
            averageControlUpdateTime += stopwatch2[n].ElapsedMilliseconds;
        }

        private void lightSensorThreadStart()
        {
            if (Thread.CurrentThread.Name != "Light Sensor Thread")
            {
                Thread.CurrentThread.Name = "Light Sensor Thread";
            }
            serialPort1.DataReceived += serialPort1_DataReceived;
        }

        void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort1.ReadLine();
                string[] values = data.Split(',');
                if (values.Length != 8)
                {
                    return;
                }
                for (int n = 0; n < values.Length; n++)
                {
                    if (values[n].Length < 4 || values[n].Length > 6)
                    {
                        return;
                    }
                    Illuminance[n] = Convert.ToDouble(values[n].Trim());
                    ShutterSpeed[n] = -0.075 * Illuminance[n] + 75.188;
                    shutter[n].absValue = (float)ShutterSpeed[n];
                }
            }
            catch
            {
                //AppendTextBox("Warning: Attempted to read from closed serial port." + Environment.NewLine);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            referenceButton.Enabled = false;
            for (int n = 0; n < cameras.Length; n++)
            {
                cameras[n].StopCapture();
                cameras[n].Disconnect();
                cameras[n].Dispose();
            }
            cameras = null;
            serialPort1.Close();
            serialPort1.Dispose();
            AppendTextBox("Stopped receiving frames from cameras." + Environment.NewLine);
            int totalFrames = frameCount[0] + frameCount[1] + frameCount[2] + frameCount[3] + frameCount[4] + frameCount[5] + frameCount[6] + frameCount[7];
            totalFrames = totalFrames == 0 ? 1 : totalFrames;
            averageProcessingTime /= totalFrames;
            AppendTextBox("Average processing time: " + averageProcessingTime + " ms" + Environment.NewLine);
            log += "Average processing time: " + averageProcessingTime + " ms" + Environment.NewLine;
            averageSpareTime /= totalFrames;
            AppendTextBox("Average spare time: " + averageSpareTime + " ms" + Environment.NewLine);
            log += "Average spare time: " + averageSpareTime + " ms" + Environment.NewLine;
            averageAcquisitionTime /= totalFrames;
            AppendTextBox("Average acquisition time: " + averageAcquisitionTime + " ms" + Environment.NewLine);
            log += "Average acquisition time: " + averageAcquisitionTime + " ms" + Environment.NewLine;
            averageSegmentationTime /= totalFrames;
            AppendTextBox("Average segmentation time: " + averageSegmentationTime + " ms" + Environment.NewLine);
            log += "Average segmentation time: " + averageSegmentationTime + " ms" + Environment.NewLine;
            averageBLOBDetectionTime /= totalFrames;
            AppendTextBox("Average BLOB detection time: " + averageBLOBDetectionTime + " ms" + Environment.NewLine);
            log += "Average BLOB detection time: " + averageBLOBDetectionTime + " ms" + Environment.NewLine;
            averageControlUpdateTime /= totalFrames;
            AppendTextBox("Average control update time: " + averageControlUpdateTime + " ms" + Environment.NewLine);
            log += "Average control update time: " + averageControlUpdateTime + " ms" + Environment.NewLine;
            System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\Log.txt", log);
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

        delegate void SetBorderColorCallback(int n, Color color, bool visible);
        private void SetBorderColor(int n, Color color, bool visible)
        {
            if (this.BorderArray[n].InvokeRequired)
            {
                SetBorderColorCallback d = new SetBorderColorCallback(SetBorderColor);
                this.BeginInvoke(d, new object[] { n, color, visible });
            }
            else
            {
                this.BorderArray[n].BackColor = color;
                this.BorderArray[n].Visible = visible;
            }
        }

        delegate void ClickStopButtonCallback();
        private void ClickStopButton()
        {
            if (this.stopButton.InvokeRequired)
            {
                ClickStopButtonCallback d = new ClickStopButtonCallback(ClickStopButton);
                this.BeginInvoke(d, new object[] { });
            }
            else
            {
                this.stopButton.PerformClick();
            }
        }

        delegate void SetLabelCallback(string labelKey, string text);
        private void SetLabel(string labelKey, string text)
        {
            if (this.LabelDictionary[labelKey].InvokeRequired)
            {
                SetLabelCallback d = new SetLabelCallback(SetLabel);
                this.BeginInvoke(d, new object[] { labelKey, text });
            }
            else
            {
                this.LabelDictionary[labelKey].Text = text;
            }
        }

        public unsafe Image<Bgr, Byte> HistogramEqualization(Image<Bgr, Byte> inputImage, double[][] referenceHistogram)
        {
            Byte[, ,] inputData = inputImage.Data;
            Byte[, ,] outputData = new Byte[ImageHeight, ImageWidth, 3];
            double[] referenceBlueHistogram = referenceHistogram[0];
            double[] referenceGreenHistogram = referenceHistogram[1];
            double[] referenceRedHistogram = referenceHistogram[2];
            double[] inputBlueHistogram = new double[256];
            double[] inputGreenHistogram = new double[256];
            double[] inputRedHistogram = new double[256];
            fixed (Byte* inputPointer = inputData)
            {
                for (int i = 0; i < 1310720; i++)
                {
                    inputBlueHistogram[*(inputPointer + i * 3)]++;
                    inputGreenHistogram[*(inputPointer + i * 3 + 1)]++;
                    inputRedHistogram[*(inputPointer + i * 3 + 2)]++;
                }
            }
            double[] inputBlueCumulativeHistogram = new double[256];
            double[] inputGreenCumulativeHistogram = new double[256];
            double[] inputRedCumulativeHistogram = new double[256];
            double[] referenceBlueCumulativeHistogram = new double[256];
            double[] referenceGreenCumulativeHistogram = new double[256];
            double[] referenceRedCumulativeHistogram = new double[256];
            double[] sum = new double[6];
            for (int i = 0; i < 256; i++)
            {
                sum[0] += inputBlueHistogram[i];
                inputBlueCumulativeHistogram[i] = sum[0];
                sum[1] += inputGreenHistogram[i];
                inputGreenCumulativeHistogram[i] = sum[1];
                sum[2] += inputRedHistogram[i];
                inputRedCumulativeHistogram[i] = sum[2];
                sum[3] += referenceBlueHistogram[i];
                referenceBlueCumulativeHistogram[i] = sum[3];
                sum[4] += referenceGreenHistogram[i];
                referenceGreenCumulativeHistogram[i] = sum[4];
                sum[5] += referenceRedHistogram[i];
                referenceRedCumulativeHistogram[i] = sum[5];
            }
            double[,] errorBlue = new double[256, 256];
            double[,] errorGreen = new double[256, 256];
            double[,] errorRed = new double[256, 256];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    errorBlue[i, j] = referenceBlueCumulativeHistogram[i] - inputBlueCumulativeHistogram[j] + inputBlueHistogram[i] / 2.0;
                    errorGreen[i, j] = referenceGreenCumulativeHistogram[i] - inputGreenCumulativeHistogram[j] + inputGreenHistogram[i] / 2.0;
                    errorRed[i, j] = referenceRedCumulativeHistogram[i] - inputRedCumulativeHistogram[j] + inputRedHistogram[i] / 2.0;
                }
            }
            Byte[] TBlue = new Byte[256];
            Byte[] TGreen = new Byte[256];
            Byte[] TRed = new Byte[256];
            for (int j = 0; j < 256; j++)
            {
                double minimumBlue = 99999999999999;
                double minimumGreen = 99999999999999;
                double minimumRed = 99999999999999;
                for (int i = 0; i < 256; i++)
                {
                    if (errorBlue[i, j] < -0.01953125) { errorBlue[i, j] = 1310720; }
                    if (errorBlue[i, j] < minimumBlue) { minimumBlue = errorBlue[i, j]; TBlue[j] = (byte)i; }
                    if (errorGreen[i, j] < -0.01953125) { errorGreen[i, j] = 1310720; }
                    if (errorGreen[i, j] < minimumGreen) { minimumGreen = errorGreen[i, j]; TGreen[j] = (byte)i; }
                    if (errorRed[i, j] < -0.01953125) { errorRed[i, j] = 1310720; }
                    if (errorRed[i, j] < minimumRed) { minimumRed = errorRed[i, j]; TRed[j] = (byte)i; }
                }
            }
            fixed (Byte* outputPointer = outputData)
            fixed (Byte* inputPointer = inputData)
                for (int i = 0; i < 1310720; i++)
                {
                    *(outputPointer + i * 3) = TBlue[(int)*(inputPointer + i * 3)];
                    *(outputPointer + i * 3 + 1) = TGreen[(int)*(inputPointer + i * 3 + 1)];
                    *(outputPointer + i * 3 + 2) = TRed[(int)*(inputPointer + i * 3 + 2)];
                }
            return new Image<Bgr, Byte>(outputData);
        }

        public Image<Gray, Byte> Segmentation(Image<Bgr, Byte> input, string GPUorCPU)
        {
            Image<Gray, Byte> output = new Image<Gray, Byte>(ImageWidth, ImageHeight);
            if (GPUorCPU == "CPU")
            {
                Image<Gray, Byte>[] channel = input.Split();
                output = channel[1] - channel[2];
                output._ThresholdBinary(new Gray(BinaryThreshold), new Gray(255));
                StructuringElementEx kernel = new StructuringElementEx(OpeningSize, OpeningSize, OpeningSize / 2, OpeningSize / 2, CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
                output._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_OPEN, 1);
            }
            else
            {
                context.SetCurrent();
                byte[, ,] data = input.Data;
                int[] hostImage = new int[ImageHeight * ImageWidth];
                unsafe
                {
                    fixed (byte* pointer = data)
                    {
                        for (int i = 0; i < (ImageHeight * ImageWidth); i++)
                        {
                            hostImage[i] = *(pointer + i * 3 + 1) - *(pointer + i * 3 + 2);
                        }
                    }
                }
                CudaDeviceVariable<int> deviceImage = hostImage;
                threshold.Run(deviceImage.DevicePointer, ImageWidth, ImageHeight, BinaryThreshold);
                //morphology.Run(deviceImage.DevicePointer, ImageWidth, ImageHeight, 0, 4);
                //morphology.Run(deviceImage.DevicePointer, ImageWidth, ImageHeight, 1, 4);
                hostImage = deviceImage;
                deviceImage.Dispose();
                data = new byte[ImageHeight, ImageWidth, 1];
                unsafe
                {
                    fixed (byte* pointer = data)
                        for (int i = 0; i < ImageHeight * ImageWidth; i++)
                        {
                            *(pointer + i) = (byte)hostImage[i];
                        }
                }
                output = new Image<Gray, byte>(data);
            }
            return output;
        }

        public bool BLOBDetection(Image<Gray, Byte> input)
        {
            bool output = false;/*
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
            }*/
            return output;
        }

        private unsafe void referenceButton_Click(object sender, EventArgs e)
        {
            /*
            ClickStopButton();
            Byte[, ,] referenceData = images[0].Data;
            double[] referenceBlueHistogram = new double[256];
            double[] referenceGreenHistogram = new double[256];
            double[] referenceRedHistogram = new double[256];
            fixed (Byte* referencePointer = referenceData)
                for (int i = 0; i < 1310720; i++)
                {
                    referenceBlueHistogram[*(referencePointer + i * 3)]++;
                    referenceGreenHistogram[*(referencePointer + i * 3 + 1)]++;
                    referenceRedHistogram[*(referencePointer + i * 3 + 2)]++;
                }
            ReferenceHistogram[0] = referenceBlueHistogram;
            ReferenceHistogram[1] = referenceGreenHistogram;
            ReferenceHistogram[2] = referenceRedHistogram;
            */
        }

        private void cameraSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            BorderArray[cameraSelection.SelectedIndex].BackColor = Color.Yellow;
            BorderArray[cameraSelection.SelectedIndex].Visible = true;
        }

        private void frameRateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            globalFrameRate = frameRateTrackBar.Value / 2.0;
            globalFrameRateLabel.Text = ((double)frameRateTrackBar.Value / 2.0).ToString("F1") + " fps";
            if (cameras != null)
            {
                for (int n = 0; n < cameras.Length; n++)
                {
                    frameRate.absValue = (float)globalFrameRate;
                    cameras[n].SetProperty(frameRate);
                }
            }
        }

        private void blobSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            BLOBSize = blobSizeTrackBar.Value;
            blobSizeValue.Text = blobSizeTrackBar.Value + " px";
        }

        private void binaryThresholdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            BinaryThreshold = binaryThresholdTrackBar.Value;
            binaryThresholdValue.Text = binaryThresholdTrackBar.Value.ToString();
        }

        private void openingSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            OpeningSize = openingSizeTrackBar.Value;
            openingSizeValue.Text = openingSizeTrackBar.Value + " px";
        }
    }
    public static class MyExtensions
    {
        public static void EmbedCameraID(this ManagedGigECamera camera, int n)
        {
            EmbeddedImageInfo embeddedInfo = camera.GetEmbeddedImageInfo();

            if ((n / 4) == 0)  embeddedInfo.brightness.onOff = false;
            else embeddedInfo.brightness.onOff = true;

            if (((n % 4) / 2) == 0) embeddedInfo.gain.onOff = false;
            else embeddedInfo.gain.onOff = true;

            if (((n % 4) % 2) == 0) embeddedInfo.shutter.onOff = false;
            else embeddedInfo.shutter.onOff = true;

            camera.SetEmbeddedImageInfo(embeddedInfo);
        }

        public static int GetEmbeddedCameraID(this ManagedImage rawImage)
        {
            int fours = (int)rawImage.imageMetadata.embeddedBrightness == 0 ? 0 : 1;
            int twos = (int)rawImage.imageMetadata.embeddedGain == 0 ? 0 : 1;
            int ones = (int)rawImage.imageMetadata.embeddedShutter == 0 ? 0 : 1;
            return fours * 4 + twos * 2 + ones * 1;
        }
    }

    public class Target
    {
        // Time data field and property
        private DateTime _time;
        public DateTime time
        {
            get { return _time; }
            set { _time = value; }
        }

        // Camera ID field and property
        private int _camera;
        public int camera
        {
            get { return _camera; }
            set { _camera = value; }
        }

        // Frame number field and property
        private int _frame;
        public int frame
        {
            get { return _frame; }
            set { _frame = value; }
        }
    }
}