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
        private double illuminance;
        private CameraProperty autoExposure;
        private CameraProperty brightness;
        private CameraProperty frameRate;
        private CameraProperty gain;
        private CameraProperty shutter;
        private CameraProperty temperature;
        private CameraProperty whiteBalance;

        private ManagedImage _image, rbgImage;

        public Camera(uint serialNumber)
        {
            this.cameraSerialNumber = serialNumber;
            camera = new ManagedGigECamera();
            ManagedBusManager busManager = new ManagedBusManager();
            ManagedPGRGuid guid = busManager.GetCameraFromSerialNumber((uint)serialNumber);
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

            //Exposure set automatically
            autoExposure = new CameraProperty(PropertyType.AutoExposure);
            autoExposure.onOff = true;
            autoExposure.autoManualMode = true;
            autoExposure.absControl = true;
            camera.SetProperty(autoExposure);

            //Brightness set automatically
            brightness = new CameraProperty(PropertyType.Brightness);
            brightness.onOff = true;
            brightness.autoManualMode = true;
            brightness.absControl = true;
            camera.SetProperty(brightness);

            //Frame rate set manually, initialised to 1fps
            //frameRate = new CameraProperty(PropertyType.FrameRate);
            //frameRate.onOff = true;
            //frameRate.autoManualMode = false;
            //frameRate.absControl = true;
            //frameRate.absValue = (float)GlobalFrameRate;
            //camera.SetProperty(frameRate);

            //Shutter speed to be set manually, initialised to 100ms
            shutter = new CameraProperty(PropertyType.Shutter);
            shutter.onOff = true;
            shutter.autoManualMode = false;
            shutter.absControl = true;
            shutter.absValue = 100;
            camera.SetProperty(shutter);

            //Gain to be set automatically with specified range
            gain = new CameraProperty(PropertyType.Gain);
            gain.onOff = true;
            gain.autoManualMode = true;
            gain.absControl = true;
            camera.SetProperty(gain);
            camera.WriteRegister(0x10A0, 0xC30000FF);

            //White balance to be set automatically
            whiteBalance = new CameraProperty(PropertyType.WhiteBalance);
            whiteBalance.onOff = true;
            whiteBalance.autoManualMode = true;
            camera.SetProperty(whiteBalance);

            //Temperature property enabled
            temperature = new CameraProperty(PropertyType.Temperature);
            temperature.onOff = true;
            temperature.absControl = true;
            camera.SetProperty(temperature);

            //Initial illuminance
            illuminance = 0;
        }

        public Image<Bgr, Byte> getImage()
        {
            _image = new ManagedImage();
            rbgImage = new ManagedImage();

            camera.StartCapture();
            camera.RetrieveBuffer(_image);
            _image.Convert(PixelFormat.PixelFormatBgr, rbgImage);
            camera.StopCapture();
            try
            {
                //camera.StartCapture();
                //camera.RetrieveBuffer(_image);
                //_image.Convert(PixelFormat.PixelFormatBgr, rbgImage);
                //camera.StopCapture();
            }
            catch
            {

            }
            return new Image<Bgr, Byte>(rbgImage.bitmap);
            
        }
    }
}
