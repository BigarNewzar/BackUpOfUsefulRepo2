using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_version2
{
    class point2D
    {
        private int _x;
        private int _y;
        private double _pScore;//as it really wanted priority
        private double _hScore;
        private double _fScore;
        private double _gScore;
        private point2D _parentNode;
        private string _outputString;

        public point2D(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public point2D(point2D parent)
        {
            _x = parent.X;
            _y = parent.Y;
        }

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
        public double Pscore
        {
            get 
            { 
                return _pScore;
            }      
            set 
            {
                _pScore = value;
            }   
        }

        public string Coordinate
        {
            get
            {
                _outputString = "Pos X = " + X + ", Pos Y = " + Y ;
                return _outputString;
            }
        }

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