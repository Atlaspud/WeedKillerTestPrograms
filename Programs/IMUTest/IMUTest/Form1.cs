using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMUTest
{
    public partial class Form1 : Form
    {
        private IMU imu; 


        public Form1()
        {
            InitializeComponent();
            imu = new IMU("COM10");
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
        }

        private void getValues_Click(object sender, EventArgs e)
        {
            serialTextOutput.Text += "Pitch: " + imu.getCurrentPitch().ToString() + //"\r\n" +
                " Roll: " + imu.getCurrentRoll().ToString() + //"\r\n" +
                " Yaw: " + imu.getCurrentYaw().ToString() + "\r\n";
        }

        private void stop_Click(object sender, EventArgs e)
        {
            imu.closeConnection();
        }

        private void errorText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
