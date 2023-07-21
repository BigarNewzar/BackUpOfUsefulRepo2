using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_1
{
    public class Percept
    {
        
            private string _fileName;
            private string _line;
            private string[] _lineSegment;
            
            
            private string[] _splitValueFromEmpty;
            private int _value;

            private string[] _splitValueXY;
            private int _maxX;
            private int _maxY;

            private string[] _splitAgentXY;
            private int _agentX;
            private int _agentY;

            private int[,] _possibleGoalXYArray;
            private string[] _goals;
            private string[] _goalsSplitterXY;
            private int _goalX;
            private int _goalY;



            


            private CoordinateFixer _sanitizeCoordinates;
            private Map _map;
            private Agent _agent;



        public Percept(string filename)
            {
            
            _fileName = filename;
            _line = Readfile(_fileName);


           // _sanitizeCoordinates = new CoordinateFixer();

            _lineSegment = _line.Split("\n");

            _map = new Map(_lineSegment);

            _agent = new Agent(_lineSegment[1], _map);

            Console.WriteLine("Agent's position X = " + _agent.X + " and Y = " + _agent.Y);
            

           //Need to code for agent movement: up or down, left or right and pass in map there (make sure to account for walls--ie max and min x and y values, account for nulls,)
           //if it hits null, then make it move for the other 3 options in order
           //order of movement (up=1, left=2, down=3 ,right=4)



           //Need to code for algo the agent will  use

            ////splitting 1st line to get X and Y value of array size 
            //_splitValueXY = _lineSegment[0].Split(",");        
            //_maxX = GetValue(_splitValueXY,0,"[",1);
            //_maxY = GetValue(_splitValueXY,1 ,"]",0);


            
            //_splitAgentXY = _lineSegment[1].Split(","); 
            //_agentX = GetValue(_splitAgentXY, 0, "(", 1);
            //_agentY = GetValue(_splitAgentXY, 1, ")", 0);

            //need to code for multiple and single goals, multiple goals will be seperated with " | ". need to see how it deals with this if there is no " | "
             

            //_possibleGoalXYArray =

            //Now create an array of _maxX and _maxY that can store the remaining data or smth

            //make sure to pass null, initial position and other fields to it as well
            //MakeMap(_maxX, _maxY, _lineSegment);



        }

        private string Readfile(string filename) {

            try
            {
                //calling the function to store it as a readable object
                StreamReader sr = new StreamReader(_fileName);

                //calling function to read it
                _line = sr.ReadToEnd();

                //keeping it for intant testing to ensure alldata being read
                //Console.WriteLine(_line); 


                return _line;
                
                
            }
            catch (FileNotFoundException exnotfound)
            {
                Console.WriteLine("Percept file is not found. Please make sure file is in Resources folder, named MapFile and in txt format");

                _line = "";

                return _line;
            }
            catch (Exception ex)
            {
                // handle other exceptions
                _line = "";

                return _line;
            }

        }

       
        //public int GetValue(string[] split, int i, string s, int j)
        //{
            
        //    _splitValueFromEmpty = split[i].Split(s);

        //    //need a try catch for this
        //    try
        //    {
        //        _value = Int32.Parse(_splitValueFromEmpty[j]);

        //        Console.WriteLine(_value);

        //        return _value;
        //    }
        //    catch (Exception MaxXvaluenotfound)
        //    {
        //        Console.WriteLine("Value has not been found. Please ensure the first line in file has been written in [a,b], 2nd line has been written in (a,b) format where both a and b are numbers and 3rd line has been writte in (a,b) or (a,b) | (c,d) |.....(z,v) where a,b,c,d....z are all numbers");
        //        _value = 0;
        //        return _value;
        //    }
            


        //}

        //make it void for now, will later have to make it output into int[,]
        //public void GetGoalValues(string line)
        //{
        //    try
        //    {
        //        if (line.Contains("|"))
        //        {
        //        //split it into array with multiple row
        //            _goals = line.Split(" | ");

                
        //            //need ot print it all out as array outputs with proper comments on output

        //            //(7,0) | (10,3) 
        //            for (int goali = 0; goali < _goals.Length; goali ++ )
        //            {
        //                _goalsSplitterXY = _goals[goali].Split(",");
        //                _goalX = GetValue(_goalsSplitterXY, 0, "(", 1);
        //                _goalY = GetValue(_goalsSplitterXY, 1, ")", 0);

        //                Console.WriteLine("Will add X and Y to Goal Array now");

        //                //_possibleGoalXYArray[goali, goali].Add
        //                //try to store them as coordinate type values which are linked to one another. Create new class of "goal coordinate" if needed
        //                //like goal coordinatelist where each has x,y values

        //                //or maybe pass them normally to map and then inside the map, callthee methods to isolate them and make them book up the coordinates in the map?

        //                //maybe try to keep them inside map and if coordinate of map matches with goal then put in goal as placeholder for those cells?


        //            }
                    
        //        }
        //        else
        //        {
        //            //split it into array with only 1 row
        //            _goalsSplitterXY = line.Split(",");
        //            _goalX = GetValue(_goalsSplitterXY, 0, "(", 1);
        //            _goalY = GetValue(_goalsSplitterXY, 1, ")", 0);

        //            //need to add it to an array now

        //            Console.WriteLine("Only 1 goal value, X =" + _goalX + " and Y = " + _goalY );
        //        }

        //    }
            

        //    //return _possibleGoalXYArray;

        //     catch (Exception Line2GoalDeclarationError)
        //        {
        //        Console.WriteLine("2nd Line of file (goal decalration) has not been properly written. It should either be a single (a,b) line where a and b are numbers or a line or (a,b) | (c,d) |.....(z,v) where a,b,c,d....z are all numbers");
                
        //    }

        //}




       



    }
}
