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
        Image<Bgr, byte> colourCorrectedImage;
        Image<Gray, byte> thresholdImage;
        Image<Gray, byte> maskImage;
        Image<Bgr, byte> displayImage;
        Image<Bgr, byte> patchImage;
        Image<Gray, byte> patchMask;

        //Classification memory
        List<bool> imageClassificationMemory;
        List<bool> windowClassificationMemory;

        //Browsing variables
        string[] files;
        string imageFolder;

        //Text file content
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
                /*if (File.Exists(imageFolder + "\\imageClassificationMemory.csv"))
                {
                    string text = File.ReadAllText(imageFolder + "\\imageClassificationMemory.csv").Split(',');
                    imageClassificationMemory = new List<bool>();
                    foreach (string line in text)
                    {
                        if (line != "")
                        imageClassificationMemory.Add(bool.Parse(line));
                    }
                }
                if (File.Exists(imageFolder + "\\windowClassificationMemory.csv"))
                {
                    string text = File.ReadAllText(imageFolder + "\\windowClassificationMemory.csv").Split(',');
                    windowClassificationMemory = new List<bool>();
                    foreach (string line in text)
                    {
                        if (line != "")
                        windowClassificationMemory.Add(bool.Parse(line));
                    }
                }
                if (files.Count() != imageClassificationMemory.Count())
                {
                    textbox.AppendText("Image classification memory does not match target directory.");
                }
                */

                runBtn.Enabled = true;
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            //Reset counters
            int fileCount = 0;
            int totalPatchCount = 0;
            int totalLantanaPatchCount = 0;
            int totalNonLantanaPatchCount = 0;

            //Start message textbox
            textBox.AppendText("Started." + Environment.NewLine);

            //Reset text files
            imageInformation = "Image Number,File Name,Number of Patches,Number of Lantana Patches,Number of Non-Lantana Patches,Image Contains Lantana\n";
            lantanaPatchInformation = "Lantana Patch Number,Image Number,Image Contains Lantana\n";
            nonLantanaPatchInformation = "Non-Lantana Patch Number,Image Number,Image Contains Lantana\n";

            imageClassificationMemory = new List<bool>();
            windowClassificationMemory = new List<bool>();
            
            foreach (string file in files)
            {
                //Update labels
                fileCount++;
                fileCountLabel.Text = fileCount + "";
                fileNameLabel.Text = file;

                //Load image from photoshop with shadow/highlight technique
                originalImage = ImageProcessor.shadowHighlight(file);

                //Load image from file
                //originalImage = new Image<Bgr,byte>(file);

                //Perform colour correction
                //colourCorrectedImage = ImageProcessor.correctColour(originalImage);

                //Compute binary mask
                thresholdImage = ImageProcessor.thresholdImage(originalImage/*colourCorrectedImage*/);
                maskImage = ImageProcessor.morphology(thresholdImage);
                maskImage.Save(imageFolder + "\\mask.tiff");

                //Find patches
                List<int[]> windowLocationArray = ImageProcessor.findWindows(maskImage, PATCH_SIZE);
                if (windowLocationArray.Count == 0)
                {
                    //If no windows found, save image to folder so we can take a looksy
                    File.Copy(file, file.Replace(imageFolder, imageFolder + "\\ImagesWithoutPatches\\"));
                    maskImage.Save(file.Replace(imageFolder, imageFolder + "\\ImagesWithoutPatches\\").Replace(".tif", "mask.tif"));
                    thresholdImage.Save(file.Replace(imageFolder, imageFolder + "\\ImagesWithoutPatches\\").Replace(".tif", "threshold.tif"));
                }

                //Display original image
                originalPictureBox.Image = originalImage.Bitmap;
                maskPictureBox.Image = new Bitmap(1280, 1024);
                thresholdPictureBox.Image = new Bitmap(1280, 1024);
                patchPictureBox.Image = new Bitmap(96, 96);

                //Manual image classifier
                DialogResult imageResult = MessageBox.Show("Is there lantana present in this image?", "Image Classifier", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                imageClassificationMemory.Add(imageResult == DialogResult.Yes ? true : false);

                //Automatic image classifier
                //DialogResult imageResult = imageClassificationMemory[fileCount - 1] == true ? DialogResult.Yes : DialogResult.No;

                //For each patch
                int imageLantanaPatchCount = 0;
                int imageNonLantanaPatchCount = 0;
                for (int i = 0; i < windowLocationArray.Count(); i++)
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

                    //Display patch image
                    patchPictureBox.Image = patchImage.ToBitmap();

                    //Patch classification
                    bool isLantana = false;
                    if (imageResult == DialogResult.Yes)
                    {
                        //Manual window classification
                        DialogResult windowResult = MessageBox.Show("Is this a lantana patch?", "Patch Classification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        windowClassificationMemory.Add(windowResult == DialogResult.Yes ? true : false);

                        //Automatic window classification
                        //DialogResult patchResult = windowClassificationMemory[totalPatchCount] == true ? DialogResult.Yes : DialogResult.No;

                        if (windowResult == DialogResult.Yes)
                        {
                            isLantana = true;
                        }
                    }
                    if (isLantana)
                    {
                        //Save patch image and mask
                        patchImage.Save(imageFolder + "\\LantanaPatches\\" + totalLantanaPatchCount + ".tif");
                        patchMask.Save(imageFolder + "\\LantanaPatches\\mask" + totalLantanaPatchCount + ".tif");

                        //Save patch classification information
                        lantanaPatchInformation += string.Format("{0},{1},{2}\n", totalLantanaPatchCount, fileCount, imageResult == DialogResult.Yes ? "Yes" : "No");

                        //Update counter
                        totalLantanaPatchCount++;
                        totalLantanaLabel.Text = totalLantanaPatchCount + "";
                        imageLantanaPatchCount++;
                    }
                    else
                    {
                        //Save patch image and mask
                        patchImage.Save(imageFolder + "\\NonLantanaPatches\\" + totalNonLantanaPatchCount + ".tif");
                        patchMask.Save(imageFolder + "\\NonLantanaPatches\\mask" + totalNonLantanaPatchCount + ".tif");

                        //Save patch classification information
                        nonLantanaPatchInformation += string.Format("{0},{1},{2}\n", totalNonLantanaPatchCount, fileCount, imageResult == DialogResult.Yes ? "Yes" : "No");

                        //Update counter
                        totalNonLantanaPatchCount++;
                        totalNonLantanaLabel.Text = totalNonLantanaPatchCount + "";
                        imageNonLantanaPatchCount++;
                    }
                }
                //Save image information
                imageInformation += string.Format(
                    "{0},{1},{2},{3},{4},{5}\n",
                    fileCount,
                    file,
                    windowLocationArray.Count,
                    imageLantanaPatchCount,
                    imageNonLantanaPatchCount,
                    imageResult == DialogResult.Yes ? "Yes" : "No"
                    );

                //Update progress bar
                progressBar.Value = (int)(fileCount / files.Length * 100);
            }
            //Finish message
            textBox.AppendText("Finished." + Environment.NewLine);

            //Create classification text files
            string imageClassificationText = imageClassificationMemory[0] == true ? "true" : "false";
            for (int i = 1; i < imageClassificationMemory.Count(); i++)
            {
                imageClassificationText += imageClassificationMemory[i] == true ? ",true" : ",false";
            }
            string windowClassificationText = windowClassificationMemory[0] == true ? "true" : "false";
            for (int i = 1; i < windowClassificationMemory.Count(); i++)
            {
                windowClassificationText += windowClassificationMemory[i] == true ? ",true" : ",false";
            }

            //Save text files
            File.WriteAllText(imageFolder + "\\imageClassificationMemory.csv", imageClassificationText);
            File.WriteAllText(imageFolder + "\\windowClassificationMemory.csv", windowClassificationText);
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
