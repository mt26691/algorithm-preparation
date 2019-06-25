using System;
using System.Collections.Generic;

namespace Chapter01._01.IsUnique
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Check all char in string is unique
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        public static bool IsUnique(string checkString)
        {
            var dic = new Dictionary<char, bool>();
            for (var i = 0; i < checkString.Length; i++)
            {
                if (dic.ContainsKey(checkString[i]))
                {
                    return false;
                }
                dic.Add(checkString[i], true);
            }
            return true;
        }
    }
}
