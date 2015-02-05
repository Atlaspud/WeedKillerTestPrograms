using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

// Prepares image for Classification
// Threshold Image for Green colour
// Morphological open and close to clean Thresholded image
// Fit windows to blobs
// Label windows via connected components
// Texture analysis on random window from each cluster

namespace TextureClassificationTestProgram
{
    class ImageProcessor
    {
        // Constants

        private const int IMAGE_HEIGHT = 1023;
        private const int IMAGE_WIDTH = 1279;
        private const int MORPHOLOGY_SIZE = 40;
        private const int BINARY_THRESHOLD = 20;
        private const int WINDOW_SIZE = 75;

        // Thresholds image to single out green colour

        static public Image<Gray,Byte> thresholdImage(Image<Bgr, Byte> image)
        {
            Image<Gray, Byte> outputImage = new Image<Gray, Byte>(IMAGE_WIDTH, IMAGE_HEIGHT);
            Image<Gray, Byte>[] channel = image.Split();
            outputImage = channel[1] - channel[2];
            outputImage._ThresholdBinary(new Gray(BINARY_THRESHOLD), new Gray(255));
            return outputImage;
        }

        // Clean up images using Morphological open and close

        static public Image<Gray, Byte> morphology(Image<Gray, Byte> image)
        {
            
            StructuringElementEx kernel = new StructuringElementEx(MORPHOLOGY_SIZE, MORPHOLOGY_SIZE, MORPHOLOGY_SIZE / 2, MORPHOLOGY_SIZE / 2, CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
            image._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_OPEN, 1);
            image._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_CLOSE, 1);
            return image;
        }

        // Label Connected Components

        static public Image<Gray, Byte> LabelConnectedComponents(Image<Gray, Byte> binary, int startLabel)
        {
            Contour<Point> contours = binary.FindContours(
                CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                RETR_TYPE.CV_RETR_EXTERNAL);

            int count = startLabel;
            for (Contour<Point> cont = contours; cont != null; cont = cont.HNext)
            {
                CvInvoke.cvDrawContours(binary, cont, new MCvScalar(count), new MCvScalar(0), 2, -1, LINE_TYPE.FOUR_CONNECTED, new Point(0, 0));
                ++count;
            }
            return binary;
        }

        static public Image<Gray, Byte> invertImage(Image<Gray, Byte> binaryMask)
        {
            // Convert image to 2D array
            Byte[, ,] maskData = binaryMask.Data;
            // Check for black pixel, change to black else change to white.
            for (int i = 0; i < binaryMask.Height; i += 1)
            {
                for (int j = 0; j < binaryMask.Width; j += 1)
                {
                    if (maskData[i, j, 0] == 0)
                    {
                        maskData[i, j, 0] = 255;
                    }
                    else
                    {
                        maskData[i, j, 0] = 0;
                    }
                }
            }

            return new Image<Gray, byte>(maskData);
        }

        // Search through image for white pixels

        static public List<int[]> findWindows(Image<Gray, Byte> binaryMask)
        {
            List<int[]> startingLocation = new List<int[]>();
            Byte[, ,] maskData = binaryMask.Data;
            for (int row = 0; row < binaryMask.Height; row += WINDOW_SIZE)
            {
                for (int col = 0; col < binaryMask.Width; col += WINDOW_SIZE)
                {
                    if (maskData[row, col, 0] == 255)
                    {
                        int colMaxBack = col - WINDOW_SIZE;

                        while (col >= 0 && col > colMaxBack && maskData[row, col, 0] == 255)
                        {
                            --col;
                        }
                        if (checkFit(row, col, maskData))
                        {
                            int[] points = {row, col};
                            startingLocation.Add(points);
                            if (col > IMAGE_WIDTH) col = IMAGE_WIDTH;
                        }
                        col += WINDOW_SIZE;
                    }
                }
            }
            return startingLocation;

        }

        // Check if window fits, assume it does, then check

        static private Boolean checkFit(int row, int col, Byte[, ,] maskData)
        {
            Boolean x12Fit = true;
            Boolean x22Fit = true;
            Boolean x21Fit = true;
       
            int windowBoundryX = col + WINDOW_SIZE;
            if (windowBoundryX > IMAGE_WIDTH) windowBoundryX = IMAGE_WIDTH;
            int windowBoundryY = row + WINDOW_SIZE;
            if (windowBoundryY > IMAGE_HEIGHT) windowBoundryY = IMAGE_HEIGHT;
            int startingPointX = ++col;
            int startingPointY = row;


            // Check X12 corner of box
            for (int checkCol = startingPointX; checkCol < windowBoundryX; checkCol += 10)
            {
                if (checkCol > IMAGE_WIDTH || maskData[row, checkCol, 0] != 255)
                {
                    x12Fit = false;
                    break;
                }
            }

            if (x12Fit == false) return false;

            // Check X22 Corner of box
            for (int checkRow = startingPointY; checkRow < windowBoundryY; checkRow += 10)
            {
                if ( checkRow > IMAGE_HEIGHT || maskData[checkRow, windowBoundryX, 0] != 255)
                {
                    x22Fit = false;
                    break;
                }
            }

            if (x22Fit == false) return false;

            // Check X21 Corner of box
            for (int checkCol = windowBoundryX; checkCol > col; checkCol -= 10)
            {
                if (checkCol < 0 || maskData[windowBoundryY, checkCol, 0] != 255)
                {
                    x21Fit = false;
                    break;
                }
            }

            if (x21Fit == false) return false;

            return true;
        }
    }
}
