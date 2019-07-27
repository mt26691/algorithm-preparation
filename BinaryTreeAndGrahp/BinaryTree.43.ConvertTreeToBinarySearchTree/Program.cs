using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree._43.ConvertTreeToBinarySearchTree
{
    /// <summary>
    /// https://www.techiedelight.com/convert-binary-tree-to-bst-maintaining-original-structure/?source=post_page---------------------------
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
            convertToBinaryTree(binayTree.Root);
            binayTree.LevelOrderTraversal();
            Console.ReadLine();
        }


        public static void convertToBinaryTree(BinaryTreeNode<int> rootNode)
        {
            var set = new List<int>();
            ExtractData(rootNode, set);
            Console.WriteLine("Hashset data");
            var sortedNodes = set.OrderBy(t => t).ToList();
            foreach (var item in sortedNodes)
            {
                Console.WriteLine(item);
            }

            Convert(rootNode, sortedNodes);
        }


        public static void Convert(BinaryTreeNode<int> root, List<int> sortedNode)
        {
            if (root == null)
            {
                return;
            }
            Convert(root.Left, sortedNode);
            root.Value = sortedNode.FirstOrDefault();
            sortedNode.RemoveAt(0);
            Convert(root.Right, sortedNode);
        }
        public static void ExtractData(BinaryTreeNode<int> rootNode, List<int> set)
        {
            if (rootNode == null)
            {
                return;
            }

            ExtractData(rootNode.Left, set);
            set.Add(rootNode.Value);
            ExtractData(rootNode.Right, set);
        }
    }
}
