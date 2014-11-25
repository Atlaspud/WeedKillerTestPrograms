using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionController
{
    class YawUpdate : EventArgs
    {
        private double yaw;

        public YawUpdate(double yaw)
        {
            this.yaw = yaw;
        }

        public double Yaw
        {
            get
            {
                return yaw;
            }
        }         
    }
}
