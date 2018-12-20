using System;
using Xunit;
using BinaryTree;

namespace BinaryTreeTest
{
    public class UnitTest1
    {
        Random rand = new Random();

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
            int size = 10000;
            for (int i = 0; i < size; i++)
            {
                //initialize
                int[] array = Randomize(size);
                var tree = CreateTree(array);

                //remove
                int index = rand.Next(array.Length);
                tree.Remove(array[index]);

                //Assert
                Assert.False(tree.Contains(array[index]));
                CheckTree(tree, size - 1);
            }
        }

        [Fact]
        public void Find()
        {
            int size = 100;
            for (int i = 0; i < size; i++)
            {
                int[] array = Randomize(size);
                var tree = CreateTree(array);

                for (int j = 0; j < array.Length; j++)
                {
                    Assert.True(array[j] == tree.Find(array[j]).Value);
                }
                
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

        public Tree<int> CreateTree(int[] size)
        {
            Tree<int> tree = new Tree<int>();
            for (int i = 0; i < size.Length; i++)
            {
                tree.Add(size[i]);
            }
            return tree;
            //load the size array into the tree
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
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(0, size);
            }

            return array;
        }
    }
}
