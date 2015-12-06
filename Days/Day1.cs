using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days
{
    public class Day1 : AllDays
    {
        public void Main()
        {
            string input = GetInput(1);
            int floor = CalculateFloors(input.ToCharArray());
            Console.WriteLine(floor);
        }


        private int CalculateFloors(char[] inputArr)
        {
            int floor = 0;
            int charCount = 0;
            bool foundBasement = false;
            foreach (char item in inputArr)
            {
                charCount++;
                if (item == '(')
                {
                    floor++;
                }
                else if (item == ')')
                {
                    floor--;
                }
                if (floor == -1 && !foundBasement)
                {
                    Console.WriteLine(charCount);
                    foundBasement = true;
                }
            }
            return floor;
        }
    }
}
