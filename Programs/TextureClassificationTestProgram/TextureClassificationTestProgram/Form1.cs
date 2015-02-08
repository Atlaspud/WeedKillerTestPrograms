﻿using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextureClassificationTestProgram
{
    public partial class Form1 : Form
    {
        Image<Bgr, Byte> originalImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            btnIdentify.Enabled = true;

            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog.Filter = "tif Files (.tif)|*.tif";
            openFileDialog.FilterIndex = 1;

            // Process input if the user clicked OK.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String imagePath = openFileDialog.InitialDirectory + openFileDialog.FileName;
                txtLog.Text = "Successfully Opened";
                originalImage = new Image<Bgr, Byte>(imagePath);
                picboxOriginal.Image = originalImage.ToBitmap();
            }
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
            Stopwatch stopwatchIndividual = new Stopwatch();
            Stopwatch stopwatchTotal = new Stopwatch();
            stopwatchTotal.Start();
            stopwatchIndividual.Start();

            // Threshold Image
            Image<Gray, Byte> binaryMask = ImageProcessor.thresholdImage(originalImage);
            txtLog.Text += "Threshold Completed in: " + stopwatchIndividual.ElapsedMilliseconds + "ms" + Environment.NewLine;
            stopwatchIndividual.Restart();

            // Clean Threshold Image with Morphology
            binaryMask = ImageProcessor.morphology(binaryMask);
            txtLog.Text += "Morphology Completed in: " + stopwatchIndividual.ElapsedMilliseconds + "ms" + Environment.NewLine;
            stopwatchIndividual.Restart();

            // Texture Classification on Image

            // Test edge detection
            //binaryMask = binaryMask.Canny(new Gray(120.0), new Gray(180.0));
            //txtLog.Text += "Canny Completed in: " + stopwatchIndividual.ElapsedMilliseconds + "ms" + Environment.NewLine;

            // Connected Components
            //binaryMask = ImageProcessor.LabelConnectedComponents(binaryMask, 1);
            //txtLog.Text += "Connected Components Completed in: " + stopwatchIndividual.ElapsedMilliseconds + "ms" + Environment.NewLine;

            // Invert Image
            //binaryMask = ImageProcessor.invertImage(binaryMask);
            //txtLog.Text += "Inversion Completed in: " + stopwatchIndividual.ElapsedMilliseconds + "ms" + Environment.NewLine;

            // Find how many windows can fit in image
            List<int[]> windowLocationArray = ImageProcessor.findWindows(binaryMask);
            txtLog.Text += "Found windows in: " + stopwatchIndividual.ElapsedMilliseconds + "ms" + Environment.NewLine;

            // Connected Components
            List<List<int[]>> connectedComponents = ImageProcessor.LabelConnectedComponents(windowLocationArray);
            txtLog.Text += "Found Connected components in: " + stopwatchIndividual.ElapsedMilliseconds + "ms" + Environment.NewLine;

            // Display Image
            int finalTime = (int) stopwatchTotal.ElapsedMilliseconds;
            txtLog.Text += "Total Process Completed in: " + finalTime + "ms" + Environment.NewLine;
            txtLog.Text += "Total Process estimate for 8 images Completed in: " + finalTime * 8 + "ms" + Environment.NewLine;
            stopwatchIndividual.Stop();
            stopwatchTotal.Stop();
            Image<Bgr, Byte> binaryMaskFinal = binaryMask.Convert<Bgr, Byte>();
            foreach (int[] location in windowLocationArray)
            {
                Rectangle rect = new Rectangle(location[0], location[1], 75, 75);
                binaryMaskFinal.Draw(rect, new Bgr(Color.Red), 2);
            }

            //Create the font
            MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);
            int count = 1;
            foreach (List<int[]> cluster in connectedComponents)
            {
                foreach (int[] location in cluster)
                {
                    Point point = new Point(location[0] + 37, location[1] + 37);
                    binaryMaskFinal.Draw("" + count, ref f, point, new Bgr(Color.Blue));
                }
                count++;
            }
            txtLog.Text += "Total Clusters Found at: " + connectedComponents.Count() + Environment.NewLine;
            picboxOutputImage.Image = binaryMaskFinal.ToBitmap();
        }
    }
}