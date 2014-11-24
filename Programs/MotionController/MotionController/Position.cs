using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionController
{
    class Position
    {
        private TimeSpan changeInTime;
        private DateTime time; 
        private double xPosition;
        private double yPosition;

        public Position(DateTime time, TimeSpan changeInTime, double xPosition, double yPosition)
        {
            this.time = time;
            this.changeInTime = changeInTime;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public Position(double xPosition, double yPosition)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public DateTime getTime()
        {
            return time;
        }

        public double getChangeInTime()
        {
            return changeInTime.TotalSeconds;
        }

        public double getXPosition()
        {
            return xPosition;
        }

        public double getYPosition()
        {
            return yPosition;
        }


    }
}
