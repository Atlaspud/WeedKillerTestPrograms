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
using WeedKiller2._0;
using System.IO;

namespace MotionTesterV2
{
    public partial class Form1 : Form
    {
        // Motion constants
        private const float DISTANCE_TRAVELLED_THRESHOLD = 0.13f; // half image size which is 25.6cm x 20.48cm
        private const string WSS_SERIAL_PORT = "COM10";
        private const string IMU_SERIAL_PORT = "COM9";

        // Motion Objects
        private Motion motionController;
        private Thread motionThread;

        // Motion Volatiles
        private volatile Position currentPosition;
        private volatile bool stop = false;

        public Form1()
        {
            InitializeComponent();
            InitializeCurrentDirectory();
            initialiseSystem();
        }

        private void InitializeCurrentDirectory()
        {
            string directory = Directory.GetCurrentDirectory();
            string[] folders = Directory.GetDirectories(directory);
            int runCount = folders.Length + 1;
            Directory.CreateDirectory(directory + "\\" + runCount);
            directory = directory + "\\" + runCount;
            Directory.SetCurrentDirectory(directory);
        }

        private Boolean initialiseMotion()
        {
            try
            {
                currentPosition = new Position(0, 0);
                motionController = new Motion(WSS_SERIAL_PORT, IMU_SERIAL_PORT);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace, "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }


        public Boolean initialiseSystem()
        {

            if (!initialiseMotion())
            {
                MessageBox.Show("Failed initialise Motion, Check connections and try again");
                runbutton.Text = "Reinitialise";
                return false;
            }
            UpdateChart(currentPosition);
            return true;
        }

        private void runbutton_Click(object sender, EventArgs e)
        {
            if (runbutton.Text == "Start")
            {
                runbutton.Text = "Stop";
                startSystem();
            }
            else if (runbutton.Text == "Stop")
            {
                runbutton.Text = "Start";
                stopSystem();
            }
            else
            {
                if (initialiseSystem())
                {
                    runbutton.Text = "Start";
                }
            }
        }

        public void startSystem()
        {
            currentPosition = new Position(0, 0);
            stop = false;
            motionThread = new Thread(getMotion);
            motionThread.Start();
        }

        public void stopSystem()
        {
            stop = true;
            motionThread.Abort();

        }

        public void getMotion()
        {
            while (!stop)
            {
                currentPosition = motionController.run();
                UpdateChart(currentPosition);
                Thread.Sleep(20);
            }
        }

        delegate void AppendLineCallback(string text);

        public void AppendLine(string text)
        {

            if (this.logTextBox.InvokeRequired)
            {
                AppendLineCallback d = new AppendLineCallback(AppendLine);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.logTextBox.AppendText(text + Environment.NewLine);
            }
        }

        delegate void UpdateChartCallback(Position position);

        private void UpdateChart(Position position)
        {
            if (this.motionChart.InvokeRequired)
            {
                UpdateChartCallback d = new UpdateChartCallback(UpdateChart);
                this.BeginInvoke(d, new object[] { position });
            }
            else
            {
                double x = position.getXPosition();
                double y = position.getYPosition();

                //motionChart.ChartAreas[0].AxisX.Maximum = (int)(x + 5);
                //motionChart.ChartAreas[0].AxisX.Minimum = (int)(x - 5);
                //motionChart.ChartAreas[0].AxisY.Maximum = (int)(y + 5);
                //motionChart.ChartAreas[0].AxisY.Minimum = (int)(y - 5);

                motionChart.ChartAreas[0].AxisX.Maximum = 1;
                motionChart.ChartAreas[0].AxisX.Minimum = -1;
                motionChart.ChartAreas[0].AxisY.Maximum = 5;
                motionChart.ChartAreas[0].AxisY.Minimum = -1;

                motionChart.Series["IMU"].Points.AddXY(x, y);
            }
        }

        private void setPointFlag_Click(object sender, EventArgs e)
        {
            motionController.setPointFlag();
        }

        private void resetOrigin_Click(object sender, EventArgs e)
        {
            motionController.resetOrigin();
        }
    }
}
