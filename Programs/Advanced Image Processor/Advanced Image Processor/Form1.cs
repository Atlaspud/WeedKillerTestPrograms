using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using AForge;
using AForge.Video;
using AForge.Imaging;
using AForge.Math.Geometry;

namespace Advanced_Image_Processor
{
    public partial class Form1 : Form
    {
        // Image acquisition variables
        const int ImageWidth = 2048;
        const int ImageHeight = 1536;
        Image<Bgr, Byte> originalImage;
        bool folderNotCamera = true;
        string imageFolder = "C:\\Users\\Weed-Killer\\Desktop\\New AutoCapture Image Sequences\\1";
        int frameTotal = 66;
        int frameCount = 1;
        public MJPEGStream stream = new MJPEGStream();
        string device = "1.1.1.2:10000";
        int frameRate = 5;
        double ImageRatio = 388 / 0.1; // pixel:meter
        double MaximumSpeed = 0.5; // meters per second
        Rectangle ROI;
        int totalSprayers = 4;

        // Image processing variables
        Gray BinaryThreshold = new Gray(25); // threshold for binary filter
        int OpeningSize = 20; // element size for morphological opening
        int ClosingSize = 0; // element size for morphological closing
        Gray CannyThreshold = new Gray(25); // gray threshold for canny texture detection
        int BLOBSize = 115; // element size for BLOB analysis
        long timeDummy; // timing dummy variable
        StringBuilder log; // log file
        long averageAcquisitionTime;
        long averageSegmentationTime;
        long averageFeatureExtractionTime;
        long averageBlobDetectionTime;
        long averageProcessingTime;

        public Form1()
        {
            InitializeComponent();
            logoPictureBox.Image = Bitmap.FromFile(Environment.CurrentDirectory + "\\jcu.png");
            ROI = new Rectangle(0, ((ImageHeight - (int)(MaximumSpeed / frameRate * ImageRatio)) / 2), ImageWidth, (int)(MaximumSpeed / frameRate * ImageRatio));
        }

