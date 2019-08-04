using System;

namespace HackerRank._03.BreakingTheRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = breakingRecords(new int[] { 3, 4, 21, 36, 10, 28, 35, 5, 24, 42, });
            Console.WriteLine("Hello World!");
        }

        static int[] breakingRecords(int[] scores)
        {
            var result = new int[] { 0, 0 };

            var min = scores[0];
            var max = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                var currentPoint = scores[i];
                if(currentPoint > max)
                {
                    max = currentPoint;
                    result[0]++;
                }
                if(currentPoint < min)
                {
                    min = currentPoint;
                    result[1]++;
                }
            }

            return result;
        }
    }
}
