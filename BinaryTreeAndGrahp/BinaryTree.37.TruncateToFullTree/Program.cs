using System;
using System.Collections.Generic;

namespace BinaryTree._37.TruncateToFullTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(0);

            // level 2
            binayTree.Root.Left = new BinaryTreeNode<int>(1);
            binayTree.Root.Right = new BinaryTreeNode<int>(2);

            // level 3
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(3);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(4);

            // level 4
            binayTree.Root.Left.Left.Left = new BinaryTreeNode<int>(5);

            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(7);

            binayTree.LevelOrderTraversal();
            TruncateNode(binayTree.Root);
            binayTree.LevelOrderTraversal();
            Console.ReadLine();
        }


        public static BinaryTreeNode<int> TruncateNode(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return null;
            }

            rootNode.Left = TruncateNode(rootNode.Left);
            rootNode.Right = TruncateNode(rootNode.Right);

            if ((rootNode.Left != null && rootNode.Right != null) || (rootNode.Left == null && rootNode.Right == null))
            {
                return rootNode;
            }

            if(rootNode.Left != null)
            {
                return rootNode.Left;
            }

            return rootNode.Right;

        }
    }
}
