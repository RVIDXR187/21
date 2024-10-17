using System;
using System.Linq.Expressions;

namespace DataStructuresLibrary
{
    public class DoublyLinkedList : SinglyLinkedList
    {
        private class Node
        {
            public object Data;
            public Node Next;
            public Node Previus;

            public Node(object data)
            {
                Data = data;
                Next = null;
                Previus = null;
            }
        }
        private Node _head;
        private Node _tail;
        private int _count;

        public int Count => _count;
        public object First => _head?.Data;
        public object Last => _tail?.Data;

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        public void Add(object item)
        {
                Node newNode = new Node(item);
                if (_head == null)
                {
                    _head = newNode;
                    _tail = newNode;
                }
                else
                {
                    newNode.Previus = _tail;
                    _tail.Next = newNode;
                    _tail = newNode;
                }
            _count++;
        }
        public void AddFirst(object item)
        {
            Node newNode = new Node(item);
            if(_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Previus = newNode;
                _head = newNode;
            }
            _count++;
        }
        public void Remove(object item)
        {
            Node current = _head;
            while (current != null)
            {
                if(current.Data.Equals(item))
                {
                    if(current.Data.Equals(item))
                    {
                        if(current.Previus != null)
                        {
                            current.Previus.Next = current.Next;
                        }
                        else
                        {
                            _head = current.Next;
                        }
                        if(current.Next != null)
                        {
                            current.Next.Previus = current.Previus;
                        }
                        else
                        {
                            _tail = current.Previus;
                        }
                    }
                }
            }
        }
    }
}