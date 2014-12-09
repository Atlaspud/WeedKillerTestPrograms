using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model;

namespace IMUTest
{
    public partial class Form1 : Form
    {
        private IMU imu;
        private Boolean startflag = false;
        private int counter = 0;
        public Form1()
        {
            InitializeComponent();
            imu = new IMU("COM9");
            imu.OnYawUpdate += imu_OnYawUpdate;
            startflag = false;
        }

        void imu_OnYawUpdate(object source, double yawArgs)
        {
            if (startflag)
            {
                if (counter == 25)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        serialTextOutput.Text = //"Pitch: " + imu.getCurrentPitch().ToString() + //"\r\n" +
                            //" Roll: " + imu.getCurrentRoll().ToString() +
                            //" Yaw: " + imu.getCurrentYaw().ToString() +
                            "aX: " + imu.getCurrentAX() +
                            "aY: " + imu.getCurrentAY() +
                            "aZ: " + imu.getCurrentAZ() + "\r\n";
                    }));

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

        private void serialTextOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            errorText.Text = imu.initConnection();
            startflag = true;

        }

        private void getValues_Click(object sender, EventArgs e)
        {
            if (startflag)
            {
                serialTextOutput.Text = "Pitch: " + imu.getCurrentPitch().ToString() + //"\r\n" +
                    " Roll: " + imu.getCurrentRoll().ToString() +
                    " Yaw: " + imu.getCurrentYaw().ToString() +
                    "aX: " + imu.getCurrentAX() +
                    "aY: " + imu.getCurrentAY() +
                    "aZ: " + imu.getCurrentAZ() + "\r\n";
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            imu.closeConnection();
            Application.Exit();
        }

        private void errorText_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
