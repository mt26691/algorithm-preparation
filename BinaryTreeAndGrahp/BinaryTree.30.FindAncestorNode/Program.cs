using System;
using System.Collections.Generic;

namespace BinaryTree._30.FindAncestorNode
{
    /// <summary>
    /// https://www.techiedelight.com/find-ancestors-of-given-node-binary-tree/?source=post_page---------------------------
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

            binayTree.LevelOrderTraversal();

            FindAncestorNode(binayTree.Root, binayTree.Root.Right.Left.Left);
            Console.ReadLine();
        }


        public static void FindAncestorNode<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> nodeToCheck) where T:IComparable<T>
        {
            if(root == null)
            {
                return;
            }

            if(IsPresentInTree(root, nodeToCheck) && root != nodeToCheck)
            {
                Console.WriteLine($"Ancestor of {nodeToCheck.Value} is {root.Value}");
            }

            FindAncestorNode(root.Left, nodeToCheck);
            FindAncestorNode(root.Right, nodeToCheck);
        }

        public static bool IsPresentInTree<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> nodeToCheck) where T : IComparable<T>
        {
            if(root == null)
            {
                return false;
            }

            if(root == nodeToCheck)
            {
                return true;
            }

            return IsPresentInTree(root.Left, nodeToCheck) || IsPresentInTree(root.Right, nodeToCheck);
        }
        public static void PrintRootToBotom<T>(BinaryTreeNode<T> root) where T : IComparable<T>
        {
            var result = new List<BinaryTreeNode<T>>();
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
                    if (item.Left == null && item.Right == null)
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
