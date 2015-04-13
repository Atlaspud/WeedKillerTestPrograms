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
        int PATCH_SIZE = 100;
        List<Dictionary<String, double[]>> lantanaHistograms;
        List<Dictionary<String, double[]>> nonLantanaHistograms;
        string[] files;

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

                if (!Directory.Exists(imageFolder + "\\LantanaPatches"))
                {
                    Directory.CreateDirectory(imageFolder + "\\LantanaPatches");
                }
                if (!Directory.Exists(imageFolder + "\\NonLantanaPatches"))
                {
                    Directory.CreateDirectory(imageFolder + "\\NonLantanaPatches");
                }
                files = Directory.GetFiles(imageFolder + "\\LantanaPatches", "*.tif", SearchOption.AllDirectories);
                lantanaPatchesTotal = files.Length + 1;

                files = Directory.GetFiles(imageFolder + "\\NonLantanaPatches", "*.tif", SearchOption.AllDirectories);
                nonLantanaPatchesTotal = files.Length + 1;

                // Find the total number of frames
                files = Directory.GetFiles(imageFolder, "*.tif", SearchOption.TopDirectoryOnly);
                mainFolderImagesTotal = files.Length;

                txtLog.Text = "Successfully Opened" + Environment.NewLine;
                txtLog.Text += "Total Images in Folder: " + mainFolderImagesTotal + Environment.NewLine;

                runBtn.Enabled = true;
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
            Image<Bgr, Byte> patchImage;
            nonLantanaHistograms = new List<Dictionary<String, double[]>>();
            lantanaHistograms = new List<Dictionary<String, double[]>>();

            foreach (string file in files)
            {
                string imagePath = file;
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
                        Rectangle roi = new Rectangle(location[0], location[1], PATCH_SIZE, PATCH_SIZE);
                        Image<Bgr, Byte> TempDisplayImage = originalImage.Clone();
                        patchImage = originalImage.Clone();
                        Rectangle rect = new Rectangle(location[0], location[1], PATCH_SIZE, PATCH_SIZE);
                        TempDisplayImage.Draw(rect, new Bgr(Color.Red), 2);
                        patchImage.ROI = roi;
                        picboxOriginal.Image = TempDisplayImage.ToBitmap();
                        picboxPatch.Image = patchImage.ToBitmap();
                        DialogResult result = MessageBox.Show("Is this Lantana?", "Checker", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        Dictionary<String, double[]> histogram = ImageProcessor.calculateHoG(patchImage.Convert<Gray, Byte>(), 1);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                txtLog.Text += "Yes" + Environment.NewLine;
                                patchImage.Save(imageFolder + "\\LantanaPatches\\" + lantanaPatchesTotal + ".tif");
                                lantanaHistograms.Add(histogram);
                                //Save single histogram
                                String data = "Orientation,Intensity";
                                for (int i = 0; i < 360; i++)
                                {
                                    data += "\n" + histogram["orientation"][i] + "," + histogram["intensity"][i];
                                }
                                System.IO.File.WriteAllText(imageFolder + "\\LantanaPatches\\" + lantanaPatchesTotal + ".csv", data);
                                lantanaPatchesTotal++;
                                break;
                            
                            case DialogResult.No:
                                txtLog.Text += "No" + Environment.NewLine;
                                patchImage.Save(imageFolder + "\\NonLantanaPatches\\" + nonLantanaPatchesTotal + ".tif");
                                //Save single histogram
                                data = "Orientation,Intensity";
                                for (int i = 0; i < 360; i++)
                                {
                                    data += "\n" + histogram["orientation"][i] + "," + histogram["intensity"][i];
                                }
                                System.IO.File.WriteAllText(imageFolder + "\\NonLantanaPatches\\" + nonLantanaPatchesTotal + ".csv", data);
                                nonLantanaHistograms.Add(histogram);
                                nonLantanaPatchesTotal++;
                                break;
                            
                            case DialogResult.Cancel:
                                txtLog.Text += "Cancel" + Environment.NewLine;
                                break;
                        }
                    }
                }
            }
            if (lantanaHistograms.Count > 0)
            {
                //Save lantana histograms
                String data = "Orientation";
                for (int i = 0; i < lantanaHistograms.Count; i++)
                {
                    data += ",Patch " + (i + 1);
                }
                for (int i = 0; i < 360; i++)
                {
                    data += "\n" + lantanaHistograms[0]["orientation"][i];
                    for (int j = 0; j < lantanaHistograms.Count; j++)
                    {
                        data += "," + lantanaHistograms[j]["intensity"][i];
                    }
                }
                System.IO.File.WriteAllText(imageFolder + "\\lantanaHistograms.csv", data);
            }
            if (nonLantanaHistograms.Count > 0)
            {
                //Save non lantana histograms
                String data = "Orientation";
                for (int i = 0; i < nonLantanaHistograms.Count; i++)
                {
                    data += ",Patch " + (i + 1);
                }
                for (int i = 0; i < 360; i++)
                {
                    data += "\n" + nonLantanaHistograms[0]["orientation"][i];
                    for (int j = 0; j < nonLantanaHistograms.Count; j++)
                    {
                        data += "," + nonLantanaHistograms[j]["intensity"][i];
                    }
                }
                System.IO.File.WriteAllText(imageFolder + "\\nonLantanaHistograms.csv", data);
            }
        }
    }
}
