using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Days;

namespace AdventCalendar
{
    class ProgramSelector
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                List<string> programList = new List<string>
                {
                #region Program List
                    "List of programs",
                    "Day 1 - Santa floor finder",
                    "Day 2 - Elves wrapping paper",
                    "Day 3 - Santa delivering to a infinite 2d grid",
                    "Day 4 - Santa wants bitcoins?",
                    "Day 5 - Santa's naughty and nice comparer",
                    "Day 6 - Neighbourhood lighting issues",
                    "Day 7 - Santa's innapropriate gift for bobby"
                #endregion
                };

                Console.WriteLine("Select a program");
                programList.ForEach(i => Console.WriteLine(i));
                int choice = Convert.ToInt32(Console.ReadLine());

                #region switch
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(programList[1]);
                        Day1 day1 = new Day1();
                        day1.Main();
                        break;
                    case 2:
                        Console.WriteLine(programList[2]);
                        Day2 day2 = new Day2();
                        day2.Main();
                        break;
                    case 3:
                        Console.WriteLine(programList[3]);
                        Day3 day3 = new Day3();
                        day3.Main();
                        break;
                    case 4:
                        Console.WriteLine(programList[4]);
                        Day4 day4 = new Day4();
                        day4.Main();
                        break;
                    case 5:
                        Console.WriteLine(programList[5]);
                        Day5 day5 = new Day5();
                        day5.Main();
                        break;
                    case 6:
                        Console.WriteLine(programList[6]);
                        Day6 day6 = new Day6();
                        day6.Main();
                        break;
                    case 7:
                        Console.WriteLine(programList[7]);
                        Day7 day7 = new Day7();
                        day7.Main();
                        break;
                    default:
                        break;
                }
                #endregion
            }

        }
    }
}
