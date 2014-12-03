using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace model
{
    public class Sprayer
    {
        private SprayerRelay sprayerRelay1;
        private SprayerRelay sprayerRelay2;
        private volatile Position currentPosition;

        public Sprayer(String sprayerId1, String sprayerid2)
        {
            sprayerRelay1 = new SprayerRelay(sprayerId1);
            sprayerRelay2 = new SprayerRelay(sprayerid2);
            OnTargetAdded += _OnTargetAdded;
            currentPosition = new Position(0, 0);

        }

        public void setCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition;
        }

        private void spray(int sprayerIndex, int time)
        {
            if (sprayerIndex >= 1 & sprayerIndex <= 4)
            {
                //for sprayerRelay1
                //turn a sprayer on
                sprayerRelay1.changeSprayerStatus(sprayerIndex, true);
                //wait for a period 
                Thread.Sleep(time);//ms
                //thread sleep is not ideal at all <<-------

                //turn sprayer off
                sprayerRelay1.changeSprayerStatus(sprayerIndex, false);
            }
            else if (sprayerIndex >= 5 & sprayerIndex <= 8)
            {
                //for sprayerRelay2
                //turn a sprayer on
                sprayerRelay2.changeSprayerStatus((sprayerIndex - 4), true);
                //wait for a period 
                Thread.Sleep(time);//ms
                //thread sleep is not ideal at all <<-------

                //turn sprayer off
                sprayerRelay2.changeSprayerStatus((sprayerIndex - 4), false);
            }
        }

        public delegate void TargetAddedHandler(object source, Target sprayerTarget);

        public event TargetAddedHandler OnTargetAdded;

        public void addTarget(Target target)
        {
            OnTargetAdded(this, target);
        }

        public void _OnTargetAdded(object source, Target target)
        {
            while (!target.getSprayedStatus())
            {





                spray(5,50);
                target.setSprayed();

            }

        }



    }
}
