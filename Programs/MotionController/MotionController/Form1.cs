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

namespace MotionController
{
    public partial class Form1 : Form
    {
        IMU imuSensor;
        WheelSpeedSensor wheelSS;
        Motion motionControl;
        Boolean startFlag = false;
        Position currentPosition;
        int counter = 0;
        Thread printThread;

        public Form1()
        {
            InitializeComponent();

            imuSensor = new IMU("COM9");
            wheelSS = new WheelSpeedSensor("COM10");
            motionControl = new Motion(imuSensor, wheelSS);
            //motionControl = new Motion("COM9", "COM10");
            
        }

        void printFunction()
        {
            while (true)
            {
                Thread.Sleep(1000);
                {
                    if (startFlag)
                    {
                        currentPosition = motionControl.getCurrentPosition();
                        if (currentPosition != null)
                        {
                            this.BeginInvoke(new Action(() =>
                                {
                                    textBox1.Text += currentPosition.getXPosition().ToString() + " , " +
                        currentPosition.getYPosition().ToString() +
                        " , Yaw: " + imuSensor.getCurrentYaw() +
                        " , Velocity: " + wheelSS.getCurrentVelocity() +
                        "\r\n";
                                    textBox1.ScrollToCaret();
                                })); 
                        }
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!startFlag)
            {
                textBox1.Text += motionControl.startMotionController();
                startFlag = true;
            }

            printThread = new Thread(new ThreadStart(printFunction));
            printThread.Start();

        }

        private void getPosition_Click(object sender, EventArgs e)
        {
            if (startFlag)
            {
                currentPosition = motionControl.getCurrentPosition();
                if (!currentPosition.Equals(null))
                {
                    textBox1.Text += currentPosition.getXPosition().ToString() + " , " +
                        currentPosition.getYPosition().ToString() +
                        " , Yaw: " + imuSensor.getCurrentYaw() + 
                        " , Velocity: " + wheelSS.getCurrentVelocity() +
                        "\r\n";
                    textBox1.ScrollToCaret();
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (startFlag)
            {
                motionControl.stopMotionController();
            }
            
            if (printThread.IsAlive)
            {
                printThread.Abort();
            }

            motionControl.resetOrigin();
            

        }

        private void clearConsole_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