        private void cameraButton_Click(object sender, EventArgs e)
        {
            // Set flag
            folderNotCamera = false;
            timer1.Enabled = false;
            statusTextBox.AppendText("Samsung SNB7000 ready.\n");
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            // Set flag
            folderNotCamera = true;

            // Browse for new folder
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                // Save the folder path
                imageFolder = openFolder.SelectedPath;

                // Find the total number of frames
                string[] files = Directory.GetFiles(imageFolder, "*.jpg", SearchOption.AllDirectories);
                frameTotal = files.Length;
                
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Open string builder for log
            log = new StringBuilder();
            
            // Reset textbox
            statusTextBox.Text = "";

            if (folderNotCamera == true)
            {
                // Start the counter
                frameCount = 1;
                timer1.Enabled = true;
                pauseButton.Enabled = true;
                statusTextBox.AppendText(frameTotal + " total frames identified in " + "\"" + imageFolder + "\".\n");
                averageAcquisitionTime = 0;
                averageSegmentationTime = 0;
                averageFeatureExtractionTime = 0;
                averageBlobDetectionTime = 0;
                averageProcessingTime = 0;
            }
            else if (folderNotCamera == false)
            {
                pauseButton.Enabled = false;
                frameCount = 0;
                averageAcquisitionTime = 0;
                averageSegmentationTime = 0;
                averageFeatureExtractionTime = 0;
                averageBlobDetectionTime = 0;
                averageProcessingTime = 0;

                // Start camera stream
                stream.Source = "http://" + device + "/cgi-bin/video.cgi?msubmenu=mjpg&profile=3&resolution=0&frate=" + frameRate + "&compression=1";
                stream.Login = "admin";
                stream.Password = "4321";
                Thread cameraThread = new Thread(newFrame);
                stream.Start();
                cameraThread.Start();
                
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            // Pause the timer
            timer1.Enabled = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Save logged information to text file
            System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\Log.txt", statusTextBox.Text);
            // Stop MJPEG stream if running
            if (stream.IsRunning)
            {
                stream.Stop();
            }
            // Close form
            this.Close();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stream.Stop();
            timer1.Enabled = false;
            if (folderNotCamera == false)
            {
                frameCount = 0;
                averageAcquisitionTime /= frameCount;
                statusTextBox.AppendText("Average acquisition time: " + averageAcquisitionTime + " ms\n\n");
                log.AppendLine("Average acquisition time: " + averageAcquisitionTime + " ms");
                averageSegmentationTime /= frameCount;
                statusTextBox.AppendText("Average segmentation time: " + averageSegmentationTime + " ms\n\n");
                log.AppendLine("Average segmentation time: " + averageSegmentationTime + " ms");
                averageFeatureExtractionTime /= frameCount;
                statusTextBox.AppendText("Average feature extraction time: " + averageFeatureExtractionTime + " ms\n\n");
                log.AppendLine("Average feature extraction time: " + averageFeatureExtractionTime + " ms");
                averageBlobDetectionTime /= frameCount;
                statusTextBox.AppendText("Average BLOB detection time: " + averageBlobDetectionTime + " ms\n\n");
                log.AppendLine("Average BLOB detection time: " + averageBlobDetectionTime + " ms");
                averageProcessingTime /= frameCount;
                statusTextBox.AppendText("Average processing time: " + averageProcessingTime + " ms\n\n");
                log.AppendLine("Average processing time: " + averageProcessingTime + " ms");
                log.AppendLine("");

                // Save and close text file
                File.WriteAllText(imageFolder + "\\Log.txt", log.ToString());
            }
            frameCount = 1;
        }

        void newFrame()
        {
            stream.NewFrame += stream_NewFrame;
        }

        void stream_NewFrame(object sender, AForge.Video.NewFrameEventArgs e)
        {
            pictureBox1.Image = (Bitmap)(e.Frame).Clone();
            // Display the frame count
            frameCount++;
            statusTextBox.AppendText("Frame " + frameCount + "\n");

            // Start timing process
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Acquire the image
            Image<Bgr, Byte> originalImage = new Image<Bgr, Byte>(e.Frame);
            originalImage.ROI = ROI;

            // Display the Image
            if (displayCheckBox.Checked == true)
            {
                pictureBox1.Image = originalImage.ToBitmap();
            }
            timeDummy = stopwatch.ElapsedMilliseconds;
            averageAcquisitionTime += timeDummy;

            // Image segmentation
            Image<Gray, Byte> editedImage = Segment(originalImage, BinaryThreshold, OpeningSize, ClosingSize);
            if (displayCheckBox.Checked == true)
            {
                pictureBox3.Image = editedImage.ToBitmap();
            }
            averageSegmentationTime += stopwatch.ElapsedMilliseconds - timeDummy;
            timeDummy = stopwatch.ElapsedMilliseconds;

            // Feature detection
            if (featureExtractionCheckBox.Checked == true)
            {
                editedImage._And(originalImage.Convert<Gray, Byte>());
                editedImage = DetectTexture(editedImage, CannyThreshold);
                if (displayCheckBox.Checked == true)
                {
                    pictureBox4.Image = editedImage.ToBitmap();
                }
                averageFeatureExtractionTime += stopwatch.ElapsedMilliseconds - timeDummy;
                timeDummy = stopwatch.ElapsedMilliseconds;
            }

            // Weed location
            if (blobDetectionCheckBox.Checked == true)
            {
                bool[] sprayTrigger = LocateWeeds(editedImage);
                averageBlobDetectionTime += stopwatch.ElapsedMilliseconds - timeDummy;

                // Visual spray simulation
                Bgr red = new Bgr(0, 0, 255);
                Bgr green = new Bgr(0, 255, 0);
                Gray white = new Gray(255);
                Gray black = new Gray(0);
                Image<Gray, Byte> mask = new Image<Gray, Byte>(ROI.Width, ROI.Height, new Gray(0));

                for (int i = 0; i < totalSprayers; i++)
                {
                    if (sprayTrigger[i])
                    {
                        mask.ROI = new Rectangle(i * ROI.Width / totalSprayers, 0, ROI.Width / totalSprayers, ROI.Height);
                        mask.SetValue(white);
                    }
                }
                mask.ROI = new Rectangle(0, 0, ROI.Width, ROI.Height);
                Image<Bgr, Byte> one = originalImage.And(mask.Not().Convert<Bgr, Byte>());
                Image<Bgr, Byte> two = originalImage.Add(new Image<Bgr, Byte>(ROI.Width, ROI.Height, red), mask);
                if (displayCheckBox.Checked == true)
                {
                    pictureBox4.Image = one.Or(two).ToBitmap();
                }
                if (saveCheckBox.Checked == true)
                {
                    one.Or(two).Save(imageFolder + "\\" + frameCount + "x.png");
                }
            }

            // Stop timing process and output result
            stopwatch.Stop();
            averageProcessingTime += stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (frameCount <= frameTotal)
            {
                statusTextBox.AppendText("Frame " + frameCount + "\n");

                // Start timing process
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Acquire the Image
                originalImage = new Image<Bgr, Byte>(imageFolder + "\\" + frameCount + ".jpg");
                originalImage.ROI = ROI;
                if (saveCheckBox.Checked == true)
                {
                    originalImage.Save(imageFolder + "\\" + frameCount + "before.png");
                }

                // Display the Image
                if (displayCheckBox.Checked == true)
                {
                    pictureBox1.Image = originalImage.ToBitmap();
                }
                timeDummy = stopwatch.ElapsedMilliseconds;
                averageAcquisitionTime += timeDummy;

                // Image segmentation
                Image<Gray, Byte> editedImage = Segment(originalImage, BinaryThreshold, OpeningSize, ClosingSize);
                if (displayCheckBox.Checked == true)
                {
                    pictureBox3.Image = editedImage.ToBitmap();
                }
                averageSegmentationTime += stopwatch.ElapsedMilliseconds - timeDummy;
                timeDummy = stopwatch.ElapsedMilliseconds;

                // Feature detection
                if (featureExtractionCheckBox.Checked == true)
                {
                    editedImage._And(originalImage.Convert<Gray, Byte>());
                    editedImage = DetectTexture(editedImage, CannyThreshold);
                    if (displayCheckBox.Checked == true && blobDetectionCheckBox.Checked == false)
                    {
                        pictureBox4.Image = editedImage.ToBitmap();
                    }
                    if (saveCheckBox.Checked == true && blobDetectionCheckBox.Checked == false)
                    {
                        editedImage.Save(imageFolder + "\\" + frameCount + "after.png");
                    }
                    averageFeatureExtractionTime += stopwatch.ElapsedMilliseconds - timeDummy;
                    timeDummy = stopwatch.ElapsedMilliseconds;
                }

                // Weed location
                if (blobDetectionCheckBox.Checked == true)
                {
                    bool[] sprayTrigger = LocateWeeds(editedImage);
                    averageBlobDetectionTime += stopwatch.ElapsedMilliseconds - timeDummy;

                    // Visual spray simulation
                    Bgr red = new Bgr(0, 0, 255);
                    Bgr green = new Bgr(0, 255, 0);
                    Gray white = new Gray(255);
                    Gray black = new Gray(0);
                    Image<Gray, Byte> mask = new Image<Gray, Byte>(ROI.Width, ROI.Height, new Gray(0));

                    for (int i = 0; i < totalSprayers; i++)
                    {
                        if (sprayTrigger[i])
                        {
                            mask.ROI = new Rectangle(i * ROI.Width / totalSprayers, 0, ROI.Width / totalSprayers, ROI.Height);
                            mask.SetValue(white);
                        }
                    }
                    mask.ROI = new Rectangle(0, 0, ROI.Width, ROI.Height);
                    Image<Bgr, Byte> one = originalImage.And(mask.Not().Convert<Bgr, Byte>());
                    Image<Bgr, Byte> two = originalImage.Add(new Image<Bgr, Byte>(ROI.Width, ROI.Height, red), mask);
                    if (displayCheckBox.Checked == true)
                    {
                        pictureBox4.Image = one.Or(two).ToBitmap();
                    }
                    if (saveCheckBox.Checked == true)
                    {
                        one.Or(two).Save(imageFolder + "\\" + frameCount + "y.png");
                    }
                    //
                }

                

                // Stop timing process and output result
                stopwatch.Stop();
                averageProcessingTime += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();

                // Increment frame count
                frameCount++;
            }
            else
            {
                // Stop the timer
                timer1.Enabled = false;
                frameCount = 1;

                // Write average image processing times
                averageAcquisitionTime /= frameTotal;
                statusTextBox.AppendText("Average acquisition time: " + averageAcquisitionTime + " ms\n\n");
                log.AppendLine("Average acquisition time: " + averageAcquisitionTime + " ms");
                averageSegmentationTime /= frameTotal;
                statusTextBox.AppendText("Average segmentation time: " + averageSegmentationTime + " ms\n\n");
                log.AppendLine("Average segmentation time: " + averageSegmentationTime + " ms");
                averageFeatureExtractionTime /= frameTotal;
                statusTextBox.AppendText("Average feature extraction time: " + averageFeatureExtractionTime + " ms\n\n");
                log.AppendLine("Average feature extraction time: " + averageFeatureExtractionTime + " ms");
                averageBlobDetectionTime /= frameTotal;
                statusTextBox.AppendText("Average BLOB detection time: " + averageBlobDetectionTime + " ms\n\n");
                log.AppendLine("Average BLOB detection time: " + averageBlobDetectionTime + " ms");
                averageProcessingTime /= frameTotal;
                statusTextBox.AppendText("Average processing time: " + averageProcessingTime + " ms\n\n");
                log.AppendLine("Average processing time: " + averageProcessingTime + " ms");
                log.AppendLine("");

                // Save and close text file
                File.WriteAllText(imageFolder + "\\Log.txt", log.ToString());
            }
        }
        
        public Image<Gray, Byte> Segment(Image<Bgr, Byte> image, Gray binaryThreshold, int openingSize, int closingSize)
        {
            // Split image into colour channels
            Image<Gray, Byte>[] channel = image.Split();
            
            // Subtract the red channel from the green channel
            Image<Gray, Byte> output = channel[1] - channel[2];
            if (displayCheckBox.Checked == true)
            {
                pictureBox2.Image = output.ToBitmap();
            }

            // Threshold for overlapping elements
            output = output.ThresholdBinary(binaryThreshold, new Gray(255));

            // Perform morphological opening
            StructuringElementEx openingElement = new StructuringElementEx(openingSize * 2, openingSize * 2, openingSize, openingSize, CV_ELEMENT_SHAPE.CV_SHAPE_ELLIPSE);
            output = output.MorphologyEx(openingElement, CV_MORPH_OP.CV_MOP_OPEN, 1);
            
            if (ClosingSize != 0)
            {
                // Perform morphological closing
                StructuringElementEx closingElement = new StructuringElementEx(closingSize * 2, closingSize * 2, closingSize, closingSize, CV_ELEMENT_SHAPE.CV_SHAPE_ELLIPSE);
                output = output.MorphologyEx(closingElement, CV_MORPH_OP.CV_MOP_CLOSE, 1);
            }

            // Return segmented image
            return output;
        }

        public Image<Gray, Byte> DetectTexture(Image<Gray, Byte> image, Gray CannyThreshold)
        {
            // Create textured image
            Image<Gray, Byte> imageTexture;

            // Apply Canny edge detector
            imageTexture = image.Canny(CannyThreshold, new Gray(52));

            // Return textured image
            return imageTexture;
        }
        
        public bool[] LocateWeeds(Image<Gray, Byte> image)
        {
            // Sprayer control list
            bool[] sprayTrigger = new bool[totalSprayers];
            Rectangle[] sprayArea = new Rectangle[totalSprayers];
            for (int i = 0; i < totalSprayers; i++)
            {
                sprayArea[i] = new Rectangle(i * ROI.Width / totalSprayers, 0, ROI.Width / totalSprayers, ROI.Height);
                sprayTrigger[i] = false;
            }

            // Convert from Image<Gray, Byte> to Bitmap
            Bitmap clone = image.Convert<Bgr, Byte>().ToBitmap();
            
            // Process image with blob counter
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = BLOBSize;
            blobCounter.MinHeight = BLOBSize;
            blobCounter.FilterBlobs = true;
            blobCounter.ProcessImage(clone);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            // Create convex hull searching algorithm
            GrahamConvexHull hullFinder = new GrahamConvexHull();

            // Lock image to draw on it
            BitmapData data = clone.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, clone.PixelFormat);

            // Process each blob
            foreach (Blob blob in blobs)
            {
                // Trigger sprayers based on blob location
                for (int i = 0; i < totalSprayers; i++)
                {
                    if (blob.Rectangle.IntersectsWith(sprayArea[i]))
                    {
                        sprayTrigger[i] = true;
                    }
                }

                // Get blob's edge points
                List<IntPoint> leftPoints = new List<IntPoint>();
                List<IntPoint> rightPoints = new List<IntPoint>();
                List<IntPoint> edgePoints = new List<IntPoint>();
                blobCounter.GetBlobsLeftAndRightEdges(blob,  out leftPoints, out rightPoints);
                edgePoints.AddRange(leftPoints);
                edgePoints.AddRange(rightPoints);

                // Blob's convex hull
                List<IntPoint> hull = hullFinder.FindHull(edgePoints);

                Drawing.Polygon(data, hull, Color.Red);
            }
            clone.UnlockBits(data);
            if (displayCheckBox.Checked == true)
            {
                pictureBox4.Image = clone;
            }
            if (saveCheckBox.Checked == true)
            {
                clone.Save(imageFolder + "\\" + frameCount + "after.png");
            }
            return sprayTrigger;
        }

