using System;
using System.Collections.Generic;

namespace BinaryTree._12.PrintNodeTopDown
{
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(1);

            // level 2
            binayTree.Root.Left = new BinaryTreeNode<int>(2);
            binayTree.Root.Right = new BinaryTreeNode<int>(3);

            // level 3
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(4);
            binayTree.Root.Left.Right = new BinaryTreeNode<int>(5);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Right = new BinaryTreeNode<int>(7);
            // level 4
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(8);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(9);

            PrintTopDown(binayTree.Root);

            Console.ReadLine();
        }

        public static void PrintTopDown<T>(BinaryTreeNode<T> root) where T : IComparable<T>
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine($"Travel to {root.Value}");
            if (root.Left == null && root.Right == null)
            {
                return;
            }

            var leftQueue = new Queue<BinaryTreeNode<T>>();
            leftQueue.Enqueue(root.Left);

            var rightQueue = new Queue<BinaryTreeNode<T>>();
            rightQueue.Enqueue(root.Right);

            while (true)
            {
                if (leftQueue.Count == 0 && rightQueue.Count == 0)
                {
                    break;
                }

                if (leftQueue.Count > 0)
                {
                    var leftNode = leftQueue.Dequeue();

                    if (leftNode != null)
                    {
                        Console.WriteLine($"Travel to {leftNode.Value}");
                        if (leftNode.Left != null)
                        {
                            leftQueue.Enqueue(leftNode.Left);
                        }
                        if (leftNode.Right != null)
                        {
                            leftQueue.Enqueue(leftNode.Right);
                        }
                    }
                }
                if (rightQueue.Count > 0)
                {
                    var rightNode = rightQueue.Dequeue();

                    if (rightNode != null)
                    {
                        Console.WriteLine($"Travel to {rightNode.Value}");
                        if (rightNode.Right != null)
                        {
                            rightQueue.Enqueue(rightNode.Right);
                        }
                        if (rightNode.Left != null)
                        {
                            rightQueue.Enqueue(rightNode.Left);
                        }
                    }
                }
            }
        }
    }
}
