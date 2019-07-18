using System;

namespace BinaryTree._27.DetermineIfBinaryTreeCanbeConverted
{
    /// <summary>
    /// https://www.techiedelight.com/determine-binary-tree-can-converted-another-number-swaps-left-right-child/
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

            binayTree.LevelOrderTraversal();
            Console.WriteLine(CanBeConverted(binayTree.Root.Right.Left, binayTree.Root.Right.Left));
            Console.ReadLine();
        }

        public static bool CanBeConverted(BinaryTreeNode<int> firstTree, BinaryTreeNode<int>  secondTree)
        {
            if(firstTree == null && secondTree == null)
            {
                return true;
            }

            return (firstTree != null && secondTree != null) &&
                (firstTree.Value == secondTree.Value)
                && (CanBeConverted(firstTree.Left, secondTree.Left)
                && CanBeConverted(firstTree.Right, secondTree.Right) 
                || (CanBeConverted(firstTree.Left, secondTree.Right)
                && CanBeConverted(firstTree.Right, secondTree.Left)));
        }

    }

}
