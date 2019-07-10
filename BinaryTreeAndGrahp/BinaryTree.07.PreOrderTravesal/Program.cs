using System;

namespace BinaryTree._07.PreOrderTravesal
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

            binayTree.Root.Right.Right.Left = new BinaryTreeNode<int>(7);
            binayTree.Root.Right.Right.Right = new BinaryTreeNode<int>(6);
            PreOrderTraverse(binayTree.Root);
            Console.ReadLine();
        }

        public static void PreOrderTraverse<T>(BinaryTreeNode<T> rootNode) where T : IComparable<T>
        {
            if (rootNode == null)
            {
                return;
            }
            Console.WriteLine($"Travel to {rootNode.Value}");
            PreOrderTraverse(rootNode.Left);
            PreOrderTraverse(rootNode.Right);
        }
    }
}
