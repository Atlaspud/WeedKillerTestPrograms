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

namespace CameraTest
{
    public partial class Form1 : Form
    {
        private LightSensor lightSensor;
        private string result;
        private Camera[] cameras;
        private int cameraCount = 1;
        private bool cameraDisplayFlag = false;
        
        public Form1()
        {
            InitializeComponent();
            Application.ApplicationExit += Application_ApplicationExit;
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (cameras != null) foreach (Camera camera in cameras) camera.StopCapture();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
            cameraCount = Camera.GetNumberOfCameras();
            AppendText("Found " + cameraCount + " cameras.");
            if (cameraCount == 0)
            {
                MessageBox.Show("The ethernet bus manager has failed to find your camera(s). Please check your connections.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            cameras = new Camera[cameraCount];
            cameraSelection.Items.Clear();
            cameraSelection.Items.Add("Off");
            for (int i = 0; i < cameraCount; i++)
            {
                cameraSelection.Items.Add("Camera " + (i + 1));
                cameras[i] = new Camera(Camera.SerialNumbers[i]);
                result = cameras[i].StartCapture();
                if (result != null)
                {
                    MessageBox.Show(result,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                    return;
                }
                cameras[i].CameraFrameReceived += _CameraFrameReceived;
            }
            lightSensor = new LightSensor("COM7", cameraCount);
            result = lightSensor.Start();
            if (result != null)
            {
                MessageBox.Show(result,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
            }
            lightSensor.LightSensorDataReceived += _LightSensorDataReceived;
        }

        void _CameraFrameReceived(object sender, CameraFrameReceivedEventArgs e)
        {
            this.Invoke(new Action (() =>
                {
                    if (cameraDisplayFlag)
                    {
                        int index = cameraSelection.SelectedIndex - 1;
                        if (index < 0) return;
                        if (cameras[index].GetSerial() == e.serial)
                        {
                            pictureBox1.Image = e.image.ToBitmap();
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

        void _LightSensorDataReceived(object sender, LightSensorDataReceivedEventArgs e)
        {
            double[] output = e.data;
            DateTime time = e.time;
            for (int i = 0; i < cameraCount; i++)
            {
                cameras[i].SetProperty(Camera.Property.Illuminance, output[i]);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            foreach (Camera camera in cameras)
            {
                camera.StopCapture();
            }

            if (lightSensor != null) result = lightSensor.Stop();
            if (result != null)
            {
                MessageBox.Show(result,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                return;
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
                pictureBox1.Image = new Image<Bgr, Byte>(1280, 1024, new Bgr(255, 255, 255)).ToBitmap();
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
