using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ImageProcessorTest
{
    public partial class Form1 : Form
    {
        private LightSensor lightSensor;
        private Dictionary<uint,Camera> cameras;
        private Dictionary<uint,ImageProcessor> imageProcessors;
        private int cameraCount = 1;
        private bool cameraDisplayFlag = false;
        
        public Form1()
        {
            InitializeComponent();
            InitializeCameras();
            InitializeLightSensor();
            InitializeImageProcessor();
            Application.ApplicationExit += Application_ApplicationExit;
        }

        private void InitializeCameras()
        {
            cameraCount = Camera.GetNumberOfCameras();
            AppendText("Identified " + cameraCount + " cameras." + Environment.NewLine);
            if (cameraCount == 0)
            {
                MessageBox.Show("The ethernet bus manager has failed to find your camera(s). Please check your connections.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            cameras = new Dictionary<uint,Camera>(cameraCount);
            for (int i = 0; i < cameraCount; i++)
            {
                cameras.Add(Camera.SerialNumbers[i], new Camera(Camera.SerialNumbers[i]));
                cameraSelection.Items.Add(Camera.SerialNumbers[i]);
            }
        }

        private void InitializeLightSensor()
        {
            lightSensor = new LightSensor("COM7", cameraCount);
        }

        private void InitializeImageProcessor()
        {
            imageProcessors = new Dictionary<uint,ImageProcessor>(cameraCount);
            for (int i = 0; i < cameraCount; i++)
            {
                imageProcessors.Add(Camera.SerialNumbers[i], new ImageProcessor(Camera.SerialNumbers[i]));
            }
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (cameras != null) foreach (KeyValuePair<uint,Camera> camera in cameras) camera.Value.StopCapture();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;

            lightSensor.Start();
            lightSensor.LightSensorDataReceived += _LightSensorDataReceived;
            AppendText("Started receiving light sensor data." + Environment.NewLine);

            for (int i = 0; i < cameraCount; i++)
            {
                cameras[Camera.SerialNumbers[i]].StartCapture();
                cameras[Camera.SerialNumbers[i]].CameraFrameReceived += _CameraFrameReceived;
                imageProcessors[Camera.SerialNumbers[i]].ImageProcessed += _ImageProcessed;
                AppendText("Started streaming from camera " + Camera.SerialNumbers[i] + "." + Environment.NewLine);
            }
        }

        void _CameraFrameReceived(object sender, CameraFrameReceivedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (cameraDisplayFlag)
                {
                    int index = cameraSelection.SelectedIndex - 1;
                    if (index < 0) return;
                    if (Camera.SerialNumbers[index] == e.serial)
                    {
                        pictureBox1.Image = new Image<Bgr, Byte>(e.image).ToBitmap();
                        frameRateLabel.Text = String.Format("{0:0.00} fps", e.frameRate);
                        shutterSpeedLabel.Text = String.Format("{0:0.00} ms", e.shutter);
                        exposureLabel.Text = String.Format("{0:0.00} EV", e.exposure);
                        brightnessLabel.Text = String.Format("{0:0.00} ", e.brightness);
                        gainLabel.Text = String.Format("{0:0.00} dB", e.gain);
                        whiteBalanceLabel.Text = String.Format("{0}:{1}", e.whiteBalanceA, e.whiteBalanceB);
                        illuminanceLabel.Text = String.Format("{0:0.00} lux", e.illuminance);
                    }
                }
            }));
            imageProcessors[e.serial].ProcessImage(e.image);
        }

        void _ImageProcessed(object sender, ImageProcessedEventArgs e)
        {
            this.Invoke(new Action(() =>
                {
                    AppendText("Image processed from camera: " + e.serial + Environment.NewLine);
                }));
        }

        void _TargetFound(object sender, TargetIdentifiedEventArgs e)
        {
            this.Invoke(new Action(() =>
                {
                    AppendText("Target identified from camera: " + e.serial + Environment.NewLine);
                }));
        }

        private void _LightSensorDataReceived(object sender, LightSensorDataReceivedEventArgs e)
        {
            double[] output = e.data;
            DateTime time = e.time;
            for (int i = 0; i < cameraCount; i++)
            {
                cameras[Camera.SerialNumbers[i]].SetProperty(Camera.Property.Illuminance, output[i]);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;

            if (lightSensor != null) lightSensor.Stop();
            lightSensor.LightSensorDataReceived -= _LightSensorDataReceived;

            for (int i = 0; i < cameraCount; i++)
            {
                cameras[Camera.SerialNumbers[i]].StopCapture();
                cameras[Camera.SerialNumbers[i]].CameraFrameReceived -= _CameraFrameReceived;
                imageProcessors[Camera.SerialNumbers[i]].ImageProcessed -= _ImageProcessed;
            }
        }

        delegate void AppendTextCallback(string text);
        private void AppendText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                AppendTextCallback d = new AppendTextCallback(AppendText);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.AppendText(text);
            }
        }

        private void breakButton_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
        }

        private void cameraSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cameraSelection.SelectedIndex > 0) cameraDisplayFlag = true;
            else
            {
                pictureBox1.Image = new Image<Bgr, Byte>(1280, 1024, new Bgr(0, 0, 0)).ToBitmap();
                frameRateLabel.Text = String.Format("-");
                shutterSpeedLabel.Text = String.Format("-");
                exposureLabel.Text = String.Format("-");
                brightnessLabel.Text = String.Format("-");
                gainLabel.Text = String.Format("-");
                whiteBalanceLabel.Text = String.Format("-");
                illuminanceLabel.Text = String.Format("-");
                cameraDisplayFlag = false;
            }
        }
    }
}
