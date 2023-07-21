using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using static System.Net.WebRequestMethods;

namespace AI_Assignment_version2
{
    /// <summary>
    /// The UI class will handle all the drawing tasks
    /// </summary>
    class UI
    {
        public UI()
        {

        }

        
        /// <summary>
        /// Draw process of expanding node for ones using Stack to store frontier nodes
        /// </summary>
        /// <param name="initial">Agent position</param>
        /// <param name="goal">Goal position</param>
        /// <param name="wall">Wall position</param>
        /// <param name="visitedNode">Node that is currently being visited</param>
        /// <param name="mapWidth">Max width of map</param>
        /// <param name="mapLength">Max length of map</param>
        /// <param name="frontier">Nodes that are currently in frontier</param>
        public void Draw(point2D initial, point2D goal, List<room> wall, point2D visitedNode, int mapWidth, int mapLength, Stack<point2D> frontier)
        {
            Console.Clear();
            bool wallDrawn = false;

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {
                    //Set position of Agent
                    if ((initial.X == j) && (initial.Y == i))
                    {
                        Console.Write("|i");
                        continue;
                    }

                    //Set position of goal
                    if ((goal.X == j) && (goal.Y == i))
                    {
                        Console.Write("|g");
                        continue;
                    }

                    

                    //Set position of the visitedNode
                    if ((visitedNode.X == j) && (visitedNode.Y == i))
                    {
                        Console.Write("|x");
                        continue;
                    }

                    //Set posiiton of nodes in frontier
                    if (frontier.Any(x => x.X == j && x.Y == i))
                    {
                        Console.Write("|f");
                        continue;
                    }

                    //Set position of wall
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
                    //Set empty cells
                    if (wallDrawn == false)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine("|");
            }

            //Output of where goal was found
            if ((visitedNode.X == goal.X) && (visitedNode.Y == goal.Y))
            {
                Console.WriteLine("\nSolution found at: X = " + visitedNode.X + " Y = " + visitedNode.Y);

            }
            //Outputting nodes that are in the frontier 
            else
            {
                Console.WriteLine("Frontier node:");
                foreach (var f in frontier)
                {
                    Console.WriteLine("\t(X = " + f.X + " Y = " + f.Y + ")");
                }
                //Outputting node that is currently being visited
                Console.WriteLine("\nExpanding node: X = " + visitedNode.X + " Y = " + visitedNode.Y);
            }
            Thread.Sleep(100);

            Console.Clear();
        }

        /// <summary>
        /// Draw process of expanding node for ones using Queue to store frontier nodes
        /// </summary>
        /// <param name="initial">Agent position</param>
        /// <param name="goal">Goal position</param>
        /// <param name="wall">Wall position</param>
        /// <param name="visitedNode">Node that is currently being visited</param>
        /// <param name="mapWidth">Max width of map</param>
        /// <param name="mapLength">Max length of map</param>
        /// <param name="frontier">Nodes that are currently in frontier</param>
        public void Draw(point2D initial, point2D goal, List<room> wall, point2D visitedNode, int mapWidth, int mapLength, Queue<point2D> frontier)
        {
            Console.Clear();
            bool wallDrawn = false;

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {
                    //Set position of Agent
                    if ((initial.X == j) && (initial.Y == i))
                    {
                        Console.Write("|i");
                        continue;
                    }

                    //Set position of goal
                    if ((goal.X == j) && (goal.Y == i))
                    {
                        Console.Write("|g");
                        continue;
                    }

                    //Set position of the visitedNode
                    if ((visitedNode.X == j) && (visitedNode.Y == i))
                    {
                        Console.Write("|x");
                        continue;
                    }
                    //Set posiiton of nodes in frontier
                    if (frontier.Any(x => x.X == j && x.Y == i))
                    {
                        Console.Write("|f");
                        continue;
                    }

                    //Set position of wall
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

                    //Set empty cells
                    if (wallDrawn == false)
                    {
                        Console.Write("| ");


                    }
                }
                Console.WriteLine("|");
            }

