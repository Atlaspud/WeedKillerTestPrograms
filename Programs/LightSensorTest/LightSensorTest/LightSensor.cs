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
        private Thread thread;
        private Boolean isReading;

        //Light sensor output in lux
        private double[] lightSensorOutput;
        
        //Event handler for new light sensor output
        public event LightSensorEventHandler NewLightSensorOutput;

        /*
         * Default Constructor for Light Sensor
         * 
         * Passes serial port.
         */
        public LightSensor(String portName)
        {
            //Instantiate global properties
            this.portName = portName;
            baudRate = 9600;
            isReading = false;
            
            //Create light sensor thread and port
            serialPort = new SerialPort(this.portName, baudRate);
            thread = new Thread(lightSensorEventLoop);
            thread.Name = "LightSensorThread";
            lightSensorOutput = new double[8];
        }

        /*
         * Start reading from light sensors.
         * 
         * Passes number of sensors to read from. Maximum and default is 8.
         * 
         * Returns null if successful or string detailing nature of error.
         */
        public string start(int sensorCount = 8)
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
                    isReading = true;
                    thread.Start();
                }
                catch (Exception e)
                {
                    return e.ToString();
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
            isReading = false;
            if (serialPort.IsOpen)
            {
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
        private void lightSensorEventLoop()
        {
            serialPort.DataReceived += (object sender, SerialDataReceivedEventArgs e) =>
            {
                string data = serialPort.ReadLine();
                string[] values = data.Split(',');
                if (values.Length != 8)
                {
                    return;
                }
                for (int n = 0; n < 8; n++)
                {
                    try
                    {
                        lightSensorOutput[n] = Convert.ToDouble(values[n].TrimEnd('\r'));
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }

                }
                //Fire new light sensor output event
                if (NewLightSensorOutput != null)
                {
                    NewLightSensorOutput(this, new LightSensorEventArgs("", lightSensorOutput));
                }
            };
        }

        /*
         * Get method for light sensor output
         */
        public double[] getLightSensorOutput()
        {
            return lightSensorOutput;
        }

    }

    //Custom event handler for new light sensor output
    public delegate void LightSensorEventHandler(object source, LightSensorEventArgs e);

    //EventArgs class that describes the event to the class that recieves it.
    public class LightSensorEventArgs : EventArgs
    {
        private string eventInfo;
        private double[] lightSensorOutput;

        public LightSensorEventArgs(string eventInfo, double[] lightSensorOutput)
        {
            this.eventInfo = eventInfo;
            this.lightSensorOutput = lightSensorOutput;
        }

        public string getInfo()
        {
            return eventInfo;
        }

        public double[] getOutput()
        {
            return lightSensorOutput;
        }
    }
}
