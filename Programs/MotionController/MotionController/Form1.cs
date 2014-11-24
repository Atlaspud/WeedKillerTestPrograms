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

            //imuSensor = new IMU("COM9");
            //wheelSS = new WheelSpeedSensor("COM10");
            motionControl = new Motion("COM9", "COM10");
            //printThread = new Thread(new ThreadStart(printFunction));
            //printThread.Start();
        }

        void printFunction()
        {
            while (true)
            {
                if (counter == 1000000)
                {
                    if (startFlag)
                    {
                        currentPosition = motionControl.getCurrentPosition();
                        if (!currentPosition.Equals(null))
                        {
                            textBox1.Text += currentPosition.getXPosition().ToString() + " , " + currentPosition.getYPosition().ToString() + "\r\n";
                            textBox1.ScrollToCaret();
                        }
                    }
                    counter = 0;
                }
                else
                {
                    counter++;
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

        }

        private void getPosition_Click(object sender, EventArgs e)
        {
            if (startFlag)
            {
                currentPosition = motionControl.getCurrentPosition();
                if (!currentPosition.Equals(null))
                {
                    textBox1.Text += currentPosition.getXPosition().ToString() + " , " + currentPosition.getYPosition().ToString() + "\r\n";
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
            Application.Exit();

        }
    }
}
