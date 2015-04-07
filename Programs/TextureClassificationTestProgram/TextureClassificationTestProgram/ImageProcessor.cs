﻿using Emgu.CV;
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
// Texture analysis on random window from each cluster *

namespace TextureClassificationTestProgram
{
    class ImageProcessor
    {
        // Constants

        private const int IMAGE_HEIGHT = 1023;
        private const int IMAGE_WIDTH = 1279;
        //private const int IMAGE_HEIGHT = 2448;
        //private const int IMAGE_WIDTH = 3264;
        private const int MORPHOLOGY_SIZE = 20;
        //private const int BINARY_THRESHOLD = 20;
        private const int BINARY_THRESHOLD = 17;
        private const int WINDOW_SIZE = 75;
        private const double CONNECTION_THRESHOLD = 82;

        // Thresholds image to single out green colour

        static public Image<Gray,Byte> thresholdImage(Image<Bgr, Byte> image)
        {
            Image<Gray, Byte> outputImage = new Image<Gray, Byte>(IMAGE_WIDTH, IMAGE_HEIGHT);
            Image<Gray, Byte>[] channel = image.Split();
            outputImage = channel[1] - channel[2];
            outputImage._ThresholdBinary(new Gray(BINARY_THRESHOLD), new Gray(255));
            return outputImage;
        }

        static public Image<Gray, Byte> thresholdImageHSV(Image<Bgr, Byte> image, int HueH, int HueL, int SatH, int SatL, int ValH, int ValL)
        {
            Image<Hsv, Byte> imageHsv = image.Convert<Hsv, Byte>();
            Image<Gray, Byte>[] channel = imageHsv.Split();
            
            //Hue
            CvInvoke.cvInRangeS(channel[0], new Gray(HueL).MCvScalar, new Gray(HueH).MCvScalar, channel[0]);
            //Sat
            CvInvoke.cvInRangeS(channel[1], new Gray(SatL).MCvScalar, new Gray(SatH).MCvScalar, channel[1]);
            //Sat
            CvInvoke.cvInRangeS(channel[2], new Gray(ValL).MCvScalar, new Gray(ValH).MCvScalar, channel[2]);

            Image<Gray, Byte> outputImage = channel[0].And(channel[1].And(channel[2]));

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

        static public Image<Gray, Byte> morphology(Image<Gray, Byte> image, int morphSize)
        {
            StructuringElementEx kernel = new StructuringElementEx(morphSize, morphSize, morphSize / 2, morphSize / 2, CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
            image._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_OPEN, 1);
            image._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_CLOSE, 1);
            //image._MorphologyEx(kernel, CV_MORPH_OP.CV_MOP_OPEN, 1);
            //image._Erode(morphSize);
            //image._Dilate(morphSize - 1);
            return image;
        }

        // Label Connected Components

        static public List<List<int[]>> LabelConnectedComponents(List<int[]> components)
        {
            // Calculate the centroid of each window and perform a radial check with a threshold value to determine connection
            List<List<int[]>> sortedConnectedComponents = new List<List<int[]>>();
            for (int i = 0; i < components.Count(); i++)
            {
                int[] component = components[i];
                Boolean newConnection = true;
                for (int k = 0; k < sortedConnectedComponents.Count(); k++)
                {
                    if (sortedConnectedComponents[k].Contains(component))
                    {
                        newConnection = false;
                        break;
                    }
                }
                if (newConnection)
                {
                    sortedConnectedComponents.Add(new List<int[]> {component});
                }
                double[] componentCentroid = getCentroid(component);
                for (int j = i + 1; j < components.Count(); j++)
                {
                    int[] neighbour = components[j];
                    double[] neighbourCentroid = getCentroid(neighbour);
                    if (isConnected(componentCentroid, neighbourCentroid))
                    {
                        for (int k = 0; k < sortedConnectedComponents.Count(); k++)
                        {
                            if (sortedConnectedComponents[k].Contains(component) && !sortedConnectedComponents[k].Contains(neighbour))
                            {
                                sortedConnectedComponents[k].Add(neighbour);
                                break;
                            }
                        }
                    }
                }
            }

            // check redundancy
            List<List<int[]>> cleanedConnectedComponents = new List<List<int[]>>();
            cleanedConnectedComponents.Add(sortedConnectedComponents[0]);
            for (int cluster = 1; cluster < sortedConnectedComponents.Count(); cluster++)
            {
                List<int[]> tempcomponentList = sortedConnectedComponents[cluster];
                for (int tempCoord = tempcomponentList.Count() - 1; tempCoord >= 0; tempCoord--)
                {
                    for (int cleanedComponents = cleanedConnectedComponents.Count() - 1; cleanedComponents >= 0; cleanedComponents--)
                    {
                        if (cleanedConnectedComponents[cleanedComponents].Contains(tempcomponentList[tempCoord]))
                        {
                            tempcomponentList.Remove(tempcomponentList[tempCoord]);
                            break;
                        }
                    }
                }
                cleanedConnectedComponents.Add(tempcomponentList);
            }
            return cleanedConnectedComponents;
        }

        static private Boolean isConnected(double[] coordOne, double[] coordTwo)
        {
            double xDiff = coordOne[0] - coordTwo[0];
            double yDiff = coordOne[1] - coordTwo[1];
            if (CONNECTION_THRESHOLD >= Math.Sqrt(Math.Pow(xDiff,2) + Math.Pow(yDiff,2)))
            {
                return true;
            }
            return false;
        }

        static private Boolean isMultiple()
        {
            return true;
        }

        static private double[] getCentroid(int[] coordinate)
        {
            return new double[]{coordinate[0]/2,coordinate[1]/2};
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
            Byte[, ,] maskData = binaryMask.Data; // y,x structure
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
                        if (checkFit(col, row, maskData))
                        {
                            int[] points = {col, row};
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

        static private Boolean checkFit(int col, int row, Byte[, ,] maskData)
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
