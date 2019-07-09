using System;

namespace BinaryTree._02.PreOrderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(5);

            binayTree.Root.Left = new BinaryTreeNode<int>(4);
            binayTree.Root.Right = new BinaryTreeNode<int>(3);
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(2);
            binayTree.Root.Left.Right = new BinaryTreeNode<int>(1);
            binayTree.InorderTraverse(binayTree.Root);
            Console.ReadLine();
        }
    }
}
