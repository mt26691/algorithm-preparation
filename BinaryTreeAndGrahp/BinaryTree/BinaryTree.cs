﻿using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; } = null;

        public BinaryTree()
        {

        }
        public BinaryTree(T rootValue)
        {
            Root = new BinaryTreeNode<T>(rootValue);
        }

        public void PreorderTraverse(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value);
                PreorderTraverse(node.Left);
                PreorderTraverse(node.Right);
            }
        }

        public void InorderTraverse(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InorderTraverse(node.Left);
                Console.WriteLine(node.Value);
                InorderTraverse(node.Right);
            }
        }

        public void PostOrderTraverse(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraverse(node.Left);
                PostOrderTraverse(node.Right);
                Console.WriteLine(node.Value);
            }
        }

        public void LevelOrderTraversal(BinaryTreeNode<T> root = null)
        {
            if (root == null)
            {
                root = Root;
            }
            if (root == null)
            {
                return;
            }

            root.LevelOrderTraversal();
        }

        /// <summary>
        /// http://www.techiedelight.com/level-order-traversal-binary-tree/
        /// </summary>
        public void SpiralOrderTraversal()
        {
            var root = Root;
            if (root == null)
            {
                return;
            }

            var queue = new Queue<BinaryTreeNode<T>>();
            var stack = new Stack<BinaryTreeNode<T>>();
            var tempQueue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            var fromLeftToRight = true;

            while (true)
            {
                var queueCount = queue.Count;
                var stackCount = stack.Count;
                if (queueCount == 0 && stackCount == 0)
                {
                    return;
                }

                if (fromLeftToRight)
                {
                    while (queueCount > 0)
                    {
                        var data = queue.Dequeue();
                        Console.WriteLine($"Travel to {data.Value}");
                        if (data.Left != null)
                        {
                            stack.Push(data.Left);
                            tempQueue.Enqueue(data.Left);
                        }
                        if (data.Right != null)
                        {
                            stack.Push(data.Right);
                            tempQueue.Enqueue(data.Right);
                        }
                        queueCount = queue.Count;
                    }
                }
                else
                {
                    while (stackCount > 0)
                    {
                        var data = stack.Pop();
                        Console.WriteLine($"Travel to {data.Value}");
                        var queueData = tempQueue.Dequeue();

                        if (queueData.Left != null)
                        {
                            queue.Enqueue(queueData.Left);
                        }
                        if (queueData.Right != null)
                        {
                            queue.Enqueue(queueData.Right);
                        }
                        stackCount = stack.Count;
                    }
                }

                fromLeftToRight = !fromLeftToRight;
            }
        }

        /// <summary>
        /// https://www.techiedelight.com/reverse-level-order-traversal-binary-tree/
        /// </summary>
        public void ReverseLevelTraversal()
        {
            if (Root == null)
            {
                return;
            }

            var stack = new Stack<BinaryTreeNode<T>>();

            var pollingQueue = new Queue<BinaryTreeNode<T>>();
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                stack.Push(currentNode);
                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }
            }

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                Console.WriteLine($"Revere order travelal {node.Value}");
            }
        }

        /// <summary>
        /// This function is used for checking the given node is presented in the tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="checkNode"></param>
        /// <returns></returns>
        public bool IsPresentInTree(BinaryTreeNode<T> root, BinaryTreeNode<T> checkNode)
        {
            if (root == null)
            {
                return false;
            }

            if (root == checkNode)
            {
                return true;
            }

            return IsPresentInTree(root.Left, checkNode) || IsPresentInTree(root.Right, checkNode);
        }
    }
}
