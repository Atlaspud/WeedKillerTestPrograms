using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotionController
{
    class IMU
    {
        //Serial Port Variables
        private SerialPort serialPort;
        private int periodMSB;
        private int periodLSB;
        private string port;
        private int baudRate;
        private Parity parity;
        private int dataBits;
        private StopBits stopBits;
        private int count;

        //Data
        private double currentYaw;
        private double currentPitch;
        private double currentRoll;
        
        //Threading
        private Thread imuThread;

        public IMU(String port)
        {
            //Serial Port Config
            this.port = port;
            baudRate = 115200;
            parity = Parity.None;
            dataBits = 8;
            stopBits = StopBits.One;
            periodMSB = 5;
            periodLSB = 6;
            count = 0; 

            //Thread 
            imuThread = new Thread(new ThreadStart(newData));

            //Serial Port Config
            serialPort = new SerialPort(port, baudRate, parity, dataBits, stopBits);
        }

        public String initConnection()
        {

            if (!serialPort.IsOpen)
            {
                // Open Serial Port and Thread for Autoblock
                try
                {
                    serialPort.Open();
                    imuThread.Start();
                }
                catch (IOException e)
                {
                    //return "Bad: " + e;
					return "Bad";
                }

            }
            return "Good";
        }

        public void closeConnection()
        {
            //Close Serial Port
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }

            //Stop Autoblock Thread
            if (imuThread.IsAlive)
            {
                imuThread.Abort();
            }
        }

        public double getCurrentYaw()
        {
            return currentYaw;
        }

        public double getCurrentPitch()
        {
            return currentPitch;
        }

        public double getCurrentRoll()
        {
            return currentRoll;
        }

        private void newData()
        {
            serialPort.DataReceived += serialPort_DataReceived;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            
            //Check Serial Port is open
            if (!sp.IsOpen)
            {
                return;
            }

            //Get message from serial
            try
            {
                string message = sp.ReadLine();
                string[] data = message.Split(',');

                for (int n = 0; n < data.Length; n++)
                {
                    switch (n) 
                    { 
                        case 0:
                            currentYaw = Convert.ToDouble(data[n].Substring(4, data[n].Length));
                        break;
                        case 1:
                            currentPitch = Convert.ToDouble(data[n]);
                        break;
                        case 2:
                            currentRoll = Convert.ToDouble(data[n]);
                        break; 
                    }
                }
            }
            catch
            {
                
            } 
        }












    }
}
