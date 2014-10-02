using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace WheelSpeedSensorTest
{
    class WheelSpeedSensor
    {
        // 
        private int pulsesPerRevolution;
        private double wheelRadius;

        //Serial Port Variables
        private SerialPort serialPort;
        private int periodMSB;
        private int periodLSB;
        private int terminatingByte;
        private int escapeByte;
        private string port;
        private int baudRate;
        private Parity parity;
        private int dataBits;
        private StopBits stopBits;

        // Time information
        private DateTime time1;
        private DateTime time2;
        private double timeDelta;
        private int count;
        private double oldVelocity;
        private double currentVelocity;

        //Threading
        Thread autoblockThread;

        /*
         * Default Constructor will uses the same settings 
         * as the ones used in Motion Tracker 2 
         * 
         * COM port is Passed
         * 
         */
        public WheelSpeedSensor(string port)
        {
            //default constructor
            pulsesPerRevolution = 12;
            wheelRadius = 0.164;

            //Serial Port Config
            periodMSB = 5;
            periodLSB = 6;
            terminatingByte = 192;
            escapeByte = 219;
            this.port = port; //COM Port passed in at the moment
            // AUTO COM PORT CONFIGURE ROUTINE? <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            baudRate = 115200;
            parity = Parity.None;
            dataBits = 8;
            stopBits = StopBits.One;

            //Set count to 0
            count = 0; 

            //Autoblock thread 
            autoblockThread = new Thread(new ThreadStart(newData));
            
            //Serial Port Config
            serialPort = new SerialPort(port, baudRate, parity, dataBits, stopBits);

            // Open Serial Port for Autoblock
            try
            {
                serialPort.Open();
                autoblockThread.Start();
            }
            //catch (IOException)
            catch (IOException e)
            {
                Console.WriteLine(e); //This is here to get the error to go away
                //SERIAL MESSAGE ERROR HERE<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                //FLAGS? 
            }
        }

        // STOPING CODE (Finalize) (do this properly) <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public void closeSerialPort()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }

            //PROPERLY CHECK AND STOP THREAD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            autoblockThread.Abort(); 
        } 

        public double getCurrentVelocity()
        {
            return currentVelocity;
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
            int message = sp.ReadByte();
            if (message == terminatingByte)
            {
                int[] payload = new int[8];
                int i = 0;
                if (!serialPort.IsOpen)
                {
                    return;
                }
                message = serialPort.ReadByte();
                string output = "" + message;
                while (message != terminatingByte)
                {
                    if (message == escapeByte)
                    {
                        if (!serialPort.IsOpen)
                        {
                            return;
                        }
                        message = serialPort.ReadByte();
                        switch (message)
                        {
                            case 220:
                                message = terminatingByte;
                                break;
                            case 221:
                                message = escapeByte;
                                break;
                        }
                    }
                    payload[i++] = message;
                    output += " " + message;
                    if (!serialPort.IsOpen)
                    {
                        return;
                    }
                    message = serialPort.ReadByte();
                }

                
                if (count == 0)
                {
                    time1 = DateTime.Now;
                    oldVelocity = calculateVelocity(payload[periodMSB], payload[periodLSB], pulsesPerRevolution, wheelRadius);
                }
                else
                {
                    time2 = DateTime.Now;
                    currentVelocity = calculateVelocity(payload[periodMSB], payload[periodLSB], pulsesPerRevolution, wheelRadius);
                    timeDelta = (double)(time2.Ticks - time1.Ticks) / 10000000.0;

                    //distance += timedelta * (velocity1 + velocity2) / 2.0;

                    time1 = time2;
                    oldVelocity = currentVelocity;
                }
                count++;
            }
        }

        private static double calculateVelocity(int msb, int lsb, int pulsesPerRevolution, double wheelRadius)
        {
            int period = msb * 256 + lsb;
            double velocity;
            if (period == 0)
            {
                velocity = 0.0;
            }
            else
            {
                velocity = 57600.0 / ((double)pulsesPerRevolution * (double)period) * (2.0 * Math.PI * wheelRadius);
            }
            return velocity;
        }


    }
}
