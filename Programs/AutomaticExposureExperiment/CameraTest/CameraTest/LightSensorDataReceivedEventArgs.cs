using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraTest
{
    public delegate void LightSensorDataReceivedEventHandler(object sender, LightSensorDataReceivedEventArgs e);

    public class LightSensorDataReceivedEventArgs : EventArgs
    {
        public double[] data { get; set; }
        public DateTime time { get; set; }
        public string debug { get; set; }
    }
}
