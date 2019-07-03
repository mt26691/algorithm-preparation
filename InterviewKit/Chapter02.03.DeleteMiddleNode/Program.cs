using System;
using System.Collections.Generic;

namespace Chapter02._03.DeleteMiddleNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            
            for (int i = 10; i < 20; i++)
            {
                list.AddLast(i);
            }
            for (int i = 1; i < 10; i++)
            {
                list.AddFirst(i);
            }
            var middleNode = GetMiddleNode(list.First, 4);
            Console.WriteLine(middleNode.Value);
            list.PrintNode();
            list.DeleteNode(middleNode);
            list.PrintNode();
            list.DeleteNode(list.First);
            list.PrintNode();
            Console.ReadLine();
        }

        public static LinkedListNode GetMiddleNode(LinkedListNode head, int k)
        {
            for (int i = 0; i < k; i++)
            {
                if (head.Next == null)
                {
                    return null;
                }
                head = head.Next;
            }

            return head;
        }

        public static void DeleteMiddleNode(LinkedListNode<int> middleNode)
        {
            // point previous to next
            if (middleNode == null)
            {
                return;
            }
        }
    }

    public class LinkedList
    {

        public LinkedListNode First { get; set; }

        public LinkedListNode Last { get; set; }

        public int Count { get; private set; } = 0;
        public LinkedList()
        {
            First = null;
            Last = null;
        }

        public LinkedListNode AddFirst(int value)
        {
            var node = new LinkedListNode(value);
            if (First == null)
            {
                First = node;
                if (Last == null)
                {
                    Last = node;
                }
            }
            else
            { 
                First.Previous = node;
                node.Next = First;
                First = node;
            }
            Count++;
            return node;
        }

        public LinkedListNode AddLast(int value)
        {
            var node = new LinkedListNode(value);
            if (Last == null)
            {
                Last = node;
                if (First == null)
                {
                    First = node;
                }
            }
            else
            {
                Last.Next = node;
                node.Previous = Last;
                Last = node;
            }
            Count++;
            return node;
        }

        public void DeleteNode(LinkedListNode node)
        {
            if (node == null)
            {
                return;
            }
            // if this is first node
            if (node.Previous == null)
            {
                First = node.Next;
            }

            // if this is last node
            if (node.Next == null)
            {
                Last = node.Previous;
            }

            if (node.Previous != null && node.Next != null)
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }

            Count--;
        }

        public void PrintNode()
        {
            var head = First;
            while (head != null)
            {
                Console.Write(head.Value + ", ");
                head = head.Next;
            }
            Console.WriteLine();
        }
    }

    public class LinkedListNode
    {
        public int Value { get; set; }

        public LinkedListNode Next { get; set; }

        public LinkedListNode Previous { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }
    }
}
