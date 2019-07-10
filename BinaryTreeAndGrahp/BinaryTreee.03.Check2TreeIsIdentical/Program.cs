using BinaryTree;
using System;

namespace BinaryTreee._03.Check2TreeIsIdentical
{
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(5);

            binayTree.Root.Left = new BinaryTreeNode<int>(4);
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(2);
            binayTree.Root.Left.Right = new BinaryTreeNode<int>(1);

            binayTree.Root.Right = new BinaryTreeNode<int>(3);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(9);
            binayTree.Root.Right.Right = new BinaryTreeNode<int>(8);

            var binayTree1 = new BinaryTree<int>(5);
            binayTree1.Root.Left = new BinaryTreeNode<int>(4);
            binayTree1.Root.Left.Left = new BinaryTreeNode<int>(2);
            binayTree1.Root.Left.Right = new BinaryTreeNode<int>(1);

            binayTree1.Root.Right = new BinaryTreeNode<int>(3);
            binayTree1.Root.Right.Left = new BinaryTreeNode<int>(9);
            binayTree1.Root.Right.Right = new BinaryTreeNode<int>(8);

            Console.WriteLine(IsIdentical(binayTree.Root, binayTree1.Root));
            Console.ReadLine();
        }

        public static bool IsIdentical(BinaryTreeNode<int> node1, BinaryTreeNode<int> node2)
        {
            if(node1 == null && node2 == null)
            {
                return true;
            }

            if(node1 == null || node2 == null)
            {
                return false;
            }

            return node1.Value == node2.Value
                && IsIdentical(node1.Left, node2.Left) && IsIdentical(node1.Right, node2.Right);
        }
    }
}
