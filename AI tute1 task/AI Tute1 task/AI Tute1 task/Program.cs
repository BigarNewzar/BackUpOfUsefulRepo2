// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTxtFileToProcessing
{
    class Array
    {
        static void Main(string[] args)
        {

            String input = File.ReadAllText(@"D:\visual stuido 2022 repo\AI tute1 task\AI Tute1 task\filestuff.txt");

            //declaring them here, forgot the best practise so yeah.......
            int i = 0, j = 0; //for array
            int x=3, y=4; //for notepad text input size

            //alternatively streamreader, readline, line split can be used to dynmically read them no matter what row or column


            //fixing array size for now
            string[,] MultiArray = new string[x, y];
            foreach (var row in input.Split('\n'))
            {
                j = 0; 
                foreach (var col in row.Trim().Split(' '))
                {
                    MultiArray[i, j] = col.Trim();
                    j++;
                }
                i++;
            }

           // for (int i2 = 0; i2<x; i2++)
            //{
              //  for (int j2=0; j2<y; j2++)
                //{
               //     Console.WriteLine(MultiArray[i2, j2]);
               // }
            //}


            //currently its in an array, so for each line, pass it to class called route
            //for each route j value changes whilst i value remains same

            for (int i3 = 0; i3 < x; i3++)
            {
                Route R = new Route(MultiArray[i3, 0], MultiArray[i3, 1], MultiArray[i3, 2], MultiArray[i3, 3]);

               // Console.WriteLine(MultiArray[i3, 0] + " " + MultiArray[i3, 1] + " " + MultiArray[i3, 2] + " " + MultiArray[i3, 3]);
                R.PrintRoute();
            }
            

           
        }
    }
}
