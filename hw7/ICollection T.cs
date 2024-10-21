namespace DataStructuresLibrary.Interfaces
{
    public interface ICollection<T>
    {
        int Count { get; }

        void Add(T item); 
        bool Remove(T item);
        bool Contains(T item);
        void Clear();
        T[] ToArray();  
    }
}
