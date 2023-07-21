using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_1
{
    public  class CoordinateFixer
    {

        private string[] _split;
        private string[] _splitValueFromEmpty;
        private int _value;

        public CoordinateFixer( string[] split) {
            _split = split;
        }

        public int GetValue(int i, string s, int j)
        {

            _splitValueFromEmpty = _split[i].Split(s);

            //need a try catch for this
            try
            {
                _value = Int32.Parse(_splitValueFromEmpty[j]);

                Console.WriteLine("Value checked by Fixer: " + _value);

                return _value;
            }
            catch (Exception Valuenotfound)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Value has not been found. Please ensure the 1st line in file has been written in [a,b]");
                Console.WriteLine("2nd line has been written in (a,b) format where both a and b are numbers"); 
                Console.WriteLine("3rd line has been writte in (a,b) or (a,b) | (c,d) |.....(z,v) where a,b,c,d....z are all numbers");   
                Console.WriteLine("and 4th and rest of line written in (a,b,c,d) where a,b,c,d are all numbers");
                Console.WriteLine(" ");
                _value = 0;
                return _value;
            }



        }

        
    }
}
