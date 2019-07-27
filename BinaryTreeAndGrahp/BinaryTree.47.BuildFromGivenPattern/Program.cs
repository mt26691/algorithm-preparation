using System;
using System.Collections.Generic;

namespace BinaryTree._47.BuildFromGivenPattern
{
    /// <summary>
    /// https://www.techiedelight.com/build-binary-tree-given-parent-array/?source=post_page---------------------------
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BuildFromGivenPattern(new int[] { -1, 0, 0, 1, 2, 2, 4, 4 });
            Console.ReadLine();
        }

        public static void BuildFromGivenPattern(int[] pattern)
        {

            var nodeList = new List<BinaryTreeNode<int>>();

            BinaryTreeNode<int> rootNode;
            for (int i = 0; i < pattern.Length; i++)
            {
                nodeList.Add(new BinaryTreeNode<int>(i));
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == -1)
                {
                    rootNode = nodeList[i];
                }
                else
                {
                    var parentNode = nodeList[pattern[i]];

                    if (parentNode != null)
                    {
                        if (parentNode.Left == null)
                        {
                            parentNode.Left = nodeList[i];
                        }
                        else if (parentNode.Right == null)
                        {
                            parentNode.Right = nodeList[i];
                        }
                    }
                }
            }
        }

    }

}
