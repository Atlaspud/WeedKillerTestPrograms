using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace CameraTest
{
    public delegate void CameraFrameReceivedEventHandler(object sender, CameraFrameReceivedEventArgs e);

    public class CameraFrameReceivedEventArgs : EventArgs
    {
        public Image<Bgr, Byte> image { get; set; }
        public DateTime time { get; set; }
        public uint serial { get; set; }
        public string debug { get; set; }
        public double frameRate { get; set; }
        public double shutter { get; set; }
        public double exposure { get; set; }
        public double brightness { get; set; }
        public double gain { get; set; }
        public int whiteBalanceA { get; set; }
        public int whiteBalanceB { get; set; }
        public double illuminance { get; set; }
    }
}
