using System;

namespace BinaryTree._02.PreOrderTraversal
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

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
    }
}
