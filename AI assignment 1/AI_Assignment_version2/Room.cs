using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_version2
{
    class room
    {
        private point2D _pos;
        private bool _isWall;
        private List<Path> _paths = new List<Path>();


        public point2D Pos
        {
            get
            {
                return _pos;
            }
        }

        public room(point2D ppos, bool wall)
        {
            _pos = ppos;
            _isWall = wall;
        }

        public bool IsWall
        {
            get
            {
                return _isWall;
            }

            set
            {
                _isWall = value;
            }
        }

        public List<Path> Paths
        {
            get
            {
                return _paths;
            }

            set
            {
                _paths = value;
            }
        }


    }
}