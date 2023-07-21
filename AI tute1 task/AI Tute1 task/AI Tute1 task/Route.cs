using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTxtFileToProcessing
{

    public class Route
    {
        private string _CityFrom;
        private string _CityTo;
        private string _ActualDistance;
        private string _StraightLineDistance;



        public Route(string CityFrom, string CityTo, string ActualDistance, string StraightLineDistance) {

            _CityFrom = CityFrom;
            _CityTo = CityTo;
            _ActualDistance = ActualDistance;
            _StraightLineDistance = StraightLineDistance;
        }

    public void PrintRoute()
    {
        //do stuff
            if (_ActualDistance == "-1")
            {
                Console.WriteLine("Cannot drive from " + _CityFrom + " to " + _CityTo + ", however there is a straight line distance of " + _StraightLineDistance);
            }

            else {
                Console.WriteLine("Travel from city " + _CityFrom + " to " + _CityTo + " with a straight line distance of " +  _StraightLineDistance + " and an actual distance of " + _ActualDistance);
            }

    }





}
}
