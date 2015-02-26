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
using System.IO;

namespace AutomaticExposureTest
{
    public partial class Form1 : Form
    {
        //Global variables
        bool stop;
        Camera camera;
        Image<Bgr, Byte> image;
        SmartImage smartImage;
        int imageCount;
        double illuminance;
        double exposureValue;

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
                textBox.Text += String.Format("Found {0} cameras.\n", cameraCount);
                camera = new Camera(SerialNumbers[0]);
                imageCount = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void initialiseDirectory()
        {
            string directory = Directory.GetCurrentDirectory();
            string[] folders = Directory.GetDirectories(directory);
            int runCount = folders.Length + 1;
            Directory.CreateDirectory(directory + "\\" + runCount);
            directory = directory + "\\" + runCount;
            Directory.SetCurrentDirectory(directory);
        }

        private void initialiseDataFile()
        {
            using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + "\\data.csv", false))
            {
                file.WriteLine("Image Number,Shutter (ms),Brightness (%),Gain (dB),Exposure (EV_100),White Balance Blue,White Balance Red,Mean Blue Pixel Intensity,Mean Green Pixel Intensity,Mean Red Pixel Intensity,Illuminance (lux)");
            }
        }

        public Boolean initialiseSystem()
        {
            if (!initialiseVision())
            {
                MessageBox.Show("Failed to initialise cameras. Check connection and try again.", "Error",MessageBoxButtons.OK);
                runButton.Text = "Initialise";
                return false;
            }
            initialiseDirectory();
            initialiseDataFile();
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
            textBox.Text += String.Format("Started automatic exposure loop.\n");
        }

        public void stopSystem()
        {
            stop = true;
            textBox.Text += String.Format("Stopped automatic exposure loop.\n");
        }

        private void systemLoop()
        {
            while (!stop)
            {
                //Set desired exposure value
                illuminance = camera.getIlluminance();
                exposureValue = -1 * (1.2741 * Math.Log(illuminance,Math.E) + 0.0101);
                camera.setAutoExposure(exposureValue);

                //Get image from camera
                smartImage = camera.waitForSmartImage();
                image = smartImage.image;

                //Display image and image count
                this.BeginInvoke(new Action(() =>
                {
                    textBox.Text += String.Format("Image: {0}\n", imageCount);
                    pictureBox.Image = image.Bitmap;
                    image.Save(Directory.GetCurrentDirectory() + "\\" + imageCount + ".tif");
                }));

                //Save metadata from smart image
                string sample = "";
                sample = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}\n",
                    imageCount,
                    smartImage.shutter,
                    smartImage.brightness,
                    smartImage.gain,
                    smartImage.exposure,
                    smartImage.whiteBalanceBlue,
                    smartImage.whiteBalanceRed,
                    smartImage.meanPixelIntensity[0],
                    smartImage.meanPixelIntensity[1],
                    smartImage.meanPixelIntensity[2],
                    illuminance);

                //Incrementation
                imageCount++;
            }

            //Stop camera
            camera.stop();
        }
    }
}
