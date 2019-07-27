using System;

namespace BinaryTree._49.FindMaxDiffBetweenDecentdantAndChild
{
    /// <summary>
    /// https://www.techiedelight.com/find-maximum-difference-node-descendants/?source=post_page---------------------------
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(100);

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
            var value = int.MaxValue;
            FindDiff(binayTree.Root, ref value);
            Console.WriteLine($"Min value = {value}");
            Console.ReadLine();
        }

        public static void FindDiff(BinaryTreeNode<int> rootNode, ref int minValue)
        {
            if (rootNode == null)
            {
                return;
            }

            var value = rootNode.Value;

            if (value < minValue)
            {
                minValue = value;
            }

            FindDiff(rootNode.Left, ref minValue);
            FindDiff(rootNode.Right, ref minValue);
        }

    }
}
