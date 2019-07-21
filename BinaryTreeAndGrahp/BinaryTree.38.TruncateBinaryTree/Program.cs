using System;

namespace BinaryTree._38.TruncateBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(0);

            // level 2
            binayTree.Root.Left = new BinaryTreeNode<int>(1);
            binayTree.Root.Right = new BinaryTreeNode<int>(2);

            // level 3
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(3);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(4);

            // level 4
            binayTree.Root.Left.Left.Left = new BinaryTreeNode<int>(5);

            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(7);

            binayTree.LevelOrderTraversal();
            Console.WriteLine("---------");
            TruncateNode(binayTree.Root, null, 10, 0);
            binayTree.LevelOrderTraversal();
            Console.ReadLine();
        }


        public static BinaryTreeNode<int> TruncateNode(BinaryTreeNode<int> rootNode, BinaryTreeNode<int> parent, int k, int sum)
        {
            if (rootNode == null)
            {
                return null;
            }

            sum = sum + rootNode.Value;
            TruncateNode(rootNode.Left, rootNode, k, sum);
            TruncateNode(rootNode.Right, rootNode, k, sum);

            if (sum < k && rootNode.Left == null && rootNode.Right == null)
            {
                if(parent.Left == rootNode)
                {
                    parent.Left = null;
                }
                else if(parent.Right == rootNode)
                {
                    parent.Right = null;
                }

                rootNode = null;
            }

            return rootNode;
        }
    }

}
