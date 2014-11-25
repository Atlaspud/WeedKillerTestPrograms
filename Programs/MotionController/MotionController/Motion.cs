using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MotionController
{
    class Motion
    {
        private IMU imuSensor;
        private WheelSpeedSensor wheelSpeedSensor;

        private DateTime startTime;
        private DateTime oldStartTime;

        private TimeSpan changeInTime;

        private double currentXPosition;
        private double currentYPosition;
        private double changeInX;
        private double changeInY;
        private double yaw;
        private double newVectorAngle;
        private double velocity;
        private double newVectorMagnitude;
        private int xNegative;
        private int yNegative;

        private Position currentPosition;

        public Motion(IMU imuSensor, WheelSpeedSensor wheelSpeedSensor)
        {
            this.imuSensor = imuSensor;
            this.wheelSpeedSensor = wheelSpeedSensor;
            yaw = 0;
            velocity = 0;
            resetOrigin();
        }

        public Motion(String IMUCOM, String WSSCOM)
        {
            this.imuSensor = new IMU(IMUCOM);
            this.wheelSpeedSensor = new WheelSpeedSensor(WSSCOM);
            yaw = 0;
            velocity = 0;
            resetOrigin();
        }

        public void resetOrigin()
        {
            currentXPosition = 0;
            currentYPosition = 0;
            newVectorAngle = 0;
            changeInX = 0;
            newVectorMagnitude = 0;
            changeInY = 0;
            xNegative = 1;
            yNegative = 1;
        } 



        /*  Starts the sensors and the thread 
         *  returns "Good" or "Bad" if any of the sensors are not working properly
         */
        public String startMotionController() 
        {
            if (startSensors() == "Good")
            {
                //Add event handler for IMU
                imuSensor.OnYawUpdate += imuSensor_OnYawUpdate;

                return "Good";
            }
            else
            {
                return "Bad";
            }
            
        }

        private void imuSensor_OnYawUpdate(object source, YawUpdate yawArgs)
        {
            startTime = DateTime.Now;
            yaw = imuSensor.getCurrentYaw();
            velocity = wheelSpeedSensor.getCurrentVelocity();
            newVectorAngle = 90 - yaw;
            //If angle is greater than 180
            if (newVectorAngle > 180)
            {
                newVectorAngle = -(180 - newVectorAngle);
            }
            //MASSIVE SOURCE OF POSSIBLE ERROR ######################################################################################
            changeInTime = startTime - oldStartTime;

            //There needs to be a minimum time between measurements
            if (changeInTime.TotalMilliseconds > 50)
            {
                //Magnitude = velocity * changeInTime
                newVectorMagnitude = velocity * changeInTime.TotalSeconds;

                //If the angle is negative then the y axis will be negative
                if (newVectorAngle < 0)
                {
                    newVectorAngle = -1 * newVectorAngle;
                    yNegative = -1;
                }
                else
                {
                    yNegative = 1;
                }

                //if the angle is greater than 90 degrees then the x axis will be negative
                if (newVectorAngle > 90)
                {
                    newVectorAngle = newVectorAngle - 90;
                    xNegative = -1;
                }
                else
                {
                    xNegative = 1;
                }

                //Determine how much the x and y position has changed due to the new movement
                changeInX = xNegative * (Math.Sin(newVectorAngle)) * newVectorMagnitude;
                changeInY = yNegative * (Math.Cos(newVectorAngle)) * newVectorMagnitude;

                //add the changes to the position to give the new current position
                currentXPosition += changeInX;
                currentYPosition += changeInY;

                //Probably not needed?
                //stopTime = DateTime.Now;
                //Storge for all data
                //DataList.Add(new Position(startTime, changeInTime, currentXPosition, currentYPosition));

                currentPosition = new Position(startTime, changeInTime, currentXPosition, currentYPosition);

                oldStartTime = startTime;

                //oldStopTime = stopTime;
            }
        }

        /*  Stops the Sensors and the thread if it is running
         */
        public void stopMotionController()
        {
            stopSensors();

            //Print the contents of the DataList to a .csv file
            //##################################################################################################################
            //Todo

        }

        private String startSensors()
        {
            String status = "Good";

            if (imuSensor.initConnection() != "Good")
            {
                status = "Bad";
            }

            if (wheelSpeedSensor.initConnection() != "Good")
            {
                status = "Bad";
            }

            return status;
        }

        private void stopSensors()
        {
            imuSensor.closeConnection();
            wheelSpeedSensor.closeConnection();
        } 

        public Position getCurrentPosition()
        {
            return currentPosition;
        }
    }
}
