using System;
using System.Collections.Generic;

namespace BinaryTree._17.FindNextNodeSameLevel
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
            binayTree.Root.Left.Right = new BinaryTreeNode<int>(5);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Right = new BinaryTreeNode<int>(7);
            // level 4
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(8);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(9);

            var nextNode = FindNextNode(binayTree.Root, binayTree.Root.Right.Right);

            if(nextNode == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine(nextNode.Value);
            }

            Console.ReadLine();
        }

        

        public static BinaryTreeNode<T> FindNextNode<T>(BinaryTreeNode<T> rootNode, BinaryTreeNode<T> givenNode) where T : IComparable<T>
        {
            if (rootNode == null || givenNode == null)
            {
                return null;
            }

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(rootNode);

            int level = 0;

            while (queue.Count > 0)
            {
                level++;
                var queueCount = queue.Count;
                while (queueCount-- > 0)
                {
                    var nodePool = queue.Dequeue();
                    if(nodePool == givenNode)
                    {
                        // find next node immediately
                        // if queue count == 0;
                        if(queueCount == 0)
                        {
                            return null;
                        }
                        var nextNode = queue.Dequeue();
                        return nextNode;
                    }

                    if(nodePool.Left != null)
                    {
                        queue.Enqueue(nodePool.Left);
                    }

                    if (nodePool.Right != null)
                    {
                        queue.Enqueue(nodePool.Right);
                    }
                }
            }

            Console.WriteLine("Node not found");
            return null;

        }

    }
}
