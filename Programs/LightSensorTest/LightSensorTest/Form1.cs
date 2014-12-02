using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightSensorTest
{
    public partial class Form1 : Form
    {
        //Declare global properties
        LightSensor lightSensor;
        String result;
        Boolean _continue = false;
        int sensorCount = 2;
        int timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (!_continue)
            {
                lightSensor = new LightSensor("COM7", sensorCount);
                result = lightSensor.start();
                timer = 0;
                if (result != null)
                {
                    MessageBox.Show(result,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    _continue = true;
                    lightSensor.lightSensorDataReceieved += (object sender2, LightSensorDataReceivedEventArgs e2) =>
                    {
                        timer++;
                        if (timer == 50)
                        {
                            double[] output = e2.data;
                            DateTime time = e2.time;
                            string s = "Time: " + time.ToString("hh:mm:ss") + "\r\n";
                            for (int i = 0; i < sensorCount; i++)
                            {
                                s += ("Sensor " + i + ": " + (int)output[i] + "\r\n");
                            }
                            SetText(s);
                            timer = 0;
                        }
                    };
                }
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (_continue)
            {
                if (lightSensor != null) result = lightSensor.stop();
                if (result != null)
                {
                    MessageBox.Show(result,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    _continue = false;
                }
            }
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }
    }
}
