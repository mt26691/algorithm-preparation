using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; } = null;

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

        public void LevelOrderTraversal()
        {
            var root = Root;
            if(root == null)
            {
                return;
            }

            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while(queue.Count>0)
            {
                var currentNode = queue.Dequeue();
                Console.WriteLine($"Travel to {currentNode.Value}");

                if(currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }

            }
        }
    }
}
