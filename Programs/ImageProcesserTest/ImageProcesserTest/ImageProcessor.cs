using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using FlyCapture2Managed;
using System.Drawing;
using AForge;
using AForge.Video;
using AForge.Imaging;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace ImageProcessorTest
{
    public class ImageProcessor
    {
        private Task task;
        private uint serial;
        public event TargetIdentifiedEventHandler TargetIdentified;
        public event ImageProcessedEventHandler ImageProcessed;
        private Image<Bgr,Byte> input;
        private Image<Gray,Byte> output;
        private int imageCount = 0;
        private DateTime startTime;

        private static int BinaryThreshold = 20;
        private static int MorphologyElementSize = 40;
        private static int BLOBSize = 120;
        private static bool ThresholdFlag = true;
        private static bool MorphologyFlag = false;
        private static bool BLOBDetectionFlag = false;
        private StreamWriter imageProcessorLog;

        public static void SetBinaryThreshold(int binarythreshold)
        {
            BinaryThreshold = binarythreshold;
        }

        public static void SetMorphologyElementSize(int morphologyelementsize)
        {
            MorphologyElementSize = morphologyelementsize;
        }

        public static void SetBLOBSize(int blobsize)
        {
            BLOBSize = blobsize;
        }

        public static void SetThresholdFlag(bool thresholdflag)
        {
            ThresholdFlag = thresholdflag;
        }

        public static void SetMorphologyFlag(bool morphologyflag)
        {
            MorphologyFlag = morphologyflag;
        }

        public static void SetBLOBDetectionFlag(bool blobdetectionflag)
        {
            BLOBDetectionFlag = blobdetectionflag;
        }

        public ImageProcessor(uint serial)
        {
            this.serial = serial;
            imageProcessorLog = new StreamWriter(Directory.GetCurrentDirectory() + "/imageProcessor" + serial + ".csv", true);
            imageProcessorLog.WriteLine("Serial Number, Frame Count, Target Identified?, Processing Time");
        }

        public void ProcessImage(Bitmap image)
        {
            if (task == null)
            {
                input = new Image<Bgr, Byte>(image);
                task = new Task(new Action(_Process));
                task.Start();
            }
            else if (task.IsCompleted)
            {
                input = new Image<Bgr, Byte>(image);
                task = new Task(new Action(_Process));
                task.Start();
            }
            else
            {
                task.Wait();
                input = new Image<Bgr, Byte>(image);
                task = new Task(new Action(_Process));
                task.Start();
            }
            imageCount++;
            startTime = DateTime.Now;
        }

        private void _Process()
        {
            try
            {
                output = new Image<Gray, Byte>(input.Width, input.Height, new Gray(0));
                if (ThresholdFlag) output = ColourThreshold(input);
                if (MorphologyFlag) output = MorphologicalSegmentation(output);
                bool result = false;
                if (BLOBDetectionFlag) result = DetectBLOBs(output);

                //Fire ImageProcessedEvent
                TimeSpan timespan = DateTime.Now - startTime;
                OnImageProcessed(new ImageProcessedEventArgs(timespan, output.ToBitmap(), serial));

                //Write to image processing log
                imageProcessorLog.WriteLine(serial + "," + imageCount + "," + timespan + "," + result);

                if (result)
                {
                    //Fire TargetFoundEvent
                    Target target = new Target();
                    OnTargetIdentified(new TargetIdentifiedEventArgs(target, serial));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        protected virtual void OnImageProcessed(ImageProcessedEventArgs e)
        {
            ImageProcessedEventHandler handler = ImageProcessed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnTargetIdentified(TargetIdentifiedEventArgs e)
        {
            TargetIdentifiedEventHandler handler = TargetIdentified;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private Image<Gray, Byte> ColourThreshold(Image<Bgr, Byte> input)
        {
            Image<Gray, Byte> output = new Image<Gray, Byte>(input.Width, input.Height);
            Image<Gray, Byte>[] channel = input.Split();
            output = channel[1] - channel[2];
            output._ThresholdBinary(new Gray(BinaryThreshold), new Gray(255));
            return output;
        }

        private Image<Gray, Byte> MorphologicalSegmentation(Image<Gray, Byte> input)
        {
            StructuringElementEx kernel = new StructuringElementEx(MorphologyElementSize, MorphologyElementSize, MorphologyElementSize / 2, MorphologyElementSize / 2, CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
            return input.MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_OPEN, 1); ;
        }

        private bool DetectBLOBs(Image<Gray, Byte> input)
        {
            bool output = false;
            Bitmap image = input.ToBitmap();
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = false;
            blobCounter.ProcessImage(image);
            Rectangle[] blobs = blobCounter.GetObjectsRectangles();
            foreach (Rectangle blob in blobs)
            {
                if (blob.Height * blob.Width >= BLOBSize * BLOBSize)
                {
                    output = true;
                    break;
                }
            }
            return output;
        }
    }
}
