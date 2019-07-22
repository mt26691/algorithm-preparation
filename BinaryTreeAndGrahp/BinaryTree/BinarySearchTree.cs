using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable<T>
    {
        public BinarySearchTree()
        {

        }

        public BinarySearchTree(T rootValue) : base(rootValue)
        {

        }


        public BinaryTreeNode<T> Insert(BinaryTreeNode<T> root, T value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T>(value);
                if (Root == null)
                {
                    Root = root;
                }
            }

            if (root.Value.CompareTo(value) > 0)
            {
                root.Left = Insert(root.Left, value);
            }
            else if (root.Value.CompareTo(value) < 0)
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }
    }
}
