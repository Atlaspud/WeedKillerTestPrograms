using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatchExtraction
{
    public partial class Form1 : Form
    {
        Image<Bgr, Byte> originalImage;
        string imageFolder;
        int mainFolderImagesTotal;
        int lantanaPatchesTotal;
        int nonLantanaPatchesTotal;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Browse for new folder
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                // Save the folder path
                imageFolder = openFolder.SelectedPath;

                // Find the total number of frames
                string[] files = Directory.GetFiles(imageFolder, "*.tif", SearchOption.TopDirectoryOnly);
                mainFolderImagesTotal = files.Length;

                files = Directory.GetFiles(imageFolder + "\\LantanaPatches", "*.tif", SearchOption.AllDirectories);
                lantanaPatchesTotal = files.Length + 1;

                files = Directory.GetFiles(imageFolder + "\\NonLantanaPatches", "*.tif", SearchOption.AllDirectories);
                nonLantanaPatchesTotal = files.Length + 1;

                txtLog.Text = "Successfully Opened" + Environment.NewLine;
                txtLog.Text += "Total Images in Folder: " + mainFolderImagesTotal + Environment.NewLine;

                runBtn.Enabled = true;
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
            Image<Bgr, Byte> patchImage;

            for (int i = 0; i < mainFolderImagesTotal; i++)
            {
                string imagePath = imageFolder + "\\" + i + ".tif";
                originalImage = new Image<Bgr, Byte>(imagePath);

                Image<Gray, Byte> binaryMask = ImageProcessor.thresholdImage(originalImage);
                binaryMask = ImageProcessor.morphology(binaryMask);
                List<int[]> windowLocationArray = ImageProcessor.findWindows(binaryMask);
                List<List<int[]>> connectedComponents = ImageProcessor.LabelConnectedComponents(windowLocationArray);

                //Create the font
                MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);
                foreach (List<int[]> cluster in connectedComponents)
                {
                    foreach (int[] location in cluster)
                    {
                        Rectangle roi = new Rectangle(location[0], location[1], 75, 75);
                        Image<Bgr, Byte> TempDisplayImage = originalImage.Clone();
                        patchImage = originalImage.Clone();
                        Rectangle rect = new Rectangle(location[0], location[1], 75, 75);
                        TempDisplayImage.Draw(rect, new Bgr(Color.Red), 2);
                        patchImage.ROI = roi;
                        picboxOriginal.Image = TempDisplayImage.ToBitmap();
                        picboxPatch.Image = patchImage.ToBitmap();
                        DialogResult result = MessageBox.Show("Is this Lantana?", "Checker", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            txtLog.Text += "Yes" + Environment.NewLine;
                            patchImage.Save(imageFolder + "\\LantanaPatches\\" + lantanaPatchesTotal + ".tif");
                            lantanaPatchesTotal++;
                        }
                        else
                        {
                            txtLog.Text += "No" + Environment.NewLine;
                            patchImage.Save(imageFolder + "\\NonLantanaPatches\\" + nonLantanaPatchesTotal + ".tif");
                            nonLantanaPatchesTotal++;
                        }
                    }
                }
            }

        }
    }
}
