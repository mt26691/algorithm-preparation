using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree._21.ConvertTreeToSumTree
{
    /// <summary>
    /// https://www.techiedelight.com/inplace-convert-a-tree-sum-tree/
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

            CalculateSumTree(binayTree.Root);

            binayTree.LevelOrderTraversal();
            Console.ReadLine();
        }

        public static int CalculateSumTree(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = CalculateSumTree(root.Left);

            int right = CalculateSumTree(root.Right);

            if (left != 0 || right != 0)
            {
                root.Value = left + right;
            }

            return root.Value;
        }


        public static void PrintPreOrderTree<T>(BinaryTreeNode<T> root) where T : IComparable<T>
        {
            if (root == null)
            {
                return;
            }

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(root);

            int level = 0;
            while (queue.Count > 0)
            {
                level++;
                int queueCount = queue.Count;
                Console.WriteLine($"Level = {level}");

                while (queueCount-- > 0)
                {
                    var currentNode = queue.Dequeue();
                    Console.Write($"{currentNode.Value} ");
                    if (currentNode.Left != null)
                    {
                        queue.Enqueue(currentNode.Left);
                    }
                    if (currentNode.Right != null)
                    {
                        queue.Enqueue(currentNode.Right);
                    }
                }
                Console.WriteLine();
            }
        }
    }

}
