using System;

namespace BinaryTree._26.ConvertToMirror
{
    /// <summary>
    /// https://www.techiedelight.com/convert-binary-tree-to-its-mirror/
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

            ConvertToMirror(binayTree.Root);

            binayTree.LevelOrderTraversal();

            Console.ReadLine();
        }

        public static void ConvertToMirror(BinaryTreeNode<int> rootNode)
        {
            if(rootNode == null)
            {
                return;
            }

            ConvertToMirror(rootNode.Left);
            ConvertToMirror(rootNode.Right);

            var rightNode = rootNode.Right;
            rootNode.Right = rootNode.Left;
            rootNode.Left = rightNode;
        }

    }
}
