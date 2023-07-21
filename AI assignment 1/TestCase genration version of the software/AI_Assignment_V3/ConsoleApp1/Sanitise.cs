using System;
using System.Text.RegularExpressions;//need it for regex
using System.Collections.Generic;

namespace AI_Assignment_version2
{
    /// <summary>
    /// Sanitise the strings being passed into it to bring out the numbers
    /// </summary>
    public class Sanitise
    {
        private string _splitString;

        /// <summary>
        /// create class instance of sanitise
        /// </summary>
        /// <param name="s">string that will be sanitised</param>
        public Sanitise(string s)
        {
            _splitString = s;
        }

        /// <summary>
        /// Takes in string and extracts out the numbers
        /// </summary>
        /// <returns>gives out a list of numbers as intList</returns>
        public List<int> getInt()
        {
            //split numbers using regex
            string[] numbers = Regex.Split(_splitString, @"\D+");
            //ref: https://www.c-sharpcorner.com/blogs/split-string-using-regexsplit-regular-expression-in-c-sharp
            //it will split the string passed using the numbers and thus no need to go through hassle of removing slash and brackets

            List<int> intList = new List<int>();

            //after split, if its a number, pass it to list of number. But if its null or empty space, then ignore
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