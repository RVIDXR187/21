using System;

namespace DataStructuresLibrary
{
    public class CustomList
    {
        private object[] _items;
        private int _count;

        public CustomList()
        {
            _items = new object[4];
            _count = 0;
        }

        public CustomList(int capacity)
        {
            _items = new object[capacity];
            _count = 0;
        }

        public int Count => _count;

        public object this[int index]
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

        public void Add(object item)
        {
            EnsureCapacity();
            _items[_count++] = item;
        }

        public void Insert(int index, object item)
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

        public void Remove(object item)
        {
            int index = IndexOf(item);
            if (index != -1)
                RemoveAt(index);
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

        public bool Contains(object item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Clear()
        {
            _items = new object[4];
            _count = 0;
        }

        public object[] ToArray()
        {
            object[] result = new object[_count];
            for (int i = 0; i < _count; i++)
            {
                result[i] = _items[i];
            }
            return result;
        }

        public void Reverse()
        {
            for (int i = 0, j = _count - 1; i < j; i++, j--)
            {
                object temp = _items[i];
                _items[i] = _items[j];
                _items[j] = temp;
            }
        }

        private void EnsureCapacity()
        {
            if (_count >= _items.Length)
            {
                object[] newArray = new object[_items.Length * 2];
                for (int i = 0; i < _items.Length; i++)
                {
                    newArray[i] = _items[i];
                }
                _items = newArray;
            }
        }
    }
}
