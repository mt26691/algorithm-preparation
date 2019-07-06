using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter03.StackQueue._02.StackWithMin
{
    class Program
    {
        static void Main(string[] args)
        {
            StackWithMin<int> stack = new StackWithMin<int>();
            stack.Push(5);
            stack.Push(4);
            stack.Push(6);
            stack.Push(7);
            Console.WriteLine(stack.Min);
            Console.WriteLine(stack.Max);
            Console.WriteLine("Hello World!");
        }
    }

    public class StackWithMin<T> where T : IComparable<T>
    {
        private List<T> stackValues = new List<T>();

        public T Min { get; private set; }

        public T Max { get; private set; }

        public int Count { get { return stackValues.Count; } }
        public StackWithMin()
        {

        }

        public T Pop()
        {
            if (stackValues.Count > 0)
            {
                var returnedData = stackValues[0];
                stackValues.RemoveAt(0);
                return returnedData;
            }
            throw new IndexOutOfRangeException();
        }


        public T Push(T value)
        {
            if (Count == 0)
            {
                Min = value;
                Max = value;
            }
            if (value.CompareTo(Min) <= 0)
            {
                Min = value;
            }

            if (value.CompareTo(Max) >= 0)
            {
                Max = value;
            }

            stackValues.Add(value);
            return value;
        }
    }
}
