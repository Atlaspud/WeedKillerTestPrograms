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
        Image<Bgr, Byte> originalImage;
        string imageFolder;
        int mainFolderImagesTotal;
        int lantanaPatchesTotal;
        int nonLantanaPatchesTotal;
        int patchSize = 75;
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string file = ofd.FileName;
                Image<Bgr, byte> input = new Image<Bgr, byte>(file);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Restart();
                Image<Bgr, byte> output = ImageProcessor.shadowHighlight(input);
                textBox.AppendText("Processing time = " + stopwatch.ElapsedMilliseconds + " ms");
                originalPictureBox.Image = input.Bitmap;
                thresholdPictureBox.Image = output.Bitmap;
            }
            /*
            textBox.Text = "";

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

                runBtn.Enabled = true;
            }
             * */
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> patchImage;
            nonLantanaHistograms = new List<Dictionary<String, double[]>>();
            lantanaHistograms = new List<Dictionary<String, double[]>>();
            fileCount = 0;
            patchCount = 0;
            lantanaCount = 0;
            nonLantanaCount = 0;
            textBox.Text = "Start";
            noLeavesFound = "";

            foreach (string file in files)
            {
                fileCount++;
                fileCountLabel.Text = fileCount + "";
                fileNameLabel.Text = file;
                originalImage = new Image<Bgr, byte>(file);
                thresholdPictureBox.Image = ImageProcessor.thresholdImage(originalImage).Bitmap;
                Image<Gray, Byte> binaryMask = ImageProcessor.thresholdImage(originalImage);
                binaryMask = ImageProcessor.morphology(binaryMask);
                maskPictureBox.Image = binaryMask.Bitmap;
                originalPictureBox.Image = originalImage.Bitmap;
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
                        Image<Bgr, Byte> originalDisplayImage = originalImage.Clone();
                        Image<Bgr, Byte> maskDisplayImage = binaryMask.Convert<Bgr, Byte>();
                        patchImage = originalImage.Clone();
                        originalDisplayImage.Draw(roi, new Bgr(Color.Red), 2);
                        originalPictureBox.Image = originalDisplayImage.ToBitmap();

                        maskDisplayImage.Draw(roi, new Bgr(Color.Red), 2);
                        maskPictureBox.Image = maskDisplayImage.ToBitmap();

                        patchImage.ROI = roi;
                        binaryMask.ROI = roi;
                        patchImage = patchImage.And(patchImage, binaryMask);
                        patchPictureBox.Image = patchImage.Convert<Gray,byte>().ToBitmap();

                        DialogResult result = MessageBox.Show("Is this Lantana?", "Checker", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        Dictionary<String, double[]> histogram = ImageProcessor.calculateHoG(ImageProcessor.extractROI(originalImage.Convert<Gray,byte>(),roi), 1);
                        binaryMask.ROI = new Rectangle(0, 0, originalImage.Width, originalImage.Height);
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
            textBox.Text += "Finished training. Saving histograms...";
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
            textBox.Text += "Finished saving histograms.";
            File.WriteAllText(imageFolder + "\\noLeavesFound.txt", noLeavesFound);
        }

        private void patchSizeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            patchSize = int.Parse((sender as ComboBox).Text);
        }
    }
}
