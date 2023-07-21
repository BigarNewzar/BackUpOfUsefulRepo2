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

        static void Main(string[] args)
        {
            //garbage collector
            GC.Collect();

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            //need to make 100 of them
            for (int i = 0; i < 10; i++)
            {
                // Creating a file
                string myfile = "D:\\visual stuido 2022 repo\\AI assignment 1\\AI_Assignment_V3\\ConsoleApp1\\bin\\Release\\Map" + i + ".txt";

                // Appending the given texts
                using (StreamWriter sw = File.AppendText(myfile))
                {
                    //making for size5*5,10*10 and 20*20

                    int mapArraySize = 20;

                    //check 5*5, 10* 10, 20*20 cases---100 cases for each--- single vs multi goal case
                    int maxA = mapArraySize;
                    int maxB = mapArraySize;
                    point2D MapSize = new point2D(maxA, maxB);

                    Random rnd = new Random();
                    int startA = rnd.Next(0, mapArraySize);
                    int startB = rnd.Next(0, mapArraySize);
                    point2D initial = new point2D(startA, startB);


                    sw.WriteLine("[" +maxA +"," +maxB+ "]");
                    sw.WriteLine("(" + startA + "," + startB + ")");

                    

                    List<point2D> goallist = new List<point2D>();
                    for(int j =0; j< mapArraySize / 2; j++)
                    {
                        goallist.Add( new point2D(rnd.Next(0, mapArraySize), rnd.Next(0, mapArraySize)));
                    }

                    string goalline="";

                    foreach(point2D g in goallist) 
                    {
                        goalline= "(" + g.X + "," + g.Y + ") | ";
                    }

                    

                    sw.WriteLine(goalline);
                    //for single goal
                    //sw.WriteLine("(" + goalA + "," + goalB + ")");


                    //for multigoal-- currrently using for 2 goals
                   // makemultigoal(sw,rnd,goalA,goalB, mapArraySize);

                    //making random no of walls depending on map size
                    //int random = rnd.Next(mapArraySize);

                    for (int k=0; k< rnd.Next(mapArraySize); k++)
                    {
                        makemultiwall(sw, rnd, goallist, startA, startB, mapArraySize);
                        //makemultiwall(sw, rnd, goalA, goalB, startA, startB, mapArraySize, mapArraySize);
                    }

                }


                static void makemultiwall(StreamWriter sw, Random rnd, List<point2D>goalline, int startA, int startB, int mapArraySize)
                {

                    int wallA = rnd.Next(0, mapArraySize);
                    int wallB = rnd.Next(0, mapArraySize);

                    //need to set condition where length and width doesnt exceed map A and B size--- here we restrict mapsize using mapArraySize
                    //restricted size by half


                    int wallLength = rnd.Next(1,5);
                    int wallWidth = rnd.Next(1,5);

                    for (int j = wallB; j < wallB + wallWidth; j++)
                    {
                        for (int i = wallA; i < wallA + wallLength; i++)
                        {
                            foreach (point2D g in goalline)
                            {
                                //these will make wall cells.they cant be goal, they cant be start exceed the value of mapsize
                                if (i == g.X && j == g.Y || i == startA && j == startB || i >= mapArraySize || j >= mapArraySize)
                                {
                                    makemultiwall(sw, rnd, goalline, startA, startB, mapArraySize/ 4);
                                }
                                else { sw.WriteLine("(" + wallA + "," + wallB + "," + wallLength + "," + wallWidth + ")"); }
                                 
                            }
                        }
                    }

                   


                    //A + length, B + width: get the cells, none of the cells should overlap goal or person, or exceed the map size


                }


                //static void makemultigoal(StreamWriter sw, Random rnd, int goalA, int goalB, int mapArraySize)
                //{
                //    int goalC = rnd.Next(0, mapArraySize);
                //    int goalD = rnd.Next(0, mapArraySize);
                //    if (goalC != goalA && goalD != goalB)
                //    {
                //        sw.WriteLine("(" + goalA + "," + goalB + ") | (" + goalC + "," + goalD + ")");
                //    }
                //    else
                //    {
                //        makemultigoal(sw,rnd,goalA,goalB, mapArraySize);
                //    }
                //}

                //static void makemultiwall(StreamWriter sw, Random rnd, int goalA, int goalB, int startA, int startB, int mapArraySize, int wallLimUsingMapArraySize) 
                //{

                //    int wallA = rnd.Next(0, mapArraySize);
                //    int wallB = rnd.Next(0, mapArraySize);

                //    //need to set condition where length and width doesnt exceed map A and B size--- here we restrict mapsize using mapArraySize
                //    //restricted size by half

                //    if (wallLimUsingMapArraySize < 1) 
                //    { 
                //        wallLimUsingMapArraySize = 1; 
                //    }

                //    int wallLength = rnd.Next(wallLimUsingMapArraySize);
                //    int wallWidth = rnd.Next(wallLimUsingMapArraySize);

                //    for (int j = wallB; j < wallB + wallWidth; j++)
                //    {
                //        for (int i = wallA; i < wallA + wallLength; i++)
                //        {
                //            //these will make wall cells.they cant be goal, they cant be start exceed the value of mapsize
                //            if (i == goalA && j == goalB || i == startA && j == startB || i>= mapArraySize || j>= mapArraySize)
                //            {
                //                makemultiwall(sw, rnd, goalA, goalB, startA, startB, mapArraySize, mapArraySize/4);
                //            }                                                       

                //        }
                //    }

                //    sw.WriteLine("(" + wallA + "," + wallB + "," + wallLength + "," + wallWidth + ")");


                //    //A + length, B + width: get the cells, none of the cells should overlap goal or person, or exceed the map size


                //}

                watch.Stop();

                //10,000 ticks ==1 ms
                //ref: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.ticks?view=net-7.0
                Console.WriteLine("Execution Time:" + watch.ElapsedTicks + "ticks");


                //gets me the number of bytes currently thought to be allocated
                Console.WriteLine(GC.GetTotalMemory(true));

                //garbage collector
                GC.Collect();


                //521760

                //17015463936

            }


        }
    }
}