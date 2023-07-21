using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_version2
{
    class Path
    {
        room _location;

        public Path(room location)
        {
            _location = location;
        }

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