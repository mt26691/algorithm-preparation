using System;

namespace BinaryTree._55.FindKthElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinarySearchTree<int>(15);

            // level 2
            binayTree.Root.Left = new BinaryTreeNode<int>(10);
            binayTree.Root.Right = new BinaryTreeNode<int>(20);

            // level 3
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(8);
            binayTree.Root.Left.Right = new BinaryTreeNode<int>(12);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(18);
            binayTree.Root.Right.Right = new BinaryTreeNode<int>(25);

            // level 4
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(17);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(19);
            binayTree.Root.Right.Right.Right = new BinaryTreeNode<int>(30);

            binayTree.LevelOrderTraversal();
            Console.WriteLine($"{FindKthSmallest(binayTree.Root, 0, 2)}");
        }

        public static int FindKthSmallest(BinaryTreeNode<int> root, int i, int k)
        {
            if (root == null)
            {
                return int.MaxValue;
            }

            int left = FindKthSmallest(root.Left, i + 1, k);

            if (left != int.MaxValue)
            {
                return left;
            }

            if (i + 1 == k)
            {
                return root.Value;
            }
            return FindKthSmallest(root.Right, i + 1, k);
        }

    }

}
