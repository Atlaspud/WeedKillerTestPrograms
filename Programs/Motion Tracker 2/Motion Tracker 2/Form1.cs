using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AForge;
using AForge.Video;
using AForge.Imaging;
using Motion.SDK;

namespace MotionTracker2
{
    public partial class Form1 : Form
    {
        // Global constants and variables
        MJPEGStream stream;
        DataCollection<DataPoint> autoblockData;
        const int PulsesPerRevolution = 12;
        const double WheelRadius = 0.164;
        const int BufferSize = 5;
        const int PeriodMSB = 5;
        const int PeriodLSB = 6;
        const int TerminatingByte = 192;
        const int EscapeByte = 219;
        const string port = "COM11";
        const int BaudRate = 115200;
        const Parity PARITY = Parity.None;
        const int DataBits = 8;
        const StopBits STOPBITS = StopBits.One;
        SerialPort serialPort;
        double distance;
        int count;
        Bitmap frame;
        DateTime startTime;
        DateTime stopTime;
        // Variables for plotting polar coordinates
        private ChartStyle cs;
        private DataCollection dc;
        // Client host and configurable data service port settings
        int motionPort = 32076;
        string host = "";
        // Number of samples for calibration routine
        const int nSamples = 300;
        // Calibration offset and sensitivity readings
        double AOffx = 0; double AOffy = 0; double AOffz = 0;
        double BOffx = 0; double BOffy = 0; double BOffz = 0;
        double ASyy = 1; double BSyy = 1;
        double ARollReference = 0; double APitchReference = 0;
        double BRollReference = 0; double BPitchReference = 0;
        double thresholdVelocity = 0.25;
        bool stopFlag;
        double _yaw;
        double yaw
        {
            get { return _yaw; }
            set
            {
                _yaw = value;
                RefreshYawPlot();
            }
        }
        double _roll;
        double roll
        {
            get { return _roll; }
            set
            {
                _roll = value;
                RefreshRollPlot();
            }
        }
        double _pitch;
        double pitch
        {
            get { return _pitch; }
            set
            {
                _pitch = value;
                RefreshPitchPlot();
            }
        }

        public Form1()
        {
            InitializeComponent();
            logoPictureBox.Image = new Bitmap(Environment.CurrentDirectory + "\\jcu.png");
            // Initialise polar plot
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            // Subscribing to a paint eventhandler to drawingPanel:
            YawPlotPanel.Paint += new PaintEventHandler(YawPlotPanelPaint);
            RollPlotPanel.Paint += new PaintEventHandler(RollPlotPanelPaint);
            PitchPlotPanel.Paint += new PaintEventHandler(PitchPlotPanelPaint);
            // Settings for polar plot
            dc = new DataCollection();
            cs = new ChartStyle(this);
            cs.RMax = 1;
            cs.RMin = 0;
            cs.NTicks = 1;
            cs.AngleStep = 30;
            cs.AngleDirection = ChartStyle.AngleDirectionEnum.CounterClockWise;
            cs.TickFontColor = Color.White;
            try
            {
                Client client = new Client(host, motionPort);

                if (client.isConnected())
                {
                    String xml_definition =
                        "<?xml version=\"1.0\"?>" +
                        "<configurable>" +
                        "<sensor><a/></sensor>" +
                        "<preview><r><x/><z/></r></preview>" +
                        "</configurable>";
                    client.writeData(xml_definition);
                }

                if (client.waitForData())
                {
                    int sampleCount = 0;
                    while (true)
                    {
                        byte[] data = client.readData();
                        if (data == null || sampleCount++ >= nSamples)
                        {
                            break;
                        }
                        IDictionary<int, Format.ConfigurableElement> container = Format.Configurable(data);
                        Format.ConfigurableElement ASample = container[1];
                        Format.ConfigurableElement BSample = container[2];
                        double Ax = ASample.value(0); double Ay = ASample.value(1); double Az = ASample.value(2);
                        double Bx = BSample.value(0); double By = BSample.value(1); double Bz = BSample.value(2);
                        double ARoll = ASample.value(3); double APitch = ASample.value(4);
                        double BRoll = BSample.value(3); double BPitch = BSample.value(4);
                        AOffx += Ax;
                        AOffy += Ay;
                        AOffz += Az;
                        BOffx += Bx;
                        BOffy += By;
                        BOffz += Bz;
                        ARollReference += ARoll;
                        APitchReference += APitch;
                        BRollReference += BRoll;
                        BPitchReference += BPitch;
                    }
                    AOffx /= nSamples;
                    AOffy /= nSamples;
                    AOffz /= nSamples;
                    BOffx /= nSamples;
                    BOffy /= nSamples;
                    BOffz /= nSamples;
                    AOffy -= ASyy;
                    BOffy -= BSyy;
                    ARollReference /= nSamples;
                    APitchReference /= nSamples;
                    BRollReference /= nSamples;
                    BPitchReference /= nSamples;
                }
                AppendTextBox("Motion node accelerometers calibrated.\n");
                startButton.Enabled = true;
            }
            catch (Exception ex)
            {
                AppendTextBox("\nFailed to connect to motion node accelerometer client.\n" + ex + "\n");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startFlagButton.Enabled = true;
            stopButton.Enabled = true;
            startButton.Enabled = false;
            Thread autoblockThread = new Thread(new ThreadStart(newData));
            serialPort = new SerialPort(port, BaudRate, PARITY, DataBits, STOPBITS);
            /*
            stream = new MJPEGStream();
            stream.Source = "http://1.1.1.2:10000/cgi-bin/video.cgi?msubmenu=mjpg&profile=3&resolution=0&frate=5&compression=1";
            stream.Login = "admin";
            stream.Password = "4321";
            Thread cameraThread = new Thread(newFrame);
            stream.Start();
            cameraThread.Start();
            */
            Thread accelerometerThread = new Thread(readAccelerometerData);
            accelerometerThread.Start();
            try
            {
                serialPort.Open();
                autoblockThread.Start();
            }
            catch (IOException)
            {
                AppendTextBox("Autoblock not configured.\n");
            }
            autoblockData = new DataCollection<DataPoint>();
            distance = 0.0;
            count = 0;
            textBox1.Text = "";
            stopFlag = false;
            yaw = 0;
            roll = 0;
            pitch = 0;
            SetSpeedometer("0.0 m/s");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            startButton.Enabled = true;
            startFlagButton.Enabled = false;
            finishFlagButton.Enabled = false;
            stopFlag = true;
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.Dispose();
            if (stream.IsRunning)
            {
                stream.Stop();
            }
        }

        private void startFlagButton_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            Bitmap startFrame = frame;
            startFlagButton.Enabled = false;
            finishFlagButton.Enabled = true;
        }

