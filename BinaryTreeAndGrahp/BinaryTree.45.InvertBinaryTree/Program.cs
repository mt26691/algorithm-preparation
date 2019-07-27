using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree._45.InvertBinaryTree
{
    /// <summary>
    /// https://www.techiedelight.com/invert-binary-tree-recursive-iterative/?source=post_page---------------------------
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
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(4);

            // level 4
            binayTree.Root.Left.Left.Left = new BinaryTreeNode<int>(9);

            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(7);

            binayTree.LevelOrderTraversal();
            Console.WriteLine("---------");
            InvertTree(binayTree.Root);
            binayTree.LevelOrderTraversal();
            Console.ReadLine();
        }

        public static void InvertTree(BinaryTreeNode<int> rootNode)
        {
            if(rootNode == null)
            {
                return;
            }

            var leftNode = rootNode.Left;
            rootNode.Left = rootNode.Right;
            rootNode.Right = leftNode;

            InvertTree(rootNode.Left);
            InvertTree(rootNode.Right);
        }
    }

}
