using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionController
{
    class Position
    {
        private double time;
        private double changeInTime;
        private double xPosition;
        private double yPosition;

        public Position(double time, double changeInTime, double xPosition, double yPosition)
        {
            this.time = time;
            this.changeInTime = changeInTime;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public Position(double xPosition, double yPosition)
        {
            time = 0;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public double getTime()
        {
            return time;
        }

        public double getChangeInTime()
        {
            return changeInTime;
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
