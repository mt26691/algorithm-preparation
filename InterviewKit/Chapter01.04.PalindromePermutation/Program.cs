using System;
using System.Collections.Generic;

namespace Chapter01._04.PalindromePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindromePermutation("aaaabbbccc"));
            Console.ReadLine();
        }

        /// <summary>
        /// Palindrome Permutation string can't have more than 1 odd char
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static bool IsPalindromePermutation(string inputString)
        {
            var frequencyDic = BuildFrequencyTable(inputString);

            int oddCount = 0;
            foreach (var item in frequencyDic)
            {
                if (item.Value % 2 == 1)
                {
                    oddCount++;
                    if (oddCount > 1)
                    {
                        return false;
                    }
                }
            }


            return true;
        }
        public static Dictionary<char, int> BuildFrequencyTable(string inputString)
        {
            var result = new Dictionary<char, int>();
            for (int i = 0; i < inputString.Length; i++)
            {
                var currentChar = inputString[i];
                if (result.ContainsKey(currentChar))
                {
                    result[currentChar] += 1;
                }
                else
                {
                    result.Add(currentChar, 1);
                }
            }

            return result;
        }
    }
}
