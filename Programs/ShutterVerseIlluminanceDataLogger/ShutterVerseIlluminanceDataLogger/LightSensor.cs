using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShutterVerseIlluminanceDataLogger
{
    class LightSensor
    {
        //Declare global properties
        private SerialPort serialPort;
        private string portName;
        private int baudRate;
        private int sensorCount;

        //Light sensor output in lux
        private double[] lightSensorOutput;
        
        //Event handler for new light sensor output
        public event LightSensorDataReceivedEventHandler LightSensorDataReceived;

        /*
         * Default Constructor for Light Sensor
         * 
         * Passes serial port and number of sensors to read from.
         */
        public LightSensor(String portName, int sensorCount = 8)
        {
            //Instantiate global properties
            this.portName = portName;
            this.sensorCount = sensorCount;
            baudRate = 9600;
            
            //Create light sensor thread and port
            serialPort = new SerialPort(this.portName, baudRate);
            lightSensorOutput = new double[this.sensorCount];
        }

        /*
         * Start reading from light sensors.
         */
        public void start()
        {
            if (!serialPort.IsOpen)
            {
                try
                {                    
                    serialPort.Open();
                    serialPort.Write("<" + sensorCount);
                    serialPort.DataReceived += serialPort_DataReceived;
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
            }
        }



        // Get latest illuminance values
        public double[] getIlluminance()
        {
            return lightSensorOutput;
        }

        /*
         * Stop reading from light sensors.
         * 
         * Passes nothing.
         * 
         * Returns null if successful or string detailing nature of error.
         */
        public void stop()
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.DataReceived -= serialPort_DataReceived;
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
            }
        }

        /*
         * Light sensor thread start method
         * 
         * Runs serial data receieved event loop thread
         *
         */
        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string message = serialPort.ReadLine();
                string[] values = message.Split(',');
                if (values.Length != sensorCount)
                {
                    return;
                }
                for (int n = 0; n < sensorCount; n++)
                {
                    lightSensorOutput[n] = Convert.ToDouble(values[n].TrimEnd('\r'));
                }
                LightSensorDataReceivedEventArgs args = new LightSensorDataReceivedEventArgs();
                args.data = lightSensorOutput;
                args.time = DateTime.Now;
                OnLightSensorDataReceived(args);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void OnLightSensorDataReceived(LightSensorDataReceivedEventArgs e)
        {
            LightSensorDataReceivedEventHandler handler = LightSensorDataReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
