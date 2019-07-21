using System;

namespace BinaryTree._40.CheckIfGivenTreeIsBalanceHeightOrNot
{
    /// <summary>
    /// https://www.techiedelight.com/check-given-binary-tree-is-height-balanced-not/?source=post_page---------------------------
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
            binayTree.Root.Right.Left = new BinaryTreeNode<int>(4);

            // level 4
            binayTree.Root.Left.Left.Left = new BinaryTreeNode<int>(6);

            binayTree.Root.Right.Left.Left = new BinaryTreeNode<int>(6);
            binayTree.Root.Right.Left.Right = new BinaryTreeNode<int>(7);

            binayTree.LevelOrderTraversal();
            Console.WriteLine("---------");
            Console.WriteLine(IsBalanceTree(binayTree.Root));
            Console.ReadLine();
        }

        public static bool IsBalanceTree(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return false;
            }

            var left = RootMaxHeight(rootNode.Left);
            var right = RootMaxHeight(rootNode.Right);

            var max = Math.Max(left, right);
            var min = Math.Min(left, right);

            return max - min <= 1;
        }

        public static int RootMaxHeight(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return 0;
            }

            int leftHeight = RootMaxHeight(rootNode.Left);
            int rightHeight = RootMaxHeight(rootNode.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static void FindMaxPath(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return;
            }
            var sum = RootToLeaftSum(rootNode);
            PrintPath(rootNode, sum);
        }

        public static bool PrintPath(BinaryTreeNode<int> rootNode, int sum)
        {
            if (sum == 0)
            {
                return true;
            }
            if (rootNode == null)
            {
                return false;
            }

            var left = PrintPath(rootNode.Left, sum - rootNode.Value);
            var right = PrintPath(rootNode.Right, sum - rootNode.Value);

            if (left || right)
            {
                Console.WriteLine($"Path {rootNode.Value}");
            }
            return left || right;
        }
        public static int RootToLeaftSum(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            var left = RootToLeaftSum(root.Left);
            var right = RootToLeaftSum(root.Right);

            return (left > right ? left : right) + root.Value;
        }
    }
}
