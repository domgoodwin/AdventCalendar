using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://adventofcode.com/day/2
// input lines with H x W x L
// 

namespace Days
{
    public class Day2 : AllDays
    {
        public void Main()
        {
            string input = GetInput(2);
            string[] inputs = FormatInputs(input);
            int totalWrapping = CalculateWrappingPaper(inputs);
            int totalRibbon = CalculateRibbon(inputs);
            Console.WriteLine("Total wrapping paper: {0}", totalWrapping);
            Console.WriteLine("Total wrapping paper: {0}", totalRibbon);
        }

        private string[] FormatInputs(string input)
        {
            List<string> inputs = new List<string>();
            string[] inputArr = input.Split('\n');
            return inputArr;
        }

        private int CalculateWrappingPaper(string[] inputs)
        {
            int total = 0;
            foreach (string item in inputs)
            {
                string[] dimensions = item.Split('x');
                int h = Convert.ToInt32(dimensions[0]);
                int w = Convert.ToInt32(dimensions[1]);
                int l = Convert.ToInt32(dimensions[2]);
                total += (2 * l * w) + (2 * w * h) + (2 * h * l) + GetMinSide(l, w, h);
            }
            return total;
        }

        private int CalculateRibbon(string[] inputs)
        {
            int total = 0;
            foreach (string item in inputs)
            {
                string[] dimensions = item.Split('x');
                int h = Convert.ToInt32(dimensions[0]);
                int w = Convert.ToInt32(dimensions[1]);
                int l = Convert.ToInt32(dimensions[2]);
                total += GetMinPerimeter(h, w, l) + (h * w * l);
            }
            return total;
        }

        private int GetMinSide(int h, int w, int l)
        {
            List<int> numbers = new List<int> { h, w, l };
            int smallestPlain = numbers.Min();
            numbers.Remove(smallestPlain);
            int secondSmallestPlain = numbers.Min();
            return smallestPlain * secondSmallestPlain;
        }

        private int GetMinPerimeter(int h, int w, int l)
        {
            List<int> numbers = new List<int> { h, w, l };
            int smallestPlain = numbers.Min();
            numbers.Remove(smallestPlain);
            int secondSmallestPlain = numbers.Min();
            return (smallestPlain + secondSmallestPlain) * 2;
        }
    }
}