            //Output of where goal was found
            if ((visitedNode.X == goal.X) && (visitedNode.Y == goal.Y))
            {

                Console.WriteLine("\nSolution found at: X = " + visitedNode.X + " Y = " + visitedNode.Y);

            }

            //Outputting nodes that are in the frontier
            else
            {
                Console.WriteLine("Frontier node:");
                foreach (var f in frontier)
                {
                    Console.WriteLine("\t(X = " + f.X + " Y = " + f.Y + ")");
                }
                //Outputting node that is currently being visited
                Console.WriteLine("\nExpanding node: X = " + visitedNode.X + " Y = " + visitedNode.Y);
            }
            Thread.Sleep(100);

            Console.Clear();
        }

        /// <summary>
        /// Draw process of expanding node for ones using List to store frontier nodes
        /// </summary>
        /// <param name="initial">Agent position</param>
        /// <param name="goal">Goal position</param>
        /// <param name="wall">Wall position</param>
        /// <param name="visitedNode">Node that is currently being visited</param>
        /// <param name="mapWidth">Max width of map</param>
        /// <param name="mapLength">Max length of map</param>
        /// <param name="frontier">Nodes that are currently in frontier</param>	
        public void Draw(point2D initial, point2D goal, List<room> wall, point2D visitedNode, int mapWidth, int mapLength, List<point2D> frontier)
        {
            Console.Clear();
            bool wallDrawn = false;

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {

                    //Set position of Agent
                    if ((initial.X == j) && (initial.Y == i))
                    {
                        Console.Write("|i");
                        continue;
                    }

                    //Set position of goal
                    if ((goal.X == j) && (goal.Y == i))
                    {
                        Console.Write("|g");
                        continue;
                    }

                    //Set position of the visitedNode
                    if ((visitedNode.X == j) && (visitedNode.Y == i))
                    {
                        Console.Write("|x");
                        continue;
                    }

                    //Set posiiton of nodes in frontier
                    if (frontier.Any(x => x.X == j && x.Y == i))
                    {
                        Console.Write("|f");
                        continue;
                    }

                    //Set position of wall
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

                    //Set empty cells
                    if (wallDrawn == false)
                    {
                        Console.Write("| ");
                    }
                }
                Console.WriteLine("|");
            }
            
            //Output of where goal was found
            if ((visitedNode.X == goal.X) && (visitedNode.Y == goal.Y))
            {

                Console.WriteLine("\nSolution found at: X = " + visitedNode.X + " Y = " + visitedNode.Y);

            }
            //Outputting nodes that are in the frontier 
            else
            {
                Console.WriteLine("Frontier node:");
                foreach (var f in frontier)
                {
                    Console.WriteLine("\t(X = " + f.X + " Y = " + f.Y + ")");
                }

                //Outputting node that is currently being visited
                Console.WriteLine("\nExpanding node: X = " + visitedNode.X + " Y = " + visitedNode.Y);
            }
            Thread.Sleep(100);

            Console.Clear();
        }


        /// <summary>
        /// Drawing the solution path that the search algo found
        /// </summary>
        /// <param name="initial">Agent position</param>
        /// <param name="goal">Goal position</param>
        /// <param name="wall">Wall position</param>
        /// <param name="mapWidth">Max width of map</param>
        /// <param name="mapLength">Max length of map</param>
        /// <param name="path">path that the algo took</param>
        public void DrawPath(point2D initial, point2D goal, List<room> wall, int mapWidth, int mapLength, List<point2D> path)
        {
            

            Console.Clear();
            bool wallDrawn = false;
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {
                    //Set position of Agent
                    if ((initial.X == j) && (initial.Y == i))
                    {
                        Console.Write("|i");
                        continue;
                    }

                    //Set position of goal
                    if ((goal.X == j) && (goal.Y == i))
                    {
                        Console.Write("|g");
                        continue;
                    }

                    //Set the nodes that are in path
                    if (path.Any(x => x.X == j && x.Y == i))
                    {
                        Console.Write("|x");
                        continue;
                    }

                    //Set position of wall
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

                    //Set empty cells
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