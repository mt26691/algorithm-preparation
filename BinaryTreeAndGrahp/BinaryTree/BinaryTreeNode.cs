using System;

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

        
    }
}
