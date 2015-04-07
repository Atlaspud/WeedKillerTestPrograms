using Emgu.CV;
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

                btnIdentify.Enabled = true;
                thresholdTestBtn.Enabled = true;
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
            //Image<Gray, Byte> binaryMask = ImageProcessor.thresholdImageHSV(originalImage, 89, 35,
            //    246, 87, 246, 95);
            txtLog.Text += String.Format("Threshold Completed in: {0}ms{1}", stopwatchIndividual.ElapsedMilliseconds, Environment.NewLine);
            stopwatchIndividual.Restart();

            // Clean Threshold Image with Morphology
            //binaryMask = ImageProcessor.morphology(binaryMask);
            binaryMask = ImageProcessor.morphology(binaryMask, hSBMorph.Value);
            txtLog.Text += String.Format("Morphology Completed in: {0}ms{1}", stopwatchIndividual.ElapsedMilliseconds, Environment.NewLine);
            stopwatchIndividual.Restart();

            // Find how many windows can fit in image
            List<int[]> windowLocationArray = ImageProcessor.findWindows(binaryMask);
            txtLog.Text += String.Format("Found windows in: {0}ms{1}", stopwatchIndividual.ElapsedMilliseconds, Environment.NewLine);

            // Connected Components
            List<List<int[]>> connectedComponents = ImageProcessor.LabelConnectedComponents(windowLocationArray);
            txtLog.Text += String.Format("Found Connected components in: {0}ms{1}", stopwatchIndividual.ElapsedMilliseconds, Environment.NewLine);

            // Display Image
            int finalTime = (int) stopwatchTotal.ElapsedMilliseconds;
            txtLog.Text += String.Format("Total Process Completed in: {0}ms{1}", finalTime, Environment.NewLine);
            txtLog.Text += String.Format("Total Process estimate for 8 images Completed in: {0}ms{1}", finalTime * 8, Environment.NewLine);
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
                    Point point = new Point(location[0] + 45, location[1] + 45);
                    binaryMaskFinal.Draw("" + count, ref f, point, new Bgr(Color.Blue));
                }
                count++;
            }
            txtLog.Text += String.Format("Total Clusters Found at: {0}{1}", connectedComponents.Count(), Environment.NewLine);
            picboxOutputImage.Image = binaryMaskFinal.ToBitmap();

            if (connectedComponents.Count() > 0)
            {
                for (int i = 0; i < connectedComponents.Count(); i++)
                {

                }
            }
        }

        private void tmrThreshold_Tick(object sender, EventArgs e)
        {
            Image<Gray, Byte> binaryMask = ImageProcessor.thresholdImageHSV(originalImage, hSBHueH.Value, hSBHueL.Value,
                hSBSatH.Value, hSBSatL.Value, hSBValH.Value, hSBValL.Value);
            binaryMask = ImageProcessor.morphology(binaryMask, hSBMorph.Value);
            picboxOutputImage.Image = binaryMask.ToBitmap();
        }

        private void thresholdTestBtn_Click(object sender, EventArgs e)
        {
            if (thresholdTestBtn.Text == "Threshold")
            {
                btnIdentify.Enabled = false;
                btnBrowse.Enabled = false;
                thresholdTestBtn.Text = "Stop";
                tmrThreshold.Start();
            }
            else
            {
                btnIdentify.Enabled = true;
                btnBrowse.Enabled = true;
                thresholdTestBtn.Text = "Threshold";
                tmrThreshold.Stop();
                txtLog.Text = "Hue H: " + hSBHueH.Value + " Hue L: " + hSBHueL.Value + Environment.NewLine;
                txtLog.Text += "Sat H: " + hSBSatH.Value + " Sat L: " + hSBSatL.Value + Environment.NewLine;
                txtLog.Text += "Val H: " + hSBValH.Value + " Val L: " + hSBValL.Value + Environment.NewLine;
                txtLog.Text += "Morphological Size: " + hSBMorph.Value;
            }
        }
    }
}
