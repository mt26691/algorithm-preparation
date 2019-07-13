using System;
using System.Collections.Generic;

namespace BinaryTree._18.CheckCompleteTreeOrNot
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

            var completeTree = new BinaryTree<int>(1);

            // level 2
            completeTree.Root.Left = new BinaryTreeNode<int>(2);
            completeTree.Root.Right = new BinaryTreeNode<int>(3);

            // level 3
            completeTree.Root.Left.Left = new BinaryTreeNode<int>(4);
            completeTree.Root.Left.Right = new BinaryTreeNode<int>(5);
            completeTree.Root.Right.Left = new BinaryTreeNode<int>(6);
            completeTree.Root.Right.Right = new BinaryTreeNode<int>(7);

            var inCompleteTree = new BinaryTree<int>(1);

            // level 2
            inCompleteTree.Root.Left = new BinaryTreeNode<int>(2);
            inCompleteTree.Root.Right = new BinaryTreeNode<int>(3);

            // level 3
            inCompleteTree.Root.Left.Left = new BinaryTreeNode<int>(4);
            inCompleteTree.Root.Left.Right = new BinaryTreeNode<int>(5);
            inCompleteTree.Root.Right.Right = new BinaryTreeNode<int>(7);


            CheckCompleteTree(binayTree.Root);
            CheckCompleteTree(completeTree.Root);
            CheckCompleteTree(inCompleteTree.Root);
            Console.ReadLine();
        }



        public static void CheckCompleteTree<T>(BinaryTreeNode<T> rootNode) where T : IComparable<T>
        {
            if (rootNode == null )
            {
                return;
            }

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(rootNode);

            int level = 0;

            while (queue.Count > 0)
            {
                level++;
                var queueCount = queue.Count;
                var previousIsNull = false;
                while (queueCount-- > 0)
                {
                    var nodePool = queue.Dequeue();
                    
                    if(nodePool.Left == null && nodePool.Right != null)
                    {
                        Console.WriteLine("This is not the complete tree");
                        return;
                    }

                    if(nodePool.Left == null || nodePool.Right == null)
                    {
                        previousIsNull = true;
                    }

                    if(previousIsNull && (nodePool.Left != null || nodePool.Right != null))
                    {
                        Console.WriteLine("This is not the complete tree");
                        return;
                    }
                    if (nodePool.Left != null)
                    {
                        queue.Enqueue(nodePool.Left);
                    }

                    if (nodePool.Right != null)
                    {
                        queue.Enqueue(nodePool.Right);
                    }
                }
            }

            Console.WriteLine("This is the complete tree");

        }

    }
}
