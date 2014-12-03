using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Position
    {
        private DateTime time;
        private double changeInTime;
        private double xPosition;
        private double yPosition;

        public Position(DateTime time, double changeInTime, double xPosition, double yPosition)
        {
            this.time = time;
            this.changeInTime = changeInTime;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public Position(double xPosition, double yPosition)
        {
            time = DateTime.Now;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public DateTime getTime()
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


        static public Boolean isPositionWithinLimits(double xMin, double xMax, double yMin, double yMax, Position position)
        {
            if (((position.getXPosition() < xMax) & (position.getXPosition() > xMin)) 
                & ((position.getYPosition() < yMax)&(position.getYPosition() > yMin)))
            {
                return true;
            } 
            return false;
        }

        static public Position positionInReferenceTo(Position position, Position referencePosition)
        {
            //Returns the position of position in reference to the position of the referencePosition

            double referencedXPosition = position.getXPosition() - referencePosition.getXPosition();
            double referencedYPosition = position.getYPosition() - referencePosition.getYPosition();

            return new Position(position.getTime(), position.getChangeInTime(), referencedXPosition, referencedYPosition);
        }

    }
}
