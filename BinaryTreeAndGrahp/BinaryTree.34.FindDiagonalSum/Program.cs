using System;
using System.Collections.Generic;

namespace BinaryTree._34.FindDiagonalSum
{

    /// <summary>
    /// https://www.techiedelight.com/find-diagonal-sum-given-binary-tree/?source=post_page---------------------------
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
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(5);
            binayTree.Root.Right.Right = new BinaryTreeNode<int>(6);

            // level 4
            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(7);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(8);

            binayTree.LevelOrderTraversal();
            CalculateSum(binayTree.Root);
            CalculateSumByMath(binayTree.Root);
            Console.ReadLine();
        }


        public static void CalculateSum(BinaryTreeNode<int> rootNode)
        {

            var results = new Dictionary<int, int>();
            Travelsal(rootNode, 0, results);

            foreach (var item in results)
            {
                Console.WriteLine($"Diagonal sum  {item}");
            }
        }

        public static void Travelsal(BinaryTreeNode<int> rootNode, int horiztionalLevel, Dictionary<int, int> results)
        {
            if (rootNode == null)
            {
                return;
            }

            if (!results.ContainsKey(horiztionalLevel))
            {
                results.Add(horiztionalLevel, rootNode.Value);
            }
            else
            {
                results[horiztionalLevel] += (rootNode.Value);
            }

            Travelsal(rootNode.Left, horiztionalLevel + 1, results);
            Travelsal(rootNode.Right, horiztionalLevel, results);
        }

        public class Pair
        {
            public int XLevel { get; set; }

            public int YLevel { get; set; }

            public BinaryTreeNode<int> Node { get; set; }
        }
        public static void CalculateSumByMath(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return;
            }
            var pair = new Pair() { Node = rootNode, XLevel = 0, YLevel = 0 };
            var queue = new Queue<Pair>();
            queue.Enqueue(pair);
            Dictionary<int, int> results = new Dictionary<int, int>();
            while (queue.Count > 0)
            {
                var queueCount = queue.Count;
                while (queueCount-- > 0)
                {
                    var currentNode = queue.Dequeue();
                    var key = currentNode.YLevel - currentNode.XLevel;

                    if (!results.ContainsKey(key))
                    {
                        results.Add(key, currentNode.Node.Value);
                    }
                    else
                    {
                        results[key] += (currentNode.Node.Value);
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
                Console.WriteLine($"Diagonal sum by Math  {item}");
            }
        }
    }
}
