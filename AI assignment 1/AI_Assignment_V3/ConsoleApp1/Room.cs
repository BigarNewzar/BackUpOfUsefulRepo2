using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_version2
{
    /// <summary>
    /// Sets up room, whether or not it has wall and path to other room
    /// </summary>
    class room
    {
        private point2D _pos;
        private bool _isWall;
        private List<Path> _paths = new List<Path>();

        /// <summary>
        /// Getter for room position
        /// </summary>
        public point2D Pos
        {
            get
            {
                return _pos;
            }
        }

        /// <summary>
        /// Setup room position and whether it is wall or not
        /// </summary>
        /// <param name="ppos">X, Y Position of room</param>
        /// <param name="wall"> Whether it is wall or open</param>
        public room(point2D ppos, bool wall)
        {
            _pos = ppos;
            _isWall = wall;
        }

        /// <summary>
        /// Getter and setter for whether wall or not
        /// </summary>
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

        /// <summary>
        /// Getter and Setter for path list
        /// </summary>
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