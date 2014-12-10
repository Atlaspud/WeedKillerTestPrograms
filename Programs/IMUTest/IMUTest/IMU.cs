using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace model
{
    public class IMU
    {
        //Serial Port Variables
        private SerialPort serialPort;
        private string port;
        private int baudRate;
        private Parity parity;
        private int dataBits;
        private StopBits stopBits;
        //Data
        private double currentYaw;
        private double currentPitch;
        private double currentRoll;

        private double currentAX;
        private double currentAY;
        private double currentAZ;

        private StreamWriter textOutput = new StreamWriter(Directory.GetCurrentDirectory() + "/IMUData.csv", false);

        private IMUData currentIMUData;
        private double velocity = 1;
        private double velocityMagnitude = 0;

        private int counter;

        private double initialAx = 0;

        private Boolean initialFlag = true;

        private double direction = 1;

        public IMU(String port)
        {
            //Serial Port Config
            this.port = port;
            baudRate = 57600;
            parity = Parity.None;
            dataBits = 8;
            stopBits = StopBits.One;

            //Serial Port Config
            serialPort = new SerialPort(port, baudRate, parity, dataBits, stopBits);

        }

        public String initConnection()
        {
            currentIMUData = new IMUData();

            if (!serialPort.IsOpen)
            {
                // Open Serial Port and Thread for Autoblock
                try
                {
                    serialPort.Open();
                    serialPort.DataReceived += serialPort_DataReceived;

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
        }

        public double getCurrentYaw()
        {
            return currentIMUData.getYaw();
        }

        public double getCurrentPitch()
        {
            return currentIMUData.getPitch();
        }

        public double getCurrentRoll()
        {
            return currentIMUData.getRoll(); 
        }

        public double getCurrentAX()
        {
            return currentIMUData.getAX();
        }

        public double getCurrentAY()
        {
            return currentIMUData.getAY();
        }

        public double getCurrentAZ()
        {
            return currentIMUData.getAZ();
        } 
        public delegate void YawUpdateHandler(object source, double yawArgs);

        public event YawUpdateHandler OnYawUpdate; 

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
                DateTime imuDataTime = DateTime.Now;
                double changeInTime = (imuDataTime.Ticks / TimeSpan.TicksPerMillisecond) - (currentIMUData.getTime().Ticks / TimeSpan.TicksPerMillisecond);
                string message = sp.ReadLine();
                string[] data = message.Split(',','=');

                for (int n = 0; n < data.Length; n++)
                {
                    switch (n)
                    {
                        case 1:
                            currentYaw = Double.Parse(data[n]);

                            //Trigger Yaw Update event
                            double yawArgs = currentYaw;
                            OnYawUpdate(this, yawArgs);

                            break;
                        case 2:
                            currentPitch = Double.Parse(data[n]);
                            break;
                        case 3:
                            currentRoll = Double.Parse(data[n].Trim());
                            break;
                        case 4:
                            currentAX = Double.Parse(data[n].Trim());
                            break;
                        case 5:
                            currentAY = Double.Parse(data[n].Trim());
                            break;
                        case 6:
                            currentAZ = Double.Parse(data[n].Trim());
                            break;
                    }
                }

                textOutput.WriteLine(currentIMUData.ToString());

                double velocity = currentAX * changeInTime / 1000;

                if (initialFlag)
                {
                    if (currentAX != 0)
                    {
                        initialAx = currentAX;
                        initialFlag = false;
                    }
                }

                if (counter == 10)
                {
                    counter = 0;
                    initialFlag = true;
                    if ((currentAX > (10)) | (currentAX < -10))
                    {
                        velocityMagnitude = velocity;
                    }
                }
                else
                {
                    counter++;
                    if ((currentAX > (10)) | (currentAX < -10))
                    {
                        velocityMagnitude += velocity;
                    }
                }

                if (velocity < -10)
                {
                    direction = -1;
                }
                else if (velocity > 10)
                {
                    direction = 1;
                }

                currentIMUData = new IMUData(imuDataTime, changeInTime, currentAX, currentAY, currentAZ, currentYaw, currentPitch, currentRoll, velocity, velocityMagnitude, direction);
            
            }
            catch
            {
               //There should probably be something here. 
            } 
        }
    }
}
