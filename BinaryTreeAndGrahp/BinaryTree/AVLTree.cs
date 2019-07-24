using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{

    public class AVLTree<T> : BinaryTree<T> where T : IComparable<T>
    {
        public AVLTree()
        {

        }

        public AVLTree(T rootValue) : base(rootValue)
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
                return root;
            }

            if (root.Value.CompareTo(value) > 0)
            {
                root.Left = Insert(root.Left, value);
            }
            else if (root.Value.CompareTo(value) < 0)
            {
                root.Right = Insert(root.Right, value);
            }
            else
            {
                // duplicate not allow
                return root;
            }

            // check node height
            var leftHeight = GetNodeHeight(root.Left);
            var rightHeight = GetNodeHeight(root.Right);

            if (leftHeight - rightHeight > 1 && value.CompareTo(root.Left.Value) < 0)
            {
                //If balance factor is greater than 1, 
                //then the current node is unbalanced and 
                //we are either in Left Left case or left Right case. 
                //To check whether it is left left case or not, 
                //compare the newly inserted key with the key in 
                //left subtree root.
                return RightRotate(root);

            }
            else if (leftHeight - rightHeight > 1 && value.CompareTo(root.Left.Value) > 0)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }
            else if (leftHeight - rightHeight < -1 && value.CompareTo(root.Right.Value) > 0)
            {
                // left rotate
                return LeftRotate(root);
            }
            else if (leftHeight - rightHeight < -1 && value.CompareTo(root.Right.Value) < 0)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }

        public int GetNodeHeight(BinaryTreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                return 0;
            }

            int left = GetNodeHeight(currentNode.Left);
            int right = GetNodeHeight(currentNode.Right);

            return Math.Max(left, right) + 1;
        }

        public BinaryTreeNode<T> RightRotate(BinaryTreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                return currentNode;
            }

            if (currentNode.Left != null)
            {
                var leftNode = new BinaryTreeNode<T>(currentNode.Left.Value);
                leftNode.Left = currentNode.Left.Left;
                leftNode.Right = currentNode.Left.Right;

                if (currentNode.Left.Right != null)
                {
                    currentNode.Left = new BinaryTreeNode<T>(currentNode.Left.Right.Value);
                }
                else
                {
                    currentNode.Left = null;
                }

                leftNode.Right = currentNode;

                return leftNode;
            }

            return currentNode;
        }

        public BinaryTreeNode<T> LeftRotate(BinaryTreeNode<T> currentNode)
        {
            if (currentNode == null)
            {
                return currentNode;
            }

            if (currentNode.Right != null)
            {
                var rightNode = new BinaryTreeNode<T>(currentNode.Right.Value);
                rightNode.Left = currentNode.Right.Left;
                rightNode.Right = currentNode.Right.Right;

                if (currentNode.Right.Left != null)
                {
                    currentNode.Right = new BinaryTreeNode<T>(currentNode.Right.Left.Value);
                }
                else
                {
                    currentNode.Right = null;
                }

                rightNode.Left = currentNode;

                return rightNode;
            }

            return currentNode;
        }
    }
}
