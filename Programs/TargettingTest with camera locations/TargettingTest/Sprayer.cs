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
        private const int SPRAY_TIME = 50; //ms
        private static readonly double[,] SPRAYER_LOCATIONS = new double [8,2] { { -0.875, -1.35 }, { -0.625, -1.35 }, { -0.375, -1.35 }, { -0.125, -1.35 }, //Sprayer Relay 1 (Sprayers 1-4)
                                                              { 0.125, -1.35 }, { 0.375, -1.35 }, { 0.625, -1.35 }, { 0.875, -1.35 } }; // Sprayer Relay 2 (Sprayers 5-8)

        public Sprayer(String sprayerId1, String sprayerid2)
        {
            sprayerRelay1 = new SprayerRelay(sprayerId1);
            sprayerRelay2 = new SprayerRelay(sprayerid2);
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
        
        //Create Event or thread for this to run in
        public void addTarget(Target target)
        {
            Thread targetThread = new Thread(delegate()
            {
                while (!target.getSprayedStatus())
                {
                    Position targetPositionReferencedToTrailer = Position.positionInReferenceTo(target.getPosition(), currentPosition);

                    if (engageSprayer(targetPositionReferencedToTrailer, rotateSprayerPositionsForYaw(currentPosition))) { target.setSprayed(); }
                }
            });

            targetThread.Start();
        }

        private double[,] rotateSprayerPositionsForYaw(Position currentPosition)
        {

            double[,] rotatedSprayerPositions = new double[8, 2];

            for (int i = 0; i < 8; i++)
            {
                //rotated X coordinate
                rotatedSprayerPositions[i, 0] = (SPRAYER_LOCATIONS[i, 0] * Math.Cos(currentPosition.getYaw() + (Math.PI / 2.0))) + (SPRAYER_LOCATIONS[i, 1] * Math.Sin(currentPosition.getYaw() + (Math.PI / 2.0)));

                //rotated Y coordinate
                rotatedSprayerPositions[i, 1] = -(SPRAYER_LOCATIONS[i, 0] * Math.Sin(currentPosition.getYaw() + (Math.PI / 2.0))) + (SPRAYER_LOCATIONS[i, 1] * Math.Cos(currentPosition.getYaw() + (Math.PI / 2.0)));
            }

            return rotatedSprayerPositions;
        }


        private Boolean engageSprayer(Position positionOfTarget, double[,] sprayerPositions)
        {
            Boolean sprayed = false;
            for (int i = 0; i < 8; i++)
            {
                //Sprayer 1-8
                if (Position.isPositionWithinLimits(
                    (sprayerPositions[i, 0] - 0.1), //Xmin Position
                    (sprayerPositions[i, 0] + 0.1), //XMax Position
                    (sprayerPositions[i, 1] - 0.1), //YMin Position
                    (sprayerPositions[i, 1] + 0.1), //YMax Position
                    positionOfTarget)) //Where the centre of image is
                    //There is potential that this may miss half a target area (which is the area of the image)
                {
                    spray((i + 1), SPRAY_TIME);
                    sprayed = true;
                }
            }
            return sprayed;
        }

    }
}
