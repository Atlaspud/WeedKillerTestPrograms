using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace model
{
    public class Motion
    {
        private IMU imuSensor;
        private WheelSpeedSensor wheelSpeedSensor;

        private double startTime;
        private double oldStartTime;
        private double changeInTime;
        private double currentXPosition;
        private double currentYPosition;
        private double yaw;
        private double velocity;
        private double distance;

        private int counter;

        private Position currentPosition;

        private Boolean initialYawFlag = true;
        private double initialYaw = 0;

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
            distance = 0;

            //Initialize the oldStartTime value of the time
            DateTime startingDateTime = DateTime.Now;

            //Convert the time into just milliseconds (otherwise overflows will occur when the seconds change or minutes.. etc)
            startTime = startingDateTime.Ticks / TimeSpan.TicksPerMillisecond;

            oldStartTime = startTime;

            currentPosition = new Position(startingDateTime, oldStartTime, 0.0, 0.0);

            initialYawFlag = true;
        } 

        public String startMotionController() 
        {
            if (startSensors() == "Good")
            {

                resetOrigin();

                //Add event handler for IMU
                imuSensor.OnYawUpdate += imuSensor_OnYawUpdate;

                return "Good";
            }
            else
            {
                return "Bad";
            }
            
        }

        public delegate void MotionUpdateHandler(object source, MotionUpdate motionUpdateArgs);

        public event MotionUpdateHandler OnMotionUpdate; 

        private void imuSensor_OnYawUpdate(object source, YawUpdate yawArgs)
        {         
            DateTime startingDateTime = DateTime.Now;
            //Convert the time into just milliseconds (otherwise overflows will occur when the seconds change or minutes.. etc)
            startTime = startingDateTime.Ticks / TimeSpan.TicksPerMillisecond;

            //yaw = (yawArgs.Yaw) * (Math.PI/180) ;
            yaw = Math.PI / 2.0;

            if (initialYawFlag)
            {
                initialYaw = yaw;
                initialYawFlag = false;
            }

            yaw -= initialYaw + Math.PI/2.0;

            velocity = wheelSpeedSensor.getCurrentVelocity();

            changeInTime = startTime - oldStartTime;

            //Magnitude = velocity * changeInTime
            distance = velocity * (changeInTime / 1000);

            //Determine how much the x and y position has changed due to the new movement
            double x = (Math.Cos(yaw)) * distance;
            double y = (Math.Sin(yaw)) * distance;

            //add the changes to the position to give the new current position
            currentXPosition += x;
            currentYPosition += -y;

            currentPosition = new Position(startingDateTime, changeInTime, currentXPosition, currentYPosition);

            oldStartTime = startTime;

            //Position positionArgs = new Position(0, 1);
            MotionUpdate motionUpdateArgs = new MotionUpdate(currentPosition);

            // TODO 
            // Implement a circular buffer of 200 positions (approximately 5 seconds of information)
            // when values are overwritten the overwritten value is saved to the end of a .csv file





            //This if statement will only cause the event to trigger every 10 times the serial has been updated
            //The data for every time the OnYawUpdate is trigger can be accessed every time however
            if (counter == 10)
            {
                OnMotionUpdate(this, motionUpdateArgs);
                counter = 0;
            }
            else
            {
                counter++;
            }
        }

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
