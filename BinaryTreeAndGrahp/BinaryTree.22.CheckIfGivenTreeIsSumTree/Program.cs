using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree._22.CheckIfGivenTreeIsSumTree
{

    /// <summary>
    /// https://www.techiedelight.com/check-given-binary-tree-sum-tree-not/
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

            IsSumTree(binayTree.Root);
            CalculateSumTree(binayTree.Root);
            IsSumTree(binayTree.Root);
            binayTree.LevelOrderTraversal();

            Console.ReadLine();
        }

        public static bool IsSumTree(BinaryTreeNode<int> root)
        {

            if (root == null)
            {
                return false;
            }

            var queue = new Queue<BinaryTreeNode<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var queueCount = queue.Count;
                while (queueCount-- > 0)
                {
                    var currentNode = queue.Dequeue();

                    if (currentNode.Left != null || currentNode.Right != null)
                    {
                        var left = currentNode.Left == null ? 0 : currentNode.Left.Value;
                        var right = currentNode.Right == null ? 0 : currentNode.Right.Value;

                        if (currentNode.Value != left + right)
                        {
                            Console.WriteLine("given tree is not sum tree");
                            return false;
                        }
                    }
                    if (currentNode.Left != null)
                    {
                        queue.Enqueue(currentNode.Left);
                    }
                    if(currentNode.Right != null)
                    {
                        queue.Enqueue(currentNode.Right);
                    }
                }
            }

            Console.WriteLine("given tree is sum tree");
            return true;
        }

        public static int CalculateSumTree(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = CalculateSumTree(root.Left);

            int right = CalculateSumTree(root.Right);

            if (left != 0 || right != 0)
            {
                root.Value = left + right;
            }

            return root.Value;
        }
    }
}
