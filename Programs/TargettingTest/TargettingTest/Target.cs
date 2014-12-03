using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Target
    {
        private Position targetPosition;
        private Boolean sprayedStatus;
        private int cameraIndex;


        public Target(Position targetPosition, int cameraIndex)
        {
            this.targetPosition = targetPosition;

            //camera index must be between 1 and 8
            if (cameraIndex > 8)
            {
                this.cameraIndex = 8;
            }
            else if (cameraIndex < 1)
            {
                cameraIndex = 1;
            }
            else
            {
                this.cameraIndex = cameraIndex;
            }

            sprayedStatus = false;
        }

        public void setSprayed()
        {
            sprayedStatus = true;
        }

        public Boolean getSprayedStatus()
        {
            return sprayedStatus;
        }

        public Position getPosition()
        {
            return targetPosition;
        }
    }
}
