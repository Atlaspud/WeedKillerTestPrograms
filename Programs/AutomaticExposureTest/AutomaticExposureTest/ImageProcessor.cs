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
                    meanBlue += ((int)data[i, j, 0] / (image.Height * image.Width));
                    meanGreen += ((int)data[i, j, 1] / (image.Height * image.Width));
                    meanRed += ((int)data[i, j, 2] / (image.Height * image.Width));
                }
            }
            return new double[] { meanBlue, meanGreen, meanRed };
        }
    }
}
