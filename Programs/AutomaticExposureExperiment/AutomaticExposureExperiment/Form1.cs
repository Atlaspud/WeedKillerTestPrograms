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

namespace AutomaticExposureExperiment
{
    public partial class Form1 : Form
    {

        private bool stop;
        private Camera camera;
        private Image<Bgr, Byte> image;
        private string outputDirectory;

        private double[] shutterValues;
        private double[] exposureValues;
        private double[] gainValues;

        const double SHUTTER_MAXIMUM = 120;
        const double SHUTTER_MINIMUM = 0;
        const double EXPOSURE_MAXIMUM = 0;
        const double EXPOSURE_MINIMUM = 0;
        const double GAIN_MAXIMUM = 0;
        const double GAIN_MINIMUM = 0;

        const int NUMBER_OF_STEPS = 10;

        private int insideLightExperimentCount;
        private int insideDarkExperimentCount;
        private int outsideLightExperimentCount;
        private int outsideDarkExperimentCount;

        private string imageDirectory;
        private int imageCount;

        private enum LightingCondition { insideLight, insideDark, outsideLight, outsideDark };
        private LightingCondition lightingCondition;

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

        private void initialiseDirectory()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                //Save the folder path
                outputDirectory = folder.SelectedPath;
                Directory.CreateDirectory(outputDirectory + "\\insideLight\\");
                Directory.CreateDirectory(outputDirectory + "\\insideDark\\");
                Directory.CreateDirectory(outputDirectory + "\\outsideLight\\");
                Directory.CreateDirectory(outputDirectory + "\\outsideDark\\");

