using System;
using System.Collections.Generic;

namespace HackerRank._02.GradingStudents
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/grading/problem
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var results = gradingStudents(new List<int>() { 73, 67, 38, 33 });
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Hello World!");
        }

        public static List<int> gradingStudents(List<int> grades)
        {
            var result = new List<int>();
            foreach (var item in grades)
            {
                if (item < 38)
                {
                    result.Add(item);
                }
                else
                {
                    var multiple5 = (item / 5 + 1) * 5;

                    if (multiple5 - item < 3)
                    {
                        result.Add(multiple5);
                    }
                    else
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

    }
}
