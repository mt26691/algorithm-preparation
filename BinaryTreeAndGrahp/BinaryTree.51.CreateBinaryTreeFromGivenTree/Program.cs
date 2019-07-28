using System;
using System.Linq;

namespace BinaryTree._51.CreateBinaryTreeFromGivenTree
{
    /// <summary>
    /// https://www.techiedelight.com/search-given-key-in-bst/?source=post_page---------------------------
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode<int> root = null;
            var keys = new int[] { 15, 10, 20, 8, 12, 18, 25 };
            keys = keys.OrderBy(t => t).ToArray();

            root = CreateTree(keys, 0, keys.Length - 1, root);

            root.LevelOrderTraversal();
        }

        public static BinaryTreeNode<int> CreateTree(int[] givenSortedKeys, int low, int high, BinaryTreeNode<int> root)
        {
            if (low > high)
            {
                return root;
            }

            int mid = (low + high) / 2;

            root = new BinaryTreeNode<int>(givenSortedKeys[mid]);

            root.Left = CreateTree(givenSortedKeys, low, mid - 1, root.Left);

            root.Right = CreateTree(givenSortedKeys, mid + 1, high, root.Right);

            return root;
        }

    }
}
