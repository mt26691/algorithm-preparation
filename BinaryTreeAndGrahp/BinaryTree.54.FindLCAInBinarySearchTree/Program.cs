using System;

namespace BinaryTree._54.FindLCAInBinarySearchTree
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
            var node = FindLCA(binayTree.Root, 17, 20);
            Console.WriteLine($"Loweest common ancestor of 17 and 20 is {node.Value}");
        }

        public static BinaryTreeNode<int> FindMaximumNode(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return null;
            }

            while (root.Right != null)
            {
                root = root.Right;
            }

            return root;
        }

        public static bool IsPresentValue(BinaryTreeNode<int> root, int value)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Value == value)
            {
                return true;
            }

            if (root.Value > value)
            {
                return IsPresentValue(root.Left, value);
            }

            return IsPresentValue(root.Right, value);
        }

        public static BinaryTreeNode<int> FindLCA(BinaryTreeNode<int> root, int value1, int value2)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Value > Math.Max(value1, value2))
            {
                // on the left
                return FindLCA(root.Left, value1, value2);
            }
            else if (root.Value < Math.Min(value1, value2))
            {
                // on the right
                return FindLCA(root.Right, value1, value2);
            }
            else
            {
                if (IsPresentValue(root, value1) && IsPresentValue(root, value2))
                {
                    return root;
                }
                return null;
            }
        }
    }

}
