using System;
using System.Collections.Generic;

namespace BinaryTree._33.VerticalTravesal
{
    /// <summary>
    /// https://www.techiedelight.com/vertical-traversal-binary-tree/?source=post_page---------------------------
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

            binayTree.LevelOrderTraversal();
            VericalTraversal(binayTree.Root);
            Console.ReadLine();
        }


        public static void VericalTraversal(BinaryTreeNode<int> rootNode)
        {
            var results = new Dictionary<int, List<int>>();
            Travelsal(rootNode, 0, results);

            foreach (var item in results)
            {
                Console.WriteLine($"\nVertical traversal for {item.Key}");
                foreach(var result in item.Value)
                {
                    Console.Write($"{result} ");
                }
            }
        }

        public static void Travelsal(BinaryTreeNode<int> rootNode, int horiztionalLevel, Dictionary<int, List<int>> results)
        {
            if (rootNode == null)
            {
                return;
            }
            
            if(!results.ContainsKey(horiztionalLevel))
            {
                results.Add(horiztionalLevel, new List<int> { rootNode.Value });
            }
            else
            {
                results[horiztionalLevel].Add(rootNode.Value);
            }

            Travelsal(rootNode.Left, horiztionalLevel - 1, results);
            Travelsal(rootNode.Right, horiztionalLevel + 1, results);
        }
    }

}
