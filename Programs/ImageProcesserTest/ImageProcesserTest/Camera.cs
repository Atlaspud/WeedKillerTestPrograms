using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyCapture2Managed;
using System.Windows.Forms;
using System.IO;

namespace ImageProcessorTest
{
    public class Camera
    {
        // Static Members
        public enum Property { Shutter, Gain, Illuminance, FrameRate, AutoExposure, Brightness, Temperature, WhiteBalance };
        public static readonly uint[] SerialNumbers = new uint[8]
        {
            //13421033,
            //13421041,
            13421043,
            13421046,
            13421051,
            13421053,
            5,6,7,8
            //13421056,
            //13421057
        };
        private static double GlobalFrameRate = 2.5;

        // Instance Members
        private ManagedGigECamera camera;
        private uint serialNumber;
        public event CameraFrameReceivedEventHandler CameraFrameReceived;
        private double illuminance;
        private CameraProperty autoExposure;
        private CameraProperty brightness;
        private CameraProperty frameRate;
        private CameraProperty gain;
        private CameraProperty shutter;
        private CameraProperty temperature;
        private CameraProperty whiteBalance;
        private int frameCount;
        private StreamWriter cameraLog;

        /*
         * Camera constructor
         * 
         * Creates, initialises and connects to a new camera object, with specified serial number and display box.
         * Inputs: Camera serial number and optional picture box
         * Output: None
         */
        public Camera(uint serialNumber)
        {
            this.serialNumber = serialNumber;
            camera = new ManagedGigECamera();
            ManagedBusManager busManager = new ManagedBusManager();
            ManagedPGRGuid guid = busManager.GetCameraFromSerialNumber((uint)serialNumber);
            camera.Connect(guid);
            InitialiseCamera();
            cameraLog = new StreamWriter(Directory.GetCurrentDirectory() + "/Camera" + serialNumber + ".csv", true);
            cameraLog.WriteLine("Serial Number, Frame Count, Time Received, Brightness, Exposure, Frame Rate, Gain, Illuminance, Shutter, White Balance");
        }

        public static int GetNumberOfCameras()
        {
            ManagedBusManager busManager = new ManagedBusManager();
            return (int)busManager.GetNumOfCameras();
        }

        /*
         * InitialiseCamera
         * 
         * Initialises camera image settings and properties
         * 
         */

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

            //Frame rate set manually, initialised to 2.5fps
            frameRate = new CameraProperty(PropertyType.FrameRate);
            frameRate.onOff = true;
            frameRate.autoManualMode = false;
            frameRate.absControl = true;
            frameRate.absValue = (float) GlobalFrameRate;
            camera.SetProperty(frameRate);

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

        public static void SetGlobalFrameRate(double frameRate)
        {
            GlobalFrameRate = frameRate;
        }

        /*
         * SetProperty
         * 
         * Input: Property enum type and value
         * 
         * Output: No return. Sets specified camera property and value.
         */
        public void SetProperty(Property property, double value)
        {
            switch (property)
            {
                case Property.FrameRate:
                    frameRate.absValue = (float)value;
                    camera.SetProperty(frameRate);
                    break;

                case Property.Gain:
                    gain.absValue = (float)value;
                    camera.SetProperty(gain);
                    break;

                case Property.Illuminance:
                    illuminance = value;
                    break;

                case Property.Shutter:
                    shutter.absValue = (float) value;
                    camera.SetProperty(shutter);
                    break;
            }
        }
        
        /*
         * StartCapture
         * 
         * Starts capturing frames from camera and triggering specified callback.
         * 
         * Inputs: None
         * Outputs: None
         *
         */
        public void StartCapture()
        {
            camera.StartCapture(CameraFrameReceivedCallback);
            frameCount = 0;
        }

        /*
         * CameraFrameReceivedCallback
         * 
         * Converts raw image to BGR format and fires frame received event to subscribing threads.
         * 
         * Inputs: StartCapture passes 
         * Outputs: None
         * 
         */

        private void CameraFrameReceivedCallback(ManagedImage rawImage)
        {
            frameCount++;
            //Get timestamp and convert image into necessary format
            DateTime time = DateTime.Now;
            ManagedImage convertedImage = new ManagedImage();
            rawImage.Convert(PixelFormat.PixelFormatBgr, convertedImage);

            //Fire CameraFrameReceivedEvent
            CameraFrameReceivedEventArgs args = new CameraFrameReceivedEventArgs();
            args.image = convertedImage.bitmap;
            args.time = time;
            args.serial = serialNumber;
            args.brightness = camera.GetProperty(PropertyType.Brightness).absValue;
            args.exposure = camera.GetProperty(PropertyType.AutoExposure).absValue;
            args.frameRate = camera.GetProperty(PropertyType.FrameRate).absValue;
            args.gain = camera.GetProperty(PropertyType.Gain).absValue;
            args.illuminance = illuminance;
            args.shutter = camera.GetProperty(PropertyType.Shutter).absValue;
            args.whiteBalanceA = (int) camera.GetProperty(PropertyType.WhiteBalance).valueA;
            args.whiteBalanceB = (int) camera.GetProperty(PropertyType.WhiteBalance).valueB;
            OnCameraFrameReceived(args);
            
            //Log camera frame data
            cameraLog.WriteLine(serialNumber + "," + frameCount + "," + time.TimeOfDay + "," + args.brightness + "," + args.exposure + "," +
                args.frameRate + "," + args.gain + "," + args.illuminance + "," + args.shutter + "," + args.whiteBalanceA + "-" + args.whiteBalanceB);

            //Update shutter speed
            SetProperty(Property.Shutter, -0.1682 * illuminance + 210.43);
            SetProperty(Property.FrameRate, GlobalFrameRate);
        }

        protected virtual void OnCameraFrameReceived(CameraFrameReceivedEventArgs e)
        {
            CameraFrameReceivedEventHandler handler = CameraFrameReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void StopCapture()
          {
            if (camera.IsConnected())
            {
                camera.StopCapture();
            }

        }

        public uint GetSerial()
        {
            return serialNumber;
        }
    }
}
