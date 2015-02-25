﻿using System;
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
        public double whiteBalance;
        public double gain;
        public double meanRedPixelIntensity;
        public double meanBluePixelIntensity;
        public double meanGreenPixelIntensity;

        public ImageAndMetadata(Image<Bgr, Byte> image, ImageMetadata metadata)
        {
            this.image = image;
            this.shutter = metadata.embeddedShutter;
            this.exposure = metadata.embeddedExposure;
            this.brightness = metadata.embeddedBrightness;
            this.whiteBalance = metadata.embeddedWhiteBalance;
            this.gain = metadata.embeddedGain;

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