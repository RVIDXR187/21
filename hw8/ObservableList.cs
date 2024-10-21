using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DatastructuresLibrary
{
    public class ObservableList<T>
    {
        private readonly List<T> _list;

        public event EventHandler<ItemChangedEventArgs<T>> ItemAdded;
        public event EventHandler<ItemChangedEventArgs<T>> ItemInserted;
        public event EventHandler<ItemChangedEventArgs<T>> ItemRemoved;

        public ObservableList()
        {
            _list = new List<T>();
        }
        public void Add(T item)
        {
            _list.Add(item);
            OnItemAdded(item);
        }
        public void Insert(int index, T item)
        {
            if(index < 0 || index > _list.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _list.Insert(index, item);
            OnItemInserted(index, item);
        }
        public bool Remove(T item)
        {
            bool removed = _list.Remove(item);
            if(removed)
            {
                OnItemRemoved(item);
            }
            return removed;
        }
        public T this[int index]
        {
            get
            {
                if(index < 0 || index >= _list.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _list[index]; 
            }
            set
            {
                if(index < 0 || index >= _list.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                _list[index] = value;
            }
        }
        public int Count => _list.Count;
        protected virtual void OnItemAdded(T item)
        {
            ItemAdded?.Invoke(this, new ItemChangedEventArgs<T>(item));
        }
        protected virtual void OnItemInserted(int index, T item)
        {
            ItemInserted?.Invoke(this, new ItemChangedEventArgs<T>(item, index));
        }

        protected virtual void OnItemRemoved(T item)
        {
            ItemRemoved?.Invoke(this, new ItemChangedEventArgs<T>(item));
        }
        public class ItemChangedEventArgs<T> : EventArgs
        {
            public T Item { get; }
            public int? Index { get; }

            public ItemChangedEventArgs(T item, int? index = null)
            {
                Item = item;
                Index = index;
            }
        }
    }
}