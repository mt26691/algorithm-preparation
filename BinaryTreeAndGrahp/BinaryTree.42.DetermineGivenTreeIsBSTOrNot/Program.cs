using System;

namespace BinaryTree._42.DetermineGivenTreeIsBSTOrNot
{

    /// <summary>
    /// https://www.techiedelight.com/determine-given-binary-tree-is-a-bst-or-not/?source=post_page---------------------------
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var binaySearchTree = new BinarySearchTree<int>();
            int[] keys = { 15, 10, 20, 8, 12, 16, 25 };

            foreach (var key in keys)
            {
                binaySearchTree.Root = binaySearchTree.Insert(binaySearchTree.Root, key);
            }

            binaySearchTree.LevelOrderTraversal();
            Console.WriteLine("---------");
            Console.WriteLine(IsBinaySearchTree(binaySearchTree.Root, int.MinValue, int.MaxValue));
        }

        public static bool IsBinaySearchTree(BinaryTreeNode<int> rootNode, int minValue, int maxValue)
        {
            if (rootNode == null)
            {
                return true;
            }


            if(rootNode.Value < minValue || rootNode.Value > maxValue)
            {
                return false;
            }

            return IsBinaySearchTree(rootNode.Left, minValue, rootNode.Value)
                && IsBinaySearchTree(rootNode.Right, rootNode.Value, maxValue);
        }
    }

}
