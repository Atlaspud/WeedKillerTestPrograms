﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace ShutterVerseIlluminanceDataLogger
{
    public partial class Form1 : Form
    {
        Camera cameraOne;
        public Form1()
        {
            cameraOne = new Camera(13421033);
            InitializeComponent();
        }

        private void addCloudShadeBtn_Click(object sender, EventArgs e)
        {
            cameraViewPicBox.Image = cameraOne.getImage().ToBitmap();
        }
    }
}