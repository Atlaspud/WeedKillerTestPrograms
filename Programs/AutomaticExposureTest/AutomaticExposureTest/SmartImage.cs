using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyCapture2Managed;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace AutomaticExposureTest
{
    public class SmartImage
    {
        public Image<Bgr, Byte> image;
        public double shutter;
        public double exposure;
        public double brightness;
        public double whiteBalanceBlue;
        public double whiteBalanceRed;
        public double gain;
        public double[] meanPixelIntensity;

        public SmartImage(Image<Bgr, Byte> image, ImageMetadata metadata)
        {
            this.image = image;
            this.meanPixelIntensity = ImageProcessor.meanPixelIntensity(image);
            this.shutter = getAbsoluteShutter(metadata.embeddedShutter);
            this.exposure = getAbsoluteExposureValue(metadata.embeddedExposure);
            this.brightness = getAbsoluteBrightness(metadata.embeddedBrightness);
            this.whiteBalanceBlue = getWhiteBalanceBlueLevel(metadata.embeddedWhiteBalance);
            this.whiteBalanceRed = getWhiteBalanceRedLevel(metadata.embeddedWhiteBalance);
            this.gain = getAbsoluteGain(metadata.embeddedGain);
        }

        private double getAbsoluteShutter(uint shutterRegister)
        {
            double absoluteShutter;
            absoluteShutter = shutterRegister & 0x00000FFF;
            return absoluteShutter;
        }

        private double getAbsoluteExposureValue(uint exposureValueRegister)
        {
            double absoluteExposureValue;
            absoluteExposureValue = exposureValueRegister & 0x00000FFF;
            return absoluteExposureValue;
        }

        private double getAbsoluteBrightness(uint brightnessRegister)
        {
            double absoluteBrightness;
            absoluteBrightness = brightnessRegister & 0x00000FFF;
            return absoluteBrightness;
        }

        private double getAbsoluteGain(uint gainRegister)
        {
            double absoluteGain;
            absoluteGain = gainRegister & 0x00000FFF;
            return absoluteGain;
        }

        private double getWhiteBalanceBlueLevel(uint whiteBalanceRegister)
        {
            return whiteBalanceRegister & 0x00FFF000 >> 12;
        }

        private double getWhiteBalanceRedLevel(uint whiteBalanceRegister)
        {
            return whiteBalanceRegister & 0x00000FFF;
        }
    }
}
