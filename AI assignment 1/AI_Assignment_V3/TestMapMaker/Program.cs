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
        /// Makes multiple walls that dont overlap with start and are not outside the map and stores it as a list
        /// </summary>
        /// <param name="sw">the stream writer file</param>
        /// <param name="rnd">the rnd generator</param>
        /// <param name="mapArraySize">the same of the map</param>
        /// <param name="startA">X position of start</param>
        /// <param name="startB">Y position of start</param>
        /// <returns>List of walls</returns>
        static List<point2D> makeMultiWall(StreamWriter sw,Random rnd, int mapArraySize, int startA, int startB) {

            List<point2D> wallList= new List<point2D>();
            List<point2D> tempwalllist = new List<point2D>();

            int wallA = rnd.Next(0, mapArraySize);
            int wallB = rnd.Next(0, mapArraySize);

            //ensuring mapsize doesnt go lower than 2 and ensure that the width and length of wall can be properly set up and at minimum have a 1 as value
            if (mapArraySize < 2) { mapArraySize = 2; }

            int wallLength = rnd.Next(1, mapArraySize/2);
            int wallWidth = rnd.Next(1, mapArraySize/2);

            //did this to easily catch when wall is wrongly created
            int finalWallA = -1;
            int finalWallB = -1;
            int finalWallLength = -1;
            int finalWallWidth = -1;

            //this will be used to see whether wall is legit or not> if it doesnt overlap with start and isnt out of map, it will be taken as legit
            bool check = false;

            for (int j = wallB; j < wallB + wallLength; j++)
            {
                for (int k = wallA; k < wallA + wallWidth; k++)
                {
                    //these will make wall cells.they cant be start and cant exceed the value of mapsize
                    if ((k == startA && j == startB) || (k >= mapArraySize) || (j >= mapArraySize))
                    {
                        check = true;                      
                    }        
                }
            }

            //for walls that weren't legit (ie overlapped wih either start or were outside of map), run this function again and pass to temp list
            if (check) 
            { 
                tempwalllist = makeMultiWall(sw, rnd, startA, startB, mapArraySize);
                 
            }
            //for legit walls, pass them to wall list as final wall
            else 
            {
                finalWallA = wallA;
                finalWallB = wallB;
                finalWallLength = wallLength;
                finalWallWidth = wallWidth;

                //if anything was still there is tempwalllist, pass it to wallist
                if (tempwalllist.Count() != 0) 
                {
                    wallList.AddRange(tempwalllist.ToList());                    
                }
                wallList.Add(new point2D(finalWallA, finalWallB, finalWallLength, finalWallWidth));                 
            }

            return wallList;
            
        }

        /// <summary>
        /// It will make a list of goal coordinates depending on the noOfGoal that is passed to it and returns it
        /// </summary>
        /// <param name="sw">the stream writer file</param>
        /// <param name="rnd">the rnd generator</param>
        /// <param name="mapArraySize">the same of the map</param>
        /// <param name="noOfGoal">the no of goal coordinates that is desired</param>
        /// <returns>a list of goal coordinates</returns>
        static List<point2D> makeGoals(StreamWriter sw, Random rnd, int mapArraySize, int noOfGoal) 
        {
            // makes new goal list
            List<point2D> goallist = new List<point2D>();
            //this value will determine how many goal coordinates will be made
            int goalMakeRND = noOfGoal;

            //this will be passed to the file as goal line
            string goalLine = "";

            //makes certain no of goal coordinates and adds them to goal list
            //also shows them on console for quick check
            for (int g = 0; g < goalMakeRND; g++)
            {
                goallist.Add(new point2D(rnd.Next(0, mapArraySize), rnd.Next(0, mapArraySize)));


                Console.WriteLine(goallist[g].X + ", " + goallist[g].Y);
            }



            //if its for last element, then no need to write " | "part and instead just end with ")"
            //otherwise need to write in "("X","Y") |" format for each case
            for (int gg = 0; gg < goalMakeRND; gg++)
            {
                if (gg == goallist.Count() - 1)
                {
                    goalLine = goalLine + "(" + goallist[gg].X + "," + goallist[gg].Y + ")";

                    break;
                }
                else
                {
                    goalLine = goalLine + "(" + goallist[gg].X + "," + goallist[gg].Y + ") | ";
                    continue;
                }
            }

            //write the line to file and return back the goalist
            sw.WriteLine(goalLine);
            return goallist;
        }

        /// <summary>
        /// If any wall overlaps with goal, remove that wall
        /// </summary>
        /// <param name="temporaryWallList">passes the original wall list</param>
        /// <param name="goallist">passes the goal list</param>
        /// <returns>gives out the final wall list where no walls overlap with goal</returns>
        static List<point2D> RemoveWallOnGoal(List<point2D> temporaryWallList, List<point2D> goallist) 
        {
            
            foreach (point2D wall in temporaryWallList.ToList()) 
            {
                foreach (point2D goal in goallist)
                {
                    for (int j = wall.Y; j < wall.Y + wall.Length; j++)
                    {
                        for (int k = wall.X; k < wall.X + wall.Width; k++)
                        {
                            //if any wall cell is same as goal, remove that wall
                            if (k == goal.X && j == goal.Y)
                            {
                                temporaryWallList.Remove(wall);                              
                            }
                        }
                    }
                }
            }
            return temporaryWallList;
        }

        static void Main(string[] args)
        {
            //garbage collector
            GC.Collect();

            //need to make 100 of them
            for (int i = 0; i < 100; i++)
            {
                // Creating a file in the directory i want. Change this "path" to suit the directory where you want the txt files to appear. the Map+ i +txt will make the mapfile with names: Map0.txt, Map1.txt, Map2.txt,etc.
                string myfile = "D:\\visual stuido 2022 repo\\AI assignment 1\\AI_Assignment_V3\\ConsoleApp1\\bin\\Release\\Map" + i + ".txt";

                // Appending the given texts
                using (StreamWriter sw = File.AppendText(myfile))
                {
                    //making for size5*5,10*10 and 20*20

                    int mapArraySize = 20;

                    //check 5*5, 10* 10, 20*20 cases---100 cases for each---random no of goals
                    int maxA = mapArraySize;
                    int maxB = mapArraySize;
                    sw.WriteLine("[" + maxA + "," + maxB + "]");


                    //generate random number for use everywhere
                    Random rnd = new Random();

                    //generate random start point
                    int startA = rnd.Next(0, mapArraySize);
                    int startB = rnd.Next(0, mapArraySize);
                    sw.WriteLine("(" + startA + "," + startB + ")");


                    //the integer at the end here determines how many goals will be made. 
                    //Beware! Currently this system has been designed to completely remove wall coords that match with goal and thus increasing the value would decrease change of even a single wall from spawning
                    List<point2D>finalGoalList= makeGoals(sw, rnd, mapArraySize, 1);



                    //generate walls and remove those who dont fit start or are outside of map
                    List<point2D> temporaryWallList = new List<point2D>();
                    for (int l = 0; l < mapArraySize * mapArraySize; l++)
                    {
                        temporaryWallList =makeMultiWall(sw, rnd, mapArraySize, startA, startB);
                    }

                    //removes each and every instances where if coordinate of created wall overlaps with any of the goals made, the wall will be removed completely. Afterthat it adds to final wallist
                    //Note: turn this off if you want to have impossible goals (ie goals where wall and goal coord overlap and also ones where goal is smack middle of walls)
                    List<point2D> finalWallList = RemoveWallOnGoal(temporaryWallList, finalGoalList);

                    //writes walls to the txt file (if any exist)
                    foreach (point2D wall in finalWallList)
                    {
                        sw.WriteLine("(" + wall.X + "," + wall.Y + "," + wall.Width + "," + wall.Length + ")");
                    }

                }


            }        
                        
        }
    }  

}
    
