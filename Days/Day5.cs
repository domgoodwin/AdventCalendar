using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://adventofcode.com/day/5
// vowels are aeiou only.
// nice has 3 vowels, 1 set of repeating letters and does not contain:
// ab, cd, pq or xy

namespace Days
{
    public class Day5 : AllDays
    {
        public void Main()
        {
            string input = GetInput(5);
            string[] eachLine = FormatInput(input);
            List<string> ret = eachLine.Where(s => CheckNiceNewRules(s)).ToList();
            int niceCount = NiceCounter(eachLine);
            int niceCountNewRules = ret.Count;
            Console.WriteLine("normal: {0}, new rules: {1}",niceCount, niceCountNewRules);
        }

        private string[] FormatInput(string input)
        {
            return input.Split('\n');
        }

        private int NiceCounter(string[] inputLines)
        {
            int count = 0;
            foreach (string line in inputLines)
            {
                if (CheckNice(line))
                {
                    count++;
                }
            }
            return count;
        }

        private int NiceCounterNewRules(string[] inputLines)
        {
            int count = 0;
            foreach (string line in inputLines)
            {
                if (CheckNiceNewRules(line))
                {
                    count++;
                }
            }
            return count;
        }

        private bool CheckNice(string line)
        {
            int vowelCount = 0;
            bool checkRepeat = false;
            // Is false when it contains ab, cd, pq, xy
            bool checkContain = true;
            char[] chars = line.ToCharArray();
            if (line.Contains("ab")
                || line.Contains("cd")
                || line.Contains("pq")
                || line.Contains("xy"))
            {
                checkContain = false;
            }
            for (int i = 0; i < chars.Length; i++)
            {
                if (VowelCheck(chars[i]))
                {
                    vowelCount++;
                }
                if(i == 0)
                {
                    if(chars[i] == chars[i + 1])
                    {
                        checkRepeat = true;
                    }
                }
                else if(i == chars.Length - 1)
                {
                    if(chars[i] == chars[i - 1])
                    {
                        checkRepeat = true;
                    }
                }
                else
                {
                    if (chars[i] == chars[i - 1])
                    {
                        checkRepeat = true;
                    }
                    if (chars[i] == chars[i + 1])
                    {
                        checkRepeat = true;
                    }
                }
            }
            return checkRepeat && (vowelCount > 2) && checkContain;
        }

        private bool CheckNiceNewRules(string line)
        {
            // needs a pair of two letters that repeat
            // ie. aabcdaa  - 'aa' twice
            // and needs one letter which repeats with a single letter between
            // ie. aba OR aaa
            bool checkPairs = false;
            bool checkRepeat = false;
            for (int i = 0; i < line.Length - 1; i++)
            {
                string pair = line.Substring(i, 2);
                if (line.IndexOf(pair, i + 2) != -1)
                    checkPairs = true;
            }

            for (int i = 0; i < line.Length - 2; i++)
            {
                if (line[i] == line[i + 2])
                    checkRepeat =  true;
            }
            return checkPairs && checkRepeat;
        }

        private bool VowelCheck(char character)
        {
            if(    character == 'a' 
                || character == 'e'
                || character == 'i'
                || character == 'o'
                || character == 'u')
            {
                return true;
            }
            return false;
        }
    }
}
