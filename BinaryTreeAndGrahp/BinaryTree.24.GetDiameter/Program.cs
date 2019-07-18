using System;
using System.Collections.Generic;

namespace BinaryTree._24.GetDiameter
{
    /// <summary>
    /// https://www.techiedelight.com/find-diameter-of-a-binary-tree/
    /// </summary>
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


            var checkTree = new BinaryTree<int>(1);

            // level 2
            checkTree.Root.Left = new BinaryTreeNode<int>(5);
            checkTree.Root.Left = new BinaryTreeNode<int>(5);
            checkTree.Root.Right = new BinaryTreeNode<int>(7);

            var result = new Diameter();

            GetDiameter(binayTree.Root, result);
            Console.WriteLine(result.Value);
            binayTree.LevelOrderTraversal();

            result = new Diameter();
            GetDiameter(binayTree.Root.Right, result);
            Console.WriteLine(result.Value);

            Console.ReadLine();
        }

        public class Diameter
        {
            public int Value { get; set; }
        }
        public static int GetDiameter(BinaryTreeNode<int> root, Diameter result)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = GetDiameter(root.Left, result);
            int rightHeight = GetDiameter(root.Right, result);

            int maxDimeter = leftHeight + rightHeight + 1;

            if (result.Value < maxDimeter)
            {
                result.Value = maxDimeter;
            }

            return Math.Max(leftHeight, rightHeight) + 1;
        }

    }
}
