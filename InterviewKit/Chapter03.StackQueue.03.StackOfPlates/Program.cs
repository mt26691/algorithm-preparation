using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter03.StackQueue._03.StackOfPlates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class SetOfStack<T> where T : IComparable<T>
    {
        private List<Stack<T>> stacks = new List<Stack<T>>();

        private Stack<T> lastStack;
        private Stack<T> firstStack;

        private int defaultCapacity = 5;
        public SetOfStack()
        {
            lastStack = new Stack<T>();
            firstStack = lastStack;
            stacks = new List<Stack<T>>();
            stacks.Add(lastStack);
        }

        public void Push(T value)
        {
            if(IsFullLastStack())
            {
                lastStack = new Stack<T>();
                lastStack.Push(value);
                stacks.Add(lastStack);
                return;
            }

            lastStack.Push(value);
        }

        public T Pop()
        {
            if(lastStack.Count == 0)
            {
                stacks.Remove(lastStack);
                lastStack = stacks.Last();
            }

            var item = lastStack.Pop();

            return item;
        }

        public T PopAt(int index)
        {
            var currentStack = stacks[index];
            return currentStack.Pop();
        }

        private bool IsFullLastStack()
        {
            return lastStack.Count == defaultCapacity;
        }
    }
}
