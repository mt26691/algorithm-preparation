using System;
using System.Collections.Generic;
using System.Linq;
namespace Chapter01._02.CheckPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(IsPermutation("abc", "cba"));
        }

        /// <summary>
        ///  A Permutation of a string is another string that contains same characters, 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool IsPermutation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            var s1Chars = s1.ToCharArray()
                .OrderBy(t => t).ToArray();
            var s2Chars = s2.ToCharArray().OrderBy(t => t).ToArray();

            var s1OrderString = new string(s1Chars);
            var s2OrderString = new string(s2Chars);

            return s1OrderString == s2OrderString;
        }
    }
}
