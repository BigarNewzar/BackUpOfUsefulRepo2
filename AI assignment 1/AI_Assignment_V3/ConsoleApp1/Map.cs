using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AI_Assignment_version2
{
    /// <summary>
    /// Set up the entire map that the agent will search on, including position of wall,paths and goal
    /// </summary>
    class map
    {
        List<room> _room = new List<room>();
        private int _width;
        private int _length;
        private List<string> _wall;
        private List<room> _wallList = new List<room>();

        /// <summary>
        /// Getter for list of rooms
        /// </summary>
        public List<room> Room
        {
            get
            {
                return _room;
            }
        }

        /// <summary>
        /// Getter for Max width of Map
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Getter for Max length of Map
        /// </summary>
        public int Length
        {
            get
            {
                return _length;
            }
        }

        /// <summary>
        /// Getter for list of walls
        /// </summary>
        public List<room> WallList
        {
            get
            {
                return _wallList;
            }
        }


        /// <summary>
        /// Make the Map
        /// </summary>
        /// <param name="mapSize">size of map</param>
        /// <param name="mapWall">list of walls that will be put on map</param>
        public map(string mapSize, List<string> mapWall)
        {
            //clean the mapsize to readable values
            Sanitise s = new Sanitise(mapSize);

            //converts the values to ints and seperated them to two coordinates and puts width and length
            List<int> coordinate = s.getInt();
            _width = coordinate[0];
            _length = coordinate[1];

            //set map wall
            _wall = mapWall;

            //draw the map
            drawMap();
        }

        

        /// <summary>
        /// Draw the map
        /// </summary>
        public void drawMap()
        {
            //Keep in mind, X and Y are reversed in c# array! i is basically Y and j is basically x of cartesian coordinates!
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _length; j++)
                {
                    //make and add rooms to roomlist
                    _room.Add(new room(new point2D(j, i), false));
                }
            }

            //Make all walls
            for (int i = 0; i < _wall.Count; i++)
            {
                drawWall(_wall[i]);
            }

            //make paths to connect the rooms
            drawPath();
        }

        /// <summary>
        /// Draw the paths that will connect the rooms
        /// Currently, using it to ensure that the Search Algos would put the preference of going up first, then left, then down and right. Issue: For Depth first search and depth limited depth first search, its using Stack and not list or queue. Thus it ill cause those two algos to go in reverse
        /// </summary>
        public void drawPath()
        {
            for (int i = 0; i < _room.Count; i++)
            {
                if (!_room[i].IsWall)
                {
                    //make path to room above the current room first
                    if (i > _length - 1)
                    {
                        if (!_room[i - _length].IsWall)
                        {
                            _room[i].Paths.Add(new Path(_room[i - _length]));
                        }
                    }

                    //make path to room left of the current room next
                    for (int j = 0; j < _width; j++)
                    {
                        if ((i > j * _length) && (i < (j + 1) * _length))
                        {
                            _room[i].Paths.Add(new Path(_room[i - 1]));
                        }
                    }

                    //make path to room down of the current room next
                    if (i < _length * _width - _length)
                    {
                        if (!_room[i + _length].IsWall)
                        {
                            _room[i].Paths.Add(new Path(_room[i + _length]));
                        }
                    }

                    //make path to room right of the current room in the end
                    for (int j = 0; j < _width; j++)
                    {
                        if ((i >= j * _length) && (i < (j + 1) * _length - 1))
                        {
                            _room[i].Paths.Add(new Path(_room[i + 1]));
                        }
                    }

                }
            }

            //room which are walls do not need paths connecting them
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

        /// <summary>
        /// Drawing the walls from the lines that has info about the walls
        /// </summary>
        /// <param name="oneWall">wall list that has been obtained from Program.cs</param>
        public void drawWall(string oneWall)
        {
            //remove symbols from the wall lines and pass them into coordinates after converting them into ints
            Sanitise s = new Sanitise(oneWall);
            List<int> coordinate = s.getInt();

            //ensure max value for the coordinate by adding the l and w values from txt file and thus find the cells that should have walls and inject the wall into them
            for (int j = coordinate[1]; j < coordinate[1] + coordinate[3]; j++)
            {
                for (int i = coordinate[0]; i < coordinate[0] + coordinate[2]; i++)
                {
                    int index = _room.FindIndex(x => (x.Pos.X == i) && (x.Pos.Y == j));
                    _room[index].IsWall = true;
                }
            }

            //room that has wall, add to wall list
            foreach (room r in _room)
            {
                if (r.IsWall == true)
                {
                    _wallList.Add(r);
                }
            }
        }
    }
}