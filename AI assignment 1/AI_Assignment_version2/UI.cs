using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AI_Assignment_version2
{
    class UI
    {
        public UI()
        {

        }

        //Draw process of expanding node
        public void Draw(point2D initial, point2D goal, List<room> wall, point2D visitedNode, int mapWidth, int mapLength, Stack<point2D> open)
        {
            Console.Clear();
            bool wallDrawn = false;

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {
                    //find out where to place this
                    //foreach (var o in open) {
                    //    if ((o.X == j) && (o.Y == i))
                    //    {
                    //        Console.Write("|o");
                    //        continue;
                    //    }
                    //}



                    if ((initial.X == j) && (initial.Y == i))
                    {
                        Console.Write("|i");
                        continue;
                    }

                    if ((goal.X == j) && (goal.Y == i))
                    {
                        Console.Write("|g");
                        continue;
                    }

                    if ((visitedNode.X == j) && (visitedNode.Y == i))
                    {
                        Console.Write("|x");
                        continue;
                    }

                    foreach (room r in wall)
                    {
                        if ((r.IsWall == true) && (r.Pos.X == j) && (r.Pos.Y == i))
                        {
                            Console.Write("|w");
                            wallDrawn = true;
                            break;
                        }
                        wallDrawn = false;
                    }

                    if (wallDrawn == false)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine("|");
            }

            if ((visitedNode.X == goal.X) && (visitedNode.Y == goal.Y))
            {
                Console.WriteLine("\nSolution found at: X = " + visitedNode.X + " Y = " + visitedNode.Y);

            }
            else
            {
                Console.WriteLine("Open node:");
                foreach (var o in open)
                { 
                    Console.WriteLine("\t(X = " + o.X + " Y = " + o.Y +")");
                }

                Console.WriteLine("\nExpanding node: X = " + visitedNode.X + " Y = " + visitedNode.Y); 
            }
            Thread.Sleep(100);
        }


        public void Draw(point2D initial, point2D goal, List<room> wall, point2D visitedNode, int mapWidth, int mapLength, Queue<point2D> open)
        {
            Console.Clear();
            bool wallDrawn = false;

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {

                    if ((initial.X == j) && (initial.Y == i))
                    {
                        Console.Write("|i");
                        continue;
                    }

                    if ((goal.X == j) && (goal.Y == i))
                    {
                        Console.Write("|g");
                        continue;
                    }

                    if ((visitedNode.X == j) && (visitedNode.Y == i))
                    {
                        Console.Write("|x");
                        continue;
                    }

                    foreach (room r in wall)
                    {
                        if ((r.IsWall == true) && (r.Pos.X == j) && (r.Pos.Y == i))
                        {
                            Console.Write("|w");
                            wallDrawn = true;
                            break;
                        }
                        wallDrawn = false;
                    }

                    if (wallDrawn == false)
                    {
                          Console.Write("| "); 
                        
                        
                    }
                }
                Console.WriteLine("|");
            }

            if ((visitedNode.X == goal.X) && (visitedNode.Y == goal.Y))
            {

                Console.WriteLine("\nSolution found at: X = " + visitedNode.X + " Y = " + visitedNode.Y);

            }
            else 
            {
                Console.WriteLine("Open node:");
                foreach (var o in open)
                {
                    Console.WriteLine("\t(X = " + o.X + " Y = " + o.Y + ")");
                }

                Console.WriteLine("\nExpanding node: X = " + visitedNode.X + " Y = " + visitedNode.Y);
            }
            Thread.Sleep(100);
        }
        public void Draw(point2D initial, point2D goal, List<room> wall, point2D visitedNode, int mapWidth, int mapLength, List<point2D> open)
        {
            Console.Clear();
            bool wallDrawn = false;

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {

                    //foreach (var o in open)
                    //{
                    //    if ((o.X == j) && (o.Y == i))
                    //    {
                    //        Console.Write("|o");
                    //        continue;
                    //    }
                    //}



                    if ((initial.X == j) && (initial.Y == i))
                    {
                        Console.Write("|i");
                        continue;
                    }

                    if ((goal.X == j) && (goal.Y == i))
                    {
                        Console.Write("|g");
                        continue;
                    }

                    if ((visitedNode.X == j) && (visitedNode.Y == i))
                    {
                        Console.Write("|x");
                        continue;
                    }

                    foreach (room r in wall)
                    {
                        if ((r.IsWall == true) && (r.Pos.X == j) && (r.Pos.Y == i))
                        {
                            Console.Write("|w");
                            wallDrawn = true;
                            break;
                        }
                        wallDrawn = false;
                    }

                    if (wallDrawn == false)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine("|");
            }

            if ((visitedNode.X == goal.X) && (visitedNode.Y == goal.Y))
            {
               
                Console.WriteLine("\nSolution found at: X = " + visitedNode.X + " Y = " + visitedNode.Y);

            }
            else
            {
                Console.WriteLine("Open node:");
                foreach (var o in open)
                {
                    Console.WriteLine("\t(X = " + o.X + " Y = " + o.Y + ")");
                }

                Console.WriteLine("\nExpanding node: X = " + visitedNode.X + " Y = " + visitedNode.Y);
            }
            Thread.Sleep(100);
        }

        //Draw solution
        public void DrawPath(point2D initial, point2D goal, List<room> wall, int mapWidth, int mapLength, List<point2D> path)
        {
            Console.Clear();
            bool wallDrawn = false;
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {
                    if ((initial.X == j) && (initial.Y == i))
                    {
                        Console.Write("|i");
                        continue;
                    }

                    if ((goal.X == j) && (goal.Y == i))
                    {
                        Console.Write("|g");
                        continue;
                    }

                    if (path.Any(x => x.X == j && x.Y == i))
                    {
                        Console.Write("|x");
                        continue;
                    }

                    foreach (room r in wall)
                    {
                        if ((r.IsWall == true) && (r.Pos.X == j) && (r.Pos.Y == i))
                        {
                            Console.Write("|w");
                            wallDrawn = true;
                            break;
                        }
                        wallDrawn = false;
                    }

                    if (wallDrawn == false)
                    { 
                    Console.Write("| ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine();
        }
    }
}