using System;
using System.Collections.Generic;

namespace BinaryTree._48.CountSubTree
{

    /// <summary>
    /// https://www.techiedelight.com/count-subtrees-value-nodes-binary-tree/?source=post_page---------------------------
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(0);

            // level 2
            binayTree.Root.Left = new BinaryTreeNode<int>(1);
            binayTree.Root.Right = new BinaryTreeNode<int>(2);

            // level 3
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(6);

            // level 4
            binayTree.Root.Left.Left.Left = new BinaryTreeNode<int>(9);
            binayTree.Root.Left.Left.Right = new BinaryTreeNode<int>(9);
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(6);

            binayTree.LevelOrderTraversal();
            Console.WriteLine("---------");
            FindSubTree(binayTree.Root);
            Console.ReadLine();
        }

        public static void FindSubTree(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return;
            }

            var value = rootNode.Value;

            if (IsRightTree(rootNode, value))
            {
                Console.WriteLine($"This tree contains same value");
                rootNode.LevelOrderTraversal();
                Console.WriteLine("-----------------------");
            }
            FindSubTree(rootNode.Left);
            FindSubTree(rootNode.Right);
        }

        public static bool IsRightTree(BinaryTreeNode<int> root, int value)
        {
            if (root == null)
            {
                return true;
            }
            return root.Value == value
                && IsRightTree(root.Left, value)
                && IsRightTree(root.Right, value);
        }
    }
}
