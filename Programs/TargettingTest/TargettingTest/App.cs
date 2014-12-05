using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace controller
{
    public class App
    {
        public Motion motionController;
        public Sprayer sprayer;
        public volatile Position currentPosition;

        public App()
        {
            motionController = new Motion("COM9", "COM10");
            sprayer = new Sprayer("FTXG3YUN", "FTVAS7VX");
            motionController.startMotionController();

        }

        //Event Definition which the GUI subscribes to to have an up to date currentPosition
        public delegate void MotionUpdateHandler(object source, Position currentPosition);
        public event MotionUpdateHandler OnMotionUpdate;

        private void motionControl_OnMotionUpdate(object source, MotionUpdate motionUpdateArgs)
        {
            //Update currentPosition
            currentPosition = motionController.getCurrentPosition();

            //Trigger Event for the GUI update
            OnMotionUpdate(this, currentPosition);
        }

        //Event which the sprayer subscribes to to add a new target when the Image processor has found a target
        public delegate void TargetFoundHandler(object source, Target targetArgs); 
        public event TargetFoundHandler OnTargetFound;

        //This will be an event which the application subscribes to from the image processor, just a function for the time being
        public void targetFromImageProcessorEvent(Target target)
        { 
            OnTargetFound(this, target);
        }
    }
}
