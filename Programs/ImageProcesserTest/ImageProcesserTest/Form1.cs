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
    public partial class View : Form
    {
        #region Global Variables

        private LightSensor lightSensor;
        private Dictionary<uint,Camera> cameras;
        private Dictionary<uint,ImageProcessor> imageProcessors;
        private int cameraCount = 1;
        private bool cameraDisplayFlag = false;
        private bool processFlag = false;

        #endregion

        #region View Constructor

        public View()
        {
            //Initialization
            InitializeComponent();
            InitializeCameras();
            InitializeLightSensor();
            InitializeImageProcessor();
            InitializeView();

            // Finalization
            Application.ApplicationExit += _ApplicationExit;
        }

        #endregion

        #region Finalization Methods

        void _ApplicationExit(object sender, EventArgs e)
        {
            if (cameras != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (processFlag)
                    {
                        cameras[Camera.SerialNumbers[i]].StopCapture();
                    }
                    cameras[Camera.SerialNumbers[i]].StopLogging();
                    imageProcessors[Camera.SerialNumbers[i]].StopLogging();
                }
            }
        }

        #endregion

        #region Initialization Methods

        private void InitializeCameras()
        {
            cameraCount = Camera.GetNumberOfCameras();
            if (cameraCount == 0)
            {
                MessageBox.Show("The ethernet bus manager has failed to find the camera(s). Ensure the camera(s) are connected and correctly configured.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                AppendLine(cameraCount + " cameras have been detected.");
                cameras = new Dictionary<uint, Camera>(cameraCount);
                for (int i = 0; i < cameraCount; i++)
                {
                    cameras.Add(Camera.SerialNumbers[i], new Camera(Camera.SerialNumbers[i]));
                }
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

        private void InitializeView()
        {
            for (int i = 0; i < cameraCount; i++)
            {
                cameraSelection.Items.Add(Camera.SerialNumbers[i]);
            }
        }

        #endregion

        #region View Event Handlers

        private void startButton_Click(object sender, EventArgs e)
        {
            // Update the view status.
            startButton.Enabled = false;
            stopButton.Enabled = true;
            processFlag = true;

            try
            {
                // Start reading from the light sensors.
                lightSensor.Start();
                lightSensor.LightSensorDataReceived += _LightSensorDataReceived;
                AppendLine("Started reading from the light sensors.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                // Start capturing images from each camera and setup the image processor event handlers.
                for (int i = 0; i < cameraCount; i++)
                {
                    cameras[Camera.SerialNumbers[i]].StartCapture();
                    cameras[Camera.SerialNumbers[i]].CameraFrameReceived += _CameraFrameReceived;
                    imageProcessors[Camera.SerialNumbers[i]].ImageProcessed += _ImageProcessed;
                    imageProcessors[Camera.SerialNumbers[i]].TargetIdentified += _TargetIdentified;
                    AppendLine("Started streaming from camera " + Camera.SerialNumbers[i] + ".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            processFlag = false;
            /*
            
            */
            try
            {
                lightSensor.LightSensorDataReceived -= _LightSensorDataReceived;
                lightSensor.Stop();
            
                for (int i = 0; i < cameraCount; i++)
                {
                    cameras[Camera.SerialNumbers[i]].CameraFrameReceived -= _CameraFrameReceived;
                    imageProcessors[Camera.SerialNumbers[i]].ImageProcessed -= _ImageProcessed;
                    cameras[Camera.SerialNumbers[i]].StopCapture();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = 0; i < 8; i++)
            {
                
            }
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

        private void breakButton_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
        }

        #endregion

        #region Model Event Handlers

        private void _CameraFrameReceived(object sender, CameraFrameReceivedEventArgs e)
        {
            if (processFlag)
            {
                imageProcessors[e.serial].ProcessImage(e.image);
                this.BeginInvoke(new Action(() =>
                {
                    if (cameraDisplayFlag)
                    {
                        int index = cameraSelection.SelectedIndex - 1;
                        if (index < 0) return;
                        if (Camera.SerialNumbers[index] == e.serial)
                        {
                            pictureBox1.Image = (Bitmap)e.image.Clone();
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
            }
        }

        private void _ImageProcessed(object sender, ImageProcessedEventArgs e)
        {
            if (processFlag)
            {
                AppendLine("Image processed from camera: " + e.serial);
                this.BeginInvoke(new Action(() =>
                    {
                        int index = cameraSelection.SelectedIndex - 1;
                        if (index < 0) return;
                        if (Camera.SerialNumbers[index] == e.serial)
                        {
                            pictureBox2.Image = (Bitmap)e.processedImage.Clone();
                        }
                    }));
            }
        }

        private void _TargetIdentified(object sender, TargetIdentifiedEventArgs e)
        {
            if (processFlag)
            {
                this.BeginInvoke(new Action(() =>
                    {
                        AppendLine("Target identified from camera: " + e.serial);
                    }));
            }
        }

        private void _LightSensorDataReceived(object sender, LightSensorDataReceivedEventArgs e)
        {
            if (processFlag)
            {
                double[] output = e.data;
                DateTime time = e.time;
                for (int i = 0; i < cameraCount; i++)
                {
                    cameras[Camera.SerialNumbers[i]].SetProperty(Camera.Property.Illuminance, output[i]);
                }
            }
        }

        #endregion

        #region Invoke View Methods

        delegate void AppendLineCallback(string text);

        private void AppendLine(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                AppendLineCallback d = new AppendLineCallback(AppendLine);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.AppendText(text + Environment.NewLine);
            }
        }

        #endregion

        private void frameRateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Camera.SetGlobalFrameRate(frameRateTrackBar.Value / 2.0);
            frameRateLabel2.Text = frameRateTrackBar.Value / 2.0 + " fps";
        }

        private void blobSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ImageProcessor.SetWindowSize(windowSizeTrackBar.Value);
            windowSizeLabel.Text = windowSizeTrackBar.Value + " px";
        }

        private void binaryThresholdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ImageProcessor.SetBinaryThreshold(binaryThresholdTrackBar.Value);
            binaryThresholdLabel.Text = binaryThresholdTrackBar.Value + "";
        }

        private void morphologySizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ImageProcessor.SetMorphologyElementSize(morphologySizeTrackBar.Value);
            morphologySizeLabel.Text = morphologySizeTrackBar.Value + " px";
        }

        private void binaryThresholdCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ImageProcessor.SetThresholdFlag(binaryThresholdCheckBox.Checked);
        }

        private void blobDetectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ImageProcessor.SetBLOBDetectionFlag(blobDetectionCheckBox.Checked);
        }

        private void morphologyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ImageProcessor.SetMorphologyFlag(morphologyCheckBox.Checked);
        }

        private void saveImageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ImageProcessor.SetSaveFlag(true);
            Camera.SetSaveFlag(true);
        }
    }
}
