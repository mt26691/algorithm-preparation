using System;

namespace BinaryTree._50.SearchInBinaryTree
{

    /// <summary>
    /// https://www.techiedelight.com/search-given-key-in-bst/?source=post_page---------------------------
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
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(18);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(19);
            binayTree.Root.Right.Right.Right = new BinaryTreeNode<int>(30);

            binayTree.LevelOrderTraversal();
            var data = FindData(binayTree.Root, 31);
            if(data != null)
            {
                Console.WriteLine($"Result = {data.Value}");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        public static BinaryTreeNode<int> FindData(BinaryTreeNode<int> root, int value)
        {
            if (root == null)
            {
                return null;
            }

            var currentNode = root;
            while (true)
            {
                if (currentNode.Value == value)
                {
                    return currentNode;
                }
                if (currentNode.Value < value && currentNode.Right != null)
                {
                    currentNode = currentNode.Right;
                }
                else if (currentNode.Value > value && currentNode.Left != null)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    return null;
                }

            }
        }

    }
}
