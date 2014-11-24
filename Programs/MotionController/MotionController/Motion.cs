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

        private Thread motionThread;

        private DateTime startTime;
        //private DateTime stopTime;

        //private DateTime currentTime;//?

        private DateTime oldStartTime;
        //private DateTime oldStopTime;

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

        //private List<Position> DataList;
        private Position currentPosition;

        public Motion(IMU imuSensor, WheelSpeedSensor wheelSpeedSensor)
        {
            this.imuSensor = imuSensor;
            this.wheelSpeedSensor = wheelSpeedSensor;
            currentXPosition = 0;
            currentYPosition = 0;
            yaw = 0;
            newVectorAngle = 0;
            changeInX = 0;
            velocity = 0;
            newVectorMagnitude = 0;
            changeInY = 0;
            xNegative = 1;
            yNegative = 1;

           // DataList = new List<Position>();
            
        }

        public Motion(String IMUCOM, String WSSCOM)
        {
            this.imuSensor = new IMU(IMUCOM);
            this.wheelSpeedSensor = new WheelSpeedSensor(WSSCOM);
            currentXPosition = 0;
            currentYPosition = 0;
            yaw = 0;
            newVectorAngle = 0;
            changeInX = 0;
            velocity = 0;
            newVectorMagnitude = 0;
            changeInY = 0;
            xNegative = 1;
            yNegative = 1;

            // DataList = new List<Position>();

        }

        /*  Starts the sensors and the thread 
         *  returns "Good" or "Bad" if any of the sensors are not working properly
         */
        public String startMotionController() 
        {
            if (startSensors() == "Good")
            {
                motionThread = new Thread(new ThreadStart(dataCollection));
                motionThread.Start();

                return "Good";
            }
            else
            {
                return "Bad";
            }
            
        }

        /*  Stops the Sensors and the thread if it is running
         */
        public void stopMotionController()
        {
            stopSensors();

            if (motionThread.IsAlive)
            {
                motionThread.Abort();
            } 


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

        private void dataCollection()
        {
            while (true)
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
               // if (changeInTime.TotalMilliseconds > 50)
                //{
                    //Magnitude = velocity * changeInTime
                    newVectorMagnitude = velocity * changeInTime.TotalSeconds;

                    if (newVectorAngle < 0)
                    {
                        newVectorAngle = -1 * newVectorAngle;
                        yNegative = -1;
                    }
                    else
                    {
                        yNegative = 1;
                    }

                    if (newVectorAngle > 90)
                    {
                        newVectorAngle = newVectorAngle - 90;
                        xNegative = -1;
                    }
                    else
                    {
                        xNegative = 1;
                    }

                    changeInX = xNegative * (Math.Sin(newVectorAngle)) * newVectorMagnitude;
                    changeInY = yNegative * (Math.Cos(newVectorAngle)) * newVectorMagnitude;

                    currentXPosition += changeInX;
                    currentYPosition += changeInY;

                    //Probably not needed?
                    //stopTime = DateTime.Now;

                    //Storge for all data
                    //DataList.Add(new Position(startTime, changeInTime, currentXPosition, currentYPosition));
                    currentPosition = new Position(startTime, changeInTime, currentXPosition, currentYPosition);

                    oldStartTime = startTime;
                    //oldStopTime = stopTime;
               // }
            } 

        }

        public Position getCurrentPosition()
        {
            return currentPosition;
        }
    }
}
