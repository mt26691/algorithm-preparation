using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree._46.FindMaxWidth
{
    /// <summary>
    /// https://www.techiedelight.com/find-maximum-width-given-binary-tree/?source=post_page---------------------------
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(0);

            // level 2
            binayTree.Root.Left = new BinaryTreeNode<int>(1);
            binayTree.Root.Right = new BinaryTreeNode<int>(2);

            // level 3
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(4);

            // level 4
            binayTree.Root.Left.Left.Left = new BinaryTreeNode<int>(9);
            binayTree.Root.Left.Left.Right = new BinaryTreeNode<int>(9);
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(7);

            binayTree.LevelOrderTraversal();
            Console.WriteLine("---------");
            var maxwidth = FindMaxWidth(binayTree.Root);
            Console.WriteLine($"Max width = {maxwidth}");
            Console.ReadLine();
        }

        public static int FindMaxWidth(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return 0;
            }

            int result = 0;
            var queue = new Queue<BinaryTreeNode<int>>();
            queue.Enqueue(rootNode);

            while (queue.Count > 0)
            {
                var queueCount = queue.Count;
                if (result < queueCount)
                {
                    result = queueCount;
                }

                while (queueCount-- > 0)
                {
                    var currentNode = queue.Dequeue();
                    if (currentNode.Left != null)
                    {
                        queue.Enqueue(currentNode.Left);
                    }
                    if (currentNode.Right != null)
                    {
                        queue.Enqueue(currentNode.Right);
                    }
                }
            }

            return result;
        }
    }

}
