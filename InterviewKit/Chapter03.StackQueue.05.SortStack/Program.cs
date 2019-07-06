using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter03.StackQueue._05.SortStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(3);
            stack.Push(9);
            stack.Push(5);
            stack.Push(7);

            var sorted = SortStack(stack);
            Console.WriteLine(sorted.Pop());
            Console.WriteLine(sorted.Pop());
            Console.WriteLine(sorted.Pop());
            Console.WriteLine(sorted.Pop());
            Console.WriteLine("Hello World!");
        }

        public static Stack<int> SortStack(Stack<int> inputStack)
        {
            var tempStack = new Stack<int>();
            while (inputStack.Count > 0)
            {
                int temp = inputStack.Pop();
                while (tempStack.Count > 0 && tempStack.Peek() > temp)
                {
                    inputStack.Push(tempStack.Pop());
                }
                tempStack.Push(temp);
            }

            while(tempStack.Count>0)
            {
                inputStack.Push(tempStack.Pop());
            }

            return inputStack;
        }
    }
}