        private void frameRateBar_ValueChanged(object sender, EventArgs e)
        {
            // Update the timer interval matching the frame rate
            timer1.Interval = (int)(1000 / frameRateBar.Value);
            frameRate = frameRateBar.Value;
            frameRateValue.Text = frameRateBar.Value + " fps";

            // Update the image ROI based on the selected frame rate
            ROI = new Rectangle(0, ((ImageHeight - (int)(MaximumSpeed / frameRate * ImageRatio)) / 2), ImageWidth, (int)(MaximumSpeed / frameRate * ImageRatio));
        }

        private void binaryThresholdBar_ValueChanged(object sender, EventArgs e)
        {
            BinaryThreshold = new Gray(binaryThresholdBar.Value);
            binaryThresholdValue.Text = binaryThresholdBar.Value.ToString();
        }

        private void openingSizeBar_ValueChanged(object sender, EventArgs e)
        {
            OpeningSize = openingSizeBar.Value;
            openingSizeValue.Text = openingSizeBar.Value + " px";
        }

        private void blobSizeBar_ValueChanged(object sender, EventArgs e)
        {
            BLOBSize = BLOBSizeBar.Value;
            blobSizeValue.Text = BLOBSizeBar.Value + " px";
        }

        private void cannyThresholdBar_ValueChanged(object sender, EventArgs e)
        {
            CannyThreshold = new Gray(cannyThresholdBar.Value);
            cannyThresholdValue.Text = cannyThresholdBar.Value.ToString();
        }

        private void closingSizeBar_ValueChanged(object sender, EventArgs e)
        {
            ClosingSize = closingSizeBar.Value;
            closingSizeValue.Text = closingSizeBar.Value + " px";
        }
    }
}