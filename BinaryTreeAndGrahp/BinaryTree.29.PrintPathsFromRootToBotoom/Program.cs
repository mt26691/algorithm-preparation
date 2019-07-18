using System;
using System.Collections.Generic;

namespace BinaryTree._29.PrintPathsFromRootToBotoom
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

            binayTree.LevelOrderTraversal();

            PrintRootToBotom(binayTree.Root);
            Console.ReadLine();
        }

        public static void PrintRootToBotom<T>(BinaryTreeNode<T> root) where T : IComparable<T>
        {
            var result =  new List<BinaryTreeNode<T>>();
            PreOrderTraversal(root, result);
        }

        public static void PreOrderTraversal<T>(BinaryTreeNode<T> root, List<BinaryTreeNode<T>> result) where T : IComparable<T>
        {
            if (root == null)
            {
                return;
            }

            result.Add(root);

            // if this is leaf node
            if (root.Left == null && root.Right == null)
            {
                // print all from result
                Console.WriteLine("\nPath from root");
                foreach (var item in result)
                {
                    if(item.Left == null && item.Right == null)
                    {
                        Console.Write($"{item.Value}");
                    }
                    else
                    {
                        Console.Write($"{item.Value} -> ");
                    }
                }
            }
            PreOrderTraversal(root.Left, result);
            PreOrderTraversal(root.Right, result);

            if (result.Count > 0)
            {
                result.RemoveAt(result.Count - 1);
            }
        }
    }
}
