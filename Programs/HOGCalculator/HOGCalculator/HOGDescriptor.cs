using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOGCalculator
{
    class HOGDescriptor
    {
        public enum DerivativeMask { Centred1D, NonCentred1D, CubicCorrected1D, RobertsCross2D, Prewitt3D, Sobel3D };

        //Settings
        private int windowSize;
        private int blockSize;
        private double blockOverlap;
        private int cellSize;
        private int numberOfBins;
        private bool signedGradient;
        private bool downweightEdges;
        private double l2HysThreshold;
        private bool rotationInvariant;
        private bool gammaCorrection;
        private DerivativeMask derivativeMask;

        //Processing variables
        private int blockStride;
        private int blocksPerWindow;
        private int cellsPerBlock;
        private double[,,,] spatialWeights;
        private int[,,,] spatialBins;

        /// <summary>
        /// This constructor creates an instance of the HOGDescriptor class and performs overhead computations to reduce workload in computing descriptor vectors.
        /// </summary>
        /// <param name="windowSize">The size of the detection window (pixels).</param>
        /// <param name="blockSize">The size of each block (cells).</param>
        /// <param name="blockOverlap">The fractional overlap of each block.</param>
        /// <param name="cellSize">The size of each cell (pixels).</param>
        /// <param name="numberOfBins">The number of bins for the gradient orientations.</param>
        /// <param name="signedGradient">Determines whether the gradient orientation range is signed [0°,360°), or unsigned [0°,180°).</param>
        /// <param name="downweightEdges">Determines whether or not the block edges are downweighted via a Gaussian spatial window.</param>
        /// <param name="l2HysThreshold">The threshold parameter for L2-Hys normalization.</param>
        /// <param name="rotationInvariant">Determines whether or not our novel rotation invariance modification is applied.</param>
        /// <param name="gammaCorrection">Determines whether or not gamma correction is applied to the window prior to computation.</param>
        /// <param name="derivativeMask">Selects the DerivativeMask for computing image derivatives.</param>
        /// <param name="histogramInterpolation">Selects the method of histogram interpolation.</param>
        public HOGDescriptor(
            int windowSize = 96,
            int blockSize = 2,
            double blockOverlap = 0.5,
            int cellSize = 8,
            int numberOfBins = 9,
            bool signedGradient = false,
            bool downweightEdges = true,
            double l2HysThreshold = 0.2,
            bool rotationInvariant = false,
            bool gammaCorrection = false,
            DerivativeMask derivativeMask = DerivativeMask.Sobel3D)
        {
            this.windowSize = windowSize;
            this.blockSize = blockSize;
            this.cellSize = cellSize;
            this.blockOverlap = blockOverlap;
            this.numberOfBins = numberOfBins;
            this.signedGradient = signedGradient;
            this.downweightEdges = downweightEdges;
            this.l2HysThreshold = l2HysThreshold;
            this.rotationInvariant = rotationInvariant;
            this.gammaCorrection = gammaCorrection;
            this.derivativeMask = derivativeMask;

            this.blockStride = (int)(blockSize * cellSize * blockOverlap);
            this.blocksPerWindow = (windowSize / blockStride - 1) * (windowSize / blockStride - 1);
            this.cellsPerBlock = blockSize * blockSize;

            //Gaussian spatial window
            double[,] gaussianSpatialWindow = new double[0, 0];
            if (downweightEdges == true) gaussianSpatialWindow = getGaussianSpatialWindow(blockSize * cellSize, 0.5 * blockSize * cellSize);

            //Pre-compute spatial bin interpolation weighting
            spatialWeights = new double[blocksPerWindow, blockSize * cellSize, blockSize * cellSize, 4];
            spatialBins = new int[blocksPerWindow,blockSize * cellSize, blockSize * cellSize,4];
            int blockCount = 0;
            for (int blockStartX = 0; blockStartX < (windowSize - blockStride); blockStartX += blockStride)
            {
                int blockEndX = blockStartX + blockSize * cellSize;
                for (int blockStartY = 0; blockStartY < (windowSize - blockStride); blockStartY += blockStride)
                {
                    int blockEndY = blockStartY + blockSize * cellSize;
                    for (int y = blockStartY; y < blockEndY; y++)
                    {
                        for (int x = blockStartX; x < blockEndX; x++)
                        {
                            //Get block specific indices
                            int i = x - blockStartX;
                            int j = y - blockStartY;

                            //Calculate spatial bin interpolation weighting
                            double cellX = (j + 0.5f) / cellSize - 0.5f;
                            double cellY = (i + 0.5f) / cellSize - 0.5f;
                            int icellX0 = (int)Math.Floor(cellX);
                            int icellY0 = (int)Math.Floor(cellY);
                            int icellX1 = icellX0 + 1, icellY1 = icellY0 + 1;
                            cellX -= icellX0;
                            cellY -= icellY0;

                            if ((uint)icellX0 < (uint)blockSize && (uint)icellX1 < (uint)blockSize)
                            {
                                if ((uint)icellY0 < (uint)blockSize && (uint)icellY1 < (uint)blockSize)
                                {
                                    spatialBins[blockCount,i,j,0] = icellX0 * blockSize + icellY0;
                                    spatialWeights[blockCount, i, j, 0] = (1.0 - cellX) * (1.0 - cellY);
                                    spatialBins[blockCount, i, j, 1] = icellX1 * blockSize + icellY0;
                                    spatialWeights[blockCount, i, j, 1] = cellX * (1.0 - cellY);
                                    spatialBins[blockCount, i, j, 2] = icellX0 * blockSize + icellY1;
                                    spatialWeights[blockCount, i, j, 2] = (1.0 - cellX) * cellY;
                                    spatialBins[blockCount, i, j, 3] = icellX1 * blockSize + icellY1;
                                    spatialWeights[blockCount, i, j, 3] = cellX * cellY;

                                }
                                else
                                {
                                    if ((uint)icellY0 < (uint)blockSize)
                                    {
                                        icellY1 = icellY0;
                                        cellY = 1.0 - cellY;
                                    }
                                    spatialBins[blockCount, i, j, 0] = icellX0 * blockSize + icellY1;
                                    spatialWeights[blockCount, i, j, 0] = (1.0 - cellX) * cellY;
                                    spatialBins[blockCount, i, j, 1] = icellX1 * blockSize + icellY1;
                                    spatialWeights[blockCount, i, j, 1] = cellX * cellY;
                                    spatialBins[blockCount, i, j, 2] = 0;
                                    spatialWeights[blockCount, i, j, 2] = 0;
                                    spatialBins[blockCount, i, j, 3] = 0;
                                    spatialWeights[blockCount, i, j, 3] = 0;
                                }
                            }
                            else
                            {
                                if ((uint)icellX0 < (uint)blockSize)
                                {
                                    icellX1 = icellX0;
                                    cellX = 1.0 - cellX;
                                }

                                if ((uint)icellY0 < (uint)blockSize && (uint)icellY1 < (uint)blockSize)
                                {
                                    spatialBins[blockCount, i, j, 0] = icellX1 * blockSize + icellY0;
                                    spatialWeights[blockCount, i, j, 0] = cellX * (1.0 - cellY);
                                    spatialBins[blockCount, i, j, 1] = icellX1 * blockSize + icellY1;
                                    spatialWeights[blockCount, i, j, 1] = cellX * cellY;
                                    spatialBins[blockCount, i, j, 2] = 0;
                                    spatialWeights[blockCount, i, j, 2] = 0;
                                    spatialBins[blockCount, i, j, 3] = 0;
                                    spatialWeights[blockCount, i, j, 3] = 0;
                                }
                                else
                                {
                                    if ((uint)icellY0 < (uint)blockSize)
                                    {
                                        icellY1 = icellY0;
                                        cellY = 1.0 - cellY;
                                    }
                                    spatialBins[blockCount, i, j, 0] = icellX1 * blockSize + icellY1;
                                    spatialWeights[blockCount, i, j, 0] = cellX * cellY;
                                    spatialBins[blockCount, i, j, 1] = 0;
                                    spatialWeights[blockCount, i, j, 1] = 0;
                                    spatialBins[blockCount, i, j, 2] = 0;
                                    spatialWeights[blockCount, i, j, 2] = 0;
                                    spatialBins[blockCount, i, j, 3] = 0;
                                    spatialWeights[blockCount, i, j, 3] = 0;
                                }
                            }

                            //Apply gaussian spatial window weighting
                            if (downweightEdges)
                            {
                                double w = gaussianSpatialWindow[i, j];
                                spatialWeights[blockCount, i, j, 0] *= w;
                                spatialWeights[blockCount, i, j, 1] *= w;
                                spatialWeights[blockCount, i, j, 2] *= w;
                                spatialWeights[blockCount, i, j, 3] *= w;
                            }
                        }
                    }
                    blockCount++;
                }
            }
        }

        /// <summary>
        /// Computes a HOG descriptor vector from the given image, with the settings from the constructor.
        /// </summary>
        /// <param name="image">The image to be described. Must be (windowSize x windowSize).</param>
        /// <returns></returns>
        public float[] compute(Image<Bgr, byte> image)
        {
            //Get dimensions
            int height = image.Height;
            int width = image.Width;

            //Get orientation range
            int orientationRange = 0;
            if (signedGradient) orientationRange = 360;
            else orientationRange = 180;

            //Optional: Apply sqrt gamma correction
            if (gammaCorrection) image._GammaCorrect(0.5);

            //Optional: Smooth window
            //if(gaussianBlur > 0) image._SmoothGaussian(gaussianBlur);

            //Convolve image with first order derivative mask
            //ConvolutionKernelF[] masks = getDerivativeMasks(DerivativeMask.Sobel3D);
            //Image<Bgr, float> dxImage = image.Convolution(masks[0]);
            //Image<Bgr, float> dyImage = image.Convolution(masks[1]);
            Image<Bgr, float> dxImage = image.Sobel(1, 0, 3);
            Image<Bgr, float> dyImage = image.Sobel(0, 1, 3);

            //Calculate and store gradient magnitude and orientation for each pixel
            float[, ,] dxImageData = dxImage.Data;
            float[, ,] dyImageData = dyImage.Data;
            double[,] orientations = new double[height, width];
            double[,] magnitudes = new double[height, width];

            double[] orientationHistogram = new double[orientationRange];

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    double orientation = 0;
                    double magnitude = 0;
                    double largestMagnitude = 0;
                    for (int channel = 0; channel < 3; channel++)
                    {
                        magnitude = Math.Sqrt(Math.Pow(dxImageData[i, j, channel], 2) + Math.Pow(dyImageData[i, j, channel], 2));
                        if (magnitude > largestMagnitude)
                        {
                            largestMagnitude = magnitude;
                            orientation = Math.Atan2(dyImageData[i, j, channel], dxImageData[i, j, channel]) * 180.0 / Math.PI; //[-180,180]
                            //Convert to signed or unsigned orientation
                            if (orientation < 0)
                            {
                                orientation += orientationRange;//[0,180) or [0,360)
                            }
                        }
                    }
                    magnitudes[i, j] = largestMagnitude;
                    orientations[i, j] = orientation;
                    //int index = (int)Math.Round(orientation, MidpointRounding.AwayFromZero);
                    //if (index == orientationHistogram.Length) index = 0;
                    //orientationHistogram[index]++;
                }
            }

            /*//Rotation invariance feature
            if (rotationInvariance)
            {
                double largestValue = 0;
                int largestBin = 0;
                for (int i = 0; i < orientationHistogram.Length; i++)
                {
                    if (orientationHistogram[i] > largestValue)
                    {
                        largestValue = orientationHistogram[i];
                        largestBin = i;
                    }
                }
                for (int i = 0; i < orientations.GetLength(0); i++)
                {
                    for (int j = 0; j < orientations.GetLength(1); j++)
                    {
                        orientations[i, j] -= largestBin;
                        if (orientations[i, j] < 0) orientations[i, j] += orientationHistogram.Length;
                    }
                }
            }*/

            //Initialise histogram
            double[, ,] histograms = new double[blocksPerWindow, cellsPerBlock, numberOfBins];

            //Divide image into overlapping blocks
            int blockCount = 0;
            int binStep = orientationRange / numberOfBins;

            //Perform histogram vote interpolation for every cell in each block
            for (int blockStartX = 0; blockStartX < (height - blockStride); blockStartX += blockStride)
            {
                int blockEndX = blockStartX + blockSize * cellSize;
                for (int blockStartY = 0; blockStartY < (width - blockStride); blockStartY += blockStride)
                {
                    int blockEndY = blockStartY + blockSize * cellSize;
                    for (int y = blockStartY; y < blockEndY; y++)
                    {
                        for (int x = blockStartX; x < blockEndX; x++)
                        {
                            //Get block specific indices
                            int i = x - blockStartX;
                            int j = y - blockStartY;

                            //Calculate orientation bin interpolation weighting
                            double orientation = orientations[x, y];
                            double[] orientationWeights = new double[2];
                            int[] orientationBins = new int[2];
                            double angle = orientations[x, y] / binStep - 0.5;
                            int angleFloor = (int)Math.Floor(angle);
                            angle -= angleFloor;

                            orientationWeights[0] = 1.0 - angle;
                            orientationWeights[1] = angle;

                            if (angleFloor < 0)
                            {
                                angleFloor += numberOfBins;
                            }
                            else if (angleFloor >= numberOfBins)
                            {
                                angleFloor -= numberOfBins;
                            }

                            orientationBins[0] = angleFloor;
                            angleFloor++;
                            angleFloor &= angleFloor < numberOfBins ? -1 : 0;
                            orientationBins[1] = angleFloor;

                            //Perform trilinear interpolation
                            for (int k = 0; k < 4; k++)
                            {
                                for (int n = 0; n < 2; n++)
                                {
                                    histograms[blockCount, spatialBins[blockCount, i, j, k], orientationBins[n]] += magnitudes[x, y] * spatialWeights[blockCount, i, j, k] * orientationWeights[n];
                                }
                            }
                        }
                    }
                    blockCount++;
                }
            }

            //Perform L2-Hys normalization and return 1D final descriptor
            float[] finalDescriptor = new float[blocksPerWindow * cellsPerBlock * numberOfBins];
            for (int block = 0; block < blocksPerWindow; block++)
            {
                //Normalise
                double sum = 0;
                for (int cell = 0; cell < cellsPerBlock; cell++)
                {
                    for (int bin = 0; bin < numberOfBins; bin++)
                    {
                        sum += histograms[block, cell, bin] * histograms[block, cell, bin];
                    }
                }
                double scale = 1.0 / (Math.Sqrt(sum) + numberOfBins * cellsPerBlock * 0.1);
                //Clip
                sum = 0;
                for (int cell = 0; cell < cellsPerBlock; cell++)
                {
                    for (int bin = 0; bin < numberOfBins; bin++)
                    {
                        histograms[block, cell, bin] = Math.Min(histograms[block, cell, bin] * scale, l2HysThreshold);
                        sum += histograms[block, cell, bin] * histograms[block, cell, bin];
                    }
                }
                scale = 1.0 / (Math.Sqrt(sum) + 0.001);
                //Renormalise
                for (int cell = 0; cell < cellsPerBlock; cell++)
                {
                    for (int bin = 0; bin < numberOfBins; bin++)
                    {
                        histograms[block, cell, bin] *= scale;
                        finalDescriptor[block * cellsPerBlock * numberOfBins + cell * numberOfBins + bin] = Convert.ToSingle(histograms[block, cell, bin]);
                    }
                }
            }
            return finalDescriptor;
        }

        /// <summary>
        /// Visually represents the HOG descriptor via star diagrams for each cell.
        /// </summary>
        /// <param name="image">The image from which the HOG descriptor was previously generated.</param>
        /// <param name="descriptor">The descriptor returned via the HOG computation.</param>
        /// <param name="scaleFactor">The scale factor determines how large the original image is resized in order to be more visually pleasing.</param>
        /// <returns></returns>
        public Image<Bgr,byte> visualise(Image<Bgr,byte> image, float[] descriptor, int scaleFactor)
        {
            Image<Bgr, byte> visual = image.Resize(scaleFactor, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            double binStep = 0;
            if (signedGradient) binStep = 2 * Math.PI / numberOfBins;
            else binStep = Math.PI / numberOfBins;

            int uniqueCellsPerWindow = (int)Math.Pow(windowSize/cellSize,2);

            double[,,] gradientMagnitudes = new double[windowSize / cellSize, windowSize / cellSize, numberOfBins];
            int[,] cellUpdateCounter = new int[windowSize / cellSize, windowSize / cellSize];

            for (int i = 0; i < windowSize / cellSize; i++)
            {
                for (int j = 0; j < windowSize / cellSize; j++)
                {
                    cellUpdateCounter[i,j] = 0;
                    for (int k = 0; k < numberOfBins; k++)
                    {
                        gradientMagnitudes[i,j,k] = 0.0;
                    }
                }
            }

            int descriptorIndex = 0;
            for (int blockX = 0; blockX < (windowSize / cellSize - 1); blockX++)
            {
                for (int blockY = 0; blockY < (windowSize / cellSize - 1); blockY++)
                {
                    for (int cell = 0; cell < 4; cell++)
                    {
                        int cellX = blockX;
                        int cellY = blockY;
                        if (cell == 1) cellY++;
                        if (cell == 2) cellX++;
                        if (cell == 3)
                        {
                            cellX++;
                            cellY++;
                        }

                        for (int bin = 0; bin < numberOfBins; bin++)
                        {
                            double gradientMagnitude = descriptor[descriptorIndex];
                            descriptorIndex++;

                            gradientMagnitudes[cellX, cellY, bin] += gradientMagnitude;
                        }

                        cellUpdateCounter[cellX, cellY]++;
                    }
                }
            }

            for (int cellX = 0; cellX < windowSize / cellSize; cellX++)
            {
                for (int cellY = 0; cellY < windowSize / cellSize; cellY++)
                {
                    for (int bin = 0; bin < numberOfBins; bin++)
                    {
                        gradientMagnitudes[cellX, cellY, bin] /= (double)cellUpdateCounter[cellX, cellY];
                    }
                }
            }

            for (int cellX = 0; cellX < windowSize / cellSize; cellX++)
            {
                for (int cellY = 0; cellY < windowSize / cellSize; cellY++)
                {
                    int drawX = cellX * cellSize;
                    int drawY = cellY * cellSize;

                    double mx = drawX + cellSize / 2.0;
                    double my = drawY + cellSize / 2.0;

                    for (int bin = 0; bin < numberOfBins; bin++)
                    {
                        double currentGradientMagnitude = gradientMagnitudes[cellX, cellY, bin];
                        if (currentGradientMagnitude != 0)
                        {
                            double currentGradientOrientation = bin * binStep + binStep / 2;

                            double xVectorComponent = Math.Cos(currentGradientOrientation);
                            double yVectorComponent = Math.Sin(currentGradientOrientation);

                            double maximumVectorLength = cellSize / 2;
                            double visualScale = 3;
                            double xVectorScale = xVectorComponent * currentGradientMagnitude * maximumVectorLength * visualScale;
                            double yVectorScale = yVectorComponent * currentGradientMagnitude * maximumVectorLength * visualScale;
                            double x1 = 0, x2 = 0, y1 = 0, y2 = 0;
                            if (signedGradient)
                            {
                                x1 = mx;
                                y1 = my;
                                x2 = mx + xVectorScale;
                                y2 = my + yVectorScale;
                            }
                            else
                            {
                                x1 = mx - xVectorScale;
                                y1 = my - yVectorScale;
                                x2 = mx + xVectorScale;
                                y2 = my + yVectorScale;
                            }

                            visual.Draw(new LineSegment2D(new Point((int)x1*scaleFactor, (int)y1*scaleFactor), new Point((int)x2*scaleFactor, (int)y2*scaleFactor)), new Bgr(0, 0, 255), 2);
                        }
                    }
                }
            }
            return visual;
        }

        /// <summary>
        /// Returns a 2D Gaussian spatial window of specified size and standard deviation.
        /// </summary>
        /// <param name="size">Size of the window.</param>
        /// <param name="sigma">Standard deviation of the Gaussian distribution.</param>
        /// <returns></returns>
        public static double[,] getGaussianSpatialWindow(int size, double sigma = -1)
        {
            sigma = sigma >= 0 ? sigma : size / 4.0;
            double[,] gaussianWindow = new double[size, size];
            double scale = 1.0 / (sigma * sigma * 2);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double x = i - (size * 0.5);
                    double y = j - (size * 0.5);
                    //if (size % 2 == 0)
                    //{
                    //    x += 0.5;
                    //    y += 0.5;
                    //}
                    gaussianWindow[i, j] = Math.Exp(-1 * ((Math.Pow(x, 2) + Math.Pow(y, 2)) * scale));
                }
            }
            return gaussianWindow;
        }

        /// <summary>
        /// Returns one of the designated derivative masks in the form of a ConvolutionKernelF.
        /// </summary>
        /// <param name="type">Derivative mask type. Includes 1D (centred, uncentred and cubic-corrected), 2D (Roberts cross) and 3D (Sobel, Prewitt).</param>
        /// <returns></returns>
        public static ConvolutionKernelF[] getDerivativeMasks(DerivativeMask type)
        {
            float[,] dxMask = new float[0, 0];
            float[,] dyMask = new float[0, 0];

            switch (type)
            {
                case DerivativeMask.Centred1D:
                    dxMask = new float[1, 3]; dyMask = new float[1, 3];
                    dxMask[0, 0] = -1; dyMask[0, 0] = 1;
                    dxMask[0, 1] = 0; dyMask[0, 1] = 0;
                    dxMask[0, 2] = 1; dyMask[0, 2] = -1;
                    break;

                case DerivativeMask.CubicCorrected1D:
                    dxMask = new float[1, 5]; dyMask = new float[1, 5];
                    dxMask[0, 0] = 1; dyMask[0, 0] = -1;
                    dxMask[0, 1] = -8; dyMask[0, 1] = 8;
                    dxMask[0, 2] = 0; dyMask[0, 2] = 0;
                    dxMask[0, 3] = 8; dyMask[0, 3] = -8;
                    dxMask[0, 4] = -1; dyMask[0, 4] = 1;
                    break;

                case DerivativeMask.NonCentred1D:
                    dxMask = new float[1, 2]; dyMask = new float[1, 2];
                    dxMask[0, 0] = -1; dyMask[0, 0] = 1;
                    dxMask[0, 1] = 1; dyMask[0, 1] = -1;
                    break;

                case DerivativeMask.Prewitt3D:
                    dxMask = new float[3, 3]; dyMask = new float[3, 3];
                    dxMask[0, 0] = -1; dyMask[0, 0] = -1;
                    dxMask[0, 1] = 0; dyMask[0, 1] = -1;
                    dxMask[0, 2] = 1; dyMask[0, 2] = -1;
                    dxMask[1, 0] = -1; dyMask[1, 0] = 0;
                    dxMask[1, 1] = 0; dyMask[1, 1] = 0;
                    dxMask[1, 2] = 1; dyMask[1, 2] = 0;
                    dxMask[2, 0] = -1; dyMask[2, 0] = 1;
                    dxMask[2, 1] = 0; dyMask[2, 1] = 1;
                    dxMask[2, 2] = 1; dyMask[2, 2] = 1;
                    break;

                case DerivativeMask.RobertsCross2D:
                    dxMask = new float[2, 2]; dyMask = new float[2, 2];
                    dxMask[0, 0] =  1; dyMask[0, 0] =  0;
                    dxMask[1, 0] =  0; dyMask[1, 0] =  1;
                    dxMask[0, 1] =  0; dyMask[0, 1] = -1;
                    dxMask[1, 1] = -1; dyMask[1, 1] =  0;
                    break;

                case DerivativeMask.Sobel3D:
                    dxMask = new float[3, 3]; dyMask = new float[3, 3];
                    dxMask[0, 0] = -1; dyMask[0, 0] = -1;
                    dxMask[0, 1] = 0; dyMask[0, 1] = -2;
                    dxMask[0, 2] = 1; dyMask[0, 2] = -1;
                    dxMask[1, 0] = -2; dyMask[1, 0] = 0;
                    dxMask[1, 1] = 0; dyMask[1, 1] = 0;
                    dxMask[1, 2] = 2; dyMask[1, 2] = 0;
                    dxMask[2, 0] = -1; dyMask[2, 0] = 1;
                    dxMask[2, 1] = 0; dyMask[2, 1] = 2;
                    dxMask[2, 2] = 1; dyMask[2, 2] = 1;
                    break;
            }

            return new ConvolutionKernelF[] { new ConvolutionKernelF(dxMask), new ConvolutionKernelF(dyMask) };
        }

        /// <summary>
        /// Static and outdated implementation of HOG descriptor calculator. It does not account for unsigned gradients, colour images, derivative mask selection, or local contrast normalization.
        /// </summary>
        /// <param name="input">Input image must be grayscale.</param>
        /// <param name="binSize">Gradient orientation bin size between [1,360].</param>
        /// <returns></returns>
        public static Dictionary<String, double[]> calculateHOG(Image<Gray, Byte> input, int binSize = 1)
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
            Dictionary<String, double[]> histogram = new Dictionary<String, double[]>(2)
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
