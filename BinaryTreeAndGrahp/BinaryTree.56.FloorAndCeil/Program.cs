using System;

namespace BinaryTree._56.FloorAndCeil
{
    /// <summary>
    /// https://www.techiedelight.com/floor-ceil-bst-iterative-recursive/?source=post_page---------------------------
    /// </summary>
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
            FindFloorAndCeil(binayTree.Root, 29, int.MinValue, int.MaxValue);
        }

        public static void FindFloorAndCeil(BinaryTreeNode<int> root, int searchValue, int floor, int ceil)
        {
            if (root == null)
            {
                if (floor != int.MinValue)
                {
                    Console.WriteLine($"Floor value = {floor}");
                }
                if (ceil != int.MaxValue)
                {
                    Console.WriteLine($"Ceil value = {ceil}");
                }
                return;
            }
            if (root.Value == searchValue)
            {
                Console.WriteLine($"Floor and ceil value = {searchValue}");
                return;
            }

            if (root.Value > searchValue)
            {
                FindFloorAndCeil(root.Left, searchValue, floor, root.Value);
            }
            else
            {
                FindFloorAndCeil(root.Right, searchValue, root.Value, ceil);
            }
        }
    }
}
