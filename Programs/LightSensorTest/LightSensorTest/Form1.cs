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
        Boolean startFlag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (!startFlag)
            {
                lightSensor = new LightSensor("COM7");
                result = lightSensor.start();
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
                    startFlag = true;
                    lightSensor.NewLightSensorOutput += (object sender2, LightSensorEventArgs e2) =>
                    {
                        double[] output = e2.getOutput();
                        string s = "";
                        for (int i = 0; i < 8; i++)
                        {
                            s += ("Sensor " + i + ": " + (int) output[i] + "\r\n");
                        }
                        AppendTextBox(s);
                    };
                }
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (startFlag == false)
            {
                result = lightSensor.stop();
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
                    startFlag = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] output = lightSensor.getLightSensorOutput();
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
                this.textBox1.Text = text;
            }
        }
    }
}
