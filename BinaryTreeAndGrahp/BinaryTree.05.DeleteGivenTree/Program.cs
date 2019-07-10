using System;

namespace BinaryTree._05.DeleteGivenTree
{
    /// <summary>
    /// https://www.techiedelight.com/delete-given-binary-tree-iterative-recursive/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(5);

            binayTree.Root.Left = new BinaryTreeNode<int>(4);
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(2);
            binayTree.Root.Left.Right = new BinaryTreeNode<int>(1);

            binayTree.Root.Right = new BinaryTreeNode<int>(3);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(9);
            binayTree.Root.Right.Right = new BinaryTreeNode<int>(8);

            binayTree.Root.Right.Right.Left = new BinaryTreeNode<int>(8);
            DeleteTree(binayTree.Root);
            Console.ReadLine();
        }
        
        public static void DeleteTree(BinaryTreeNode<int> rootNode)
        {
            if(rootNode == null)
            {
                return;
            }

            DeleteTree(rootNode.Left);
            DeleteTree(rootNode.Right);
            Console.WriteLine($"Delete node with value = {rootNode.Value}");
            rootNode = null;
        }
    }
}
