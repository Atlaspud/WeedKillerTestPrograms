using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SprayerTest
{
    public partial class Form1 : Form
    {
        Boolean sprayerStatus1;
        Boolean sprayerStatus2;
        Boolean sprayerStatus3;
        Boolean sprayerStatus4;
        Boolean sprayerStatus5;
        Boolean sprayerStatus6;
        Boolean sprayerStatus7;
        Boolean sprayerStatus8;
        Boolean sprayerRelayStatus;
        SprayerRelay sprayerRelay0;
        SprayerRelay sprayerRelay1;


        public Form1()
        {
            InitializeComponent();

            sprayerStatus1 = false;
            sprayerStatus2 = false;
            sprayerStatus3 = false;
            sprayerStatus4 = false;
            sprayerStatus5 = false;
            sprayerStatus6 = false;
            sprayerStatus7 = false;
            sprayerRelayStatus = false;
            sprayerRelay0 = new SprayerRelay("FTXG3YUN");
            sprayerRelay1 = new SprayerRelay("FTVAS7VX");
            textBox1.Text = SprayerRelay.printIds();
        }

        private void sprayer1_Click(object sender, EventArgs e)
        {
            if (sprayerStatus1)
            {
                sprayerRelay0.changeSprayerStatus(1, false);
                sprayer1.Text = "Sprayer 1: OFF";
                sprayerStatus1 = false;
            }
            else
            {
                sprayerRelay0.changeSprayerStatus(1, true);
                sprayer1.Text = "Sprayer 1: ON";
                sprayerStatus1 = true;
            }
        }

        private void sprayer2_Click(object sender, EventArgs e)
        {
            if (sprayerStatus2)
            {
                sprayerRelay0.changeSprayerStatus(2, false);
                sprayer2.Text = "Sprayer 1: OFF";
                sprayerStatus2 = false;
            }
            else
            {
                sprayerRelay0.changeSprayerStatus(2, true);
                sprayer2.Text = "Sprayer 1: ON";
                sprayerStatus2 = true;
            }
        }

        private void sprayer3_Click(object sender, EventArgs e)
        {
            if (sprayerStatus3)
            {
                sprayerRelay0.changeSprayerStatus(3, false);
                sprayer3.Text = "Sprayer 1: OFF";
                sprayerStatus3 = false;
            }
            else
            {
                sprayerRelay0.changeSprayerStatus(3, true);
                sprayer3.Text = "Sprayer 1: ON";
                sprayerStatus3 = true;
            }
        }

        private void sprayer4_Click(object sender, EventArgs e)
        {
            if (sprayerStatus4)
            {
                sprayerRelay0.changeSprayerStatus(4, false);
                sprayer4.Text = "Sprayer 1: OFF";
                sprayerStatus4 = false;
            }
            else
            {
                sprayerRelay0.changeSprayerStatus(4, true);
                sprayer4.Text = "Sprayer 1: ON";
                sprayerStatus4 = true;
            }
        }

        private void sprayer5_Click(object sender, EventArgs e)
        {
            if (sprayerStatus5)
            {
                sprayerRelay1.changeSprayerStatus(1, false);
                sprayer5.Text = "Sprayer 1: OFF";
                sprayerStatus5 = false;
            }
            else
            {
                sprayerRelay1.changeSprayerStatus(1, true);
                sprayer5.Text = "Sprayer 1: ON";
                sprayerStatus5 = true;
            }
        }

        private void sprayer6_Click(object sender, EventArgs e)
        {
            if (sprayerStatus6)
            {
                sprayerRelay1.changeSprayerStatus(2, false);
                sprayer6.Text = "Sprayer 1: OFF";
                sprayerStatus6 = false;
            }
            else
            {
                sprayerRelay1.changeSprayerStatus(2, true);
                sprayer6.Text = "Sprayer 1: ON";
                sprayerStatus6 = true;
            }
        }

        private void sprayer7_Click(object sender, EventArgs e)
        {
            if (sprayerStatus7)
            {
                sprayerRelay1.changeSprayerStatus(3, false);
                sprayer7.Text = "Sprayer 1: OFF";
                sprayerStatus7 = false;
            }
            else
            {
                sprayerRelay1.changeSprayerStatus(3, true);
                sprayer7.Text = "Sprayer 1: ON";
                sprayerStatus7 = true;
            }
        }

        private void sprayer8_Click(object sender, EventArgs e)
        {
            if (sprayerStatus8)
            {
                sprayerRelay1.changeSprayerStatus(4, false);
                sprayer8.Text = "Sprayer 1: OFF";
                sprayerStatus8 = false;
            }
            else
            {
                sprayerRelay1.changeSprayerStatus(4, true);
                sprayer8.Text = "Sprayer 1: ON";
                sprayerStatus8 = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
