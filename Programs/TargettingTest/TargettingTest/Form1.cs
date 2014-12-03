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

namespace TargettingTest
{
    public partial class Form1 : Form
    {
        public Motion motionController;
        public Sprayer sprayer;
        public Position currentPosition;


        public Form1()
        {
            InitializeComponent();
            motionController = new Motion("COM9", "COM10");
            sprayer = new Sprayer("FTXG3YUN", "FTVAS7VX");
            motionController.startMotionController();
            motionController.OnMotionUpdate += motionControl_OnMotionUpdate;
        }

        private void motionControl_OnMotionUpdate(object source, MotionUpdate motionUpdateArgs)
        {
            currentPosition = motionController.getCurrentPosition();
            this.BeginInvoke(new Action(() =>
            {
                //textBox1.Text += motionControl.getCurrentPosition().getTime() + "," +
                //    currentPosition.getXPosition().ToString() +
                //    "," + currentPosition.getYPosition().ToString() +
                //    "," + imuSensor.getCurrentYaw() +
                //    "," + wheelSS.getCurrentVelocity() +
                //    //" , InitYaw: " + motionControl.initialYaw +
                //    //" , vector angle: " + motionControl.newVectorAngle +
                //    "\r\n";
                //textBox1.ScrollToCaret();
                //textBox1.Update();

                chart1.Series["Series1"].Points.AddXY(currentPosition.getXPosition(), currentPosition.getYPosition());
            })); 
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void startbutton_Click(object sender, EventArgs e)
        {

        }

        private void addtarget_Click(object sender, EventArgs e)
        {
            Target target = new Target(motionController.getCurrentPosition(), 1);
            sprayer.addTarget(target);
            chart1.Series["Series2"].Points.AddXY(target.getLocation().getXPosition(), target.getLocation().getYPosition());

        }

        private void stopbutton_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
