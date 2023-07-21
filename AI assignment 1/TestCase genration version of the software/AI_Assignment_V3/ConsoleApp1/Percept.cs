using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AI_Assignment_version2
{
    /// <summary>
    /// Reads in file and seperates the lines into walls, map, intial and goal information lines
    /// </summary>
    class percept
    {

        private string _line;
        private StreamReader _file;
        private List<string> _wall = new List<string>();
        private string _map;
        private string _initialState;
        private string _goalState;
        /// <summary>
        /// checks file exists or not and call stream reader to read file
        /// </summary>
        /// <param name="testfile">the filename passed from Program.cs file</param>
        public percept(string testfile)
        {
            try
            {
                _file = new StreamReader(testfile);
            }
            catch (FileNotFoundException exnotfound)
            {
                Console.WriteLine("Percept file is not found. Please make sure file is properly named, put in a txt format and is in the same directory as the .exe file");
            }
        }
        /// <summary>
        /// Getter for list of walls
        /// </summary>
        public List<string> Wall
        {
            get
            {
                return _wall;
            }
        }
        /// <summary>
        /// Getter for Initial State
        /// </summary>

        public string InitialState
        {
            get
            {
                return _initialState;
            }
        }
        /// <summary>
        /// Getter for Goal state
        /// </summary>
        public string GoalState
        {
            get
            {
                return _goalState;
            }
        }

        /// <summary>
        /// Getter for Map
        /// </summary>
        public string Map
        {
            get
            {
                return _map;
            }
        }



        /// <summary>
        /// Allocate data from text _file to program variable by reading in the lines
        /// </summary>
        public void populateData()
        {
            int counter = 0;

            while ((_line = _file.ReadLine()) != null)
            {
                //Map Max X and Y values
                if (counter == 0)
                {
                    _map = _line;
                }

                //player X and Y values
                if (counter == 1)
                {
                    _initialState = _line;
                }

                //Goal X and Y values
                if (counter == 2)
                {
                    _goalState = _line;
                }

                //all other lines are walls, so wall x, y, width and height alues
                if (counter >= 3)
                {
                    _wall.Add(_line);
                }

                //increment counter
                counter++;
            }
        }
    }
}