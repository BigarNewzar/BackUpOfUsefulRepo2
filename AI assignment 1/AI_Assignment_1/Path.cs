using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_1
{
    class Path
    {
        private Room _location;

        //constructor for room
        public Path(Room location)
        {
            _location = location;
        }

        //getter and setter for room 
        public Room Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }
    }
}
