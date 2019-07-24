using System;

namespace BinaryTree._44.AVLTreeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var tree = new AVLTree<int>();

            /* Constructing tree given in the above figure */
            tree.Root = tree.Insert(tree.Root, 10);
            tree.Root = tree.Insert(tree.Root, 20);
            tree.Root = tree.Insert(tree.Root, 30);
            tree.Root = tree.Insert(tree.Root, 40);
            tree.Root = tree.Insert(tree.Root, 50);
            tree.Root = tree.Insert(tree.Root, 25);
            tree.Root = tree.Insert(tree.Root, 26);
            tree.Root = tree.Insert(tree.Root, 27);

            tree.LevelOrderTraversal();
        }
    }
}
