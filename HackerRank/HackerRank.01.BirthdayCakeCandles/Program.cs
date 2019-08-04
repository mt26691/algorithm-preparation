using System;
using System.Collections.Generic;

namespace HackerRank._01.BirthdayCakeCandles
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = birthdayCakeCandles(new int[] { 4, 3, 2, 4 });
            Console.WriteLine(result);
        }

        static int birthdayCakeCandles(int[] ar)
        {
            var dic = new Dictionary<int, int>();
            int maxValue = int.MinValue;
            foreach (var item in ar)
            {
                if (item > maxValue)
                {
                    maxValue = item;
                }
                if (dic.ContainsKey(item))
                {
                    dic[item] += 1;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }
            if(maxValue == int.MinValue)
            {
                return 0;
            }
            return dic[maxValue];
        }
    }
}
