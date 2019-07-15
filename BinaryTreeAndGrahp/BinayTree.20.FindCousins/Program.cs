using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinayTree._20.FindCousins
{
    /// <summary>
    /// https://www.techiedelight.com/print-cousins-of-given-node-binary-tree/
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


            FindCousins(binayTree.Root, binayTree.Root.Right.Left.Left);
            FindCousins(binayTree.Root, binayTree.Root.Right.Left);
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

        public static void FindCousins<T>(BinaryTreeNode<T> rootNode, BinaryTreeNode<T> givenNode) where T : IComparable<T>
        {
            if (rootNode == null || givenNode == null)
            {
                return;
            }

            var queue = new Queue<Pair<T>>();
            queue.Enqueue(new Pair<T>(null, rootNode));

            var results = new List<Pair<T>>();

            var foundGivenNode = false;
            BinaryTreeNode<T> givenNodeParent = null;
            while (queue.Count > 0 && !foundGivenNode)
            {
                var queueCount = queue.Count;
                results = new List<Pair<T>>();

                // by level
                while (queueCount-- > 0)
                {
                    var currentNode = queue.Dequeue();

                    if (currentNode.Node == givenNode)
                    {
                        foundGivenNode = true;
                        givenNodeParent = currentNode.Parent;
                    }
                    else
                    {
                        results.Add(currentNode);
                    }

                    if (currentNode.Node.Left != null)
                    {
                        queue.Enqueue(new Pair<T>(currentNode.Node, currentNode.Node.Left));
                    }
                    if (currentNode.Node.Right != null)
                    {
                        queue.Enqueue(new Pair<T>(currentNode.Node, currentNode.Node.Right));
                    }
                }
            }


            if(results.Count>0)
            {
                results = results.Where(t => t.Parent != givenNodeParent).ToList();
            }
            if (foundGivenNode && results.Count > 0)
            {
                foreach (var item in results)
                {
                    Console.WriteLine($"Cousin = {item.Node.Value}");
                }
            }
            else
            {
                Console.WriteLine("There is no cousin for this given node");
            }

        }
    }

}
