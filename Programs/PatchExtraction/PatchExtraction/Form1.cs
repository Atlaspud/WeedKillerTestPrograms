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
        int PATCH_SIZE = 96;
        Image<Bgr, Byte> workingImage;
        string imageFolder;
        int mainFolderImagesTotal;
        int lantanaPatchesTotal;
        int nonLantanaPatchesTotal;
        List<float[]> lantanaDescriptors;
        List<float[]> nonLantanaDescriptors;
        string[] files;
        int fileCount;
        int patchCount;
        int lantanaCount;
        int nonLantanaCount;
        string noLeavesFound;
        string[] classificationMemory;

        public Form1()
        {
            InitializeComponent();
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
                    Directory.CreateDirectory(imageFolder + "\\LantanaPatches");
                }
                else
                {
                    DeleteDirectory(imageFolder + "\\LantanaPatches");
                    Directory.CreateDirectory(imageFolder + "\\LantanaPatches");
                }
                if (!Directory.Exists(imageFolder + "\\NonLantanaPatches"))
                {
                    Directory.CreateDirectory(imageFolder + "\\NonLantanaPatches");
                }
                else
                {
                    DeleteDirectory(imageFolder + "\\NonLantanaPatches");
                    Directory.CreateDirectory(imageFolder + "\\NonLantanaPatches");
                }
                if (!Directory.Exists(imageFolder + "\\NoLeavesFound"))
                {
                    Directory.CreateDirectory(imageFolder + "\\NoLeavesFound");
                }
                else
                {
                    DeleteDirectory(imageFolder + "\\NoLeavesFound");
                    Directory.CreateDirectory(imageFolder + "\\NoLeavesFound");
                }

                // Find the total number of frames
                files = Directory.GetFiles(imageFolder, "*.tif", SearchOption.TopDirectoryOnly);
                mainFolderImagesTotal = files.Length;

                if (File.Exists(imageFolder + "\\classificationMemory.csv"))
                {
                    classificationMemory = File.ReadAllText(imageFolder + "\\classificationMemory.csv").Split(',');
                }

                runBtn.Enabled = true;
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> patchImage;
            lantanaDescriptors = new List<float[]>();
            nonLantanaDescriptors = new List<float[]>();
            fileCount = 0;
            patchCount = 0;
            lantanaCount = 0;
            nonLantanaCount = 0;
            textBox.AppendText("Started." + Environment.NewLine);
            noLeavesFound = "";
            int counter = 0;

            foreach (string file in files)
            {
                fileCount++;
                fileCountLabel.Text = fileCount + "";
                fileNameLabel.Text = file;
                Image<Bgr, byte> originalImage = new Image<Bgr, byte>(file);
                if (shadowHighlightCheckBox.Checked)
                {
                    workingImage = ImageProcessor.shadowHighlight(file);
                }
                else workingImage = originalImage;
                //originalPictureBox.Image = (ImageProcessor.thresholdImage(originalImage)).Bitmap;
                Image<Gray, Byte> binaryMask = ImageProcessor.thresholdImage(workingImage);
                binaryMask = ImageProcessor.morphology(binaryMask);
                List<int[]> windowLocationArray = ImageProcessor.findWindows(binaryMask, PATCH_SIZE);
                if (windowLocationArray.Count == 0)
                {
                    noLeavesFound += (file + Environment.NewLine);
                    File.Copy(file, file.Replace(imageFolder, imageFolder + "\\NoLeavesFound\\"));
                    binaryMask.Save(file.Replace(imageFolder, imageFolder + "\\NoLeavesFound\\").Replace(".tif", "mask.tif"));
                    ImageProcessor.thresholdImage(originalImage).Save(file.Replace(imageFolder, imageFolder + "\\NoLeavesFound\\").Replace(".tif", "threshold.tif"));
                }
                List<List<int[]>> connectedComponents = ImageProcessor.LabelConnectedComponents(windowLocationArray);
                for (int i = 0; i < connectedComponents.Count; i++)
                {
                    List<int[]> cluster = connectedComponents[i];
                    for (int j = 0; j < cluster.Count; j++)
                    {
                        int[] location = cluster[j];
                        patchCount++;
                        windowCountLabel.Text = patchCount + "";
                        Rectangle roi = new Rectangle(location[0], location[1], PATCH_SIZE, PATCH_SIZE);
                        Image<Bgr, Byte> workingDisplayImage = workingImage.Clone();
                        Image<Bgr, Byte> maskDisplayImage = binaryMask.Convert<Bgr, Byte>();
                        workingDisplayImage.Draw(roi, new Bgr(Color.Red), 2);
                        //workingPictureBox.Image = workingDisplayImage.ToBitmap();

                        maskDisplayImage.Draw(roi, new Bgr(Color.Red), 2);
                        //maskPictureBox.Image = maskDisplayImage.ToBitmap();

                        patchImage = ImageProcessor.extractROI(workingImage, roi);
                        Image<Gray, byte> patchMask = ImageProcessor.extractROI(binaryMask, roi);
                        //patchImage = patchImage.And(patchImage, patchMask);
                        //patchPictureBox.Image = patchImage.ToBitmap();
                        //DialogResult result = MessageBox.Show("Is this Lantana?", "Checker", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        //switch(result)
                        switch(classificationMemory[counter])
                        {
                            case "lantana"://DialogResult.Yes:
                                patchImage.Save(imageFolder + "\\LantanaPatches\\" + lantanaPatchesTotal + ".tif");
                                patchMask.Save(imageFolder + "\\LantanaPatches\\mask" + lantanaPatchesTotal + ".tif");
                                //File.WriteAllText(imageFolder + "\\LantanaPatches\\" + lantanaPatchesTotal + ".csv", data);
                                //lantanaDescriptors.Add(descriptor);
                                lantanaPatchesTotal++;
                                lantanaCount++;
                                totalLantanaLabel.Text = lantanaCount + "";
                                break;

                            case "nonlantana"://DialogResult.No:
                                patchImage.Save(imageFolder + "\\NonLantanaPatches\\" + nonLantanaPatchesTotal + ".tif");
                                patchMask.Save(imageFolder + "\\NonLantanaPatches\\mask" + nonLantanaPatchesTotal + ".tif");
                                //File.WriteAllText(imageFolder + "\\NonLantanaPatches\\" + nonLantanaPatchesTotal + ".csv", data);
                                //nonLantanaDescriptors.Add(descriptor);
                                nonLantanaPatchesTotal++;
                                nonLantanaCount++;
                                totalNonLantanaLabel.Text = nonLantanaCount + "";
                                break;
                        }
                        counter++;
                    }
                }
            }
            textBox.AppendText("Finished." + Environment.NewLine);
            File.WriteAllText(imageFolder + "\\NoLeavesFound.txt", noLeavesFound);
            //File.WriteAllText(imageFolder + "\\checkMemory.csv", checkMemory.Substring(0,checkMemory.Length-2));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ImageProcessor.cleanUpOnClose();
        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }
    }
}
