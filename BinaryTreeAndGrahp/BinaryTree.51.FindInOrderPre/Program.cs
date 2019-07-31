using System;

namespace BinaryTree._51.FindInOrderPre
{
    /// <summary>
    /// https://www.techiedelight.com/find-inorder-predecessor-given-key-bst/?source=post_page---------------------------
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
            var result = FindPredecessor(binayTree.Root, null, 18);

            Console.WriteLine(result.Value);
        }

        public static BinaryTreeNode<int> FindMaximumNode(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return null;
            }

            while (root.Right != null)
            {
                root = root.Right;
            }

            return root;
        }

        public static BinaryTreeNode<int> FindPredecessor(BinaryTreeNode<int> root, BinaryTreeNode<int> result, int key)
        {
            if (root == null)
            {
                return result;
            }

            if (root.Value == key)
            {
                if (root.Left != null)
                {
                    return FindMaximumNode(root.Left);
                }
            }
            else if (root.Value > key)
            {
                return FindPredecessor(root.Left, result, key);
            }
            else
            {
                result = root;
                return FindPredecessor(root.Right, result, key);
            }
            return result;
        }
    }
}
