using System;
using System.Collections.Generic;

namespace BinaryTree._13.PrintLeftViewOfTree
{
    /// <summary>
    /// https://www.techiedelight.com/print-left-view-of-binary-tree/
    /// </summary>
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

            PrintLeftView(binayTree.Root);

            Console.ReadLine();
        }

        public static void PrintLeftView<T>(BinaryTreeNode<T> root) where T : IComparable<T>
        {
            if (root == null)
            {
                return;
            }

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(root);
            var level = 1;
            while (queue.Count > 0)
            {
                var firstNode = false;
                var currentLevelNodeCount = queue.Count;

                while (currentLevelNodeCount-- > 0)
                {
                    var node = queue.Dequeue();
                    if (!firstNode)
                    {
                        firstNode = true;
                        Console.WriteLine($"First node of current level({level}) = {node.Value}");
                    }

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
                level++;
            }
        }
    }
}
