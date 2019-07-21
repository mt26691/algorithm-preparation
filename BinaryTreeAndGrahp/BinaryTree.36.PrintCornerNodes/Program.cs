using System;
using System.Collections.Generic;

namespace BinaryTree._36.PrintCornerNodes
{
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
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(5);
            binayTree.Root.Right.Right = new BinaryTreeNode<int>(6);

            // level 4
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(7);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(8);

            binayTree.LevelOrderTraversal();
            PrintCornerNodes(binayTree.Root);
            Console.ReadLine();
        }


        public static void PrintCornerNodes(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return;
            }
            var queue = new Queue<BinaryTreeNode<int>>();
            queue.Enqueue(rootNode);
            while (queue.Count > 0)
            {
                var queueCount = queue.Count;
                var firstNode = false;
                while (queueCount-- > 0)
                {
                    var currentNode = queue.Dequeue();

                    if(!firstNode)
                    {
                        firstNode = true;
                        Console.WriteLine($"current left most outer node {currentNode.Value}");
                    }
                    else if(queueCount == 0)
                    {
                        Console.WriteLine($"current right most outer node {currentNode.Value}");
                    }

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

        }
    }

}
