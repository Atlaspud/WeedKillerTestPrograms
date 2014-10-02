using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WheelSpeedSensorTest;

namespace WheelSpeedSensorTest
{
    public partial class Form1 : Form
    {
        WheelSpeedSensor WSS;
        bool startFlag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Create Wheel Speed Sensor instance on desired COM
            WSS = new WheelSpeedSensor("COM10");
            startFlag = true; 
        }

        private void getVelocityButton_Click(object sender, EventArgs e)
        {
            if (startFlag == true)
            {
                //gets current velocity and appends to textbox
                textBox1.AppendText(WSS.getCurrentVelocity().ToString()+"\r\n");
                textBox1.ScrollToCaret();
            } 
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startFlag = false;
            if (WSS != null)
            {
                WSS.closeSerialPort();
            }
            Application.Exit();
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
