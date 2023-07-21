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
        List<point2D> _visited = new List<point2D>();

        public List<point2D> getVisited
        {
            get
            {
                return _visited;
            }
        }

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
                //Initialize data structure for _open nodes and _visited nodes
                //Using stack here as I need last in first out
                //Ref: https://www.tutorialsteacher.com/csharp/csharp-stack
                Stack<point2D> _open = new Stack<point2D>();
                //List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                //Push the initial position in the _open stack (ie agent position)
                //put the condition somewhere around here......
                _open.Push(_pos);

                //maybe push it through a pesudo queue before passing it into the node?--to ensure the up,lft,down,right format?




                while (_open.Count != 0)
                {
                   

                    //Visit a node in the _open stack, popping the node out of the _open stack
                    _visitedNode = _open.Pop();




                    //Visit a node and expand, adding the node to the _visited list
                    _visited.Add(_visitedNode);

                    



                    Console.WriteLine("Expanding: " + _visitedNode.Coordinate);
                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _open);



                    foreach (room g in _agentMap.Room)
                    {

                        //Verify the expanding room is within the _map
                        if ((_visitedNode.X == g.Pos.X) && (_visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {


                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);
                                        Console.WriteLine(p.Location.Pos.Coordinate);

                                        ///here need to put a priority function on which action to perform
                                        ///maybe there is library for priority queue
                                        ///before adding to frontier


                                        //Push adjacent nodes to the _open frontier
                                        _open.Push(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("DFS", Pos, _goalPos, _visited);
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
            //setting depth limit as (map's total no of rooms (wall or not)/2)
            _maxDepth = (_agentMap.Length * _agentMap.Width)/2;
            
            _depth = _maxDepth;

            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y) && _depth > 0)
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for _open nodes and _visited nodes
                //Using stack here as I need last in first out
                //Ref: https://www.tutorialsteacher.com/csharp/csharp-stack
                Stack<point2D> _open = new Stack<point2D>();
                //List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                //Push the initial position in the _open stack (ie agent position)
                //put the condition somewhere around here......
                _open.Push(_pos);

                //maybe push it through a pesudo queue before passing it into the node?--to ensure the up,lft,down,right format?

                while (_open.Count != 0 && _depth > 0)
                {
                    //Visit a node in the _open stack, popping the node out of the _open stack
                    _visitedNode = _open.Pop();


                    //Visit a node and expand, adding the node to the _visited list
                    _visited.Add(_visitedNode);


                    Console.WriteLine("Expanding: " + _visitedNode.Coordinate);
                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _open);

                    //decreasing depth of how far it can go
                    _depth = _depth - 1;

                    foreach (room g in _agentMap.Room)
                    {

                        //Verify the expanding room is within the _map
                        if ((_visitedNode.X == g.Pos.X) && (_visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {


                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);
                                        Console.WriteLine(p.Location.Pos.Coordinate);

                                        ///here need to put a priority function on which action to perform
                                        ///maybe there is library for priority queue
                                        ///before adding to frontier


                                        //Push adjacent nodes to the _open frontier
                                        _open.Push(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y) && _depth > 0)
                            {
                                return solveIt("DFSLimited", Pos, _goalPos, _visited);
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
                //Initialize data structure for _open nodes and _visited nodes
                //Using Queue as need first in first out
                //ref: https://www.tutorialsteacher.com/csharp/csharp-queue
                Queue<point2D> _open = new Queue<point2D>();
                //List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                _open.Enqueue(_pos);

                while (_open.Count != 0)
                {
                    //Expand the first node of the queue
                    _visitedNode = _open.Dequeue();
                    _visited.Add(_visitedNode);

                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _open);


                    foreach (room g in _agentMap.Room)
                    {
                        //Verify the expanding room is within the _map
                        if ((_visitedNode.X == g.Pos.X) && (_visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);

                                        //Enqueue available _paths to the frontier list
                                        _open.Enqueue(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("BFS", Pos, _goalPos, _visited);
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
                //Initialize data structure for _open nodes and _visited nodes
                List<point2D> _open = new List<point2D>();
                //List<point2D> _visited = new List<point2D>();

                point2D _visitedNode;
                _open.Add(_pos);

                while (_open.Count != 0)
                {
                    //Sort the _open list order by distance of the room to goal
                    _open = _open.OrderBy(s => s.Hscore).ToList();

                    //Expand the first node of the priority list
                    _visitedNode = _open.First();
                    _open.Remove(_open.First());
                    _visited.Add(_visitedNode);

                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _open);


                    foreach (room g in _agentMap.Room)
                    {
                        //Verify the expanding room is within the _map
                        if ((_visitedNode.X == g.Pos.X) && (_visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if (!_visited.Exists(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);

                                        //Calculate heuristic value h(n)
                                        //a^2 + b^2 = c^2. So c=......
                                        p.Location.Pos.Hscore = Math.Sqrt(Math.Pow(_goalPos.X - p.Location.Pos.X, 2) + Math.Pow(_goalPos.Y - p.Location.Pos.Y, 2));

                                        //Add adjacent nodes to the _open list
                                        _open.Add(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("GBFS", Pos, _goalPos, _visited);
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
                //Initialize data structure for _open nodes and _visited nodes
                List<point2D> _open = new List<point2D>();
                //List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                //Put the initial position in the _open list
                _open.Add(_pos);

                //Initial stationary cost
                _pos.GScore = 0;

                while (_open.Count != 0)
                {
                    //Sort the _open list order by f(n)
                    _open = _open.OrderBy(s => s.FScore).ToList();

                    //Expand the first node of the priority list
                    _visitedNode = _open.First();
                    _open.Remove(_open.First());

                    //Add the expanded node to the visisted list
                    _visited.Add(_visitedNode);

                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _open);


                    foreach (room g in _agentMap.Room)
                    {
                        //Verify the expanding room is within the _map
                        if ((_visitedNode.X == g.Pos.X) && (_visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);


                                        //Calculate g(n) as the cost so far from the start to the current node
                                        p.Location.Pos.GScore = _visitedNode.GScore + 1;

                                        //Calculate f(n) value = g(n) + h(n) where h(n) is straight line distance
                                        p.Location.Pos.FScore = p.Location.Pos.GScore + Math.Sqrt(Math.Pow(_goalPos.X - p.Location.Pos.X, 2) + Math.Pow(_goalPos.Y - p.Location.Pos.Y, 2));


                                        //Add adjacent nodes to the _open list
                                        _open.Add(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("A*", Pos, _goalPos, _visited);
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
            //setting depth limit as (map's total no of rooms (wall or not)/2)
            _maxDepth = (_agentMap.Length * _agentMap.Width) / 2;

            _depth = _maxDepth;

            //Return solution if initial position is goal
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y) && _depth > 0)
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for _open nodes and _visited nodes
                List<point2D> _open = new List<point2D>();
               // List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                //Put the initial position in the _open list
                _open.Add(_pos);

                //Initial stationary cost
                _pos.GScore = 0;

                while (_open.Count != 0 && _depth > 0)
                {
                    //Sort the _open list order by f(n)
                    _open = _open.OrderBy(s => s.FScore).ToList();

                    //Expand the first node of the priority list
                    _visitedNode = _open.First();
                    _open.Remove(_open.First());

                    //Add the expanded node to the visisted list
                    _visited.Add(_visitedNode);

                    //Initialize UI
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _open);
                    //decreasing depth of how far it can go
                    _depth = _depth - 1;

                    foreach (room g in _agentMap.Room)
                    {
                        //Verify the expanding room is within the _map
                        if ((_visitedNode.X == g.Pos.X) && (_visitedNode.Y == g.Pos.Y))
                        {
                            //Verify if adjacent nodes are available
                            if (g.Paths.Count != 0)
                            {
                                foreach (Path p in g.Paths)
                                {
                                    //Repeated state checking
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_open.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);


                                        //Calculate g(n) as the cost so far from the start to the current node
                                        p.Location.Pos.GScore = _visitedNode.GScore + 1;

                                        //Calculate f(n) value = g(n) + h(n) where h(n) is straight line distance
                                        p.Location.Pos.FScore = p.Location.Pos.GScore + Math.Sqrt(Math.Pow(_goalPos.X - p.Location.Pos.X, 2) + Math.Pow(_goalPos.Y - p.Location.Pos.Y, 2));


                                        //Add adjacent nodes to the _open list
                                        _open.Add(p.Location.Pos);
                                    }
                                }
                            }

                            //If solution is found
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y) && _depth > 0)
                            {
                                return solveIt("A*DepthLim", Pos, _goalPos, _visited);
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