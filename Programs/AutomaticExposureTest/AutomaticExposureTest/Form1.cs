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
        string directory = "";
        bool stop;
        Camera camera;
        Image<Bgr, Byte> image;
        int imageCount;
        double illuminance;
        double exposureValue;
        double[] meanPixelIntensity;
        double[] exposureValues = new double[] { -7.5, -7, -6.5, -6, -5.5, -5, -4.5, -4, -3.5, -3, -2.5, -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2, 2.5 };

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
                textBox.Text += String.Format("Found {0} cameras.{1}", cameraCount, Environment.NewLine);
                camera = new Camera(SerialNumbers[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void initialiseDirectory()
        {
            directory = Directory.GetCurrentDirectory();
            string[] folders = Directory.GetDirectories(directory);
            int runCount = folders.Length + 1;
            Directory.CreateDirectory(directory + "\\" + runCount);
            directory = directory + "\\" + runCount;
        }

        private void initialiseDataFile()
        {
            using (StreamWriter file = new StreamWriter(directory + "\\data.csv", false))
            {
                file.WriteLine("Image Number,Shutter (ms),Brightness (%),Gain (dB),Exposure (EV),White Balance Blue,White Balance Red,Mean Blue Pixel Intensity,Mean Green Pixel Intensity,Mean Red Pixel Intensity,Illuminance (lux)");
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
            return true;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            switch (runButton.Text)
            {
                case "Start":
                    runButton.Text = "Stop";
                    initialiseDirectory();
                    initialiseDataFile();
                    imageCount = 0;
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
            textBox.Text += String.Format("Started automatic exposure loop.{0}", Environment.NewLine);
        }

        public void stopSystem()
        {
            stop = true;
            this.BeginInvoke(new Action(() =>
                textBox.Text += String.Format("Stopped automatic exposure loop.{0}", Environment.NewLine)
                ));
        }

        private void systemLoop()
        {
            /*
            while (!stop)
            {
                //Set desired exposure value
                illuminance = camera.getIlluminance();
                exposureValue = -1 * (1.2741 * Math.Log(illuminance,Math.E) + 0.0101);
                camera.setAutoExposure(exposureValue);

                //Get image from camera
                image = camera.waitForImage();
                pictureBox.Image = image.Bitmap;
                image.Save(Directory.GetCurrentDirectory() + "\\" + imageCount + ".tif");

                //Calculate mean pixel intensity
                meanPixelIntensity = ImageProcessor.meanPixelIntensity(image);

                //Display image and image count
                this.BeginInvoke(new Action(() =>
                {
                    if (!stop) textBox.Text += String.Format("Image: {0}{1}", imageCount, Environment.NewLine);
                }));

                //Save camera settings
                string sample = "";
                sample = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                    imageCount,
                    camera.getShutter(),
                    camera.getBrightness(),
                    camera.getGain(),
                    camera.getAutoExposure(),
                    camera.getWhiteBalance()[0],
                    camera.getWhiteBalance()[1],
                    meanPixelIntensity[0],
                    meanPixelIntensity[1],
                    meanPixelIntensity[2],
                    illuminance);

                using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + "\\data.csv", true))
                {
                    file.WriteLine(sample);
                }

                //Incrementation
                imageCount++;
            }
            */



            for (int i = 0; i < exposureValues.Count(); i++)
            {
                camera.setAutoExposure(exposureValues[i]);
                camera.waitForImage();

                //Get image from camera
                illuminance = camera.getIlluminance(); 
                image = camera.waitForImage();
                pictureBox.Image = image.Bitmap;
                image.Save(directory + "\\" + imageCount + ".tif");

                //Calculate mean pixel intensity
                meanPixelIntensity = ImageProcessor.meanPixelIntensity(image);

                //Display image and image count
                this.BeginInvoke(new Action(() =>
                {
                    textBox.Text += String.Format("Image: {0}{1}", imageCount, Environment.NewLine);
                }));

                //Save camera settings
                string sample = "";
                sample = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                    imageCount,
                    camera.getShutter(),
                    camera.getBrightness(),
                    camera.getGain(),
                    camera.getAutoExposure(),
                    camera.getWhiteBalance()[0],
                    camera.getWhiteBalance()[1],
                    meanPixelIntensity[0],
                    meanPixelIntensity[1],
                    meanPixelIntensity[2],
                    illuminance);

                using (StreamWriter file = new StreamWriter(directory + "\\data.csv", true))
                {
                    file.WriteLine(sample);
                }

                //Incrementation
                imageCount++;

            }
            if (!stop)
            {
                this.BeginInvoke(new Action(() =>
                {
                    runButton.Text = "Start";
                    stopSystem();
                    camera.stop();
                }));
            }
        }
    }
}
