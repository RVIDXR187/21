using System;
using DataStructuresLibrary.Interfaces;

namespace DataStructuresLibrary
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Value;
            public Node Left;
            public Node Right;

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private Node _root;
        private int _count;

        public BinarySearchTree()
        {
            _root = null;
            _count = 0;
        }

        public int Count => _count;

        public void Add(T value)
        {
            _root = AddRecursive(_root, value);
            _count++;
        }

        private Node AddRecursive(Node node, T value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = AddRecursive(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = AddRecursive(node.Right, value);
            }

            return node;
        }

        public bool Contains(T value)
        {
            return ContainsRecursive(_root, value);
        }

        private bool ContainsRecursive(Node node, T value)
        {
            if (node == null)
            {
                return false;
            }

            if (value.CompareTo(node.Value) == 0)
            {
                return true;
            }

            if (value.CompareTo(node.Value) < 0)
            {
                return ContainsRecursive(node.Left, value);
            }
            else
            {
                return ContainsRecursive(node.Right, value);
            }
        }

        public void Clear()
        {
            _root = null;
            _count = 0;
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];
            int index = 0;
            ToArrayRecursive(_root, result, ref index);
            return result;
        }

        private void ToArrayRecursive(Node node, T[] array, ref int index)
        {
            if (node != null)
            {
                ToArrayRecursive(node.Left, array, ref index);
                array[index++] = node.Value;
                ToArrayRecursive(node.Right, array, ref index);
            }
        }
    }
}
