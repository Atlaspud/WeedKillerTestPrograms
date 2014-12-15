using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class MotionUpdate : EventArgs
    {
        private Position position;

        public MotionUpdate(Position position)
        {
            this.position = position;
        }

        public Position Position
        {
            get
            {
                return position;
            }
        }  
    }
}
