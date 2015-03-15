using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ImageAcquirer
{
    public partial class Form1 : Form
    {
        //System variables
        private string directory;
        private bool stop;
        volatile float[] illuminance;
        //double[] shutter;
        double[] gain;
        int imageNumber;
        Thread systemThread;

        //Vision variables
        private Dictionary<uint, Camera> cameras;
        private Image<Bgr, Byte>[] images;
        private int numberOfCameras;
        private static readonly uint[] SERIAL_NUMBERS = new uint[8]
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

        //Light Sensor variables
        private readonly string LIGHT_SENSOR_SERIAL_PORT = "COM5";
        private LightSensor lightSensor;
        private Thread lightSensorThread;

        public Form1()
        {
            InitializeComponent();
            initialiseSystem();
        }

        private bool initialiseSystem()
        {
            if (!initialiseVision())
            {
                MessageBox.Show("Failed to initialise cameras. Check connection and try again.", "Error", MessageBoxButtons.OK);
                return false;
            }
            if (!initialiseLightSensor())
            {
                MessageBox.Show("Failed to initialise light sensor. Check connection and try again.", "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private bool initialiseVision()
        {
            numberOfCameras = Camera.GetNumberOfCameras();
            if (numberOfCameras != 0)
            {
                cameras = new Dictionary<uint, Camera>(numberOfCameras);
                images = new Image<Bgr, Byte>[8];
                for (int i = 0; i < numberOfCameras; i++)
                {
                    cameras.Add(SERIAL_NUMBERS[i], new Camera(SERIAL_NUMBERS[i]));
                    cameras[SERIAL_NUMBERS[i]].setCameraProfile(Camera.CameraProfile.gainVsIlluminance);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool initialiseLightSensor()
        {
            try
            {
                lightSensor = new LightSensor(LIGHT_SENSOR_SERIAL_PORT);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void newDirectory()
        {
            directory = Directory.GetCurrentDirectory();
            string[] folders = Directory.GetDirectories(directory);
            directory = directory + "\\" + (folders.Length + 1);
            Directory.CreateDirectory(directory);
            using (StreamWriter file = new StreamWriter(directory + "\\Information.csv", false))
            {
                file.WriteLine("Camera Serial,Image Number,Illuminance (lux),Shutter (ms),Exposure Value (EV),Gain (dB),Brightness (%),White Balance (Blue),White Balance (Red)");
            }
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            switch (systemButton.Text)
            {
                case "Start":
                    systemButton.Text = "Stop";
                    startSystem();
                    break;

                case "Stop":
                    systemButton.Text = "Start";
                    stopSystem();
                    break;

                case "Initialise":
                    if (initialiseSystem())
                    {
                        systemButton.Text = "Start";
                    }
                    break;
            }
        }

        private void startSystem()
        {
            //Reset system variables
            stop = false;
            imageNumber = 0;
            newDirectory();
            gain = new double[numberOfCameras];
            illuminance = new float[numberOfCameras];
            //shutter = new double[numberOfCameras];

            //Start cameras
            for (int i = 0; i < numberOfCameras; i++)
            {
                cameras[SERIAL_NUMBERS[i]].start();
            }

            //Start light sensors
            lightSensorThread = new Thread(getIlluminance);
            lightSensorThread.Start();

            //Start system loop
            systemThread = new Thread(getImages);
            systemThread.Start();
        }

        private void stopSystem()
        {
            stop = true;
        }

        private void getIlluminance()
        {
            while (!stop)
            {
                illuminance = lightSensor.getCurrentReadings();
                Thread.Sleep(10);
            }
        }

        private void getImages()
        {
            while (!stop)
            {
                for (int i = 0; i < numberOfCameras; i++)
                {
                    gain[i] = -0.024 * illuminance[i] + 27.405;
                    cameras[SERIAL_NUMBERS[i]].setGain(gain[i]);

                    images[i] = cameras[SERIAL_NUMBERS[i]].waitForImage();
                    images[i].Save(directory + "\\" + imageNumber + "-" + SERIAL_NUMBERS[i] + ".tif");

                    string sample = "";
                    sample += String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                        SERIAL_NUMBERS[i],
                        imageNumber,
                        illuminance[i],
                        cameras[SERIAL_NUMBERS[i]].getShutter(),
                        cameras[SERIAL_NUMBERS[i]].getGain(),
                        cameras[SERIAL_NUMBERS[i]].getExposureValue(),
                        cameras[SERIAL_NUMBERS[i]].getBrightness(),
                        cameras[SERIAL_NUMBERS[i]].getWhiteBalance()[0],
                        cameras[SERIAL_NUMBERS[i]].getWhiteBalance()[1]);

                    using (StreamWriter file = new StreamWriter(directory + "\\Information.csv", true))
                    {
                        file.WriteLine(sample);
                    }
                }

                //Update form
                this.BeginInvoke(new Action(() =>
                {
                    imageNumberLabel.Text = String.Format("{0}", imageNumber);
                    if (!cameraComboBox.SelectedItem.Equals("None"))
                    {
                        uint serial = uint.Parse((string)cameraComboBox.SelectedItem);
                        pictureBox.Image = images[Array.IndexOf(SERIAL_NUMBERS,serial)].Bitmap;
                        illuminanceLabel.Text = String.Format("{0}",illuminance[Array.IndexOf(SERIAL_NUMBERS,serial)]);
                        shutterLabel.Text = String.Format("{0}",cameras[serial].getShutter());
                        gainLabel.Text = String.Format("{0}", cameras[serial].getGain());
                        exposureValueLabel.Text = String.Format("{0}", cameras[serial].getExposureValue());
                        brightnessLabel.Text = String.Format("{0}", cameras[serial].getBrightness());
                        whiteBalanceRedLabel.Text = String.Format("{0}", cameras[serial].getWhiteBalance()[1]);
                        whiteBalanceBlueLabel.Text = String.Format("{0}", cameras[serial].getWhiteBalance()[0]);
                    }
                }));

                imageNumber++;
            }

            //Stop cameras
            for (int i = 0; i < numberOfCameras; i++)
            {
                cameras[SERIAL_NUMBERS[i]].stop();
            }
        }

        private void cameraComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((string)cameraComboBox.SelectedItem).Equals("None"))
            {
                pictureBox.Image = pictureBox.BackgroundImage;
                illuminanceLabel.Text = "-";
                shutterLabel.Text = "-";
                gainLabel.Text = "-";
                exposureValueLabel.Text = "-";
                brightnessLabel.Text = "-";
                whiteBalanceBlueLabel.Text = "-";
                whiteBalanceRedLabel.Text = "-";
            }
        }
    }
}
