using System;
using System.Collections.Generic;

namespace Chapter02._02.KthToLastElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddLast(i);
            }

            PrintKthToLast(list.First, 4);
        }

        public static void PrintKthToLast(LinkedListNode<int> head, int k)
        {
            for (int i = 0; i < k; i++)
            {
                if (head.Next == null)
                {
                    return;
                }
                head = head.Next;
            }

            while(head != null)
            {
                Console.WriteLine(head.Value);
                head = head.Next;
            }
        }

    }
}
