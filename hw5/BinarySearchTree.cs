using System;
using System.Security.Cryptography.X509Certificates;

namespace DataStructuresLibrary
{
    public class BinarySearchThree
    {
        private class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }
        private Node _root;
        private int _count;

        public BinarySearchThree()
        {
            _root = null;
            _count = 0;
        }
        public int Count => _count;

        public void Add(int value)
        {
            _root = AddRecursive(_root, value);
            _count++;
        }
        private Node AddRecursive(Node node, int value)
        {
            if(node == null)
            {
                return new Node(value);
            }
            if(value < node.Value)
            {
                node.Left = AddRecursive(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = AddRecursive(node.Right,value);
            }
            return node;
        }
        public bool Contains(int value)
        {
            return CountainsRecursive(_root, value);
        }  
        private bool CountainsRecursive(Node node, int value)
        {
            if(node == null)
            {
                return false;
            }
            if(value == node.Value)
            {
                return true;
            }
            if (value < node.Value)
            {
                return CountainsRecursive(node.Left, value);
            }
            else
            {
                return CountainsRecursive(node.Right, value);
            }
        }
        public void Clear()
        {
            _root = null;
            _count = 0;
        }
        public int[] ToArray()
        {
            int[] result = new int[_count];
            int index = 0;
            ToArrayRecursive(_root, result, ref index);
            return result;
        }
        private void ToArrayRecursive(Node node, int[] array, ref int index)
        {
            if(node != null)
            {
                ToArrayRecursive(node.Left, array, ref index);
                array[index++] = node.Value;
                ToArrayRecursive(node.Right, array, ref index);
            }
        }
    }
}