using System;
using System.Collections.Generic;

namespace BinaryTree._19.CheckCousin
{
    /// <summary>
    /// https://www.techiedelight.com/determine-two-nodes-are-cousins/
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


            CheckCousin(binayTree.Root, binayTree.Root.Right.Left.Left, binayTree.Root.Right.Left.Right);
            CheckCousin(binayTree.Root, binayTree.Root.Right.Left.Left, binayTree.Root.Right.Right);
            CheckCousin(binayTree.Root, binayTree.Root.Left.Left, binayTree.Root.Right.Right);
            Console.ReadLine();
        }

        public class Pair<T> where T : IComparable<T>
        {
            public BinaryTreeNode<T> Parent { get; set; }

            public BinaryTreeNode<T> Node { get; set; }

            public Pair(BinaryTreeNode<T> parent, BinaryTreeNode<T> node)
            {
                Parent = parent;
                Node = node;
            }

        }


        public static void CheckCousin<T>(BinaryTreeNode<T> rootNode, BinaryTreeNode<T> firstNode, BinaryTreeNode<T> secondNode) where T : IComparable<T>
        {
            if (rootNode == null)
            {
                return;
            }

            var queue = new Queue<Pair<T>>();
            queue.Enqueue(new Pair<T>(null, rootNode));

            int level = 0;

            while (queue.Count > 0)
            {
                level++;
                var queueCount = queue.Count;
                while (queueCount-- > 0)
                {
                    var nodePool = queue.Dequeue();

                    if (nodePool.Node == firstNode || nodePool.Node == secondNode)
                    {
                        while (queueCount-- > 0)
                        {
                            var nextNode = queue.Dequeue();
                            if (nextNode.Node == firstNode || nextNode.Node == secondNode)
                            {
                                if (nextNode.Parent != nodePool.Parent)
                                {
                                    Console.WriteLine("They are counsin");
                                    return;
                                }
                            }
                        }
                        Console.WriteLine("They are not counsin");
                        return;
                    }

                    if (nodePool.Node.Left != null)
                    {
                        queue.Enqueue(new Pair<T>(nodePool.Node, nodePool.Node.Left));
                    }

                    if (nodePool.Node.Right != null)
                    {
                        queue.Enqueue(new Pair<T>(nodePool.Node, nodePool.Node.Right));
                    }
                }
            }

            Console.WriteLine("They are not counsin");

        }

    }
}
