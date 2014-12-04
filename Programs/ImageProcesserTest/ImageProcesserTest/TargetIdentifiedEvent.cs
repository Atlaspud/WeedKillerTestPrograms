using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessorTest
{
    public delegate void TargetIdentifiedEventHandler(object sender, TargetIdentifiedEventArgs e);

    public class TargetIdentifiedEventArgs : EventArgs
    {
        public Target target { get; set; }
        public uint serial { get; set; }

        public TargetIdentifiedEventArgs(Target target, uint serial)
        {
            this.target = target;
            this.serial = serial;
        }
    }
}
