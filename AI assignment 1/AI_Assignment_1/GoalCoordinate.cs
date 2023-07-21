using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_1
{
    public class GoalCoordinate
    {
        private int _goalX;
        private int _goalY;
        private string _line;


        private int[,] _possibleGoalXYArray;
        private string[] _goals;
        private string[] _goalsSplitterXY;
        private CoordinateFixer _fixer2;
        private string[,] _map;


        public GoalCoordinate(string line, string[,] map)
        {
            _line = line;
            _goalX = 0;
            _goalY = 0;
            _map = map;


            try
            {
                if (line.Contains("|"))
                {
                    //split it into array with multiple row
                    _goals = line.Split(" | ");


                    //need ot print it all out as array outputs with proper comments on output

                    //(7,0) | (10,3) 
                    for (int goali = 0; goali < _goals.Length; goali++)
                    {
                        _goalsSplitterXY = _goals[goali].Split(",");
                        _fixer2 = new CoordinateFixer(_goalsSplitterXY);
                        _goalX = _fixer2.GetValue(0, "(", 1);
                        _goalY = _fixer2.GetValue( 1, ")", 0);

                        Console.WriteLine("Will add X and Y to Goal Array now");

                        //pass map array here, if X and Y matches then put in Goal

                        //go through map, if X and y matches then put Goal key word

                        //else put empty


                        map[_goalX, _goalY] = "goal";

                        //_possibleGoalXYArray[goali, goali].Add
                        //try to store them as coordinate type values which are linked to one another. Create new class of "goal coordinate" if needed
                        //like goal coordinatelist where each has x,y values

                        //or maybe pass them normally to map and then inside the map, callthee methods to isolate them and make them book up the coordinates in the map?

                        //maybe try to keep them inside map and if coordinate of map matches with goal then put in goal as placeholder for those cells?


                    }

                }
                else
                {
                    //split it into array with only 1 row
                    _goalsSplitterXY = line.Split(",");
                    _fixer2 = new CoordinateFixer(_goalsSplitterXY);
                    _goalX = _fixer2.GetValue(0, "(", 1);
                    _goalY = _fixer2.GetValue(1, ")", 0);

                    //need to add it to an array now

                    Console.WriteLine("Only 1 goal value, X =" + _goalX + " and Y = " + _goalY);
                    map[_goalX, _goalY] = "Goal";
                }

            }


            //return _possibleGoalXYArray;

            catch (Exception Line2GoalDeclarationError)
            {
                Console.WriteLine("2nd Line of file (goal decalration) has not been properly written. It should either be a single (a,b) line where a and b are numbers or a line or (a,b) | (c,d) |.....(z,v) where a,b,c,d....z are all numbers");

            }


        }

        


        






    }
}
