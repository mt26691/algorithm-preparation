using System;
using System.Collections.Generic;

namespace BinaryTree._35.PrintDiagonalTraversal
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
            PrintDiagonalTraversal(binayTree.Root);
            Console.ReadLine();
        }

        public class Pair
        {
            public int XLevel { get; set; }

            public int YLevel { get; set; }

            public BinaryTreeNode<int> Node { get; set; }
        }
        public static void PrintDiagonalTraversal(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return;
            }
            var pair = new Pair() { Node = rootNode, XLevel = 0, YLevel = 0 };
            var queue = new Queue<Pair>();
            queue.Enqueue(pair);
            var results = new Dictionary<int, List<BinaryTreeNode<int>>>();
            while (queue.Count > 0)
            {
                var queueCount = queue.Count;
                while (queueCount-- > 0)
                {
                    var currentNode = queue.Dequeue();
                    var key = currentNode.YLevel - currentNode.XLevel;

                    if (!results.ContainsKey(key))
                    {
                        results.Add(key,  new List<BinaryTreeNode<int>>() { currentNode.Node });
                    }
                    else
                    {
                        results[key].Add(currentNode.Node);
                    }

                    if (currentNode.Node.Left != null)
                    {
                        queue.Enqueue(new Pair() { Node = currentNode.Node.Left, XLevel = currentNode.XLevel - 1, YLevel = currentNode.YLevel + 1 });
                    }

                    if (currentNode.Node.Right != null)
                    {
                        queue.Enqueue(new Pair() { Node = currentNode.Node.Right, XLevel = currentNode.XLevel + 1, YLevel = currentNode.YLevel + 1 });
                    }
                }
            }

            foreach (var item in results)
            {
                Console.WriteLine($"Diagonal Traversal");
                foreach(var node in item.Value)
                {
                    Console.Write($"{node.Value} ");
                }
                Console.WriteLine();
            }
        }
    }

}
