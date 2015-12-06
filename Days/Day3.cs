using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://adventofcode.com/day/3
// 

namespace Days
{
    public class Day3 : AllDays
    {
        public void Main()
        {
            string input = GetInput(3);
            char[] steps = FormatInput(input);
            int count = CountVisits(steps);
            int roboCount = CountVisitsWithRoboSanta(steps);
            Console.WriteLine("Count of houses recieving one present at least: {0}\nCount of houses recieving one present with ROBOSANTA: {1}", count, roboCount);
        }

        private char[] FormatInput(string input)
        {
            return input.ToCharArray();
        }

        private int CountVisits(char[] steps)
        {
            int count = 0;
            List<string> visitedPlaces = new List<String>();
            List<int> location = new List<int> { 0, 0 };
            foreach (char step in steps)
            {
                // x and y plane respectivley
                #region if movements
                if (step == '^')
                {
                    location[1]++;
                }
                if(step == 'v')
                {
                    location[1]--;
                }
                if (step == '>')
                {
                    location[0]++;
                }
                if (step == '<')
                {
                    location[0]--;
                }
                #endregion
                string currentLocation = String.Format("{0},{1}", location[0], location[1]);
                if (visitedPlaces.Contains(currentLocation))
                {
                    
                }
                else
                {
                    visitedPlaces.Add(currentLocation);
                    count++;
                }
            }

            return count;
        }

        private int CountVisitsWithRoboSanta(char[] steps)
        {
            int count = 0;
            List<string> visitedPlaces = new List<String>();
            List<int> locationSanta = new List<int> { 0, 0 };
            List<int> locationRoboSanta = new List<int> { 0, 0 };
            bool odd = false;
            foreach (char step in steps)
            {
                string currentLocation;
                // x and y plane respectivley
                #region if movements
                if (odd)
                {
                    odd = false;
                    if (step == '^')
                    {
                        locationSanta[1]++;
                    }
                    if (step == 'v')
                    {
                        locationSanta[1]--;
                    }
                    if (step == '>')
                    {
                        locationSanta[0]++;
                    }
                    if (step == '<')
                    {
                        locationSanta[0]--;
                    }
                    currentLocation = String.Format("{0},{1}", locationSanta[0], locationSanta[1]);
                }
                else
                {
                    odd = true;
                    if (step == '^')
                    {
                        locationRoboSanta[1]++;
                    }
                    if (step == 'v')
                    {
                        locationRoboSanta[1]--;
                    }
                    if (step == '>')
                    {
                        locationRoboSanta[0]++;
                    }
                    if (step == '<')
                    {
                        locationRoboSanta[0]--;
                    }
                    currentLocation = String.Format("{0},{1}", locationRoboSanta[0], locationRoboSanta[1]);
                }

                #endregion

                if (visitedPlaces.Contains(currentLocation))
                {

                }
                else
                {
                    visitedPlaces.Add(currentLocation);
                    count++;
                }
            }

            return count;
        }
    } 
}
