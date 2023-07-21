using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace AI_Assignment_1
{
    public class Room
    {
        private Point _pos;
        private bool _isWall;
        private List<Path> _paths = new List<Path>();

        public Room(Point pos, bool wall)
        {
            _pos = pos;
            _isWall = wall;
        }
        
        

        public Point Pos
        {
            get
            {
                return _pos;
            }
            set { _pos = value; }
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
