using System;

namespace BinaryTree._41.SinkNodeToBottom
{
    /// <summary>
    /// https://www.techiedelight.com/sink-nodes-containing-zero-bottom-binary-tree/?source=post_page---------------------------
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var binayTree = new BinaryTree<int>(0);

            // level 2
            binayTree.Root.Left = new BinaryTreeNode<int>(1);
            binayTree.Root.Right = new BinaryTreeNode<int>(2);

            // level 3
            binayTree.Root.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(0);

            // level 4
            binayTree.Root.Left.Left.Left = new BinaryTreeNode<int>(6);

            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(7);

            binayTree.LevelOrderTraversal();
            Console.WriteLine("---------");
            SinkZeroNode(binayTree.Root);
            binayTree.LevelOrderTraversal();
        }

        public static void SinkZeroNode(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return;
            }
            if (rootNode.Value == 0 && (rootNode.Left != null || rootNode.Right != null))
            {
                if (rootNode.Left != null && rootNode.Left.Value != 0)
                {
                    var swapNode = rootNode.Left.Value;
                    rootNode.Left.Value = rootNode.Value;
                    rootNode.Value = swapNode;
                }
                else if (rootNode.Right != null && rootNode.Right.Value != 0)
                {
                    var swapNode = rootNode.Right.Value;
                    rootNode.Right.Value = rootNode.Value;
                    rootNode.Value = swapNode;
                }
            }

            SinkZeroNode(rootNode.Left);
            SinkZeroNode(rootNode.Right);
        }
    }
}
