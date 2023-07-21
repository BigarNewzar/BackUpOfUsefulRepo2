using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_version2
{
    /// <summary>
    /// Sets up room location. will be used to link the rooms and let agent pass from room to room
    /// </summary>
    class Path
    {
        room _location;

        /// <summary>
        /// Set uo the path
        /// </summary>
        /// <param name="location">where it is (ie between which rooms)</param>
        public Path(room location)
        {
            _location = location;
        }
        /// <summary>
        /// getter and setter of the room path location
        /// </summary>
        public room Location
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