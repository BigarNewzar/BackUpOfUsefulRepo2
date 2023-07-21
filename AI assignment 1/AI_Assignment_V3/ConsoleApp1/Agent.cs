using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace AI_Assignment_version2
{
    /// <summary>
    /// Sets up Agent (AI). Also all the search algos will be run from here
    /// </summary>
    class Agent
    {
        private point2D _pos;
        private point2D _goalPos;
        private map _agentMap;
        private UI _ui = new UI();
        private int _depth;
        private int _maxDepth;
               
        /// <summary>
        /// Getter for Position of Agent
        /// </summary>
        public point2D Pos
        {
            get
            {
                return _pos;
            }
        }



        /// <summary>
        /// Sets up initial position of agent, goal positon and also the map for it to use when running the algorithms
        /// </summary>
        /// <param name="initialState"> the line that contains the initial position of the agent</param>
        /// <param name="goalState">the line that contains the position of goal</param>
        /// <param name="map">the map that the agent will look through</param>
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



        /// <summary>
        /// This will be used to print when agent moves up in path display
        /// </summary>
        /// <returns> string that says up</returns>
        public string MoveUp()
        {
            return "up";
        }

        /// <summary>
        /// This will be used to print when agent moves down in path display
        /// </summary>
        /// <returns> string that says down</returns>
        public string MoveDown()
        {
            return "down";
        }

        /// <summary>
        /// This will be used to print when agent moves right in path display
        /// </summary>
        /// <returns> string that says right</returns>
        public string MoveRight()
        {
            return "right";
        }

        /// <summary>
        /// This will be used to print when agent moves left in path display
        /// </summary>
        /// <returns> string that says left</returns>
        public string MoveLeft()
        {
            return "left";
        }


        /// <summary>
        /// The search algo for depth first search
        /// </summary>
        /// <returns>current position if at goal, no solution if no goal, solution path if goal is found</returns>
        public string DfsSearch()
        {
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y))
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for _frontier nodes and _visited nodes
                //Using stack here as I need last in first out
                //Ref: https://www.tutorialsteacher.com/csharp/csharp-stack
                Stack<point2D> _frontier = new Stack<point2D>();
                List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                //Push the initial position in the _frontier stack (ie agent position)               
                _frontier.Push(_pos);

                
                while (_frontier.Count != 0)
                {
                   
                    //Get the top node in the _frontier stack and pop it out as a visited node
                    _visitedNode = _frontier.Pop();

                    //Add visited node to the _visited list
                    _visited.Add(_visitedNode);                    


                    //See the output in verbose and graphical manner
                    Console.WriteLine("Expanding: " + _visitedNode.Coordinate);            
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _frontier);


                    foreach (room r in _agentMap.Room)
                    {
                        //Make sure the room is within the _map
                        if ((_visitedNode.X == r.Pos.X) && (_visitedNode.Y == r.Pos.Y))
                        {
                            //Make sure there is linked paths
                            if (r.Paths.Count != 0)
                            {
                                foreach (Path p in r.Paths)
                                {
                                    //Make sure no repeated state
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_frontier.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        //Make it as a parent node
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);
                                        
                                        //Push adjacent nodes to the _frontier
                                        _frontier.Push(p.Location.Pos);
                                    }
                                }
                            }

                            //If algo can find the solution
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("DFS", Pos, _goalPos, _visited);
                            }
                        }
                    }
                }

                //If algo can't find the solution
                return "No solution";
            }
        }



        /// <summary>
        /// The search algo for depth first search limited
        /// </summary>
        /// <returns>current position if at goal, no solution at given depth if no goal reached before depth is reached, solution path if goal is found</returns>
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
                //Initialize data structure for _frontier nodes and _visited nodes
                //Using stack here as I need last in first out
                //Ref: https://www.tutorialsteacher.com/csharp/csharp-stack
                Stack<point2D> _frontier = new Stack<point2D>();
                List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                //Push the initial position in the _frontier stack (ie agent position)                
                _frontier.Push(_pos);
                

                while (_frontier.Count != 0 && _depth > 0)
                {
                    //Get the top node in the _frontier stack and pop it out as a visited node
                    _visitedNode = _frontier.Pop();

                    //Add visited node to the _visited list
                    _visited.Add(_visitedNode);

                    //See the output in verbose and graphical manner                    
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _frontier);

                    //Decreasing depth of how far it can go
                    _depth = _depth - 1;

                    foreach (room r in _agentMap.Room)
                    {

                        //Make sure the room is within the _map
                        if ((_visitedNode.X == r.Pos.X) && (_visitedNode.Y == r.Pos.Y))
                        {
                            //Make sure there is linked paths
                            if (r.Paths.Count != 0)
                            {
                                foreach (Path p in r.Paths)
                                {
                                    //Make sure no repeated state (X and Y Positions of path's location's position shouldnt match any X and Y Positions of any nodes in Visited or frontier list)
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_frontier.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        //Make it as a parent node
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);
                                        
                                        //Push adjacent nodes to the _frontier
                                        _frontier.Push(p.Location.Pos);
                                    }
                                }
                            }

                            //If algo can find the solution
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y) && _depth > 0)
                            {
                                return solveIt("DFSLimited", Pos, _goalPos, _visited);
                            }
                        }
                    }
                }

                //If algo can't find the solution
                return "No solution at given depth of " + _maxDepth;
            }
        }


        /// <summary>
        /// The search algo for breadth first search
        /// </summary>
        /// <returns>current position if at goal, no solution if no goal, solution path if goal is found</returns>
        public string BfsSearch()
        {
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y))
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for _frontier nodes and _visited nodes
                //Using Queue as need first in first out
                //ref: https://www.tutorialsteacher.com/csharp/csharp-queue
                Queue<point2D> _frontier = new Queue<point2D>();
                List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                //Push initial posiiton to end of Queue
                _frontier.Enqueue(_pos);

                while (_frontier.Count != 0)
                {
                    //Get the first node in the _frontier queue and de-enqueue it out as a visited node
                    _visitedNode = _frontier.Dequeue();
                    //Add visited node to the _visited list
                    _visited.Add(_visitedNode);

                    //See the output in verbose and graphical manner
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _frontier);


                    foreach (room r in _agentMap.Room)
                    {
                        //Make sure the room is within the _map
                        if ((_visitedNode.X == r.Pos.X) && (_visitedNode.Y == r.Pos.Y))
                        {
                            //Make sure there is linked paths
                            if (r.Paths.Count != 0)
                            {
                                foreach (Path p in r.Paths)
                                {
                                    //Make sure no repeated state (X and Y Positions of path's location's position shouldnt match any X and Y Positions of any nodes in Visited or frontier list)
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_frontier.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        //Make it as a parent node
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);

                                        //Enqueue adjacent nodes to the _frontier
                                        _frontier.Enqueue(p.Location.Pos);
                                    }
                                }
                            }

                            //If algo can find the solution
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("BFS", Pos, _goalPos, _visited);
                            }
                        }
                    }
                }

                //If algo can't find the solution
                return "No solution";
            }
        }


        /// <summary>
        /// The search algo for Greedy depth first search
        /// </summary>
        /// <returns>current position if at goal, no solution if no goal, solution path if goal is found</returns>
        public string GbfsSearch()
        {
            
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y))
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for _frontier nodes and _visited nodes
                List<point2D> _frontier = new List<point2D>();
                List<point2D> _visited = new List<point2D>();

                point2D _visitedNode;

                //Push the initial position in the _frontier List (ie agent position)
                _frontier.Add(_pos);

                while (_frontier.Count != 0)
                {
                    //Sort the _frontier list order by distance of the room to goal
                    _frontier = _frontier.OrderBy(s => s.Hscore).ToList();

                    //Get the first node in the _frontier list and bring it out as a visited node
                    _visitedNode = _frontier.First();

                    //Remove the node from _frontier list
                    _frontier.Remove(_frontier.First());

                    //Add visited node to the _visited list
                    _visited.Add(_visitedNode);

                    //See the output in verbose and graphical manner
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _frontier);


                    foreach (room r in _agentMap.Room)
                    {
                        //Make sure the room is within the _map
                        if ((_visitedNode.X == r.Pos.X) && (_visitedNode.Y == r.Pos.Y))
                        {
                            //Make sure there is linked paths
                            if (r.Paths.Count != 0)
                            {
                                foreach (Path p in r.Paths)
                                {
                                    //Make sure no repeated state (X and Y Positions of path's location's position shouldnt match any X and Y Positions of any nodes in Visited or frontier list)
                                    if (!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y) && !_frontier.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        //Make it as a parent node
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);

                                        //Calculate heuristic value h(n)
                                        //a^2 + b^2 = c^2. So c=......
                                        p.Location.Pos.Hscore = Math.Sqrt(Math.Pow(_goalPos.X - p.Location.Pos.X, 2) + Math.Pow(_goalPos.Y - p.Location.Pos.Y, 2));

                                        // Push adjacent nodes to the _frontier
                                        _frontier.Add(p.Location.Pos);
                                    }
                                }
                            }

                            //If algo can find the solution
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("GBFS", Pos, _goalPos, _visited);
                            }
                        }
                    }
                }

                //If algo can't find the solution
                return "No solution";
            }
        }


        /// <summary>
        /// The search algo for A* search
        /// </summary>
        /// <returns>current position if at goal, no solution if no goal, solution path if goal is found</returns>
        public string AStarSearch()
        {
            
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y))
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for _frontier nodes and _visited nodes
                List<point2D> _frontier = new List<point2D>();
                List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                //Push the initial position in the _frontier list
                _frontier.Add(_pos);

                //Set Initial cost
                _pos.GScore = 0;

                while (_frontier.Count != 0)
                {
                    //Sort the _frontier list order by f(n)
                    _frontier = _frontier.OrderBy(s => s.FScore).ToList();

                     //Get the first node in the _frontier list and bring it out as a visited node
                    _visitedNode = _frontier.First();

                    //Remove the node from _frontier list
                    _frontier.Remove(_frontier.First());

                    //Add visited node to the _visited list
                    _visited.Add(_visitedNode);

                    //See the output in verbose and graphical manner                    
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _frontier);


                    foreach (room r in _agentMap.Room)
                    {
                        //Make sure the room is within the _map
                        if ((_visitedNode.X == r.Pos.X) && (_visitedNode.Y == r.Pos.Y))
                        {
                            //Make sure there is linked paths
                            if (r.Paths.Count != 0)
                            {
                                foreach (Path p in r.Paths)
                                {
                                    //Make sure no repeated state (X and Y Positions of path's location's position shouldnt match any X and Y Positions of any nodes in Visited or frontier list)
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_frontier.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        //Make it as a parent node
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);


                                        //Calculate g(n) as the cost so far from the start to the current node
                                        p.Location.Pos.GScore = _visitedNode.GScore + 1;

                                        //Calculate f(n) value = g(n) + h(n) where h(n) is straight line distance
                                        p.Location.Pos.FScore = p.Location.Pos.GScore + Math.Sqrt(Math.Pow(_goalPos.X - p.Location.Pos.X, 2) + Math.Pow(_goalPos.Y - p.Location.Pos.Y, 2));


                                        //Push adjacent nodes to the _frontier
                                        _frontier.Add(p.Location.Pos);
                                    }
                                }
                            }

                            //If algo can find the solution
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y))
                            {
                                return solveIt("AStar", Pos, _goalPos, _visited);
                            }
                        }
                    }
                }

                //If algo can't find the solution
                return "No solution";
            }
        }


        /// <summary>
        /// The search algo for A* Limited search
        /// </summary>
        /// <returns>current position if at goal, no solution if no goal, solution path if goal is found</returns>
        public string AStarLimitedSearch()
        {
            //setting depth limit as (map's total no of rooms (wall or not)/2)
            _maxDepth = (_agentMap.Length * _agentMap.Width) / 2;

            _depth = _maxDepth;

            
            if ((_pos.X == _goalPos.X) && (_pos.Y == _goalPos.Y) && _depth > 0)
            {
                return "The solution is the initial positition, no movement required";
            }
            else
            {
                //Initialize data structure for _frontier nodes and _visited nodes
                List<point2D> _frontier = new List<point2D>();
                List<point2D> _visited = new List<point2D>();

                //Initialize expanding node
                point2D _visitedNode;

                //Push the initial position in the _frontier list
                _frontier.Add(_pos);

                //Set initial cost
                _pos.GScore = 0;

                while (_frontier.Count != 0 && _depth > 0)
                {
                    //Sort the _frontier list order by f(n)
                    _frontier = _frontier.OrderBy(s => s.FScore).ToList();

                    //Get the first node in the _frontier list and bring it out as a visited node
                    _visitedNode = _frontier.First();

                    //Remove the node from _frontier list
                    _frontier.Remove(_frontier.First());

                    //Add visited node to the _visited list
                    _visited.Add(_visitedNode);


                    //See the output in verbose and graphical manner
                    _ui.Draw(_pos, _goalPos, _agentMap.WallList, _visitedNode, _agentMap.Width, _agentMap.Length, _frontier);
                    //Decreasing depth of how far it can go
                    _depth = _depth - 1;

                    foreach (room r in _agentMap.Room)
                    {
                        //Make sure the room is within the _map
                        if ((_visitedNode.X == r.Pos.X) && (_visitedNode.Y == r.Pos.Y))
                        {
                            //Make sure there is linked paths
                            if (r.Paths.Count != 0)
                            {
                                foreach (Path p in r.Paths)
                                {
                                    //Make sure no repeated state (X and Y Positions of path's location's position shouldnt match any X and Y Positions of any nodes in Visited or frontier list)
                                    if ((!_visited.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y)) && !_frontier.Any(x => x.X == p.Location.Pos.X && x.Y == p.Location.Pos.Y))
                                    {
                                        //Make it as a parent node
                                        p.Location.Pos.ParentNode = new point2D(_visitedNode);

                                        //Calculate g(n) as the cost so far from the start to the current node
                                        p.Location.Pos.GScore = _visitedNode.GScore + 1;

                                        //Calculate f(n) value = g(n) + h(n) where h(n) is straight line distance
                                        p.Location.Pos.FScore = p.Location.Pos.GScore + Math.Sqrt(Math.Pow(_goalPos.X - p.Location.Pos.X, 2) + Math.Pow(_goalPos.Y - p.Location.Pos.Y, 2));


                                        //Push adjacent nodes to the _frontier
                                        _frontier.Add(p.Location.Pos);
                                    }
                                }
                            }

                            //If algo can find the solution
                            if ((_visitedNode.X == _goalPos.X) && (_visitedNode.Y == _goalPos.Y) && _depth > 0)
                            {
                                return solveIt("AStarDepthLim", Pos, _goalPos, _visited);
                            }
                        }
                    }
                }

                //If algo can't find the solution
                return "No solution at given depth of " + _maxDepth;
            }
        }
                
        /// <summary>
        /// Creating the solution path for the search method used using initial position, current position and expanding backwards
        /// </summary>
        /// <param name="method">the search algo</param>
        /// <param name="initial">Intial Agent position</param>
        /// <param name="child">Current goal position</param>
        /// <param name="expanded">The nodes it used to get there</param>
        /// <returns></returns>
        public string solveIt(string method, point2D initial, point2D child, List<point2D> expanded)
        {
            string solution = "";
            List<point2D> path = new List<point2D>();
            List<string> action = new List<string>();

            //reversing the order of the nodes
            expanded.Reverse();

            //Creating the path considering goal as child and everything else leading to it as parent
            foreach (point2D p in expanded)
            {
                if ((p.X == child.X) && (p.Y == child.Y))
                { 
                    path.Add(p); 
                }
                    

                if (path.Count() != 0)
                {
                    if ((path.Last().ParentNode.X == p.X) && (path.Last().ParentNode.Y == p.Y))
                    {
                        path.Add(p);
                    }
                }
            }

            //reversing the order of the nodes to ensure path is from intial to goal
            path.Reverse();

            //Produce action from path
            for (int i = 0; i < path.Count(); i++)
            {
                if (i == path.Count() - 1)
                {
                    break;
                }

                //if value of y for next node in path is y-1, then agent has moved up
                if (path[i + 1].Y == path[i].Y - 1)
                {
                    action.Add(MoveUp());
                }

                //if value of x for next node in path is x-1, then agent has moved left
                if (path[i + 1].X == path[i].X - 1)
                {
                    action.Add(MoveLeft());
                }         

                //if value of y for next node in path is y+1, then agent has moved down
                if (path[i + 1].Y == path[i].Y + 1)
                {
                    action.Add(MoveDown());
                }

                //if value of x for next node in path is x+1, then agent has moved right
                if (path[i + 1].X == path[i].X + 1)
                {
                    action.Add(MoveRight());
                }

            }

            //List all the actions agent took in a single string where actions are seperated by ";"
            foreach (string a in action)
            {
                solution = solution + a + "; ";
            }

            //Draw the path in UI
            _ui.DrawPath(_pos, _goalPos, _agentMap.WallList, _agentMap.Width, _agentMap.Length, path);



            //////////////////////////////////////////////The following are part of Automatic Testing and data colelction///////////////
            //          finding and sending ideal path length data
            //string myfile = "D:\\visual stuido 2022 repo\\AI assignment 1\\AI_Assignment_V3\\ConsoleApp1\\bin\\Release\\OptimalPathdata20v20" +method+".txt";
            //string stuffy = path.Count().ToString();
            //using (StreamWriter sw = File.AppendText(myfile))
            //{
            //    sw.WriteLine(stuffy);
            //}
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Put method name, number of nodes in search tree and the solution path
            return method + " " + expanded.Count() + " " + solution;
        }
    }
}