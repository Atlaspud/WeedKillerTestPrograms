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
using Emgu.CV.Structure;

namespace AutomaticExposureTest
{
    public partial class Form1 : Form
    {

        bool stop;
        Camera camera;
        List<Image<Bgr, Byte>> images;

        public static readonly uint[] SerialNumbers = new uint[8]
        {
            13421033,
            13421041,
            13421043,
            13421046,
            13421051,
            13421053,
            13421056,
            13421057
        };

        public Form1()
        {
            InitializeComponent();
            initialiseSystem();
        }

        private Boolean initialiseVision()
        {
            int cameraCount = Camera.GetNumberOfCameras();
            if (cameraCount != 0)
            {
                AppendLine(String.Format("Cameras Found: {0}", cameraCount));
                camera = new Camera(SerialNumbers[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean initialiseSystem()
        {
            if (!initialiseVision())
            {
                MessageBox.Show("Failed to initialise cameras. Check cameras and try again.", "Error",MessageBoxButtons.OK);
                runButton.Text = "Initialise";
                return false;
            }
            return true;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            switch (runButton.Text)
            {
                case "Start":
                    runButton.Text = "Stop";
                    startSystem();
                    break;

                case "Stop":
                    runButton.Text = "Start";
                    stopSystem();
                    break;

                case "Initialise":
                    if (initialiseSystem())
                    {
                        runButton.Text = "Start";
                    }
                    break;
            }
        }

        public void startSystem()
        {
            stop = false;
            camera.start();
            Thread systemThread = new Thread(systemLoop);
            systemThread.Start();
        }

        public void stopSystem()
        {
            stop = true;
            camera.stop();
        }

        private void systemLoop()
        {
            while (!stop)
            {
                images.Add(camera.waitForImage());
                pictureBox.Image = images[images.Count - 1].Bitmap;
                AppendLine("" + images.Count);
            }
        }

        delegate void AppendLineCallback(string text);

        public void AppendLine(string text)
        {

            if (this.textBox.InvokeRequired)
            {
                AppendLineCallback d = new AppendLineCallback(AppendLine);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.textBox.AppendText(text + Environment.NewLine);
            }
        }
    }
}
