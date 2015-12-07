using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://adventofcode.com/day/6
// 1000x1000 grid
// Corners are:  0,0 , 0,999 , 999,999 , 999,0
// turn off, turn on or toggle

namespace Days
{
    public class Day6 : AllDays
    {
        public void Main()
        {
            string input = GetInput(6);
            string[] lines = input.Split('\n');
            Console.WriteLine(ControlLight(lines));
            Console.WriteLine(ControlNewLight(lines));

        }

        private int ControlLight(string[] lines)
        {
            int onCount = 0;
            int gridLength = 1000;
            bool[,] lightGrid = new bool[gridLength,gridLength];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] instructions = lines[i].Split(' ');
                bool on = false;
                bool toggle = false;
                int point = 2;
                if (instructions[0] == "turn")
                    on = instructions[1] == "on";
                else
                {
                    toggle = true;
                    point = 1;
                }
                int aXCoord = Convert.ToInt32(instructions[point].Split(',')[0]);
                int bXCoord = Convert.ToInt32(instructions[point + 2].Split(',')[0]);
                int aYCoord = Convert.ToInt32(instructions[point].Split(',')[1]);
                int bYCoord = Convert.ToInt32(instructions[point + 2].Split(',')[1]);
                for (int x = aXCoord; x <= bXCoord; x++)
                {
                    for (int y = aYCoord; y <= bYCoord; y++)
                    {
                        if (on)
                            lightGrid[x, y] = true;
                        else if (toggle)
                            lightGrid[x, y] = !lightGrid[x, y];
                        else
                            lightGrid[x, y] = false;
                    }
                }
                if (onCount < 0)
                    onCount = 0;
            }


            for (int row = 0; row < gridLength; row++)
            {
                for (int col = 0; col < gridLength; col++)
                {
                    if (lightGrid[row, col])
                        onCount++;
                }
            }
            return onCount;
        }

        private int ControlNewLight(string[] lines)
        {
            int brightnessCount = 0;
            int gridLength = 1000;
            int[,] lightGrid = new int[gridLength, gridLength];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] instructions = lines[i].Split(' ');
                bool on = false;
                bool toggle = false;
                int point = 2;
                if (instructions[0] == "turn")
                    on = instructions[1] == "on";
                else
                {
                    toggle = true;
                    point = 1;
                }
                int aXCoord = Convert.ToInt32(instructions[point].Split(',')[0]);
                int bXCoord = Convert.ToInt32(instructions[point + 2].Split(',')[0]);
                int aYCoord = Convert.ToInt32(instructions[point].Split(',')[1]);
                int bYCoord = Convert.ToInt32(instructions[point + 2].Split(',')[1]);
                for (int x = aXCoord; x <= bXCoord; x++)
                {
                    for (int y = aYCoord; y <= bYCoord; y++)
                    {
                        if (on)
                            lightGrid[x, y] += 1;
                        else if (toggle)
                            lightGrid[x, y] += 2;
                        else if (lightGrid[x, y] > 0)
                            lightGrid[x, y] -= 1;
                    }
                }
                if (brightnessCount < 0)
                    brightnessCount = 0;
            }


            for (int row = 0; row < gridLength; row++)
            {
                for (int col = 0; col < gridLength; col++)
                {
                    brightnessCount += lightGrid[row,col];
                }
            }
            return brightnessCount;
        }
    }
}
