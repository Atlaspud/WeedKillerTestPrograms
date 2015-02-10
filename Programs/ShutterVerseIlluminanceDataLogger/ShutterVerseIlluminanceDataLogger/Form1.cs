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

namespace ShutterVerseIlluminanceDataLogger
{
    public partial class Form1 : Form
    {
        Camera camera;
        LightSensor lightSensor;

        public Form1()
        {
            //Initialization
            InitializeComponent();
            initializeCamera();
            initializeLightSensor();

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
    }
}
