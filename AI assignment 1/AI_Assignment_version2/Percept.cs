using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AI_Assignment_version2
{
    
    class percept
    {
        private string _line;
        private StreamReader _file;
        private List<string> _wall = new List<string>();
        private string _map;
        private string _initialState;
        private string _goalState;

        public percept(string testfile)
        {
            try
            {
                _file = new StreamReader(testfile);///add a io catch here
            }
            catch (FileNotFoundException exnotfound)
            {
                Console.WriteLine("Percept file is not found. Please make sure file is properly named, put in a txt format and is in the same directory as C:\\Users\\User");
            }
        }
        public List<string> Wall
        {
            get
            {
                return _wall;
            }
        }

        public string InitialState
        {
            get
            {
                return _initialState;
            }
        }

        public string GoalState
        {
            get
            {
                return _goalState;
            }
        }

        public string Map
        {
            get
            {
                return _map;
            }
        }

       

        //Allocate data from text _file to program variable
        public void populateData()
        {
            int counter = 0;

            while ((_line = _file.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    _map = _line;
                }

                if (counter == 1)
                {
                    _initialState = _line;
                }

                if (counter == 2)
                {
                    _goalState = _line; 
                }

                if (counter >= 3)
                {
                    _wall.Add(_line);
                }

                counter++;
            }
        }

        //Print _map info +++no longer needed now, so probably can remove
        public void printInfo()
        {
            Console.WriteLine("Map size: " + _map);
            Console.WriteLine("Initial state: " + _initialState);
            Console.WriteLine("Goal state: " + _goalState);

            foreach (string w in _wall)
            {
                Console.WriteLine("Wall: " + w);
            }
        }

        public void closeFile()
        {
            _file.Close();
        }
    }
}