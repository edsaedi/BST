using System;
using Xunit;
using BinaryTree;

namespace BinaryTreeTest
{
    public class UnitTest1
    {
        [Fact]
        public void Add()
        {
            int size = 100;
            for (int j = 0; j < size; j++)
            {
                CheckTree(CreateTree(size), size);
            }
            //assert tree size is 100
        }

        [Fact]
        public void Remove()
        {
            int size = 100;
            for (int i = 0; i < size; i++)
            {
                var temp = CreateTree(size);
                Random rand = new Random();
                temp.Remove(rand.Next(0, size));
                CheckTree(temp, size);
            }
        }

        public Tree<int> CreateTree(int size)
        {
            int[] array = Randomize(size);
            Tree<int> tree = new Tree<int>();
            for (int i = 0; i < size; i++)
            {
                tree.Add(array[i]);
            }
            return tree;
        }

        internal void CheckTree(Tree<int> tree, int size)
        {
            CheckNode(tree.root);
            Assert.True(tree.Count == size);
        }

        internal void CheckNode(Node<int> node)
        {
            if (node.Left != null)
            {
                Assert.True(node.Left.Value < node.Value);
                CheckNode(node.Left);
            }
            if (node.Right != null)
            {
                Assert.True(node.Right.Value >= node.Value);
                CheckNode(node.Right);
            }
        }

        public int[] Randomize(int size)
        {
            int[] array = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(0, size);
            }

            return array;
        }
    }
}
