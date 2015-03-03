using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace AutomaticExposureTest
{
    public static class ImageProcessor
    {
        public static double[] meanPixelIntensity(Image<Bgr, Byte> image)
        {
            double meanBlue = 0;
            double meanGreen = 0;
            double meanRed = 0;

            Byte[, ,] data = image.Data;

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    meanBlue += ((double)data[i, j, 0] / ((double)image.Height * (double)image.Width));
                    meanGreen += ((double)data[i, j, 1] / ((double)image.Height * (double)image.Width));
                    meanRed += ((double)data[i, j, 2] / ((double)image.Height * (double)image.Width));
                }
            }
            return new double[] { meanBlue, meanGreen, meanRed };
        }
    }
}
