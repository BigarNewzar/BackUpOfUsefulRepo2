using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_version2
{
    class Program
    {


        static void Main(string[] args)
        {
            string s;
            //still no luck. Need to get command line to be able to pass parameters to exe version of the file!!!!

            //Environment.
            //string[] args2 = Environment.GetCommandLineArgs();
            //Console.WriteLine(Directory.GetCurrentDirectory());
            //Console.WriteLine("Press Enter name of file");
            // s = Console.ReadLine();

            Console.WriteLine("this is my value for arg" + args[0]);
            Console.ReadLine();
           


            //string[] inputStringList = s.Split(" ");
            string[] inputStringList = args;

            
            string filename = inputStringList[0];
            string searchName = inputStringList[1];
            
            
            //Load and initialize _map, state information from inputted filename
            percept p = new percept("..\\..\\..\\..\\..\\..\\..\\" + filename + ".txt");

            //percept p = new percept("..\\..\\..\\" + filename + ".txt");

            //Read test _file and populate data to suitable variables
            p.populateData();

            //Initialize _map
            map Map = new map(p.Map, p.Wall);



            //set the condition here for it to reach both goals
            //create a seperate file in pipeline where program goes to that file to check single or multiple goal and then calls agent
            if (p.GoalState.Contains("|"))
            {
                Sanitise goal = new Sanitise(p.GoalState);
                List<int> coordinatelist = goal.getInt();
                string _goalPos;

                //add goal pos to list of goalpos
                for (int i = 0; i <= coordinatelist.Count / 2; i = i + 2)
                {
                    _goalPos = "(" + coordinatelist[i] + "," + coordinatelist[i + 1] + ")";
                    Agent ai = new Agent(p.InitialState, _goalPos, Map);

                    chooseSearch(ai, searchName);

                    //keeping it here for testing stuff + make sure to remove it and put the auto search thingy once you know how to make c# into exe
                    Console.WriteLine("This is for Goal coordinates: X = " + coordinatelist[i] + " and Y = " + coordinatelist[i + 1] + " \nPress Enter to see for alternative (if any) ");
                    Console.ReadLine();

                }

            }
            else
            {
                Agent ai = new Agent(p.InitialState, p.GoalState, Map);

                chooseSearch(ai, searchName);

            }
            Console.ReadLine();
        }

        static void chooseSearch(Agent ai, string searchName)
        {
            switch (searchName.ToLower())
            {
                case "dfs":
                    Console.WriteLine(ai.DfsSearch());
                    break;
                case "bfs":
                    Console.WriteLine(ai.BfsSearch());
                    break;
                case "dfslim":
                    Console.WriteLine(ai.DfsLimitedSearch());
                    break;
                case "gbfs":
                    Console.WriteLine(ai.GbfsSearch());
                    break;
                case "astar":
                    Console.WriteLine(ai.AStarSearch());
                    break;
                case "astarlim":
                    Console.WriteLine(ai.AStarLimitedSearch());
                    break;
                default:
                    Console.WriteLine("No search method called " + searchName);
                    break;
                    
            }
        }
    }
}