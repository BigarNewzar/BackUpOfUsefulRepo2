using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AI_Assignment_version2
{
    class Agent
    {
        private point2D _pos;
        private point2D _goalPos;
        private map _agentMap;
        private UI _ui = new UI();
        private int _depth;
        private int _maxDepth;

        public point2D Pos
        {
            get
            {
                return _pos;
            }
        }


        //Robot constructor
        public Agent(string initialState, string goalState, map map)
        {
            Sanitise s = new Sanitise(initialState);

            List<int> coordinate = s.getInt();

            _pos = new point2D(coordinate[0], coordinate[1]);

            s = new Sanitise(goalState);

            coordinate = s.getInt();

            _goalPos = new point2D(coordinate[0], coordinate[1]);

            _agentMap = map;
        }


        //Robot notifying its position and expandable _paths
        //public void notify()
        //{
        //    Console.WriteLine("I'm currently at X =" + _pos.X + " Y = " + _pos.Y);
        //    foreach (room g in _agentMap.Room)
        //    {
        //        if ((_pos.X == g.Pos.X) && (_pos.Y == g.Pos.Y))
        //        {
        //            Console.WriteLine("From here I could go to: ");
        //            foreach (Path p in g.Paths)
        //            {
        //                Console.WriteLine(" X = " + p.Location.Pos.X  + " Y = "+ p.Location.Pos.Y);
        //            }
        //        }
        //    }
        //    Console.WriteLine("My goal is to get to X = " + _goalPos.X +" Y = "+ _goalPos.Y);
        //}


        //Movement functions
        public string MoveUp()
        {
            return "up";
        }

        public string MoveDown()
        {
            return "down";
        }

        public string MoveRight()
        {
            return "right";
        }

        public string MoveLeft()
        {
            return "left";
        }


        //Depth-First Search
        public string DfsSearch()
        {
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y))
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for open nodes and visited nodes
                //Using stack here as I need last in first out
                //Ref: https://www.tutorialsteacher.com/csharp/csharp-stack
                Stack<point2D> open = new Stack<point2D>();
                List<point2D> visited = new List<point2D>();

                //Initialize expanding node
                point2D visitedNode;

                //Push the initial position in the open stack (ie agent position)
                //put the condition somewhere around here......
                open.Push(_pos);

                //maybe push it through a pesudo queue before passing it into the node?--to ensure the up,lft,down,right format?

                


                while (open.Count != 0)
                {
                    //open = open.OrderBy(s => s.Hscore).ToList();

                    

                    

                    //open = open.OrderBy(........).ToList();--maybe set the order in open node directly before passing it to frontier?


                   
                    foreach (point2D s in open)
                    {
                        point2D upPoint = new point2D(s.X, s.Y - 1);
                        point2D leftPoint = new point2D(s.X - 1, s.Y);
                        point2D downPoint = new point2D(s.X, s.Y + 1);
                        point2D rightPoint = new point2D(s.X + 1, s.Y);


                        room up = new room(upPoint, false);//set new room assumings it not wall
                        room left = new room(leftPoint, false);
                        room down = new room(downPoint, false);
                        room right = new room(rightPoint, false);


                        if (_agentMap.Room.Contains(up) == true) //check from list whether up room available and if push it to open
                        {
                            
                          
                            upPoint.Pscore = 1;
                            open.Push(upPoint);


                        }
                        else if (_agentMap.Room.Contains(left) == true)
                        {
                            
                            
                            leftPoint.Pscore = 1;
                            open.Push(leftPoint);


                        }
                        else if (_agentMap.Room.Contains(down) == true)
                        {
                            
                           
                            downPoint.Pscore = 1;
                            open.Push(downPoint);

                        }
                        else if (_agentMap.Room.Contains(right) == true)
                        {
                            
                            
                            rightPoint.Pscore = 1;
                            open.Push(rightPoint);
                        }

                    }

                    //Visit a node in the open stack, popping the node out of the open stack
                    visitedNode = open.Pop();




                    //Visit a node and expand, adding the node to the visited list
                    visited.Add(visitedNode);

                    //Here is the Pscore. Now need to find a good way to order it
                    visited = visited.OrderBy(s => s.Pscore).ToList();



                    Console.WriteLine("Expanding: " + visitedNode.Coordinate);
                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, visitedNode, _agentMap.Width, _agentMap.Length, open);

                    

                    foreach (room g in _agentMap.Room)
                    {

                        //Verify the expanding room is within the _map
                        if ((visitedNode.X == g.Pos.X) && (visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        

                                        p.Location.Pos.ParentNode = new point2D(visitedNode);
                                        Console.WriteLine(p.Location.Pos.Coordinate);

                                        ///here need to put a priority function on which action to perform
                                        ///maybe there is library for priority queue
                                        ///before adding to frontier


                                        //Push adjacent nodes to the open frontier
                                        open.Push(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((visitedNode.X == _goalPos.X) && (visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("DFS", Pos, _goalPos, visited);
                            }
                        }
                    }
                }

                //If no solution is found
                return "No solution";
            }
        }




        public string DfsLimitedSearch()
        {
            //manually setting depth value for now
            _maxDepth = 14;

            _depth = _maxDepth;

            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y) && _depth > 0)
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for open nodes and visited nodes
                //Using stack here as I need last in first out
                //Ref: https://www.tutorialsteacher.com/csharp/csharp-stack
                Stack<point2D> open = new Stack<point2D>();
                List<point2D> visited = new List<point2D>();

                //Initialize expanding node
                point2D visitedNode;

                //Push the initial position in the open stack (ie agent position)
                //put the condition somewhere around here......
                open.Push(_pos);

                //maybe push it through a pesudo queue before passing it into the node?--to ensure the up,lft,down,right format?

                while (open.Count != 0 && _depth >0)
                {
                    //Visit a node in the open stack, popping the node out of the open stack
                    visitedNode = open.Pop();


                    //Visit a node and expand, adding the node to the visited list
                    visited.Add(visitedNode);

                   
                    Console.WriteLine("Expanding: " + visitedNode.Coordinate);
                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, visitedNode, _agentMap.Width, _agentMap.Length, open);

                    //decreasing depth of how far it can go
                    _depth= _depth - 1;

                    foreach (room g in _agentMap.Room)
                    {

                        //Verify the expanding room is within the _map
                        if ((visitedNode.X == g.Pos.X) && (visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {


                                        p.Location.Pos.ParentNode = new point2D(visitedNode);
                                        Console.WriteLine(p.Location.Pos.Coordinate);

                                        ///here need to put a priority function on which action to perform
                                        ///maybe there is library for priority queue
                                        ///before adding to frontier


                                        //Push adjacent nodes to the open frontier
                                        open.Push(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((visitedNode.X == _goalPos.X) && (visitedNode.Y == _goalPos.Y) && _depth > 0)
                            {
                                return solveIt("DFSLimited", Pos, _goalPos, visited);
                            }
                        }
                    }
                }

                //If no solution is found
                return "No solution at given depth of " + _maxDepth;
            }
        }


        //Breadth-First Search
        public string BfsSearch()
        {
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y))
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for open nodes and visited nodes
                //Using Queue as need first in first out
                //ref: https://www.tutorialsteacher.com/csharp/csharp-queue
                 Queue<point2D> open = new Queue<point2D>();
                List<point2D> visited = new List<point2D>();

                //Initialize expanding node
                point2D visitedNode;

                open.Enqueue(_pos);

                while (open.Count != 0)
                {
                    //Expand the first node of the queue
                    visitedNode = open.Dequeue();
                    visited.Add(visitedNode);

                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, visitedNode, _agentMap.Width, _agentMap.Length, open);
                    

                    foreach (room g in _agentMap.Room)
                    {
                        //Verify the expanding room is within the _map
                        if ((visitedNode.X == g.Pos.X) && (visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        p.Location.Pos.ParentNode = new point2D(visitedNode);

                                        //Enqueue available _paths to the frontier list
                                        open.Enqueue(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((visitedNode.X == _goalPos.X) && (visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("BFS", Pos, _goalPos, visited);
                            }
                        }
                    }
                }

                //If no solution is found
                return "No solution";
            }
        }


        //Greedy Best First Search
        public string GbfsSearch()
        {
            //Return solution if initial position is goal
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y))
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for open nodes and visited nodes
                List<point2D> open = new List<point2D>();
                List<point2D> visited = new List<point2D>();

                point2D visitedNode;
                open.Add(_pos);

                while (open.Count != 0)
                {
                    //Sort the open list order by distance of the room to goal
                    open = open.OrderBy(s => s.Hscore).ToList();

                    //Expand the first node of the priority list
                    visitedNode = open.First();
                    open.Remove(open.First());
                    visited.Add(visitedNode);

                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, visitedNode, _agentMap.Width, _agentMap.Length, open);
                    

                    foreach (room g in _agentMap.Room)
                    {
                        //Verify the expanding room is within the _map
                        if ((visitedNode.X == g.Pos.X) && (visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if (!visited.Exists(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        p.Location.Pos.ParentNode = new point2D(visitedNode);

                                        //Calculate heuristic value h(n)
                                        //a^2 + b^2 = c^2. So c=......
                                        p.Location.Pos.Hscore = Math.Sqrt(Math.Pow(_goalPos.X - p.Location.Pos.X, 2) + Math.Pow(_goalPos.Y - p.Location.Pos.Y, 2));

                                        //Add adjacent nodes to the open list
                                        open.Add(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((visitedNode.X == _goalPos.X) && (visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("GBFS", Pos, _goalPos, visited);
                            }
                        }
                    }
                }

                //If no solution is found
                return "No solution";
            }
        }


        //A* Search
        public string AStarSearch()
        {
            //Return solution if initial position is goal
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y))
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for open nodes and visited nodes
                List<point2D> open = new List<point2D>();
                List<point2D> visited = new List<point2D>();

                //Initialize expanding node
                point2D visitedNode;

                //Put the initial position in the open list
                open.Add(_pos);

                //Initial stationary cost
                _pos.GScore = 0;

                while (open.Count != 0)
                {
                    //Sort the open list order by f(n)
                    open = open.OrderBy(s => s.FScore).ToList();

                    //Expand the first node of the priority list
                    visitedNode = open.First();
                    open.Remove(open.First());

                    //Add the expanded node to the visisted list
                    visited.Add(visitedNode);

                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, visitedNode, _agentMap.Width, _agentMap.Length, open);
                    

                    foreach (room g in _agentMap.Room)
                    {
                        //Verify the expanding room is within the _map
                        if ((visitedNode.X == g.Pos.X) && (visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        p.Location.Pos.ParentNode = new point2D(visitedNode);


                                        //Calculate g(n) as the cost so far from the start to the current node
                                        p.Location.Pos.GScore = visitedNode.GScore + 1;

                                        //Calculate f(n) value = g(n) + h(n) where h(n) is straight line distance
                                        p.Location.Pos.FScore = p.Location.Pos.GScore + Math.Sqrt(Math.Pow(_goalPos.X - p.Location.Pos.X, 2) + Math.Pow(_goalPos.Y - p.Location.Pos.Y, 2));

                                        
                                        //Add adjacent nodes to the open list
                                        open.Add(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((visitedNode.X == _goalPos.X) && (visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("A*", Pos, _goalPos, visited);
                            }
                        }
                    }
                }

                //If no solution is found
                return "No solution";
            }
        }


        //A* Search Limited
        public string AStarLimitedSearch()
        {
            _maxDepth = 14;

            _depth = _maxDepth;

            //Return solution if initial position is goal
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y) && _depth > 0)
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for open nodes and visited nodes
                List<point2D> open = new List<point2D>();
                List<point2D> visited = new List<point2D>();

                //Initialize expanding node
                point2D visitedNode;

                //Put the initial position in the open list
                open.Add(_pos);

                //Initial stationary cost
                _pos.GScore = 0;

                while (open.Count != 0 && _depth > 0)
                {
                    //Sort the open list order by f(n)
                    open = open.OrderBy(s => s.FScore).ToList();

                    //Expand the first node of the priority list
                    visitedNode = open.First();
                    open.Remove(open.First());

                    //Add the expanded node to the visisted list
                    visited.Add(visitedNode);

                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, visitedNode, _agentMap.Width, _agentMap.Length, open);
                    //decreasing depth of how far it can go
                    _depth = _depth - 1;

                    foreach (room g in _agentMap.Room)
                    {
                        //Verify the expanding room is within the _map
                        if ((visitedNode.X == g.Pos.X) && (visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        p.Location.Pos.ParentNode = new point2D(visitedNode);


                                        //Calculate g(n) as the cost so far from the start to the current node
                                        p.Location.Pos.GScore = visitedNode.GScore + 1;

                                        //Calculate f(n) value = g(n) + h(n) where h(n) is straight line distance
                                        p.Location.Pos.FScore = p.Location.Pos.GScore + Math.Sqrt(Math.Pow(_goalPos.X - p.Location.Pos.X, 2) + Math.Pow(_goalPos.Y - p.Location.Pos.Y, 2));


                                        //Add adjacent nodes to the open list
                                        open.Add(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((visitedNode.X == _goalPos.X) && (visitedNode.Y == _goalPos.Y) && _depth > 0)
                            {
                                return solveIt("A*DepthLim", Pos, _goalPos, visited);
                            }
                        }
                    }
                }

                //If no solution is found
                return "No solution at given depth of " + _maxDepth;
            }
        }

        //Solution path
        public string solveIt(string method, point2D initial, point2D child, List<point2D> expanded)
        {
            string solution = "";
            List<point2D> path = new List<point2D>();
            List<string> action = new List<string>();

            expanded.Reverse();

            foreach (point2D p in expanded)
            {
                if ((p.X == child.X) && (p.Y == child.Y))
                    path.Add(p);

                if (path.Count() != 0)
                {
                    if ((path.Last().ParentNode.X == p.X) && (path.Last().ParentNode.Y == p.Y))
                    {
                        path.Add(p);
                    }
                }
            }

            path.Reverse();

            //Produce action from path
            for (int i = 0; i < path.Count(); i++)
            {
                if (i == path.Count() - 1)
                {
                    break;
                }


                if (path[i + 1].X == path[i].X + 1)
                {
                    action.Add(MoveRight());
                }

                if (path[i + 1].Y == path[i].Y + 1)
                {
                    action.Add(MoveDown());
                }

                if (path[i + 1].X == path[i].X - 1)
                {
                    action.Add(MoveLeft());
                }

                if (path[i + 1].Y == path[i].Y - 1)
                {
                    action.Add(MoveUp());
                }




            }

            foreach (string a in action)
            {
                solution = solution + a + "; ";
            }

            _ui.DrawPath(_pos, _goalPos, _agentMap.WallList, _agentMap.Width, _agentMap.Length, path);

            return method + " " + expanded.Count() + " " + solution;
        }
    }
}