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

        public void InorderTraverse(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value);
                InorderTraverse(node.Left);
                InorderTraverse(node.Right);
            }
        }
    }
}