        private void finishFlagButton_Click(object sender, EventArgs e)
        {
            stopTime = DateTime.Now;
            Bitmap stopFrame = frame;
            stopButton.Enabled = false;
            startButton.Enabled = true;
            startFlagButton.Enabled = false;
            finishFlagButton.Enabled = false;
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.Dispose();
            if (stream.IsRunning)
            {
                stream.Stop();
            }
        }

        private void newFrame()
        {
            stream.NewFrame += stream_NewFrame;
        }

        private void stream_NewFrame(object sender, AForge.Video.NewFrameEventArgs e)
        {
            frame = new Bitmap(e.Frame);
            pictureBox1.Image = frame;
        }

        private void AddYawData()
        {
            // Add data to polar plot from latest yaw reading
            dc.DataSeriesList.Clear();
            DataSeries ds = new DataSeries();
            ds.LineStyle.LineColor = Color.Red;
            ds.LineStyle.Thickness = 3f;
            ds.LineStyle.Pattern = DashStyle.Solid;
            ds.SeriesName = "Yaw";
            float data = -1f * (float)yaw + 90f;
            ds.AddPoint(new PointF(0, 0));
            ds.AddPoint(new PointF(data, 1));
            dc.Add(ds);
        }

        private void YawPlotPanelPaint(object sender, PaintEventArgs e)
        {
            // Re-plot data
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            AddYawData();
            cs.SetPolarAxes(g);
            dc.AddPolar(g, cs);
            //lg.AddLegend(g, dc, cs);
            g.Dispose();
            this.DoubleBuffered = true;
        }

        private void AddRollData()
        {
            // Add data to polar plot from latest yaw reading
            dc.DataSeriesList.Clear();
            DataSeries ds = new DataSeries();
            ds.LineStyle.LineColor = Color.Red;
            ds.LineStyle.Thickness = 3f;
            ds.LineStyle.Pattern = DashStyle.Solid;
            ds.SeriesName = "Roll";
            float data = -1f * (float)roll;
            ds.AddPoint(new PointF(data, 1));
            ds.AddPoint(new PointF(data + 180f, 1));
            dc.Add(ds);
        }

        private void RollPlotPanelPaint(object sender, PaintEventArgs e)
        {
            // Re-plot data
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            AddRollData();
            cs.SetPolarAxes(g);
            dc.AddPolar(g, cs);
            //lg.AddLegend(g, dc, cs);
            g.Dispose();
            this.DoubleBuffered = true;
        }

        private void AddPitchData()
        {
            // Add data to polar plot from latest yaw reading
            dc.DataSeriesList.Clear();
            DataSeries ds = new DataSeries();
            ds.LineStyle.LineColor = Color.Red;
            ds.LineStyle.Thickness = 3f;
            ds.LineStyle.Pattern = DashStyle.Solid;
            ds.SeriesName = "Pitch";
            float data = (float)pitch;
            ds.AddPoint(new PointF(data, 1));
            ds.AddPoint(new PointF(data + 180f, 1));
            dc.Add(ds);
        }

