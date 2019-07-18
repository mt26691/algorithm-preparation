using System;
using System.Collections.Generic;

namespace BinaryTree._31.FindDistanceBetweenNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(1);

            // level 2
            binayTree.Root.Left = new BinaryTreeNode<int>(2);
            binayTree.Root.Right = new BinaryTreeNode<int>(3);

            // level 3
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(4);
            binayTree.Root.Left.Right = new BinaryTreeNode<int>(5);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Right = new BinaryTreeNode<int>(7);

            // level 4
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(8);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(9);

            binayTree.LevelOrderTraversal();
            FindDistanceBetweenNode(binayTree.Root, binayTree.Root.Left, binayTree.Root.Right.Left.Left);
            FindDistanceBetweenNode(binayTree.Root, binayTree.Root.Right.Left.Right, binayTree.Root.Right.Left.Left);
            FindDistanceBetweenNode(binayTree.Root, binayTree.Root.Right.Left.Right, binayTree.Root.Right.Left.Right);
            Console.ReadLine();
        }

        public static void FindDistanceBetweenNode<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> firstNode, BinaryTreeNode<T> secondNode) where T:IComparable<T>
        {
            // find cla
            BinaryTreeNode<T> result = null;

            FindLCA(root, firstNode, secondNode, ref result);

            if(result == null)
            {
                Console.WriteLine("Can't detect the distance");
            }
            else
            {
                // find distance between level
                var firstLevel = CalculateLevel(result, firstNode, 0);
                var secondLevel = CalculateLevel(result, secondNode, 0);

                Console.WriteLine($"Distance between {firstNode.Value} and {secondNode.Value} is {firstLevel + secondLevel}");
            }
        }
        
        public static int CalculateLevel<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> nodeToCheck, int level) where T:IComparable<T>
        {
            if(root == null || nodeToCheck == null)
            {
                return 0;
            }

            if(root == nodeToCheck)
            {
                return level;
            }

            int leftLevel = CalculateLevel(root.Left, nodeToCheck, level + 1);
            int rightLevel = CalculateLevel(root.Right, nodeToCheck, level + 1);

            return Math.Max(leftLevel, rightLevel);
        }
        public static bool FindLCA<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> firstNode, 
            BinaryTreeNode<T> secondNode, ref BinaryTreeNode<T> result) where T : IComparable<T>
        {
            if(root == null)
            {
                return false;
            }

            if(root == firstNode || root == secondNode)
            {
                return true;
            }

            var leftCheck = FindLCA(root.Left, firstNode, secondNode, ref result);
            var rightCheck = FindLCA(root.Right, firstNode, secondNode, ref result);

            if(leftCheck && rightCheck)
            {
                result = root;
            }

            return leftCheck || rightCheck;
        }

        public static bool IsPresentInTree<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> nodeToCheck) where T : IComparable<T>
        {
            if (root == null)
            {
                return false;
            }

            if (root == nodeToCheck)
            {
                return true;
            }

            return IsPresentInTree(root.Left, nodeToCheck) || IsPresentInTree(root.Right, nodeToCheck);
        }
    }

}
