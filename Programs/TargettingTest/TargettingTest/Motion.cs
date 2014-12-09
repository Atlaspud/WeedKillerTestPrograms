using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


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
        private Position[] circularBuffer = new Position[200];
        private int counterForCurrentPosition;
        private int counterForOldestPosition;

        private Position currentPosition;

        private Boolean initialYawFlag = true;
        private double initialYaw = 0;

        private StreamWriter textStream = new StreamWriter(Directory.GetCurrentDirectory() + "/MotionData.csv", true);

        public Motion(IMU imuSensor, WheelSpeedSensor wheelSpeedSensor)
        {
            this.imuSensor = imuSensor;
            this.wheelSpeedSensor = wheelSpeedSensor;
            yaw = 0;
            velocity = 0;
            resetOrigin();
            textStream.WriteLine("Started");
        }

        public Motion(String IMUCOM, String WSSCOM)
        {
            this.imuSensor = new IMU(IMUCOM);
            this.wheelSpeedSensor = new WheelSpeedSensor(WSSCOM);
            yaw = 0;
            velocity = 0;
            resetOrigin();
            textStream.WriteLine("Started");
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

            currentPosition = new Position(startingDateTime, oldStartTime, 0.0, 0.0, 0);

            initialYawFlag = true;

            counterForCurrentPosition = 1;
            counterForOldestPosition = 0;

            circularBuffer[0] = currentPosition;
            textStream.WriteLine("Origin Reset");

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

        public delegate void MotionUpdateHandler(object source, Position currentPosition);

        public event MotionUpdateHandler OnMotionUpdate; 

        private void imuSensor_OnYawUpdate(object source, YawUpdate yawArgs)
        {         
            DateTime startingDateTime = DateTime.Now;
            //Convert the time into just milliseconds (otherwise overflows will occur when the seconds change or minutes.. etc)
            startTime = startingDateTime.Ticks / TimeSpan.TicksPerMillisecond;

            yaw = (yawArgs.Yaw) * (Math.PI/180) ;
            //yaw = Math.PI / 2.0;

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

            currentPosition = new Position(startingDateTime, changeInTime, currentXPosition, currentYPosition, yaw);

            oldStartTime = startTime;

            //Position positionArgs = new Position(0, 1);
            //MotionUpdate motionUpdateArgs = new MotionUpdate(currentPosition);

            // TODO 
            // Implement a circular buffer of 200 positions (approximately 5 seconds of information)
            // when values are overwritten the overwritten value is saved to the end of a .csv file

            if (counterForCurrentPosition == counterForOldestPosition)
            {
                //save oldest to .csv

                saveToCSV(circularBuffer[counterForOldestPosition], @"D:\USB\Work\WeedSprayer\Programs\TargettingTest\MotionData.csv");


                //increment counter
                if (counterForOldestPosition < 100)
                {
                    counterForOldestPosition++;
                }

                if (counterForOldestPosition == 100)
                {
                    counterForOldestPosition = 0;
                }
            }

            if (counterForCurrentPosition < 100)
            {
                circularBuffer[counterForCurrentPosition] = currentPosition;
                counterForCurrentPosition++;
            }

            if (counterForCurrentPosition == 100)
            {
                counterForCurrentPosition = 0;
            }

            //This if statement will only cause the event to trigger every 10 times the serial has been updated
            //The data for every time the OnYawUpdate is trigger can be accessed every time however
            OnMotionUpdate(this, currentPosition);
        }

        public void stopMotionController()
        {
            stopSensors();

            //Print the contents of the circularBuffer to the .csv file
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

        public void saveToCSV(Position currentPosition, String filename)
        {
            StringBuilder lineToPrint = new StringBuilder();

            lineToPrint.Append(currentPosition.getTime() + ",");
            lineToPrint.Append(currentPosition.getChangeInTime() + ",");
            lineToPrint.Append(currentPosition.getXPosition() + ",");
            lineToPrint.Append(currentPosition.getYPosition() + ",");
            lineToPrint.Append(currentPosition.getYaw());
            textStream.WriteLine(lineToPrint.ToString());

            //System.IO.File.WriteAllText(filename, lineToPrint.ToString());
        }
    }
}
