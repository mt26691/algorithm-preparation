using System;

namespace Chapter01._05.OneArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsOneEdit("pale", "ple"));
            Console.WriteLine(IsOneEdit("pales", "pale"));
            Console.WriteLine(IsOneEdit("pale","bale"));
            Console.WriteLine(IsOneEdit("pale", "bae"));
            Console.ReadLine();
        }

        public static bool IsOneEdit(string inputString, string outputString)
        {
            // same lenght
            if (inputString.Length == outputString.Length)
            {
                var foundDiff = false;
                // check if one replacement
                for (var i = 0; i < inputString.Length; i++)
                {
                    if (inputString[i] != outputString[i])
                    {
                        if (foundDiff)
                        {
                            return false;
                        }
                        else
                        {
                            foundDiff = true;
                        }
                    }
                }

                Console.WriteLine("One replacement");
                return true;
            }
            //  removal
            else if (inputString.Length + 1 == outputString.Length)
            {
                return CheckOneEditRemove(inputString, outputString);
            }
            // insertion
            else if(inputString.Length-1 == outputString.Length)
            {
                return CheckOneEditRemove(outputString, inputString);
            }

            return false;
        }

        public static bool CheckOneEditRemove(string s1, string s2)
        {
            var index1 = 0;
            var index2 = 0;
            while (index1 < s1.Length && index2 < s2.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2)
                    {
                        return false;
                    }
                    index2++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true;
        }
    }
}
