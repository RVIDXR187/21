using System;

namespace DataStructuresLibrary
{
    public class SinglyLinkedList
    {
        private class Node
        {
            public object Data;
            public Node Next;

            public Node(object data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node _head;
        private Node _tail;
        private int _count;

        public int Count => _count;
        public object First => _head?.Data;
        public object Last => _tail?.Data;

        public SinglyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        public void Add(object item)
        {
            Node newNode = new Node(item);
            if(_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }
        public void AddFirst(object item)
        {
            Node newNode = new Node(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }
            _count++;
        }
        public void Insert(int index, object item)
        {
            if (index < 0 || index > _count)
            throw new ArgumentOutOfRangeException();

            if(index == 0)
            {
                AddFirst(item);
                return;
            }
            Node newNode = new Node(item);
            Node current = _head;
            for(int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;

            if(newNode.Next == null)
            {
                _tail = newNode;
            }
            _count++;
        }
        public bool Countains(object item)
        {
            Node current = _head;
            while (current != null)
            {
                if(current.Data.Equals(item))
                return true;
                current = current.Next;
            }
            return false;
        }
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        public object[] ToArray()
        {
        object[] array = new object[_count];
        Node current = _head;
        int index = 0;
        while(current != null)
        {
            array[index++] = current.Data;
            current = current.Next;
        }
        return array;
        }
    }
}