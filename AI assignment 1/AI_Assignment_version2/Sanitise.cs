using System;
using System.Text.RegularExpressions;//need it for regex
using System.Collections.Generic;

namespace AI_Assignment_version2
{
    public class Sanitise
    {
        private string _splitString;

        public Sanitise(string s)
        {
            _splitString = s;
        }

        public List<int> getInt()
        {
            string[] numbers = Regex.Split(_splitString, @"\D+");

            //ref: https://www.c-sharpcorner.com/blogs/split-string-using-regexsplit-regular-expression-in-c-sharp
            //it will split the string passed using the numbers and thus no need to go through hassle of removing slash and brackets

            List<int> intList = new List<int>();

            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    intList.Add(i);
                }
            }

            return intList;
        }
    }
}