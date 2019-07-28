using System;
using System.Linq;

namespace BinaryTree._52.DeleteANode
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeNode<int> root = null;
            var keys = new int[] { 15, 10, 20, 8, 12, 18, 25 };
            keys = keys.OrderBy(t => t).ToArray();

            root = CreateTree(keys, 0, keys.Length - 1, root);

            root.LevelOrderTraversal();
            Console.WriteLine("--------------------");
            DeleteNode(root, 20);
            root.LevelOrderTraversal();
            Console.WriteLine("--------------------");
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


        public static void DeleteNode(BinaryTreeNode<int> root, int value)
        {
            if (root == null)
            {
                return;
            }

            var currentNode = root;
            BinaryTreeNode<int> parent = null;
            while (currentNode.Value != value)
            {
                if (currentNode.Value > value && currentNode.Left != null)
                {
                    parent = currentNode;
                    currentNode = currentNode.Left;
                }
                else if (currentNode.Value < value && currentNode.Right != null)
                {
                    parent = currentNode;
                    currentNode = currentNode.Right;
                }
                else
                {
                    return;
                }
            }

            // if this is the leaf node
            if(currentNode.Left == null && currentNode.Right == null)
            {
                if(parent.Left == currentNode)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            // if current node has only one child
            else if (currentNode.Left == null && currentNode.Right != null)
            {
                if(parent.Left == currentNode)
                {
                    parent.Left = currentNode.Right;
                }
                else
                {
                    parent.Right = currentNode.Right;
                }
            }
            // if current node has only one child
            else if(currentNode.Left != null && currentNode.Right == null)
            {
                if(parent.Left == currentNode)
                {
                    parent.Left = currentNode.Left;
                }
                else
                {
                    parent.Right = currentNode.Left;
                }
            }
            else
            {
                var minRightNode = FindMinimumNode(currentNode.Right);

                var rightValue = minRightNode.Value;

                DeleteNode(root, rightValue);
                currentNode.Value = rightValue;
            }
        }

        public static BinaryTreeNode<int> FindMinimumNode(BinaryTreeNode<int> root)
        {
            while(root.Left != null)
            {
                root = root.Left;
            }
            return root;
        }
    }
}
