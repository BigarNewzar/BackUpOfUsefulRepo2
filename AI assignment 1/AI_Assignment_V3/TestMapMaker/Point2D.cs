using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_version2
{
    /// <summary>
    /// Creates all normal nodes (only x and y) and wall nodes (x and y and w and l) , and an output string to display coordinates of points
    /// </summary>
    class point2D
    {
        private int _x;
        private int _y;
        private int _l;
        private int _w;
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
        public point2D(int x, int y, int l, int w)
        {
            _x = x;
            _y = y;
            _l = l;

            _w = w;
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
        /// Getter and setter for width position
        /// </summary>
        public int Width
        {
            get
            {
                return _w;
            }

            set
            {
                _w = value;
            }
        }

        /// <summary>
        /// Getter and setter for length position
        /// </summary>
        public int Length
        {
            get
            {
                return _l;
            }

            set
            {
                _l = value;
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