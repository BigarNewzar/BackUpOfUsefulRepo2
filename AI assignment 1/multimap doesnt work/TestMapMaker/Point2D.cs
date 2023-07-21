using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_version2
{
    /// <summary>
    /// Creates all position values as X and Y values that have parent nodes, heuristic values (hScore) [here it is straight line distance to goal], cost so far (gScore), evaluation function (fScore), and an output string to display coordinates of points
    /// </summary>
    class point2D
    {
        private int _x;
        private int _y;
        
        private string _outputString;


        /// <summary>
        /// Makes the Point2D as objects with X and Y values
        /// </summary>
        /// <param name="x">X position of object</param>
        /// <param name="y">Y position of object</param>
        public point2D(int x, int y)
        {
            _x = x;
            _y = y;
        }

      

        /// <summary>
        /// Getter and setter for X position
        /// </summary>
        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// Getter and setter for Y position
        /// </summary>
        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }


        

        /// <summary>
        /// Getter Coordinate value in more verbose manner
        /// </summary>
        public string Coordinate
        {
            get
            {
                _outputString = "Pos X = " + X + ", Pos Y = " + Y;
                return _outputString;
            }
        }

        

    }
}