using System;
using System.Collections.Generic;

namespace BinaryTree._15.PrintBottomViewOfTree
{
    /// <summary>
    /// https://www.techiedelight.com/print-bottom-view-of-binary-tree/
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

            var map = new Dictionary<int, Pair<int>>();

            PrintBottomView(binayTree.Root, map, 0, 0);

            foreach(var item in map)
            {
                Console.WriteLine($"Level = {item.Value.Level}");
                Console.WriteLine(item.Value.Node.Value);
            }

            Console.ReadLine();
        }

        public class Pair<T> where T:IComparable<T>
        {
            public int Level { get; private set; }

            public BinaryTreeNode<T>  Node{ get; private set; }

            public Pair(int level, BinaryTreeNode<T> node)
            {
                Level = level;
                Node = node;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="map"></param>
        /// <param name="level"></param>
        /// <param name="horDist"></param>
        public static void PrintBottomView<T>(BinaryTreeNode<T> root, Dictionary<int, Pair<T>> map, int level = 0, int horDist = 0) where T : IComparable<T>
        {
            if (root == null)
            {
                return;
            }

            if (!map.ContainsKey(horDist))
            {
                map.Add(horDist, new Pair<T>(level, root));
            }
            else if(map.ContainsKey(horDist))
            {
                // calculate level
                var currentNode = map[horDist];
                if(currentNode.Level < level)
                {
                    map[horDist]  = new Pair<T>(level, root);
                }
            }

            PrintBottomView(root.Left, map, level + 1, horDist - 1);

            PrintBottomView(root.Right, map, level + 1, horDist + 1);
        }

        public static void PrintLeftView<T>(BinaryTreeNode<T> root) where T : IComparable<T>
        {
            if (root == null)
            {
                return;
            }

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(root);
            var level = 1;
            while (queue.Count > 0)
            {
                var currentLevelNodeCount = queue.Count;

                while (currentLevelNodeCount-- > 0)
                {
                    var node = queue.Dequeue();
                    // last node of current level
                    if (currentLevelNodeCount == 0)
                    {
                        Console.WriteLine($"Last node of current level({level}) = {node.Value}");
                    }

                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
                level++;
            }
        }
    }
}
