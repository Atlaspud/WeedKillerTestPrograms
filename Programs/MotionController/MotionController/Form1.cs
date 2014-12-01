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

        public Form1()
        {
            InitializeComponent();

            imuSensor = new IMU("COM9");
            wheelSS = new WheelSpeedSensor("COM10");
            motionControl = new Motion(imuSensor, wheelSS);
            //motionControl = new Motion("COM9", "COM10");

            

        }

        private void motionControl_OnMotionUpdate(object source, MotionUpdate motionUpdateArgs)
        {
            printTextBoxInfo(); 	            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!startFlag)
            {
                textBox1.Text += motionControl.startMotionController();
                textBox1.Text += "\r\ntime,x,y,yaw,velocity\r\n";
                startFlag = true;
                motionControl.OnMotionUpdate += motionControl_OnMotionUpdate;
            }
        }

        private void getPosition_Click(object sender, EventArgs e)
        {
            printTextBoxInfo();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            motionControl.resetOrigin();

            if (startFlag)
            {
                motionControl.stopMotionController();
                motionControl.OnMotionUpdate -= motionControl_OnMotionUpdate;
                startFlag = !startFlag;
            }
        }

        private void clearConsole_Click(object sender, EventArgs e)
        {
            motionControl.resetOrigin();
            textBox1.Clear();
            chart1.Series["Series1"].Points.Clear(); 
        }

        private void printTextBoxInfo() 
        {
            if (startFlag)
            {
                currentPosition = motionControl.getCurrentPosition();
                if (!currentPosition.Equals(null))
                {
                    this.BeginInvoke(new Action(() =>
                        {
                            textBox1.Text += motionControl.getCurrentPosition().getTime()  + "," +
                                currentPosition.getXPosition().ToString() +
                                "," + currentPosition.getYPosition().ToString() +
                                "," + imuSensor.getCurrentYaw() +
                                ","+ wheelSS.getCurrentVelocity() +
                                //" , InitYaw: " + motionControl.initialYaw +
                                //" , vector angle: " + motionControl.newVectorAngle +
                                "\r\n";
                            textBox1.ScrollToCaret();
                            textBox1.Update();

                            chart1.Series["Series1"].Points.AddXY(currentPosition.getXPosition(),currentPosition.getYPosition());
                        })); 
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

        private void chart1_Click(object sender, EventArgs e)
        {

        }

    }
}