                using (StreamWriter file = new StreamWriter(outputDirectory + "\\data.csv", false))
                {
                    file.WriteLine("Lighting Condition,Lighting Experiment Count,Image Count,Shutter (ms),Brightness (%),Gain (dB),Exposure (EV),White Balance (Red-Blue),Mean Red Pixel Intensity,Mean Green Pixel Intensity,Mean Blue Pixel Intensity");
                }
            }
        }

        public void initialiseVariables()
        {
            shutterValues = new double[NUMBER_OF_STEPS];
            exposureValues = new double[NUMBER_OF_STEPS];
            gainValues = new double[NUMBER_OF_STEPS];

            for (int i = 0; i < NUMBER_OF_STEPS; i++)
            {
                shutterValues[i] = SHUTTER_MINIMUM + ((SHUTTER_MAXIMUM - SHUTTER_MINIMUM) / (NUMBER_OF_STEPS - 1) * i);
                exposureValues[i] = EXPOSURE_MINIMUM + ((EXPOSURE_MAXIMUM - EXPOSURE_MINIMUM) / (NUMBER_OF_STEPS - 1) * i);
                gainValues[i] = GAIN_MINIMUM + ((GAIN_MAXIMUM - GAIN_MINIMUM) / (NUMBER_OF_STEPS - 1) * i);
            }

            insideLightExperimentCount = 0;
            insideDarkExperimentCount = 0;
            outsideDarkExperimentCount = 0;
            outsideLightExperimentCount = 0;
        }

        public Boolean initialiseSystem()
        {
            initialiseDirectory();
            initialiseVariables();
            if (!initialiseVision())
            {
                MessageBox.Show("Failed to initialise cameras. Check cameras and try again.", "Error",MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void experimentButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            insideLightButton.Enabled = false;
            insideDarkButton.Enabled = false;
            outsideLightButton.Enabled = false;
            outsideDarkButton.Enabled = false;
            clickedButton.Enabled = true;

            switch (clickedButton.Text)
            {
                case "Inside Light":
                    lightingCondition = LightingCondition.insideLight;
                    insideLightButton.Text = "Stop";
                    startExperiment();
                    insideLightExperimentCount++;
                    imageDirectory = outputDirectory + "\\Inside Light\\" + insideLightExperimentCount;
                    Directory.CreateDirectory(imageDirectory);
                    AppendLine("InsideLight");
                    break;

                case "Inside Dark":
                    lightingCondition = LightingCondition.insideDark;
                    insideDarkButton.Text = "Stop";
                    startExperiment();
                    insideDarkExperimentCount++;
                    imageDirectory = outputDirectory + "\\Inside Dark\\" + insideDarkExperimentCount;
                    Directory.CreateDirectory(imageDirectory);
                    AppendLine("InsideDark");
                    break;

                case "Outside Light":
                    lightingCondition = LightingCondition.outsideLight;
                    outsideLightButton.Text = "Stop";
                    startExperiment();
                    outsideLightExperimentCount++;
                    imageDirectory = outputDirectory + "\\Outside Light\\" + outsideLightExperimentCount;
                    Directory.CreateDirectory(imageDirectory);
                    AppendLine("OutsideLight");
                    break;

                case "Outside Dark":
                    lightingCondition = LightingCondition.outsideDark;
                    outsideDarkButton.Text = "Stop";
                    startExperiment();
                    outsideDarkExperimentCount++;
                    imageDirectory = outputDirectory + "\\Outside Dark\\" + outsideDarkExperimentCount;
                    Directory.CreateDirectory(imageDirectory);
                    AppendLine("OutsideDark");
                    break;

                case "Stop":
                    switch (lightingCondition)
                    {
                        case LightingCondition.insideLight:
                            clickedButton.Text = "Inside Light";
                            break;

                        case LightingCondition.insideDark:
                            clickedButton.Text = "Inside Dark";
                            break;

                        case LightingCondition.outsideLight:
                            clickedButton.Text = "Outside Light";
                            break;

                        case LightingCondition.outsideDark:
                            clickedButton.Text = "Outside Dark";
                            break;
                    }
                    stopExperiment();
                    break;
            }
        }

        public void startExperiment()
        {
            stop = false;
            camera.start();
            imageCount = 0;
            Thread experimentThread = new Thread(experimentLoop);
            experimentThread.Start();
        }

        public void stopExperiment()
        {
            stop = true;
            insideLightButton.Enabled = true;
            insideDarkButton.Enabled = true;
            outsideLightButton.Enabled = true;
            outsideDarkButton.Enabled = true;

        }

        private void experimentLoop()
        {
            for (int i = 0; i < NUMBER_OF_STEPS; i++)
            {
                if (stop) break;
                camera.setShutterSpeed(shutterValues[i]);

                /*
                for (int j = 0; j < NUMBER_OF_STEPS; j++)
                {
                    camera.setExposure(exposureValues[j]);
                    for (int k = 0; k < NUMBER_OF_STEPS; k++)
                    {
                        camera.setGain(gainValues[i]);
                    }
                }
                */

                ImageAndMetadata imageAndMetadata = camera.waitForImage();
                image = imageAndMetadata.image;
                image.Save(imageDirectory + "\\" + imageCount + ".tif");

                string sample = "";
                switch (lightingCondition)
                {
                    case LightingCondition.insideLight:
                        sample += "Inside Light,";
                        sample += (insideLightExperimentCount + ",");
                        break;

                    case LightingCondition.insideDark:
                        sample += "Inside Dark,";
                        sample += (insideDarkExperimentCount + ",");
                        break;

                    case LightingCondition.outsideLight:
                        sample += "Outside Light,";
                        sample += (outsideLightExperimentCount + ",");
                        break;

                    case LightingCondition.outsideDark:
                        sample += "Outside Dark,";
                        sample += (outsideDarkExperimentCount + ",");
                        break;
                }
                sample += (imageCount + ";");
                sample += (imageAndMetadata.shutter + ",");
                sample += (imageAndMetadata.brightness + ",");
                sample += (imageAndMetadata.gain + ",");
                sample += (imageAndMetadata.exposure + ",");
                sample += (imageAndMetadata.whiteBalance + ",");
                sample += (imageAndMetadata.meanRedPixelIntensity + ",");
                sample += (imageAndMetadata.meanGreenPixelIntensity + ",");
                sample += (imageAndMetadata.meanBluePixelIntensity);
                using (StreamWriter file = new StreamWriter(outputDirectory + "\\data.csv", true))
                {
                    file.WriteLine(sample);
                }
                pictureBox.Image = image.Bitmap;
                imageCount++;
                AppendLine("Image count: " + imageCount);

            }

            stopExperiment();
            camera.stop();
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
