// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ArrayTxtFileToProcessing
{
    class Array
    {
        static void Main(string[] args)
        {
            
            string[] fields;
            string[] SplitEachRoomNumAndState;
            string[] furtherSplit;

            StreamReader sr = new StreamReader("D:\\visual stuido 2022 repo\\Ai tute 2 task\\AI Tute2 task\\vacummGoBrrrrr.txt");
            
            
            var lines= sr.ReadToEnd();  //stored all the lines!

            Console.WriteLine(lines);   //checking to ensure all lines go in from "filename" to "lines"



            fields = lines.Split("\n");


            for (int i = 0; i < fields.Length; i++)
                {
                    Console.WriteLine(fields[i]); //checking to ensure nth full line
                Console.WriteLine("The full line for that part");
                    SplitEachRoomNumAndState = fields[i].Trim().Split(" [");

                    for (int j = 0; j < SplitEachRoomNumAndState.Length; j++)
                    {
                        Console.WriteLine(SplitEachRoomNumAndState[j]); //checking to ensure nth full rom no and status
                    Console.WriteLine("each room number and condition");
                        furtherSplit = SplitEachRoomNumAndState[j].Trim().Split("] ");
                        //furthersplit have been splitting them, but it still needs to understand what it is storing, will need to go thr previous method of "route" done in previous class here!

                        for (int k = 0; k < furtherSplit.Length; k++)
                        {
                            Console.WriteLine(furtherSplit[k]); //checking to ensure seperate between room no and status, will pass this to a class later as it will need to understand what is being stored instead of just storing it as an array
                        Console.WriteLine("each room number and condition have been stored seperately properly");




                        }

                    }

                }
            
           
                




            //fixing array size for now
            //string[,] MultiArray = new string[x, y];
            //foreach (var row in input.Split('\n'))
            //{
            //    j = 0;
            //    foreach (var col in row.Trim().Split(' '))
            //    {
            //        MultiArray[i, j] = col.Trim();
            //        j++;
            //    }
            //    i++;
            //}

            // for (int i2 = 0; i2<x; i2++)
            //{
            //  for (int j2=0; j2<y; j2++)
            //{
            //     Console.WriteLine(MultiArray[i2, j2]);
            // }
            //}


            //currently its in an array, so for each line, pass it to class called route
            //for each route j value changes whilst i value remains same

            //for (int i3 = 0; i3 < x; i3++)
            //{
            //    Route R = new Route(MultiArray[i3, 0], MultiArray[i3, 1], MultiArray[i3, 2], MultiArray[i3, 3]);

            //    // Console.WriteLine(MultiArray[i3, 0] + " " + MultiArray[i3, 1] + " " + MultiArray[i3, 2] + " " + MultiArray[i3, 3]);
            //    R.PrintRoute();
            //}



        }
    }
}
