using System;

namespace BinaryTree._25.IsSymetricTree
{
    /// <summary>
    /// https://www.techiedelight.com/check-given-binary-tree-symmetric-structure-not/
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

            binayTree.LevelOrderTraversal();
            Console.WriteLine(IsSymetric(binayTree.Root.Left, binayTree.Root.Right));
            Console.WriteLine("-------------------");
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(8);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(9);

            // level 4
            binayTree.LevelOrderTraversal();
            Console.WriteLine(IsSymetric(binayTree.Root.Left, binayTree.Root.Right));
            Console.ReadLine();
        }

        public static bool IsSymetric(BinaryTreeNode<int> leftNode, BinaryTreeNode<int> rightNode)
        {
            if(rightNode == null && leftNode == null)
            {
                return true;
            }

            return (leftNode != null && rightNode != null) 
                && IsSymetric(leftNode.Left, rightNode.Right)
                && IsSymetric(leftNode.Right, rightNode.Left);
        }

    }

}
