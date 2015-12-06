using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Days
{
    public class AllDays
    {
        public virtual string GetInput(int dayVal)
        {
            Console.WriteLine("Reading file");
            string fileName = string.Format("day{0}input.txt", dayVal);
            string fileLocation = string.Format(@"D:\Dom\Documents\Files\Projects\AoC\AdventCalendar\{0}", fileName);
            try
            {
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    string input = sr.ReadToEnd();
                    return input;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not read file");
                return string.Empty;
            }

        }
    }
}
