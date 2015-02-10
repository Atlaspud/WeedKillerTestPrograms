using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyCapture2Managed;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ShutterVerseIlluminanceDataLogger
{
    class Camera
    {
        private uint cameraSerialNumber;

        private ManagedGigECamera camera;
        private CameraProperty exposure;
        private CameraProperty brightness;
        private CameraProperty frameRate;
        private CameraProperty gain;
        private CameraProperty shutter;
        private CameraProperty temperature;
        private CameraProperty whiteBalance;

        private ManagedImage rawImage, convertedImage;

        public Camera(uint serialNumber)
        {
            this.cameraSerialNumber = serialNumber;
            camera = new ManagedGigECamera();
            ManagedBusManager busManager = new ManagedBusManager();
            ManagedPGRGuid guid = busManager.GetCameraFromSerialNumber(serialNumber);
            camera.Connect(guid);
            InitialiseCamera();
        }

        private void InitialiseCamera()
        {
            //Image size = 1280x1024, raw8 format, no offset
            GigEImageSettings imageSettings = new GigEImageSettings();
            imageSettings.offsetX = 0;
            imageSettings.offsetY = 0;
            imageSettings.height = 1024;
            imageSettings.width = 1280;
            imageSettings.pixelFormat = PixelFormat.PixelFormatRaw8;
            camera.SetGigEImageSettings(imageSettings);

            setAutoExposure();
            setAutoBrightness();
            setFrameRate(1.0);
            setShutterSpeed(100);
            setAutoGain(0,255);
            setWhiteBalance(1023,1023);

        }

        public void start()
        {
            camera.StartCapture();
        }

        public void stop()
        {
            camera.StopCapture();
        }

        public Image<Bgr, Byte> getImage()
        {
            rawImage = new ManagedImage();
            convertedImage = new ManagedImage();
            camera.RetrieveBuffer(rawImage);
            rawImage.Convert(PixelFormat.PixelFormatBgr, convertedImage);
            try
            {

            }
            catch
            {

            }
            return new Image<Bgr, Byte>(convertedImage.bitmap);
            
        }

        public void setExposure(double value)
        {
            exposure = new CameraProperty(PropertyType.AutoExposure);
            exposure.onOff = true;
            exposure.autoManualMode = false;
            exposure.absControl = true;
            exposure.absValue = (float)value;
            camera.SetProperty(exposure);
        }

        public void setAutoExposure(double lower = 0, double upper = 0)
        {
            exposure = new CameraProperty(PropertyType.AutoExposure);
            exposure.onOff = true;
            exposure.autoManualMode = true;
            exposure.absControl = true;
            camera.SetProperty(exposure);
        }

        public void setBrightness(double value)
        {
            brightness = new CameraProperty(PropertyType.Brightness);
            brightness.onOff = true;
            brightness.autoManualMode = false;
            brightness.absControl = true;
            brightness.absValue = (float)value;
            camera.SetProperty(brightness);
        }

        public void setAutoBrightness(double lower = 0, double upper = 0)
        {
            brightness = new CameraProperty(PropertyType.Brightness);
            brightness.onOff = true;
            brightness.autoManualMode = true;
            brightness.absControl = true;
            camera.SetProperty(brightness);
        }

        public void setFrameRate(double value)
        {
            frameRate = new CameraProperty(PropertyType.FrameRate);
            frameRate.onOff = true;
            frameRate.autoManualMode = false;
            frameRate.absControl = true;
            frameRate.absValue = (float)value;
            camera.SetProperty(frameRate);
        }

        public void setShutterSpeed(double value)
        {
            shutter = new CameraProperty(PropertyType.Shutter);
            shutter.onOff = true;
            shutter.autoManualMode = false;
            shutter.absControl = true;
            shutter.absValue = (float)value;
            camera.SetProperty(shutter);
        }

        public void setAutoShutter(double lower = 0, double upper = 0)
        {
            shutter = new CameraProperty(PropertyType.Shutter);
            shutter.onOff = true;
            shutter.autoManualMode = true;
            shutter.absControl = true;
            camera.SetProperty(shutter);
        }

        public void setGain(double value)
        {
            gain = new CameraProperty(PropertyType.Gain);
            gain.onOff = true;
            gain.autoManualMode = false;
            gain.absControl = true;
            camera.SetProperty(gain);
            //camera.WriteRegister(0x10A0, 0xC30000FF); //auto gain range
        }

        public void setAutoGain(double lower, double upper)
        {
            gain = new CameraProperty(PropertyType.Gain);
            gain.onOff = true;
            gain.autoManualMode = true;
            gain.absControl = true;
            camera.SetProperty(gain);
            uint range = 0xC30000FF; //lower = 000 (0) and upper = 255 (0FF)
            camera.WriteRegister(0x10A0, 0xC30000FF);
        }

        public void setWhiteBalance(double red, double blue)
        {
            whiteBalance = new CameraProperty(PropertyType.WhiteBalance);
            whiteBalance.onOff = true;
            whiteBalance.autoManualMode = true;
            camera.SetProperty(whiteBalance);
        }

        public void setAutoWhiteBalance(double redLower, double redUpper, double blueLower, double blueUpper)
        {
            whiteBalance = new CameraProperty(PropertyType.WhiteBalance);
            whiteBalance.onOff = true;
            whiteBalance.autoManualMode = true;
            camera.SetProperty(whiteBalance);
        }

        public void enableTemperature()
        {
            temperature = new CameraProperty(PropertyType.Temperature);
            temperature.onOff = true;
            temperature.absControl = true;
            camera.SetProperty(temperature);
        }

        public void disableTemperature()
        {
            temperature = new CameraProperty(PropertyType.Temperature);
            temperature.onOff = false;
            camera.SetProperty(temperature);
    }
}
