using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinaryTreeNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public BinaryTreeNode<T> Left { get; set; } = null;

        public BinaryTreeNode<T> Right { get; set; } = null;
        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public BinaryTreeNode(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public void LevelOrderTraversal()
        {
            var root = this;
            if (root == null)
            {
                return;
            }

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(root);
            int level = 1;
            while (queue.Count > 0)
            {
                var queueCount = queue.Count;
                Console.WriteLine($"Current level = {level}");
                level++;
                while (queueCount-- > 0)
                {
                    var currentNode = queue.Dequeue();
                    Console.Write($"{currentNode.Value}  ");

                    if (currentNode.Left != null)
                    {
                        queue.Enqueue(currentNode.Left);
                    }

                    if (currentNode.Right != null)
                    {
                        queue.Enqueue(currentNode.Right);
                    }

                }
                Console.WriteLine("");
            }
        }

    }
}
