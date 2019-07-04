using System;
using System.Collections.Generic;

namespace Chapter02._07.IntersectList
{
    class Program
    {
        /// <summary>
        /// If 2 linked lists have intersection, they will have the same tail
        /// You need to check if they are the same tail. And then move forward from starting of the list
        /// to get intersection
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var list1 = new LinkedList();
            var list2 = new LinkedList();

            list1.AddLast(3);
            list1.AddLast(1);
            list1.AddLast(5);
            list1.AddLast(9);

            list2.AddLast(4);
            list2.AddLast(6);

            var node1 = new LinkedListNode(7);
            var node2 = new LinkedListNode(2);
            var node3 = new LinkedListNode(1);

            list1.AddLast(node1);
            list1.AddLast(node2);
            list1.AddLast(node3);

            list2.AddLast(node1);
            list2.AddLast(node2);
            list2.AddLast(node3);

            var result = CheckIntersection(list1, list2);

            foreach (var item in result)
            {
                Console.WriteLine(item.Value);
            }
        }

        public static List<LinkedListNode> CheckIntersection(LinkedList list1, LinkedList list2)
        {
            var tail1 = list1.Last;
            var tail2 = list2.Last;

            if (tail1 != tail2)
            {
                return new List<LinkedListNode>();
            }

            var longerList = list1.Count > list2.Count ? list1 : list2;
            var shorterList = list1.Count > list2.Count ? list2 : list1;

            var shorterHead = shorterList.First;

            var longerHead = longerList.First;
            
            // move longer head forward to sync with shorter head
            for (var i = 0; i < longerList.Count - shorterList.Count; i++)
            {
                longerHead = longerHead.Next;
            }
            while (longerHead != shorterHead)
            {
                longerHead = longerHead.Next;
                shorterHead = shorterHead.Next;
            }
            var result = new List<LinkedListNode>();
            while (shorterHead != null)
            {
                result.Add(shorterHead);
                shorterHead = shorterHead.Next;
            }
            return result;
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

            public LinkedListNode AddLast(LinkedListNode node)
            {
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

            public LinkedList PartitionList(int partValue)
            {
                var node = First;
                var beforeList = new LinkedList();
                var afterList = new LinkedList();
                while (node != null)
                {
                    if (node.Value < partValue)
                    {
                        beforeList.AddLast(node.Value);
                    }
                    else
                    {
                        afterList.AddLast(node.Value);
                    }
                    node = node.Next;
                }
                beforeList.PrintNode();
                afterList.PrintNode();
                beforeList.MergeAfter(afterList);
                return beforeList;
            }

            public void MergeAfter(LinkedList listToMerge)
            {
                if (listToMerge.Count > 0)
                {
                    Last.Next = listToMerge.First;
                    listToMerge.First.Previous = Last;
                    Count += listToMerge.Count;
                }
            }

            public bool IsPalidrome()
            {
                var head = First;
                var tail = Last;

                while (head != null && tail != null)
                {
                    if (head.Value != tail.Value)
                    {
                        return false;
                    }

                    // one for even number one for odd number
                    if (head.Next == tail || head == tail)
                    {
                        return true;
                    }

                    head = head.Next;
                    tail = tail.Previous;
                }

                return false;
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

            public LinkedListNode()
            {

            }
        }

    }

}
