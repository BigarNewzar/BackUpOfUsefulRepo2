using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace AI_Assignment_1
{
    public class Agent
    {
        private string[] _line;
        private string[] _split;
        private int _X;
        private int _Y;
        private CoordinateFixer _fixer;
        private Point pos;
        private Point goalPos;
        private Map _map;

        //(0,1)
        public Agent(string line2, Map map)
        {
            _split = line2.Split(",");

            _fixer = new CoordinateFixer(_split);

            _X = _fixer.GetValue(0, "(", 1);
            _Y = _fixer.GetValue(1, ")", 0);


            _map = map;

            AgentPaths();
            AgentMove(map);

        }

        public Point Point
        {
            get { return pos; }
            set { pos = value; }
        }
        public int X   // property
        {
            get { return _X; }   // get method
            set { _X = value; }  // set method
        }

        public int Y  // property
        {
            get { return _Y; }   // get method
            set { _Y = value; }  // set method
        }


        public void AgentPaths()
        {
            Console.WriteLine("I'm currently at X = " + X + " And Y = " + Y);
            foreach (room r in _map.)
            {
                if ((pos.X == r.Pos.X) && (pos.Y == r.Pos.Y))
                {
                    Console.WriteLine("From here I could go to: ");
                    foreach (Path p in r.Paths)
                    {
                        Console.WriteLine("X = " + p.Location.Pos.X + "Y = " + p.Location.Pos.Y);
                    }
                }
            }
            Console.WriteLine("My goal is to get to X = " + goalPos.X + "Y = " + goalPos.Y);
        }

        public void AgentMove(Map map)
        {
            foreach(room)
            if(map)
        }
    }
}
