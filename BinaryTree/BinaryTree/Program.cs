using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{

    internal class Node<T> where T : IComparable<T>
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;
        public Node<T> Parent;

        public bool IsLeftChild
        {
            get
            {
                if (Parent != null && Parent.Left == this)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (Parent != null && Parent.Right == this)
                {
                    return true;
                }
                return false;
            }
        }

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> parent)
        {
            Value = value;
            Parent = parent;
        }
    }

    public class Tree<T> where T : IComparable<T>
    {
        public int Count { get; private set; }
        internal Node<T> root;

        public Tree()
        {
            root = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            if (root == null)
            {
                return false;
            }
            return true;
        }

        private Node<T> Find(T value)
        {
            //return node if found
            Node<T> curr = root;
            while (curr != null)
            {
                //if the value is equal, return the node
                if (value.CompareTo(curr.Value) == 0)
                {
                    return curr;
                }
                //if the value is less, go left
                if (value.CompareTo(curr.Value) < 0)
                {
                    curr = curr.Left;
                }
                //if the value is greater, go right
                else if (value.CompareTo(curr.Value) > 0)
                {
                    curr = curr.Right;
                }

            }

            return null;
        }

        public bool Contains(T value)
        {
            if (Find(value) == null)
            {
                return false;
            }
            return true;
        }

        public void Add(T value)
        {
            Count++;

            if (root == null)
            {
                root = new Node<T>(value);
                return;
            }

            Node<T> curr = root;
            while (curr != null)
            {
                if (value.CompareTo(curr.Value) < 0)
                {
                    if (curr.Left == null)
                    {
                        //add the new child
                        curr.Left = new Node<T>(value, curr);
                        return;
                    }

                    curr = curr.Left;
                }
                else
                {
                    if (curr.Right == null)
                    {
                        curr.Right = new Node<T>(value, curr);
                        return;
                    }

                    curr = curr.Right;
                }
            }
        }

        public void Remove(T value)
        {
            Node<T> del = Find(value);

            if (del.Left == null && del.Right == null)
            {
                if (del.IsLeftChild)
                {
                    del.Parent.Left = null;
                }
                else if (del.IsRightChild)//if right child
                {
                    del.Parent.Right = null;
                }
                else //we are the root
                {
                    Clear();
                }
            }

            Count--;
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
