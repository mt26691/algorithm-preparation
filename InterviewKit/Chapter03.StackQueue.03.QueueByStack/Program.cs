using System;
using System.Collections.Generic;

namespace Chapter03.StackQueue._03.QueueByStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> test = new MyQueue<int>();
            test.EnQueue(1);
            test.EnQueue(3);
            test.EnQueue(2);
            Console.WriteLine(test.Dequeue());
            Console.WriteLine(test.Dequeue());
            Console.WriteLine(test.Dequeue());
            Console.WriteLine("Hello World!");
        }

    }

    public class MyQueue<T> where T : IComparable<T>
    {
        Stack<T> newestStack = new Stack<T>();
        Stack<T> latestStack = new Stack<T>();

        private void ShiftStack()
        {
            if (latestStack.Count == 0)
            {
                while (newestStack.Count > 0)
                {
                    latestStack.Push(newestStack.Pop());
                }
            }
        }
        public void EnQueue(T value)
        {
            newestStack.Push(value);
        }

        public T Dequeue()
        {
            ShiftStack();
            return latestStack.Pop();
        }

        public int Count()
        {
            return newestStack.Count + latestStack.Count;
        }
    }
}
