using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    class IMUData
    {
        private DateTime time;
        private double changeInTime;
        private double aX;
        private double aY;
        private double aZ;
        private double yaw;
        private double pitch; 
        private double roll;
        private double velocity;
        private double velocityMagnitude;

        public IMUData(DateTime time, double changeInTime, 
            double aX, double aY, double aZ, 
            double yaw, double pitch, double roll, 
            double velocity, double velocityMagnitude)
        {
            this.time = time;
            this.changeInTime = changeInTime;
            this.aX = aX;
            this.aY = aY;
            this.aZ = aZ;
            this.yaw = yaw;
            this.pitch = pitch;
            this.roll = roll;
            this.velocity = velocity;
            this.velocityMagnitude = velocityMagnitude;
        }

        public IMUData() 
        {
            this.time = DateTime.Now;
            this.changeInTime = 40;
            this.aX = 0;
            this.aY = 0;
            this.aZ = 0;
            this.yaw = 0;
            this.pitch = 0;
            this.roll = 0;
        }

        public DateTime getTime()
        {
            return time;
        }

        public double getChangeInTime()
        {
            return changeInTime;
        }

        public double getAX()
        {
            return aX;
        }

        public double getAY()
        {
            return aY;
        }

        public double getAZ()
        {
            return aZ;
        }

        public double getYaw()
        {
            return yaw;
        }

        public double getPitch()
        {
            return pitch;
        }

        public double getRoll()
        {
            return roll;
        }

        public double getVelocity()
        {
            return velocity;
        }

        public double getVelocityMagnitude()
        {
            return velocityMagnitude;
        }

        public override string ToString()
        {
            StringBuilder stringOutput = new StringBuilder();

            stringOutput.Append(time + ",");
            stringOutput.Append(changeInTime + ",");
            stringOutput.Append(aX + ",");
            stringOutput.Append(aY + ",");
            stringOutput.Append(aZ + ",");
            stringOutput.Append(yaw + ",");
            stringOutput.Append(pitch + ",");
            stringOutput.Append(roll + ",");
            stringOutput.Append(velocity + ",");
            stringOutput.Append(velocityMagnitude);

            return stringOutput.ToString();
        }

    }
}
