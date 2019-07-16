using System;
using System.Collections.Generic;

namespace BinaryTree._23.CheckIfGivenTreeIsASubTree
{
    /// <summary>
    /// https://www.techiedelight.com/determine-given-binary-tree-is-subtree-of-another-binary-tree-not/
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

            var checkTree = new BinaryTree<int>(1);

            // level 2
            checkTree.Root.Left = new BinaryTreeNode<int>(5);
            checkTree.Root.Left = new BinaryTreeNode<int>(5);
            checkTree.Root.Right = new BinaryTreeNode<int>(7);

            IsSubTree(binayTree.Root, binayTree.Root.Right);
            IsSubTree(binayTree.Root.Right, binayTree.Root);
            IsSubTree(binayTree.Root.Right, checkTree.Root);
            Console.ReadLine();
        }

        public static void IsSubTree(BinaryTreeNode<int> firstTree, BinaryTreeNode<int> givenTree)
        {
            var firstTreeOrder = new List<int>();
            InOrderTraversal(firstTree, firstTreeOrder);
            Console.WriteLine();
            var secondTreeOrder = new List<int>();
            InOrderTraversal(givenTree, secondTreeOrder);

            var longerList = firstTreeOrder.Count > secondTreeOrder.Count ? firstTreeOrder : secondTreeOrder;
            var smallerList = longerList == firstTreeOrder ? secondTreeOrder : firstTreeOrder;

            var indexOfFirst = longerList.IndexOf(smallerList[0]);
            if (indexOfFirst == -1)
            {
                Console.WriteLine("They are not a subtree of each other");
                return;
            }

            var firstString = string.Join("", longerList);

            var secondString = string.Join("", smallerList);

            if(firstString.IndexOf(secondString) == -1)
            {
                Console.WriteLine("They are not a subtree of each other");
                return;
            }

            if(firstTreeOrder.Count > secondTreeOrder.Count)
            {
                Console.WriteLine("Second tree is sub tree of first tree");
            }
            else
            {
                Console.WriteLine("First tree is sub tree of second tree");
            }
        }

        public static void InOrderTraversal(BinaryTreeNode<int> root, List<int> results)
        {
            if (root == null)
            {
                return;
            }
            InOrderTraversal(root.Left, results);
            results.Add(root.Value);
            InOrderTraversal(root.Right, results);
        }

    }
}
