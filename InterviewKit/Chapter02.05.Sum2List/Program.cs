using System;

namespace Chapter02._05.Sum2List
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();

            list.AddLast(6);
            list.AddLast(1);
            list.AddLast(7);

            var addList = new LinkedList();
            addList.AddLast(2);
            addList.AddLast(9);
            addList.AddLast(5);

            var result = list.SumList(addList);
            while(result.Next != null)
            {
                Console.Write(result.Value);
                result = result.Next;
            }

            while(result.Previous != null)
            {
                Console.Write(result.Value);
                result = result.Previous;
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

            public LinkedListNode SumList(LinkedList addList)
            {
                var result = AddList(Last, addList.Last, 0);
                return result;
            }

            private LinkedListNode AddList(LinkedListNode list1, LinkedListNode list2, int carry = 0)
            {
                if (list1 == null && list2 == null && carry == 0)
                {
                    return null;
                }

                var result = new LinkedListNode();
                int value = carry;
                if (list1 != null)
                {
                    value += list1.Value;
                }
                if (list2 != null)
                {
                    value += list2.Value;
                }

                result.Value = value % 10;

                if (list1 != null || list2 != null)
                {
                    var more = AddList(list1.Previous, list2.Previous, value >= 0 ? 1 : 0);
                    result.Next = more;
                }

                return result;
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
