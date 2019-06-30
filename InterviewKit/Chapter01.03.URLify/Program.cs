using System;

namespace Chapter01._03.URLify
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UrlifyTest("test 01 02"));
            Console.ReadLine();
        }

        public static string UrlifyTest(string inputUrl)
        {
            var result = inputUrl.Trim().Replace(" ", "%20");
            return result;
        }
    }
}
