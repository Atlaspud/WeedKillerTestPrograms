using Emgu.CV;
using Emgu.CV.Structure;
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

namespace PatchExtraction
{
    public partial class Form1 : Form
    {
        Image<Bgr, Byte> workingImage;
        string imageFolder;
        int mainFolderImagesTotal;
        int lantanaPatchesTotal;
        int nonLantanaPatchesTotal;
        int patchSize = 100;
        List<Dictionary<String, double[]>> lantanaHistograms;
        List<Dictionary<String, double[]>> nonLantanaHistograms;
        string[] files;
        int fileCount;
        int patchCount;
        int lantanaCount;
        int nonLantanaCount;
        string noLeavesFound;

        public Form1()
        {
            InitializeComponent();
        }

        private void initDirectories()
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            textBox.Text = "";

            // Browse for new folder
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                // Save the folder path
                imageFolder = openFolder.SelectedPath;

                if (!Directory.Exists(imageFolder + "\\LantanaPatches"))
                {
                    Directory.Delete(imageFolder + "\\LantanaPatches");
                    Directory.CreateDirectory(imageFolder + "\\LantanaPatches");
                }
                if (!Directory.Exists(imageFolder + "\\NonLantanaPatches"))
                {
                    Directory.Delete(imageFolder + "\\NonLantanaPatches");
                    Directory.CreateDirectory(imageFolder + "\\NonLantanaPatches");
                }

                // Find the total number of frames
                files = Directory.GetFiles(imageFolder, "*.tif", SearchOption.TopDirectoryOnly);
                mainFolderImagesTotal = files.Length;

                runBtn.Enabled = true;
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            Image<Gray, Byte> patchImage;
            nonLantanaHistograms = new List<Dictionary<String, double[]>>();
            lantanaHistograms = new List<Dictionary<String, double[]>>();
            fileCount = 0;
            patchCount = 0;
            lantanaCount = 0;
            nonLantanaCount = 0;
            textBox.AppendText("Start" + Environment.NewLine);
            noLeavesFound = "";

            foreach (string file in files)
            {
                fileCount++;
                fileCountLabel.Text = fileCount + "";
                fileNameLabel.Text = file;
                workingImage = ImageProcessor.shadowHighlight(file);
                Image<Bgr,byte> originalImage = new Image<Bgr, byte>(file);
                originalPictureBox.Image = ImageProcessor.morphology(ImageProcessor.thresholdImage(originalImage)).Bitmap;
                Image<Gray, Byte> binaryMask = ImageProcessor.thresholdImage(workingImage);
                binaryMask = ImageProcessor.morphology(binaryMask);
                maskPictureBox.Image = binaryMask.Bitmap;
                workingPictureBox.Image = workingImage.Bitmap;
                List<int[]> windowLocationArray = ImageProcessor.findWindows(binaryMask, patchSize);
                if (windowLocationArray.Count == 0)
                {
                    noLeavesFound += (file + Environment.NewLine);
                }
                List<List<int[]>> connectedComponents = ImageProcessor.LabelConnectedComponents(windowLocationArray);

                //Create the font
                MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_PLAIN, 1.0, 1.0);
                foreach (List<int[]> cluster in connectedComponents)
                {
                    foreach (int[] location in cluster)
                    {
                        patchCount++;
                        windowCountLabel.Text = patchCount + "";
                        Rectangle roi = new Rectangle(location[0], location[1], patchSize, patchSize);
                        Image<Bgr, Byte> workingDisplayImage = workingImage.Clone();
                        Image<Bgr, Byte> maskDisplayImage = binaryMask.Convert<Bgr, Byte>();
                        workingDisplayImage.Draw(roi, new Bgr(Color.Red), 2);
                        workingPictureBox.Image = workingDisplayImage.ToBitmap();

                        maskDisplayImage.Draw(roi, new Bgr(Color.Red), 2);
                        maskPictureBox.Image = maskDisplayImage.ToBitmap();

                        patchImage = ImageProcessor.extractROI(workingImage.Convert<Gray, byte>(), roi);
                        Image<Gray, byte> patchMask = ImageProcessor.extractROI(binaryMask, roi);
                        patchImage = patchImage.And(patchImage, patchMask);
                        patchPictureBox.Image = patchImage.Convert<Gray,byte>().ToBitmap();

                        DialogResult result = MessageBox.Show("Is this Lantana?", "Checker", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        Dictionary<String, double[]> histogram = ImageProcessor.calculateHoG(patchImage, 1);
                        switch (result)
                        {
                            case DialogResult.Yes:
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
                                lantanaCount++;
                                totalLantanaLabel.Text = lantanaCount + "";
                                break;
                            
                            case DialogResult.No:
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
                                nonLantanaCount++;
                                totalNonLantanaLabel.Text = nonLantanaCount + "";
                                break;
                            
                            case DialogResult.Cancel:
                                totalUnusedLabel.Text = (patchCount - lantanaCount - nonLantanaCount) + "";
                                break;
                        }
                    }
                }
            }
            textBox.AppendText("Finished training. Saving histograms..." + Environment.NewLine);
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
                File.WriteAllText(imageFolder + "\\lantanaHistograms.csv", data);
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
            textBox.AppendText("Finished saving histograms." + Environment.NewLine);
            File.WriteAllText(imageFolder + "\\noLeavesFound.txt", noLeavesFound);
        }

        private void patchSizeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            patchSize = int.Parse((sender as ComboBox).Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ImageProcessor.cleanUpOnClose();
        }
    }
}
