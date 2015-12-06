using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

// http://adventofcode.com/day/4
// 

namespace Days
{
    public class Day4 : AllDays
    {
        public void Main()
        {
            string input = GetInput(4);
            int count = FiveLeadingZeros(input);
            int countSix = SixLeadingZeros(input);
            Console.WriteLine("5 leading zeros: {0}\nSix leading zeros: {1}",count,countSix);
        }

        private string GetHash(string secretKey)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(secretKey);
            byte[] hash = md5Hasher.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private int FiveLeadingZeros(string input)
        {
            int count = 0;
            string secretKey = input + count;
            string output = GetHash(secretKey);
            while (!output.StartsWith("00000"))
            {
                count++;
                secretKey = input + count;
                output = GetHash(secretKey);
            }
            return count;
        }
        private int SixLeadingZeros(string input)
        {
            int count = 0;
            string secretKey = input + count;
            string output = GetHash(secretKey);
            while (!output.StartsWith("000000"))
            {
                count++;
                secretKey = input + count;
                output = GetHash(secretKey);
            }
            return count;
        }
    }
}
