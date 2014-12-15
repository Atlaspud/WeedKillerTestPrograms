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
        private double yaw;

        private static readonly double[,] CAMERA_LOCATIONS = new double[8, 2] { { -0.875, 0.45 }, { -0.625, 0.45 }, { -0.375, 0.45 }, { -0.125, 0.45 }, //Sprayer Relay 1 (Sprayers 1-4)
                                                              { 0.125, 0.45 }, { 0.375, 0.45 }, { 0.625, 0.45 }, { 0.875, 0.45 } }; // Sprayer Relay 2 (Sprayers 5-8)


        private static readonly double[,] SPRAYER_LOCATIONS = new double[8, 2] { { -0.875, -1.35 }, { -0.625, -1.35 }, { -0.375, -1.35 }, { -0.125, -1.35 }, //Sprayer Relay 1 (Sprayers 1-4)
                                                              { 0.125, -1.35 }, { 0.375, -1.35 }, { 0.625, -1.35 }, { 0.875, -1.35 } }; // Sprayer Relay 2 (Sprayers 5-8)


        public Position(DateTime time, double changeInTime, double xPosition, double yPosition, double yaw)
        {
            this.time = time;
            this.changeInTime = changeInTime;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.yaw = yaw;
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

        public double getYaw()
        {
            return yaw;
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

            return new Position(position.getTime(), position.getChangeInTime(), referencedXPosition, referencedYPosition, position.getYaw());
        }

        static public Position cameraTargetPosition(uint cameraSerial, Position currentPosition)
        {
            int cameraNumber;

            switch (cameraSerial)
            {
                case 13421033:
                    cameraNumber = 0;
                    break;
                case 13421041:
                    cameraNumber = 1;
                    break;
                case 13421043:
                    cameraNumber = 2;
                    break;
                case 13421046:
                    cameraNumber = 3; 
                    break;
                case 13421051:
                    cameraNumber = 4;
                    break;
                case 13421053:
                    cameraNumber = 5;
                    break;
                case 13421056:
                    cameraNumber = 6;
                    break;
                case 13421057:
                    cameraNumber = 7;
                    break;
                default:
                    cameraNumber = 0;
                    break;
            }

            //rotated X coordinate
            double rotatedCameraXPosition = (CAMERA_LOCATIONS[cameraNumber, 0] * Math.Cos(currentPosition.getYaw() + (Math.PI / 2.0))) + (CAMERA_LOCATIONS[cameraNumber, 1] * Math.Sin(currentPosition.getYaw() + (Math.PI / 2.0)));

            //rotated Y coordinate
            double rotatedCameraYPosition = -(CAMERA_LOCATIONS[cameraNumber, 0] * Math.Sin(currentPosition.getYaw() + (Math.PI / 2.0))) + (CAMERA_LOCATIONS[cameraNumber, 1] * Math.Cos(currentPosition.getYaw() + (Math.PI / 2.0)));

            double cameraXPosition = rotatedCameraXPosition + currentPosition.getXPosition();

            double cameraYPosition = rotatedCameraYPosition + currentPosition.getYPosition();

            return new Position(currentPosition.getTime(), currentPosition.getChangeInTime(), cameraXPosition, cameraYPosition, currentPosition.getYaw());
        }

        private double[] rotatedCameraPosition(Position currentPosition)
        {

            double[] rotatedSprayerPositions = new double[2];
            

            return rotatedSprayerPositions;
        }
    }
}
