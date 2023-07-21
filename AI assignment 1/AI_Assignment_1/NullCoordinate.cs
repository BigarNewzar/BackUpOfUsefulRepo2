using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Assignment_1
{
    public class NullCoordinate
    {
        private string[] _line;
        private int _nulli;
        private int _nulla;
        private int _nullb;
        private string[] _nullsSplitterXY;

        private int _nullX;
        private int _nullY;
        private int _nullHeight;
        private int _nullWidth;
        private CoordinateFixer _fixer3;
        public NullCoordinate(string[] line, string[,] map) {
            _line = line;

            makeNullobject(line, map);
        
        }

        public void makeNullobject(string[] line, string[,] map)
        {
            try {
                for (_nulli = 3; _nulli < line.Length; _nulli++)
                {
                    _nullsSplitterXY = line[_nulli].Split(",");
                    _fixer3 = new CoordinateFixer(_nullsSplitterXY);
                    //ned to think...can eb reused as split amoung multiple values..need to test and chek though
                    _nullX = _fixer3.GetValue(0, "(", 1);
                    _nullY = Int32.Parse(_nullsSplitterXY[1]);
                    _nullWidth = Int32.Parse(_nullsSplitterXY[2]);
                    _nullHeight = _fixer3.GetValue(3, ")", 0);

                    //comment this later, this is only for testing
                    Console.WriteLine("X value of null is " + _nullX + " Y value of null is" + _nullY  + " Width of null is" + _nullWidth + " Height of null is" + _nullHeight);

                    for (_nulla = _nullX; _nulla < _nullX + _nullWidth; _nulla++)
                    {
                        for (_nullb = _nullY; _nullb < _nullY + _nullHeight; _nullb++)
                        {
                            map[_nulla, _nullb] = "null";
                        }
                    }

                    //map[_nullX, _nullY] = "null";

                }
            }
            catch (Exception LineNullDeclarationError)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Line of file for declaring Null cells have not been properly written. It should either be a single (a,b,c,d) line where a,b,c,d are numbers without any space. New null values should be written below one another following similiar format");
                Console.WriteLine(" ");

            }
        }
    }
}
