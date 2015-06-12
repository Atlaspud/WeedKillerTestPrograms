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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatchExtraction
{
    public partial class Form1 : Form
    {
        //Constants
        int PATCH_SIZE = 96;

        //Image variables
        Image<Bgr, byte> originalImage;
        Image<Gray, byte> thresholdImage;
        Image<Gray, byte> maskImage;
        Image<Bgr, byte> displayImage;
        Image<Bgr, byte> patchImage;
        Image<Gray, byte> patchMask;

        //Browsing variables
        string[] files;
        string imageFolder;

        //Text file content
        string classificationMemory;
        string imageInformation;
        string nonLantanaPatchInformation;
        string lantanaPatchInformation;

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

                //Refresh output directories
                refreshDirectory(imageFolder + "\\LantanaPatches");
                refreshDirectory(imageFolder + "\\NonLantanaPatches");
                refreshDirectory(imageFolder + "\\ImagesWithoutPatches");

                // Find the total number of frames
                files = Directory.GetFiles(imageFolder, "*.tif", SearchOption.TopDirectoryOnly);

                //Run with classification memory
                //if (File.Exists(imageFolder + "\\classificationMemory.csv"))
                //{
                    //classificationMemory = File.ReadAllText(imageFolder + "\\classificationMemory.csv").Split(',');
                //}

                runBtn.Enabled = true;
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            //Reset counters
            int fileCount = 0;
            int totalPatchCount = 0;
            int lantanaPatchCount = 0;
            int nonLantanaPatchCount = 0;

            //Start message textbox
            textBox.AppendText("Started." + Environment.NewLine);

            //Reset text files
            imageInformation = "Image Number,File Name,Number of Patches,Image Contains Lantana\n";
            lantanaPatchInformation = "Lantana Patch Number,Image Number,Image Contains Lantana\n";
            nonLantanaPatchInformation = "Non-Lantana Patch Number,Image Number,Image Contains Lantana\n";

            foreach (string file in files)
            {
                //Update labels
                fileCount++;
                fileCountLabel.Text = fileCount + "";
                fileNameLabel.Text = file;

                //Load image from photoshop with shadow/highlight technique
                originalImage = ImageProcessor.shadowHighlight(file);
                //originalImage = new Image<Bgr,byte>(file);

                //Compute binary mask
                thresholdImage = ImageProcessor.thresholdImage(originalImage);
                maskImage = ImageProcessor.morphology(thresholdImage);

                //Find patches
                List<int[]> windowLocationArray = ImageProcessor.findWindows(maskImage, PATCH_SIZE);
                if (windowLocationArray.Count == 0)
                {
                    //If no windows found, save image to folder
                    File.Copy(file, file.Replace(imageFolder, imageFolder + "\\ImagesWithoutPatches\\"));
                    maskImage.Save(file.Replace(imageFolder, imageFolder + "\\ImagesWithoutPatches\\").Replace(".tif", "mask.tif"));
                    ImageProcessor.thresholdImage(originalImage).Save(file.Replace(imageFolder, imageFolder + "\\ImagesWithoutPatches\\").Replace(".tif", "threshold.tif"));
                }

                //Image classifier
                originalPictureBox.Image = originalImage.Bitmap;
                maskPictureBox.Image = new Bitmap(1280, 1024);
                thresholdPictureBox.Image = new Bitmap(1280, 1024);
                patchPictureBox.Image = new Bitmap(96, 96);
                DialogResult imageResult = MessageBox.Show("Is there lantana present in this image?", "Image Classifier", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (imageResult == DialogResult.Yes) imageInformation += string.Format("{0},{1},{2},Yes\n", fileCount, file, windowLocationArray.Count);
                else imageInformation += string.Format("{0},{1},{2},No\n", fileCount, file, windowLocationArray.Count);

                //For each patch
                for (int i = 0; i < windowLocationArray.Count; i++)
                {
                    //Update labels
                    totalPatchCount++;
                    totalPatchCountLabel.Text = totalPatchCount + "";

                    //Get location/roi of patch
                    int[] location = windowLocationArray[i];
                    Rectangle roi = new Rectangle(location[0], location[1], PATCH_SIZE, PATCH_SIZE);

                    //Extract patch image and mask
                    patchImage = ImageProcessor.extractROI(originalImage, roi);
                    patchMask = ImageProcessor.extractROI(maskImage, roi);

                    //Display original and mask image with patch border
                    displayImage = originalImage.Clone();
                    displayImage.Draw(roi, new Bgr(Color.Red), 2);
                    originalPictureBox.Image = displayImage.ToBitmap();

                    //Display mask image with patch border
                    displayImage = maskImage.Convert<Bgr, byte>();
                    displayImage.Draw(roi, new Bgr(Color.Red), 2);
                    maskPictureBox.Image = displayImage.ToBitmap();

                    //Display threshold image with patch border
                    displayImage = thresholdImage.Convert<Bgr, byte>();
                    displayImage.Draw(roi, new Bgr(Color.Red), 2);
                    thresholdPictureBox.Image = displayImage.ToBitmap();

                    //Display images
                    patchPictureBox.Image = patchImage.ToBitmap();

                    //Patch classification
                    DialogResult patchResult = MessageBox.Show("Is this a lantana patch?", "Patch Classification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (patchResult)
                    {
                        //Lantana
                        case DialogResult.Yes:

                            //Save patch image and mask
                            patchImage.Save(imageFolder + "\\LantanaPatches\\" + lantanaPatchCount + ".tif");
                            patchMask.Save(imageFolder + "\\LantanaPatches\\mask" + lantanaPatchCount + ".tif");

                            //Save patch classification information
                            lantanaPatchInformation += string.Format("{0},{1},{2}\n", lantanaPatchCount, fileCount, imageResult == DialogResult.Yes ? "Yes" : "No");
                            classificationMemory += string.Format("{0},", "lantana");

                            //Update counter
                            lantanaPatchCount++;
                            totalLantanaLabel.Text = lantanaPatchCount + "";
                            break;

                        //Non-Lantana
                        case DialogResult.No:

                            //Save patch image and mask
                            patchImage.Save(imageFolder + "\\NonLantanaPatches\\" + nonLantanaPatchCount + ".tif");
                            patchMask.Save(imageFolder + "\\NonLantanaPatches\\mask" + nonLantanaPatchCount + ".tif");

                            //Save patch classification information
                            nonLantanaPatchInformation += string.Format("{0},{1},{2}\n", nonLantanaPatchCount, fileCount, imageResult == DialogResult.Yes ? "Yes" : "No");
                            classificationMemory += string.Format("{0},", "nonlantana");

                            //Update counter
                            nonLantanaPatchCount++;
                            totalNonLantanaLabel.Text = nonLantanaPatchCount + "";
                            break;
                    }
                }
                //Update progress bar
                progressBar.Value = (int)(fileCount / files.Length * 100);
            }
            //Finish message
            textBox.AppendText("Finished." + Environment.NewLine);

            //Save text files
            File.WriteAllText(imageFolder + "\\classificationMemory.csv", classificationMemory.Substring(0, classificationMemory.Length - 1));
            File.WriteAllText(imageFolder + "\\ImageInformation.csv", imageInformation);
            File.WriteAllText(imageFolder + "\\LantanaPatchInformation.csv", lantanaPatchInformation);
            File.WriteAllText(imageFolder + "\\NonLantanaPatchInformation.csv", nonLantanaPatchInformation);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ImageProcessor.cleanUpOnClose();
        }

        public void deleteDirectory(string targetDirectory)
        {
            string[] files = Directory.GetFiles(targetDirectory);
            string[] directories = Directory.GetDirectories(targetDirectory);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string directory in directories)
            {
                deleteDirectory(directory);
            }

            Directory.Delete(targetDirectory, false);
        }

        public void refreshDirectory(string targetDirectory)
        {
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            else
            {
                deleteDirectory(targetDirectory);
                Directory.CreateDirectory(targetDirectory);
            }
        }
    }
}
