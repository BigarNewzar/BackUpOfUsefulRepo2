using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;

namespace AI_Assignment_1
{
    public class Map
    {
        private string[] _line;
        private string[] _splitValueXY;
        private int _maxX;
        private int _maxY;
        private CoordinateFixer _fixer;
        private GoalCoordinate _goalCoord;
        private NullCoordinate _nullCoord;
        private string[,] _mapArray;

        private int _mapi;
        private int _mapj;
        private Path _path;
        private Room _room;




        public Map(string[] line) {
            _line = line;
            _splitValueXY = _line[0].Split(",");

            _fixer= new CoordinateFixer(_splitValueXY);

            _maxX = _fixer.GetValue(0, "[", 1);
            _maxY = _fixer.GetValue(1, "]", 0);

            MakeMap(_maxX, _maxY, line);
        }

        public void MakeMap(int x, int y, string[] line)
        {
            _mapArray = new string[y, x];//in 2D array x and y are reversed!

            Console.WriteLine("Map will be of size X = " + x + " and Y = " + y);

            for(_mapi=0; _mapi < y; _mapi++)
            {
                for (_mapj = 0; _mapj < x; _mapj++)
                {
                    _mapArray[_mapi, _mapj] = "open";
                }

            }

            _goalCoord = new GoalCoordinate(line[2], _mapArray);

            _nullCoord = new NullCoordinate(line, _mapArray);

            //Just keep this for testing purpose to see which element is storing what info
            //can be used later on in doing the GUI part
            //also do a getter and setter for array part, if need be
            for (_mapi = 0; _mapi < y; _mapi++)
            {
                for (_mapj = 0; _mapj < x; _mapj++)
                {
                    Console.WriteLine(" Map's X= " + _mapi + " Map's Y= " + _mapj + " Map's status= " + _mapArray[_mapi, _mapj]);


                }

            }

            //percept is working as intended for map,, goal posiiton, Null position and seperated Agent position! Now need to make agent movement part!




            //create a goal class and pass the codes related to goal there
            // GoalCoordinate gCord = new GoalCoordinate(lineArray[2]);

            //let goal do this part
            // GetGoalValues(lineArray[2]);

            // NullCoordinate nCord = new NullCoordinate(lineArray);

        }
        public int MaxX   // property
        {
            get { return _maxX; }   // get method
            set { _maxX = value; }  // set method
        }

        public int MaxY  // property
        {
            get { return _maxY; }   // get method
            set { _maxY = value; }  // set method
        }
    }
}
