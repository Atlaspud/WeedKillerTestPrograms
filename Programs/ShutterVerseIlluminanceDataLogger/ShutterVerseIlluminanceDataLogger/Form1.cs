using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;

namespace ShutterVerseIlluminanceDataLogger
{
    public partial class Form1 : Form
    {
        Camera camera;
        LightSensor lightSensor;
        String saveFolder;
        int imageCount;

        public Form1()
        {
            //Initialization
            InitializeComponent();
            initializeCamera();
            initializeLightSensor();

            logTxtBox.Text = camera.getCameraInfo();

            //Finalization
            Application.ApplicationExit += finalize;
            AppDomain.CurrentDomain.UnhandledException += finalize;
        }

        private void initializeCamera()
        {
            camera = new Camera(13421033);
            camera.start();
        }

        private void initializeLightSensor()
        {
            lightSensor = new LightSensor("COM7", 1);
            lightSensor.start();
        }

        private void finalize(object o, EventArgs e)
        {
            camera.stop();
            lightSensor.stop();
        }

        private void addCloudShadeBtn_Click(object sender, EventArgs e)
        {
            cameraViewPicBox.Image = camera.getImage().ToBitmap();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            // Browse for new folder
            logTxtBox.Text = "";
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                // Save the folder path
                saveFolder = openFolder.SelectedPath;
                autoCaptureBtn.Enabled = true;
                string[] files = Directory.GetFiles(saveFolder, "*.tif", SearchOption.AllDirectories);
                imageCount = files.Length;
            }
        }

        private void autoCaptureBtn_Click(object sender, EventArgs e)
        {
            if (autoCaptureBtn.Text == "Auto Capture Start")
            {
                autoCaptureBtn.Text = "Auto Capture Stop";
                autoCaptureTimer.Enabled = true;
            }
            else
            {
                autoCaptureBtn.Text = "Auto Capture Start";
                autoCaptureTimer.Enabled = false;
            }
        }

        private void autoCaptureTimer_Tick(object sender, EventArgs e)
        {
            Image<Bgr, Byte> capturedImage = camera.getImage();
            cameraViewPicBox.Image = capturedImage.ToBitmap();
            capturedImage.ToBitmap().Save(String.Format("{0}\\{1}.tif",saveFolder,imageCount));
            logTxtBox.Text += String.Format("Got Image {0}{1}", imageCount, Environment.NewLine);
            imageCount++;
        }
    }
}
