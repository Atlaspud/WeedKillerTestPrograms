using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyCapture2Managed;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace AutomaticExposureExperiment
{
    public class ImageAndMetadata
    {
        public Image<Bgr, Byte> image;
        public double shutter;
        public double exposure;
        public double brightness;
        public double whiteBalanceBlue;
        public double whiteBalanceRed;
        public double gain;
        public double meanRedPixelIntensity;
        public double meanBluePixelIntensity;
        public double meanGreenPixelIntensity;

        public ImageAndMetadata(Image<Bgr, Byte> image, ImageMetadata metadata)
        {
            this.image = image;


            this.shutter = metadata.embeddedShutter & 0x00000FFF;
            this.exposure = metadata.embeddedExposure &  0x00000FFF;
            this.brightness = metadata.embeddedBrightness & 0x00000FFF;
            this.whiteBalanceBlue = (metadata.embeddedWhiteBalance & 0x00FFF000) >> 12;
            this.whiteBalanceRed = (metadata.embeddedWhiteBalance & 0x00000FFF); 
            this.gain = metadata.embeddedGain - 0xC3000000;

            this.meanRedPixelIntensity = 0;
            this.meanBluePixelIntensity = 0;
            this.meanGreenPixelIntensity = 0;

            Byte[, ,] data = image.Data;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    this.meanBluePixelIntensity += ((double)data[i, j, 0] / ((double)image.Height * (double)image.Width));
                    this.meanGreenPixelIntensity += ((double)data[i, j, 1] / ((double)image.Height * (double)image.Width));
                    this.meanRedPixelIntensity += ((double)data[i, j, 2] / ((double)image.Height * (double)image.Width));
                }
            }
        }
    }
}
