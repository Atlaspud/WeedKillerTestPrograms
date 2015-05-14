using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Photoshop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PatchExtraction
{
    class ImageProcessor
    {
         // Constants

        private const int IMAGE_HEIGHT = 1023;
        private const int IMAGE_WIDTH = 1279;
        private const int MORPHOLOGY_SIZE = 15;
        private const int BINARY_THRESHOLD = 17;
        private const double CONNECTION_THRESHOLD = 82;

        private static ApplicationClass objApp;

        // Perform Photoshop's shadow/highlight feature on arbitrarily sized image

        static public Image<Bgr, byte> shadowHighlight(Image<Bgr, byte> input)
        {
            //Copy input to clipboard
            Clipboard.SetImage(input.Bitmap as System.Drawing.Image);
            //Open photoshop
            if (objApp == null)
            {
                objApp = new ApplicationClass();
                objApp.Visible = false;
            }
            ActionDescriptorClass desc1, desc2;
            try
            {
                //Open new photoshop document with preset settings of clipboard
                int idMk = objApp.CharIDToTypeID("Mk  ");
                desc1 = new ActionDescriptorClass();
                int idNw = objApp.CharIDToTypeID("Nw  ");
                desc2 = new ActionDescriptorClass();
                int idpreset = objApp.StringIDToTypeID("preset");
                desc2.PutString(idpreset, "Clipboard");
                int idDcmn = objApp.CharIDToTypeID("Dcmn");
                desc1.PutObject(idNw, idDcmn, desc2);
                objApp.ExecuteAction(idMk, desc1, PsDialogModes.psDisplayNoDialogs);
            }
            catch (COMException e)
            {
                //Quit and reopen
                objApp.Quit();
                objApp = new ApplicationClass();
                objApp.Visible = false;

                //Copy to clipboard
                Clipboard.SetImage(input.Bitmap as System.Drawing.Image);

                //Open new photoshop document with preset settings of clipboard
                int idMk = objApp.CharIDToTypeID("Mk  ");
                desc1 = new ActionDescriptorClass();
                int idNw = objApp.CharIDToTypeID("Nw  ");
                desc2 = new ActionDescriptorClass();
                int idpreset = objApp.StringIDToTypeID("preset");
                desc2.PutString(idpreset, "Clipboard");
                int idDcmn = objApp.CharIDToTypeID("Dcmn");
                desc1.PutObject(idNw, idDcmn, desc2);
                objApp.ExecuteAction(idMk, desc1, PsDialogModes.psDisplayNoDialogs);
            }

            //Open new photoshop document with desired settings
            /*
            int idMk = objApp.CharIDToTypeID("Mk  ");
            ActionDescriptorClass desc1 = new ActionDescriptorClass();
            int idNw = objApp.CharIDToTypeID("Nw  ");
            ActionDescriptorClass desc2 = new ActionDescriptorClass();
            int idMd = objApp.CharIDToTypeID("Md  ");
            int idRGBM = objApp.CharIDToTypeID("RGBM");
            desc2.PutClass(idMd, idRGBM);
            int idWdth = objApp.CharIDToTypeID("Wdth");
            int idRlt = objApp.CharIDToTypeID("#Rlt");
            desc2.PutUnitDouble(idWdth, idRlt, input.Width);
            int idHght = objApp.CharIDToTypeID("Hght");
            idRlt = objApp.CharIDToTypeID("#Rlt");
            desc2.PutUnitDouble(idHght, idRlt, input.Height);
            int idRslt = objApp.CharIDToTypeID("Rslt");
            int idRsl = objApp.CharIDToTypeID("#Rsl");
            desc2.PutUnitDouble(idRslt, idRsl, 96);
            int idpixelScaleFactor = objApp.StringIDToTypeID("pixelScaleFactor");
            desc2.PutDouble(idpixelScaleFactor, 1.0);
            int idFl = objApp.CharIDToTypeID("Fl  ");
            int idTrns = objApp.CharIDToTypeID("Trns");
            desc2.PutEnumerated(idFl, idFl, idTrns);
            int idDpth = objApp.CharIDToTypeID("Dpth");
            desc2.PutInteger(idDpth,8);
            int idprofile = objApp.StringIDToTypeID("profile");
            desc2.PutString(idprofile,"sRGB IEC61966-2.1");
            int idDcmn = objApp.CharIDToTypeID("Dcmn");
            desc1.PutObject(idNw,idDcmn,desc2);
            objApp.ExecuteAction(idMk,desc1,PsDialogModes.psDisplayNoDialogs);
            */

            //Paste image into photoshop
            int idpast = objApp.CharIDToTypeID("past");
            desc1 = new ActionDescriptorClass();
            int idAntA = objApp.CharIDToTypeID("AntA");
            int idAnnt = objApp.CharIDToTypeID("Annt");
            int idAnno = objApp.CharIDToTypeID("Anno");
            desc1.PutEnumerated(idAntA, idAnnt, idAnno);
            objApp.ExecuteAction(idpast, desc1, PsDialogModes.psDisplayNoDialogs);

            //Perform shadow highlight correction
            int idadaptCorrect = objApp.StringIDToTypeID("adaptCorrect");
            desc2 = new ActionDescriptorClass();
            int idsdwM = objApp.CharIDToTypeID("sdwM");
            ActionDescriptorClass desc3 = new ActionDescriptorClass();
            int idAmnt = objApp.CharIDToTypeID("Amnt");
            int idPrc = objApp.CharIDToTypeID("#Prc");
            desc3.PutUnitDouble(idAmnt, idPrc, 100.0);
            int idWdth = objApp.CharIDToTypeID("Wdth");
            idPrc = objApp.CharIDToTypeID("#Prc");
            desc3.PutUnitDouble(idWdth, idPrc, 50.0);
            int idRds = objApp.CharIDToTypeID("Rds ");
            desc3.PutInteger(idRds, 30);
            int idaptCorrectTones = objApp.StringIDToTypeID("adaptCorrectTones");
            desc2.PutObject(idsdwM, idaptCorrectTones, desc3);
            int idhglM = objApp.CharIDToTypeID("hglM");
            ActionDescriptorClass desc4 = new ActionDescriptorClass();
            idAmnt = objApp.CharIDToTypeID("Amnt");
            idPrc = objApp.CharIDToTypeID("#Prc");
            desc4.PutUnitDouble(idAmnt, idPrc, 100.0);
            idWdth = objApp.CharIDToTypeID("Wdth");
            idPrc = objApp.CharIDToTypeID("#Prc");
            desc4.PutUnitDouble(idWdth, idPrc, 50.0);
            idRds = objApp.CharIDToTypeID("Rds ");
            desc4.PutInteger(idRds, 30);
            int idadaptCorrectTones = objApp.StringIDToTypeID("adaptCorrectTones");
            desc2.PutObject(idhglM, idadaptCorrectTones, desc4);
            int idBlcC = objApp.CharIDToTypeID("BlcC");
            desc2.PutDouble(idBlcC, 0.01);
            int idWhtC = objApp.CharIDToTypeID("WhtC");
            desc2.PutDouble(idWhtC, 0.01);
            int idCntr = objApp.CharIDToTypeID("Cntr");
            desc2.PutInteger(idCntr, 0);
            int idClrC = objApp.CharIDToTypeID("ClrC");
            desc2.PutInteger(idClrC, 100);
            objApp.ExecuteAction(idadaptCorrect, desc2, PsDialogModes.psDisplayNoDialogs);

            //Select all
            int idsetd = objApp.CharIDToTypeID("setd");
            desc1 = new ActionDescriptorClass();
            int idnull = objApp.CharIDToTypeID("null");
            ActionReferenceClass ref1 = new ActionReferenceClass();
            int idChnl = objApp.CharIDToTypeID("Chnl");
            int idfsel = objApp.CharIDToTypeID("fsel");
            ref1.PutProperty(idChnl, idfsel);
            desc1.PutReference(idnull, ref1);
            int idT = objApp.CharIDToTypeID("T   ");
            int idOrdn = objApp.CharIDToTypeID("Ordn");
            int idAl = objApp.CharIDToTypeID("Al  ");
            desc1.PutEnumerated(idT, idOrdn, idAl);
            objApp.ExecuteAction(idsetd, desc1, PsDialogModes.psDisplayNoDialogs);

            //Cut selection
            int idcut = objApp.CharIDToTypeID("cut ");
            objApp.ExecuteAction(idcut, null, PsDialogModes.psDisplayNoDialogs);

            //Close document
            int idCls = objApp.CharIDToTypeID("Cls ");
            desc1 = new ActionDescriptorClass();
            int idSvng = objApp.CharIDToTypeID("Svng");
            int idYsN = objApp.CharIDToTypeID("YsN ");
            int idN = objApp.CharIDToTypeID("N   ");
            desc1.PutEnumerated(idSvng, idYsN, idN);
            objApp.ExecuteAction(idCls, desc1, PsDialogModes.psDisplayNoDialogs);

            //Get output via clipboard
            Image<Bgr, byte> output = new Image<Bgr, byte>(Clipboard.GetImage() as Bitmap);

            //Clear clipboard
            objApp.Purge(PsPurgeTarget.psAllCaches);

            //Return output
            return output;
        }

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
            List<List<int[]>> cleanedConnectedComponents = new List<List<int[]>>();
            if (sortedConnectedComponents.Count > 0)
            {
                // check redundancy
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

        static public List<int[]> findWindows(Image<Gray, Byte> binaryMask, int windowSize)
        {
            List<int[]> startingLocation = new List<int[]>();
            Byte[, ,] maskData = binaryMask.Data; // y,x structure
            for (int row = 0; row < binaryMask.Height; row += windowSize)
            {
                for (int col = 0; col < binaryMask.Width; col += windowSize)
                {
                    if (maskData[row, col, 0] == 255)
                    {
                        int colMaxBack = col - windowSize;

                        while (col > 0 && col > colMaxBack && maskData[row, col, 0] == 255)
                        {
                            --col;
                        }
                        if (checkFit(col, row, maskData, windowSize))
                        {
                            Image<Gray, byte> test = ImageProcessor.extractROI(binaryMask,new Rectangle(col,row,windowSize,windowSize));
                            if (bruteForceCheck(test))
                            {
                                int[] points = { col, row };
                                startingLocation.Add(points);
                                if (col > IMAGE_WIDTH) col = IMAGE_WIDTH;
                            }
                        }
                        col += windowSize;
                    }
                }
            }
            return startingLocation;

        }

        static public Image<Bgr, byte> extractROI(Image<Bgr, byte> input, Rectangle roi)
        {
            int inputHeight = input.Height;
            int inputWidth = input.Width;
            int outputHeight = roi.Height;
            int outputWidth = roi.Width;
            int x = roi.X;
            int y = roi.Y;

            byte[, ,] inputData = input.Data;
            byte[, ,] outputData = new byte[outputHeight, outputWidth, 3];

            for (int i = y; i < (y + outputHeight); i++)
            {
                for (int j = x; j < (x + outputWidth); j++)
                {
                    for (int n = 0; n < 3; n++)
                    {
                        outputData[(i - y), (j - x), n] = inputData[i, j, n];
                    }
                }
            }

            return new Image<Bgr, byte>(outputData);
        }

        static public Image<Gray, byte> extractROI(Image<Gray, byte> input, Rectangle roi)
        {
            int inputHeight = input.Height;
            int inputWidth = input.Width;
            int outputHeight = roi.Height;
            int outputWidth = roi.Width;
            int x = roi.X;
            int y = roi.Y;

            byte[, ,] inputData = input.Data;
            byte[, ,] outputData = new byte[outputHeight, outputWidth, 1];

            for (int i = y; i < (y + outputHeight); i++)
            {
                for (int j = x; j < (x + outputWidth); j++)
                {
                    outputData[(i - y), (j - x), 0] = inputData[i, j, 0];
                }
            }

            return new Image<Gray, byte>(outputData);
        }

        // Thorough check of every pixel in potential patch. Must be 95% white.

        static unsafe private bool bruteForceCheck(Image<Gray,byte> mask)
        {
            byte[, ,] maskData = mask.Data;
            int height = mask.Height;
            int width = mask.Width;

            /*fixed (byte* maskPointer = maskData)
                for (int n = 0; n < height * width; n++)
                {
                    if (*(maskPointer + n) == 0) return false;
                }*/
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (maskData[i, j, 0] == 0) return false;
                }
            }
            return true;
        }

        // Check if window fits, assume it does, then check

        static private Boolean checkFit(int col, int row, Byte[, ,] maskData, int windowSize)
        {
            Boolean x12Fit = true;
            Boolean x22Fit = true;
            Boolean x21Fit = true;
       
            int windowBoundryX = col + windowSize;
            if (windowBoundryX > IMAGE_WIDTH) return false;
            int windowBoundryY = row + windowSize;
            if (windowBoundryY > IMAGE_HEIGHT) return false;
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

        public static Dictionary<String,double[]> calculateHoG(Image<Gray, Byte> input, int binSize)
        {
            Image<Gray, float> dx = input.Sobel(1, 0, 3);
            Image<Gray, float> dy = input.Sobel(0, 1, 3);
            float[, ,] dxData = dx.Data;
            float[, ,] dyData = dy.Data;
            double[] intensities = new double[360 / binSize];
            double[] orientations = new double[360 / binSize];
            double orientation = 0;
            double intensity = 0;
            double totalIntensity = 0;

            for (int i = input.Height - 1; i >= 0; i--)
            {
                for (int j = input.Width - 1; j >= 0; j--)
                {
                    // Calculate gradient orientation and intensity at pixel (i,j)
                    orientation = Math.Atan2((double)dyData[i, j, 0], (double)(dxData[i, j, 0])) * 180.0 / Math.PI + 180.0;
                    intensity = Math.Sqrt(Math.Pow((double)dxData[i, j, 0], 2) + Math.Pow((double)dyData[i, j, 0], 2));

                    // Accumulate the total gradient intensity
                    totalIntensity += intensity;

                    // Accumulate orientation-specific gradient intensity
                    for (int k = 0; k < (360 / binSize); k++)
                    {
                        orientations[k] = k * binSize;
                        if (orientation < 0.0 || orientation > 360.0)
                        {
                            //Unacceptable orientation calculated
                        }
                        else if (orientation >= (double)(k * binSize) && orientation < (double)((k + 1) * binSize))
                        {
                            intensities[k] += intensity;
                            break;
                        }
                        else if (orientation == 360.0)
                        {
                            intensities[0] += intensity;
                            break;
                        }
                    }
                }
            }

            //Normalise histogram of oriented gradients
            Dictionary<String,double[]> histogram = new Dictionary<String,double[]>(2)
            {
                { "intensity", new double[360 / binSize] },
                { "orientation", new double[360 / binSize] }
            };

            int maxIndex = Array.IndexOf(intensities, intensities.Max());
            for (int i = 0; i < (360 / binSize); i++)
            {
                //Save orientation
                histogram["orientation"][i] = orientations[i];

                //Perform intensity normalisation and rotation normalisation by circular-shift of orientation
                histogram["intensity"][i] = intensities[(maxIndex + i) % (360 / binSize)] / totalIntensity;
            }
            return histogram;
        }
    }
}
