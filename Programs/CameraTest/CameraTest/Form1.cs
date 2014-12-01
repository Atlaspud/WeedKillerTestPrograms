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

namespace CameraTest
{
    public partial class Form1 : Form
    {
        private LightSensor lightSensor;
        private string result;
        private Dictionary<uint, Camera> cameras;
        private Dictionary<uint, PictureBox> pictureBoxes;
        
        public Form1()
        {
            InitializeComponent();
            Application.ApplicationExit += Application_ApplicationExit;
            pictureBoxes = new Dictionary<uint, PictureBox>();
            for (int n = 0; n < 8; n++)
            {
                PictureBox pictureBox = new PictureBox();
                int x = 15 + (n * 120);
                int y = 15;
                pictureBox.Location = new System.Drawing.Point(x, y);
                pictureBox.Size = new System.Drawing.Size(120, 96);
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox.Visible = true;
                pictureBoxes.Add(Camera.SerialNumbers[n], pictureBox);
                this.Controls.Add(pictureBox);
            }
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (cameras != null) foreach (KeyValuePair<uint,Camera> camera in cameras) camera.Value.StopCapture();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            cameras = new Dictionary<uint, Camera>();
            for (int i = 0; i < 8; i++)
            {
                cameras.Add(Camera.SerialNumbers[i], new Camera(Camera.SerialNumbers[i], pictureBoxes[Camera.SerialNumbers[i]]));
                result = cameras[Camera.SerialNumbers[i]].StartCapture();
                if (result != null)
                {
                    MessageBox.Show(result,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                    return;
                }
                //cameras[Camera.SerialNumbers[i]].CameraFrameReceived += (camera_sender, camera_e) =>
                //    Task.Factory.StartNew(() => _CameraFrameReceived(camera_sender, camera_e));
            }
            lightSensor = new LightSensor("COM7");
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
            lightSensor.LightSensorDataReceived += (lightsensor_sender, lightsensor_e) =>
                Task.Factory.StartNew(() => _LightSensorDataReceieved(lightsensor_sender, lightsensor_e));
        }

        void _CameraFrameReceived(object sender, CameraFrameReceivedEventArgs e)
        {
            pictureBoxes[e.serial].Image = e.image.ToBitmap();
            //e.image;
            //e.time;
            //e.serial;
            //Image processing
        }

        void _LightSensorDataReceieved(object sender, LightSensorDataReceivedEventArgs e)
        {
            double[] output = e.data;
            DateTime time = e.time;
            string s = "Time: " + time.ToString("hh:mm:ss") + "\r\n";
            for (int i = 0; i < 8; i++)
            {
                s += ("Sensor " + i + ": " + (int)output[i] + "\r\n");
            }
            SetText(s);
            for (int i = 0; i < 8; i++)
            {
                cameras[Camera.SerialNumbers[i]].SetProperty(Camera.Property.Illuminance, output[i]);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<uint,Camera> camera in cameras)
            {
                camera.Value.StopCapture();
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

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }

        private void breakButton_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
        }
    }
}
