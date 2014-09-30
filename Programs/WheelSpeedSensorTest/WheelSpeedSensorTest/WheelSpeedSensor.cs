using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WheelSpeedSensorTest
{
    class WheelSpeedSensor
    {
        // 
        private int PulsesPerRevolution;
        private double WheelRadius;

        //Serial Port 
        private SerialPort serialPort;
        private int BufferSize;
        private int PeriodMSB;
        private int PeriodLSB;
        private int TerminatingByte;
        private int EscapeByte;
        private string port;
        private int BaudRate;
        private Parity PARITY;
        private int DataBits;
        private StopBits STOPBITS;

        //Autoblock Data collection
        private DataCollection<DataPoint> autoblockData;
        private DataPoint targetData;
        private int targetIndex = 0;

        //Remove DEPANDANCIES?
        // Time information <<<<<<< CLEAN UP
        private DateTime time1;
        private DateTime time2;
        private double timeDelta;
        private int count;
        private double velocity1;
        private double velocity2;
        private double distance = 0.0;




        //Unique Identifier Required for LOG
        string autoblockLog;


        /*
         * Default Constructor will uses the same settings 
         * as the ones used in Motion Tracker 2 
         * >>>ONLY USE IF THERE IS ONLY ONE SENSOR!!!<<<
         */
        WheelSpeedSensor()
        {
            //default constructor
            PulsesPerRevolution = 12;
            WheelRadius = 0.164;

            //Serial Port Config
            BufferSize = 5;
            PeriodMSB = 5;
            PeriodLSB = 6;
            TerminatingByte = 192;
            EscapeByte = 219;
            port = "COM11";
            BaudRate = 115200;
            PARITY = Parity.None;
            DataBits = 8;
            STOPBITS = StopBits.One;

            //Set count to 0
            count = 0; 

            //LOG file config


            //Autoblock thread 
            Thread autoblockThread = new Thread(new ThreadStart(newData));
            
            //Serial Port Config
            serialPort = new SerialPort(port, BaudRate, PARITY, DataBits, STOPBITS);

            // Open Serial Port for Autoblock
            try
            {
                serialPort.Open();
                autoblockThread.Start();
                //systemLog += DateTime.Now.TimeOfDay + ": Autoblock stream started." + Environment.NewLine;

            }
            catch (IOException e)
            {
                //FAIL and 
                //print e.Message;
                //AppendTextBox("Autoblock not configured.\n");
            }

            //Autoblock data collection
            autoblockData = new DataCollection<DataPoint>();


        }

        //TODO
        //-Overloaded Constructor
        //-getters
        //-setters

        private void newData()
        {
            serialPort.DataReceived += serialPort_DataReceived;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            if (!sp.IsOpen)
            {
                return;
            }
            int message = sp.ReadByte();
            if (message == TerminatingByte)
            {
                int[] payload = new int[8];
                int i = 0;
                if (!serialPort.IsOpen)
                {
                    return;
                }
                message = serialPort.ReadByte();
                string output = "" + message;
                while (message != TerminatingByte)
                {
                    if (message == EscapeByte)
                    {
                        if (!serialPort.IsOpen)
                        {
                            return;
                        }
                        message = serialPort.ReadByte();
                        switch (message)
                        {
                            case 220:
                                message = TerminatingByte;
                                break;
                            case 221:
                                message = EscapeByte;
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
                    velocity1 = CalculateVelocity(payload[PeriodMSB], payload[PeriodLSB]);
                }
                else
                {
                    time2 = DateTime.Now;
                    velocity2 = CalculateVelocity(payload[PeriodMSB], payload[PeriodLSB]);
                    timeDelta = (double)(time2.Ticks - time1.Ticks) / 10000000.0;
                    distance += timeDelta * (velocity1 + velocity2) / 2.0;
                    time1 = time2;
                    velocity1 = velocity2;
                }
                autoblockData.Add(new DataPoint() { time = time1, velocity = velocity1, distance = distance });
                SetOdometerLabel("Odometer: " + distance.ToString("F2") + " m");
                SetSpeedometerLabel("Speedometer: " + velocity1.ToString("F2") + " m/s");
                if (velocity1 > MaximumSpeed)
                {
                    systemLog += DateTime.Now.TimeOfDay + ": Maximum speed exceeded." + Environment.NewLine;
                }
                if (weeds.Count != 0)
                {
                    int temporaryIndex = 0;
                    for (int j = targetIndex; j < weeds.Count; j++)
                    {
                        targetData = new DataPoint() { time = weeds[j].time, velocity = 0, distance = 0 };
                        for (int k = temporaryIndex; k < autoblockData.Count; k++)
                        {
                            if (autoblockData[k] == targetData)
                            {
                                matchingIndex = k;
                                break;
                            }
                        }
                        temporaryIndex = matchingIndex;
                        initialDistance = autoblockData[matchingIndex].distance;
                        currentDistance = distance;
                        targetDistance = weeds[j].distance;
                        if (Math.Abs((currentDistance - initialDistance) - targetDistance) <= 0.15)
                        {
                            TctecUSB4.TctecUSB4.setBits("FTXG3YUN", weeds[j].trigger, true); // Open solenoids
                            if (Convert.ToBoolean(weeds[j].trigger & 1))
                            {
                                sprayTrigger1.BackColor = Color.Red;
                                systemLog += DateTime.Now.TimeOfDay + ": Weed " + (j + 1) + " sprayed with sprayer 1." + Environment.NewLine;
                            }
                            if (Convert.ToBoolean(weeds[j].trigger >> 1))
                            {
                                sprayTrigger2.BackColor = Color.Red;
                                systemLog += DateTime.Now.TimeOfDay + ": Weed " + (j + 1) + " sprayed with sprayer 2." + Environment.NewLine;
                            }

                            Thread.Sleep(50);
                            TctecUSB4.TctecUSB4.setBits("FTXG3YUN", weeds[j].trigger, false); // Close solenoids
                            sprayTrigger1.BackColor = Color.Green;
                            sprayTrigger2.BackColor = Color.Green;
                            weedsSprayed++;
                            SetWeedsSprayedLabel("Weeds sprayed: " + weedsSprayed);
                            targetIndex = j + 1;
                        }
                    }
                }
                count++;
            }
        }

        delegate void SetSpeedometerLabelCallback(string text);
        private void SetSpeedometerLabel(string text)
        {
            if (this.speedometerLabel.InvokeRequired)
            {
                SetSpeedometerLabelCallback d = new SetSpeedometerLabelCallback(SetSpeedometerLabel);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.speedometerLabel.Text = text;
            }
        }

        delegate void SetOdometerLabelCallback(string text);
        private void SetOdometerLabel(string text)
        {
            if (this.odometerLabel.InvokeRequired)
            {
                SetOdometerLabelCallback d = new SetOdometerLabelCallback(SetOdometerLabel);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.odometerLabel.Text = text;
            }
        }

        public class DataPoint
        {
            // Time data field and property
            private DateTime _time;
            public DateTime time
            {
                get { return _time; }
                set { _time = value; }
            }

            // Velocity data field and property
            private double _velocity;
            public double velocity
            {
                get { return _velocity; }
                set { _velocity = value; }
            }

            // Distance data field and property
            private double _distance;
            public double distance
            {
                get { return _distance; }
                set { _distance = value; }
            }

            // Equals override method
            public override bool Equals(System.Object obj)
            {
                // If parameter cannot be cast to DataPoint return false:
                DataPoint dp = obj as DataPoint;
                if ((object)dp == null)
                {
                    return false;
                }

                // Return true if the time fields are within +-30ms
                return Math.Abs(dp.time.Ticks - time.Ticks) / 10000 <= 30;
            }

            public bool Equals(DataPoint dp)
            {
                // If parameter is null return false:
                if ((object)dp == null)
                {
                    return false;
                }

                // Return true if the time fields are within +-30ms
                return Math.Abs(dp.time.Ticks - time.Ticks) / 10000 <= 30;
            }

            public static bool operator ==(DataPoint a, DataPoint b)
            {
                // If both are null, or both are same instance, return true.
                if (System.Object.ReferenceEquals(a, b))
                {
                    return true;
                }

                // If one is null, but not both, return false.
                if (((object)a == null) || ((object)b == null))
                {
                    return false;
                }

                // Return true if the time fields are within +-30ms
                return Math.Abs(a.time.Ticks - b.time.Ticks) / 10000 <= 30;
            }

            public static bool operator !=(DataPoint a, DataPoint b)
            {
                // Return not equal to result
                return !(a == b);
            }

            public override int GetHashCode()
            {
                // Generate random hash code
                return (int)velocity * (int)distance;
            }
        }

        public class DataCollection<T> : Collection<T>
        {
            // Create new data event
            public event EventHandler NewData;

            // Firing method for new data event
            protected override void InsertItem(int index, T item)
            {
                if (null != NewData)
                {
                    NewData(this, null);
                }
                base.InsertItem(index, item);
            }
        }
    }
}
