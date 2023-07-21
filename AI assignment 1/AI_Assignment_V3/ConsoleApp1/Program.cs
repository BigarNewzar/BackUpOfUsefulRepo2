using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_version2
{
    class program
    {

        /// <summary>
        /// Takes it args and also calls percept, map, goal and agent to make themselves and uses the chooseSearch method
        /// </summary>
        /// <param name="args">the commandline inputs</param>
        static void Main(string[] args)
        {

            //filename in 1st parameter passed
            string filename = args[0];

            //search algo name in 2nd parameter passed
            string searchName = args[1];


            //Load and initialize _map, state information from inputted filename
            percept p = new percept(filename + ".txt");

          

            //Read file and populate data to suitable variables
            p.populateData();

            //Initialize _map
            map Map = new map(p.Map, p.Wall);



            //set condition for multi goal handling
            if (p.GoalState.Contains("|"))
            {
                //sanitise the goal and set goal coordinates
                Sanitise goal = new Sanitise(p.GoalState);

                //create list of goal coordintes
                List<int> coordinatelist = goal.getInt();

                string _goalPos;

                //add goal positions to list of goalpos and run agent for each instance of goal
                for (int i = 0; i <= coordinatelist.Count / 2; i = i + 2)
                {
                    _goalPos = "(" + coordinatelist[i] + "," + coordinatelist[i + 1] + ")";


                    //make agent
                    Agent ai = new Agent(p.InitialState, _goalPos, Map);

                    //choose search algo to use
                    chooseSearch(ai, searchName);

                    //letting user know to press enter to see for other goal 
                    Console.WriteLine("This is for Goal coordinates: X = " + coordinatelist[i] + " and Y = " + coordinatelist[i + 1] + " \nPress Enter to see for alternative goal Coordinates (if any) ");
                    Console.ReadLine();

                }

            }
            //single goal case
            else
            {
                //make agent
                Agent ai = new Agent(p.InitialState, p.GoalState, Map);

                //choose search algo to use
                chooseSearch(ai, searchName);

            }
            Console.ReadLine();

            ///////////////////////////////////////The following are part of Automatic Testing and data colelction///////////////
            //          forcing the garbage collector to run
            //GC.Collect();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }


        /// <summary>
        /// Choose algo to use from searchName. Pass in AI to call function
        /// </summary>
        /// <param name="ai">Agent that will call functions</param>
        /// <param name="searchName">the inputted search algo names</param>
        static void chooseSearch(Agent ai, string searchName)
        {
            ///////////////////////////////////////The following are part of Automatic Testing and data colelction///////////////
            //          Capturing time taken to choose and run the algo
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

            //////////////////////////////////////////////The following are part of Automatic Testing and data colelction///////////////
            //          10,000 ticks ==1 ms. So using this to get no of ticks it needs to run algo
            //          ref: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.ticks?view=net-7.0
            //string watchTicks = watch.ElapsedTicks.ToString();
            //Console.WriteLine("Execution Time for the search function:" + watchTicks + "ticks");
            //
            //
            //          gets me the number of bytes currently thought to be allocated
            //long totalMemoryUsed = GC.GetTotalMemory(true);
            //Console.WriteLine(totalMemoryUsed);
            //Console.WriteLine("Press Enter after noting down the time and matric");
            //Console.ReadLine();
            //
            //              appending data to file on the same directory as search.exe and name it TestdataForAlgo
            //string myfile = "TestdataForAlgo" + searchName + ".txt";
            //using (StreamWriter sw = File.AppendText(myfile))
            //{
            //
            //    sw.WriteLine(watchTicks + "," + totalMemoryUsed + "," + ai.getVisited.Count);
            //
            //}
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }
    }
}