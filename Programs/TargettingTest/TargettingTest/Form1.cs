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
using controller;

namespace TargettingTest
{
    public partial class Form1 : Form
    {
        public Motion motionController;
        public Sprayer sprayer;
        public volatile Position currentPosition;
        private Boolean startFlag = false;

        public Form1()
        {
            InitializeComponent();
            //application = new App();
            currentPosition = new Position(0, 0);
            motionController = new Motion("COM9", "COM10");
            sprayer = new Sprayer("FTXG3YUN", "FTVAS7VX");

            motionController.OnMotionUpdate += motionController_OnMotionUpdate;
        }

        void motionController_OnMotionUpdate(object source, Position currentPosition)
        {
            this.currentPosition = currentPosition;
            sprayer.setCurrentPosition(currentPosition);

            this.BeginInvoke(new Action(() =>
            {
                chart1.Series["Series1"].Points.AddXY(currentPosition.getXPosition(), currentPosition.getYPosition());
            }));
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            if (motionController.startMotionController() == "Good")
            {
                startFlag = true;
            } 
        }

        private void addtarget_Click(object sender, EventArgs e)
        {
            Target target = new Target(currentPosition, 1);
            sprayer.addTarget(target);
            chart1.Series["Series2"].Points.AddXY(target.getPosition().getXPosition(), target.getPosition().getYPosition());
        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            if (startFlag)
            {
                motionController.stopMotionController();
                startFlag = false;
            }
        }
















        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
