using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AI_Assignment_version2
{
    class map
    {
        List<room> _room = new List<room>();
        private int _width;
        private int _length;
        private List<string> _wall;
        private List<room> _wallList = new List<room>();

        public List<room> Room
        {
            get
            {
                return _room;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        public List<room> WallList
        {
            get
            {
                return _wallList;
            }
        }

        //Map constructor
        public map(string mapSize, List<string> mapWall)
        {
            Sanitise s = new Sanitise(mapSize);

            List<int> coordinate = s.getInt();

            _width = coordinate[0];
            _length = coordinate[1];
            _wall = mapWall;
            drawMap();
        }

        //Draw the whole map
        public void drawMap()
        {
            //Keep in mind, X and Y are reversed in c# array! i is basically Y and j is basically x of cartesian coordinates!
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _length; j++)
                {
                    _room.Add(new room(new point2D(j, i), false));
                }
            }

            for (int i = 0; i < _wall.Count; i++)
            {
                drawWall(_wall[i]);
            }

            drawPath();
        }

        //Populate adjacent available _paths for room 
        //maybe fix this part to ensure agent sees up then left then down then right room
        public void drawPath()
        {
            for (int i = 0; i < _room.Count; i++)
            {
                if (!_room[i].IsWall)
                {
                    //this is for injection room on up

                    if (i > _length - 1)
                    {
                        if (!_room[i - _length].IsWall)
                        {
                            _room[i].Paths.Add(new Path(_room[i - _length]));
                        }
                    }

                    

                    //this is for injection room on left
                    for (int j = 0; j < _width; j++)
                    {
                        if ((i > j * _length) && (i < (j + 1) * _length))
                        {
                            _room[i].Paths.Add(new Path(_room[i - 1]));
                        }
                    }



                    //this is for injection room on down
                    if (i < _length * _width - _length)
                    {
                        if (!_room[i + _length].IsWall)
                        {
                            _room[i].Paths.Add(new Path(_room[i + _length]));
                        }
                    }

                    //this is for injection room on Right

                    for (int j = 0; j < _width; j++)
                    {
                        if ((i >= j * _length) && (i < (j + 1) * _length - 1))
                        {
                            _room[i].Paths.Add(new Path(_room[i + 1]));
                        }
                    }

                }
            }

            //Remove _paths that are obstacles
            foreach (room r in _room)
            {
                for (int i = 0; i < r.Paths.Count; i++)
                {
                    if (r.Paths[i].Location.IsWall == true)
                    {
                        r.Paths.Remove(r.Paths[i]);
                    }
                }
            }
        }

        //Draw obstacles
        public void drawWall(string oneWall)
        {
            Sanitise s = new Sanitise(oneWall);
            List<int> coordinate = s.getInt();

            //ensure max value for the coordinate by adding the l and w values from txt file
            for (int j = coordinate[1]; j < coordinate[1] + coordinate[3]; j++)
            {
                for (int i = coordinate[0]; i < coordinate[0] + coordinate[2]; i++)
                {
                    int index = _room.FindIndex(x => (x.Pos.X == i) && (x.Pos.Y == j));
                    _room[index].IsWall = true;
                }
            }

            foreach (room r in _room)
            {
                if (r.IsWall == true)
                {
                    _wallList.Add(r);
                }
            }
        }

        //Print map info
        public void printMap()
        {
            foreach (room r in _room)
            {
                Console.WriteLine("Room: X = " + r.Pos.X + " and Y = " + r.Pos.Y + " is wall = " + r.IsWall);
                Console.WriteLine("Containing: ");
                foreach (Path p in r.Paths)
                {
                    Console.WriteLine(p.Location.Pos.Coordinate);
                }
                Console.WriteLine("");
            }
        }

    }
}