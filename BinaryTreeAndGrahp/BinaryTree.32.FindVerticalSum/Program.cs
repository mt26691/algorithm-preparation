using System;
using System.Collections.Generic;

namespace BinaryTree._32.FindVerticalSum
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
            FindVerticalSum(binayTree.Root);
            Console.ReadLine();
        }


        public static void FindVerticalSum(BinaryTreeNode<int> rootNode)
        {
            var result = new Dictionary<int, int>();
            CalculateSum(rootNode, 0, result);

            foreach(var item in result)
            {
                Console.WriteLine($"Vertical sum for {item.Key} axis is = {item.Value}");
            }
        }

        public static void CalculateSum(BinaryTreeNode<int> rootNode, int horiztionalLevel, Dictionary<int, int> sumResults)
        {
            if(rootNode == null)
            {
                return;
            }
            if(!sumResults.ContainsKey(horiztionalLevel))
            {
                sumResults.Add(horiztionalLevel, rootNode.Value);
            }
            else
            {
                sumResults[horiztionalLevel] += rootNode.Value;
            }

            CalculateSum(rootNode.Left, horiztionalLevel - 1, sumResults);
            CalculateSum(rootNode.Right, horiztionalLevel + 1, sumResults);
        }
    }
}
