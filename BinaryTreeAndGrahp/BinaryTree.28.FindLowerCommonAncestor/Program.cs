using System;

namespace BinaryTree._28.FindLowerCommonAncestor
{
    /// <summary>
    /// https://www.techiedelight.com/find-lowest-common-ancestor-lca-two-nodes-binary-tree/?source=post_page---------------------------
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
            FindLowerCommonAncesTor(binayTree.Root, binayTree.Root.Right.Left.Left, binayTree.Root.Right.Left.Right);
            FindLowerCommonAncesTor(binayTree.Root, binayTree.Root.Left.Left, binayTree.Root.Right.Left.Right);
            FindLowerCommonAncesTor(binayTree.Root, binayTree.Root.Left.Left, new BinaryTreeNode<int>(9));
            Console.ReadLine();
        }

        public static void FindLowerCommonAncesTor<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> firstNode, BinaryTreeNode<T> secondNode) where T : IComparable<T>
        {
            BinaryTreeNode<T> result = null;
            FindLCA(root, firstNode, secondNode, ref result);

            if(result == null)
            {
                Console.WriteLine("Lowest common ancestor Not found");
            }
            else
            {
                Console.WriteLine($"Lowest common ancestor is {result.Value}");
            }
           
        }


        public static bool FindLCA<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> firstNode, BinaryTreeNode<T> secondNode, ref BinaryTreeNode<T> result
            ) where T : IComparable<T>
        {
            if(root == null)
            {
                return false;
            }

            if(root == firstNode || root == secondNode)
            {
                return true;
            }

            var leftCheck = FindLCA(root.Left, firstNode, secondNode, ref result);

            var rightCheck = FindLCA(root.Right, firstNode, secondNode, ref result);

            if(leftCheck && rightCheck)
            {
                result = root;
            }

            return leftCheck || rightCheck;
        }
    }

}
