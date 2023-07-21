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
        private double _hScore;
        private double _fScore;
        private double _gScore;
        private point2D _parentNode;
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
        /// To set thier parent node and ensure there is a link between parent and child for easier setup of tree search
        /// </summary>
        /// <param name="parent">ensure the child knows who its parent node was</param>
        public point2D(point2D parent)
        {
            _x = parent.X;
            _y = parent.Y;
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
        /// Getter and setter for Heuristic value
        /// </summary>
        public double Hscore
        {
            get
            {
                return _hScore;
            }

            set
            {
                _hScore = value;
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

        /// <summary>
        /// Getter and setter for evaluation function
        /// </summary>
        public double FScore
        {
            get
            {
                return _fScore;
            }

            set
            {
                _fScore = value;
            }
        }

        /// <summary>
        /// Getter and setter for cost so far to reach goal
        /// </summary>
        public double GScore
        {
            get
            {
                return _gScore;
            }

            set
            {
                _gScore = value;
            }
        }

        /// <summary>
        /// Getter and Setter for parent node for the chosen child node
        /// </summary>
        public point2D ParentNode
        {
            get
            {
                return _parentNode;
            }

            set
            {
                _parentNode = value;
            }
        }
    }
}