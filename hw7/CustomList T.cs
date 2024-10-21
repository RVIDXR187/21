using DataStructuresLibrary.Interfaces;
using System;

namespace DataStructuresLibrary
{
    public class CustomList<T> : IList<T>
    {
        private T[] _items;
        private int _count;

        public CustomList()
        {
            _items = new T[4];
            _count = 0;
        }

        public int Count => _count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException();
                _items[index] = value;
            }
        }

        public void Add(T item)
        {
            EnsureCapacity();
            _items[_count++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException();

            EnsureCapacity();
            for (int i = _count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = item;
            _count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException();

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            _items = new T[4];
            _count = 0;
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                result[i] = _items[i];
            }
            return result;
        }

        private void EnsureCapacity()
        {
            if (_count >= _items.Length)
            {
                T[] newArray = new T[_items.Length * 2];
                for (int i = 0; i < _items.Length; i++)
                {
                    newArray[i] = _items[i];
                }
                _items = newArray;
            }
        }
    }
}