        private void PitchPlotPanelPaint(object sender, PaintEventArgs e)
        {
            // Re-plot data
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            AddPitchData();
            cs.SetPolarAxes(g);
            dc.AddPolar(g, cs);
            //lg.AddLegend(g, dc, cs);
            g.Dispose();
            this.DoubleBuffered = true;
        }

        public void readAccelerometerData()
        {
            // Declare processing variables
            double g = 9.80665;
            int count = 0;
            int n = 0;
            double samplingPeriod = 0.01;
            int bufferSize = 10;
            thresholdVelocity = 0.3;
            double distance = 0.575;
            double angularVelocity = 0;
            double yawAngularAcceleration1 = 0;
            double yawAngularAcceleration2 = 0;
            double rollAngularAcceleration1 = 0;
            double rollAngularAcceleration2 = 0;
            double yawAngularVelocity = 0;
            double rollAngularVelocity = 0;
            double totalAngularVelocity = 0;
            double yawRate1 = 0;
            double yawRate2 = 0;
            double rollPrevious = 0;
            double pitchPrevious = 0;
            double[] AxBuffer = new double[bufferSize];
            double[] AyBuffer = new double[bufferSize];
            double[] AzBuffer = new double[bufferSize];
            double[] BxBuffer = new double[bufferSize];
            double[] ByBuffer = new double[bufferSize];
            double[] BzBuffer = new double[bufferSize];
            double[] ARollBuffer = new double[bufferSize];
            double[] APitchBuffer = new double[bufferSize];
            double[] BRollBuffer = new double[bufferSize];
            double[] BPitchBuffer = new double[bufferSize];

            // Create and open new client connection
            Client client = new Client(host, motionPort);

            if (client.isConnected())
            {
                String xml_definition =
                        "<?xml version=\"1.0\"?>" +
                        "<configurable>" +
                        "<sensor><a/></sensor>" +
                        "<preview><r><x/><z/></r></preview>" +
                        "</configurable>";
                client.writeData(xml_definition);
            }

            // Wait for accelerometer data from the client
            if (client.waitForData())
            {
                while (true)
                {
                    // Read data
                    byte[] data = client.readData();

                    // Stop reading data when there is none left or user presses stop
                    if (data == null || stopFlag == true)
                    {
                        break;
                    }

                    // Convert data to sensor format
                    IDictionary<int, Format.ConfigurableElement> container = Format.Configurable(data);
                    Format.ConfigurableElement ASample = container[1];
                    Format.ConfigurableElement BSample = container[2];
                    double Ax = (ASample.value(0) - AOffx) * g; double Ay = (ASample.value(1) - AOffy) * g; double Az = (ASample.value(2) - AOffz) * g;
                    double Bx = (BSample.value(0) - BOffx) * g; double By = (BSample.value(1) - BOffy) * g; double Bz = (BSample.value(2) - BOffz) * g;

                    // If the z component of A is larger than that of B, equalize both components to their average
                    double avg;
                    if (Bz - Az < 0)
                    {
                        avg = (Bz + Az) / 2;
                        Az = avg; Bz = avg;
                    }

                    // Compute running average using buffer
                    AxBuffer[count % bufferSize] = Ax;
                    AyBuffer[count % bufferSize] = Ay;
                    AzBuffer[count % bufferSize] = Az;
                    BxBuffer[count % bufferSize] = Bx;
                    ByBuffer[count % bufferSize] = By;
                    BzBuffer[count % bufferSize] = Bz;
                    ARollBuffer[count % bufferSize] = ASample.value(3) - ARollReference;
                    APitchBuffer[count % bufferSize] = ASample.value(4) - APitchReference;
                    BRollBuffer[count % bufferSize] = BSample.value(3) - BRollReference;
                    BPitchBuffer[count % bufferSize] = BSample.value(4) - BPitchReference;

                    n = count - bufferSize + 1;

                    if (n > 0)
                    {
                        // Get running average data set
                        Ax = AxBuffer.Average();
                        Ay = AyBuffer.Average();
                        Az = AzBuffer.Average();
                        Bx = BxBuffer.Average();
                        By = ByBuffer.Average();
                        Bz = BzBuffer.Average();

                        // Calculate display running average roll and pitch
                        rollPrevious = roll;
                        pitchPrevious = pitch;
                        double newRoll = (ARollBuffer.Average() + BRollBuffer.Average()) / 2.0 * 180.0 / Math.PI;
                        double newPitch = (APitchBuffer.Average() + BPitchBuffer.Average()) / 2.0 * 180.0 / Math.PI;
                        if (Math.Abs(newRoll - rollPrevious) >= 0.5)
                        {
                            roll = newRoll;
                        }
                        if (Math.Abs(newPitch - pitchPrevious) >= 0.5)
                        {
                            pitch = newPitch;
                        }

                        // Calculate angular velocity from radial accelerations with a velocity magnitude threshold
                        angularVelocity = Math.Sqrt(Math.Abs(Bz - Az) / distance);
                        if (angularVelocity < thresholdVelocity)
                        {
                            angularVelocity = 0;
                        }
                        angularVelocity = angularVelocity * 180.0 / Math.PI;

                        // Calculate angular accelerations
                        yawAngularAcceleration2 = (Bx - Ax) / distance * 180.0 / Math.PI;
                        rollAngularAcceleration2 = (By - Ay) / distance * 180.0 / Math.PI;

                        // Integrate angular velocities
                        yawAngularVelocity += samplingPeriod * (yawAngularAcceleration1 + yawAngularAcceleration2) / 2.0;
                        rollAngularVelocity += samplingPeriod * (rollAngularAcceleration1 + rollAngularAcceleration2) / 2.0;

                        // Calculate the total angular velocity
                        totalAngularVelocity = Math.Sqrt(Math.Pow(yawAngularVelocity, 2) + Math.Pow(rollAngularVelocity, 2));

                        // Integrate yaw and roll rates
                        if (Math.Abs(totalAngularVelocity) > 0)
                        {
                            yawRate2 = yawAngularVelocity * angularVelocity / totalAngularVelocity;
                        }
                        else
                        {
                            // Avoid dividing by zero
                            yawRate2 = 0;
                        }

                        // Integrate yaw and roll angles
                        double yawIncrement = samplingPeriod * (yawRate1 + yawRate2) / 2.0;
                        if (yawIncrement != 0)
                        {
                            yaw += yawIncrement;
                        }

                        // Move to next integration step
                        yawAngularAcceleration1 = yawAngularAcceleration2;
                        rollAngularAcceleration1 = rollAngularAcceleration2;
                        yawRate1 = yawRate2;
                    }
                    count++;
                }
            }
            // Abort thread once stop button is pressed
            Thread.CurrentThread.Abort();
        }

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
                DateTime time = DateTime.UtcNow;
                double velocity = CalculateVelocity(payload[PeriodMSB], payload[PeriodLSB]);
                autoblockData.Add(new DataPoint() { time = time, velocity = velocity });
                speedometer.Speed = velocity * 100;
                SetSpeedometer(velocity.ToString("F2") + " m/s");
                count++;
            }
        }

        private static double CalculateVelocity(int msb, int lsb)
        {
            int period = msb * 256 + lsb;
            double velocity;
            if (period == 0)
            {
                velocity = 0.0;
            }
            else
            {
                velocity = 57600.0 / ((double)PulsesPerRevolution * (double)period) * (2.0 * Math.PI * WheelRadius);
            }
            return velocity;
        }

        delegate void AppendTextBoxCallback(string text);
        private void AppendTextBox(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                AppendTextBoxCallback d = new AppendTextBoxCallback(AppendTextBox);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.AppendText(text);
            }
        }

        delegate void SetSpeedometerCallback(string text);
        private void SetSpeedometer(string text)
        {
            if (this.speedometerLabel.InvokeRequired)
            {
                SetSpeedometerCallback d = new SetSpeedometerCallback(SetSpeedometer);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.speedometerLabel.Text = text;
            }
        }

        delegate void RefreshYawPlotCallback();
        private void RefreshYawPlot()
        {
            if (this.YawPlotPanel.InvokeRequired)
            {
                RefreshYawPlotCallback d = new RefreshYawPlotCallback(RefreshYawPlot);
                this.BeginInvoke(d, new object[] {});
            }
            else
            {
                this.YawPlotPanel.Refresh();
            }
        }

        delegate void RefreshRollPlotCallback();
        private void RefreshRollPlot()
        {
            if (this.RollPlotPanel.InvokeRequired)
            {
                RefreshRollPlotCallback d = new RefreshRollPlotCallback(RefreshRollPlot);
                this.BeginInvoke(d, new object[] { });
            }
            else
            {
                this.RollPlotPanel.Refresh();
            }
        }

        delegate void RefreshPitchPlotCallback();
        private void RefreshPitchPlot()
        {
            if (this.PitchPlotPanel.InvokeRequired)
            {
                RefreshPitchPlotCallback d = new RefreshPitchPlotCallback(RefreshPitchPlot);
                this.BeginInvoke(d, new object[] { });
            }
            else
            {
                this.PitchPlotPanel.Refresh();
            }
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
            return (int)velocity * (int)(time.Ticks / 1000000);
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

    public class DoubleBufferedPanel : Panel { public DoubleBufferedPanel() : base() { DoubleBuffered = true; } }
}
