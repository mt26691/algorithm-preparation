using System;
using System.Text;

namespace Chapter01._06.StringCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CompressString("aaabbcccddde"));
            Console.ReadLine();
        }

        public static string CompressString(string inputString)
        {
            var builder = new StringBuilder();
            var count = 0;
            for (var i = 0; i < inputString.Length; i++)
            {
                count++;

                if (i + 1 >= inputString.Length || inputString[i + 1] != inputString[i])
                {
                    builder.Append(inputString[i]);
                    builder.Append(count);
                    count = 0;
                }
            }
            return builder.ToString();
        }
    }
}
