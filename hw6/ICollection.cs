namespace DataStructuresLibrary.Interfaces
{
    public interface ICollection
    {
        int Count { get; }

        void Add(object item);
        bool Remove(object item);
        bool Contains(object item);
        void Clear();
        object[] ToArray();
    }
}