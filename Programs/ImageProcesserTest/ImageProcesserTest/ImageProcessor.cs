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

        private static int ImageHeight = 1024;
        private static int ImageWidth = 1280;
        private static bool SaveFlag = false;
        private static int BinaryThreshold = 20;
        private static int MorphologyElementSize = 40;
        private static int WindowSize = 100;
        private static bool ThresholdFlag = true;
        private static bool MorphologyFlag = false;
        private static bool WindowExtractionFlag = false;
        private StreamWriter imageProcessorLog;

        public static void SetSaveFlag(bool flag)
        {
            SaveFlag = flag;
        }

        public static void SetBinaryThreshold(int binarythreshold)
        {
            BinaryThreshold = binarythreshold;
        }

        public static void SetMorphologyElementSize(int morphologyelementsize)
        {
            MorphologyElementSize = morphologyelementsize;
        }

        public static void SetWindowSize(int windowSize)
        {
            WindowSize = windowSize;
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
            WindowExtractionFlag = blobdetectionflag;
        }

        public ImageProcessor(uint serial)
        {
            this.serial = serial;
            imageProcessorLog = new StreamWriter(Directory.GetCurrentDirectory() + "/imageProcessor" + serial + ".csv");
            imageProcessorLog.WriteLine("Serial Number, Frame Count, Processing Time (ms), Target Identified");
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
        }

        private void _Process()
        {
            try
            {
                startTime = DateTime.Now;
                output = new Image<Gray, Byte>(input.Width, input.Height, new Gray(0));
                if (ThresholdFlag) output = ColourThreshold(input);
                if (MorphologyFlag) output = MorphologicalSegmentation(output);
                bool result = false;
                if (WindowExtractionFlag) result = WindowExtraction(output);

                if (SaveFlag)
                {
                    output.Save(Directory.GetCurrentDirectory() + "/processed/" + serial + "-" + imageCount + ".tif");
                }

                //Write to image processing log
                int milliseconds = (int)(DateTime.Now.Ticks - startTime.Ticks) / 10000;
                imageProcessorLog.WriteLine(serial + "," + imageCount + "," + milliseconds + "," + result);

                //Fire image processed event
                OnImageProcessed(new ImageProcessedEventArgs(milliseconds, output.ToBitmap(), serial));

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

        private bool RestrictedStartingPoint(int i, int j, List<Tuple<int, int, int, int>> limits)
        {
            bool output = false;
            for (int n = 0; n < limits.Count; n++)
            {
                if (i >= limits[n].Item1 && i <= limits[n].Item2 && j >= limits[n].Item3 && j <= limits[n].Item4)
                {
                    output = true;
                }
            }
            return output;
        }

        public bool WindowExtraction(Image<Gray, Byte> binaryMask, Image<Gray, Byte> image = null)
        {
            Byte[, ,] mask = binaryMask.Data;
            List<TextureWindow> windows = new List<TextureWindow>();
            List<Tuple<int, int, int, int>> limits = new List<Tuple<int, int, int, int>>();
            for (int i = 0; i < ImageHeight - WindowSize; i += 1)
            {
                for (int j = 0; j < ImageWidth - WindowSize; j += 1)
                {
                    Byte upperLeft = mask[i, j, 0];
                    Byte upperRight = mask[i, j + WindowSize - 1, 0];
                    Byte lowerLeft = mask[i + WindowSize - 1, j, 0];
                    Byte lowerRight = mask[i + WindowSize - 1, j + WindowSize - 1, 0];
                    if (upperLeft != 0 && upperRight != 0 && lowerLeft != 0 && lowerRight != 0 && !RestrictedStartingPoint(i, j, limits))
                    {
                        //image.ROI = new Rectangle(j, i, WindowSize, WindowSize);
                        windows.Add(new TextureWindow());//image.Copy(), i, j));
                        limits.Add(new Tuple<int, int, int, int>(i - WindowSize, i + WindowSize - 1, j - WindowSize, j + WindowSize - 1));
                    }
                }
            }
            if (windows.Count > 0) return true;
            else return false;
        }

        public void StopLogging()
        {
            imageProcessorLog.Close();
        }
    }
}
