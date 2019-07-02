using System;
using System.Collections.Generic;

namespace Chapter02._01.RemoveDuplicateNode
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

            for (int i = 0; i < 10; i++)
            {
                list.AddLast(i);
            }

            PrintNode(list);
            var result = RemoveDuplicate(list);
            PrintNode(result);
            Console.ReadLine();
        }

        public static LinkedList<int> RemoveDuplicate(LinkedList<int> inputList)
        {
            var set = new HashSet<int>();
            var currentNode = inputList.First;
            
            while (currentNode != null)
            {
                if (set.Contains(currentNode.Value))
                {
                    var nextNode = currentNode.Next;
                    inputList.Remove(currentNode);
                    currentNode = nextNode;
                }
                else
                {
                    set.Add(currentNode.Value);
                    currentNode = currentNode.Next;
                }
            }

            return inputList;
        }

        public static void PrintNode(LinkedList<int> inputList)
        {
            var head = inputList.First;
            while(head != null)
            {
                Console.Write(head.Value + ", ");
                head = head.Next;
            }
            Console.WriteLine();
        }
    }
}
