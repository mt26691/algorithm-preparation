using System;

namespace BinaryTree._02.PreOrderTraversal
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

            Console.WriteLine("PreorderTraverse");
            binayTree.PreorderTraverse(binayTree.Root);
            Console.WriteLine("End PreorderTraverse");

            Console.WriteLine("InorderTraverse");
            binayTree.InorderTraverse(binayTree.Root);
            Console.WriteLine("End InorderTraverse");

            Console.WriteLine("PostOrderTraverse");
            binayTree.PostOrderTraverse(binayTree.Root);
            Console.WriteLine("End PostOrderTraverse");
            Console.ReadLine();
        }
    }
}
