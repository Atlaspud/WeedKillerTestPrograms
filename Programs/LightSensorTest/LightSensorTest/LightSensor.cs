using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightSensorTest
{
    class LightSensor
    {
        //Declare global properties
        private SerialPort serialPort;
        private string portName;
        private int baudRate;
        private String buffer;
        private int sensorCount;

        //Light sensor output in lux
        private double[] lightSensorOutput;
        
        //Event handler for new light sensor output
        public event LightSensorDataReceivedEventHandler lightSensorDataReceieved;

        /*
         * Default Constructor for Light Sensor
         * 
         * Passes serial port.
         */
        public LightSensor(String portName, int sensorCount)
        {
            //Instantiate global properties
            this.portName = portName;
            this.sensorCount = sensorCount;
            baudRate = 9600;
            
            //Create light sensor thread and port
            serialPort = new SerialPort(this.portName, baudRate);
            lightSensorOutput = new double[sensorCount];
        }

        /*
         * Start reading from light sensors.
         * 
         * Passes number of sensors to read from. Maximum and default is 8.
         * 
         * Returns null if successful or string detailing nature of error.
         */
        public string start()
        {
            if (serialPort.IsOpen)
            {
                return portName + " is already open.";
            }
            else
            {
                try
                {                    
                    serialPort.Open();
                    serialPort.Write("<" + sensorCount);
                    serialPort.DataReceived += serialPort_DataReceived;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            return null;
        }

        /*
         * Stop reading from light sensors.
         * 
         * Passes nothing.
         * 
         * Returns null if successful or string detailing nature of error.
         */
        public string stop()
        {
            if (serialPort.IsOpen)
            {
                serialPort.DataReceived -= serialPort_DataReceived;
                serialPort.Close();
            }
            else
            {
                return portName + " is not open.";
            }
            return null;
        }

        /*
         * Light sensor thread start method
         * 
         * Runs serial data receieved event loop thread
         *
         */
        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e1)
        {
            try
            {
                string buffer = serialPort.ReadLine();
                string[] values = buffer.Split(',');
                if (values.Length != sensorCount)
                {
                    return;
                }
                for (int n = 0; n < sensorCount; n++)
                {
                    try
                    {
                        lightSensorOutput[n] = Convert.ToDouble(values[n].TrimEnd('\r'));
                    }
                    catch (FormatException e2)
                    {
                        MessageBox.Show(e2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                LightSensorDataReceivedEventArgs args = new LightSensorDataReceivedEventArgs();
                args.data = lightSensorOutput;
                args.time = DateTime.Now;
                OnLightSensorDataReceived(args);
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        protected virtual void OnLightSensorDataReceived(LightSensorDataReceivedEventArgs e)
        {
            LightSensorDataReceivedEventHandler handler = lightSensorDataReceieved;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
