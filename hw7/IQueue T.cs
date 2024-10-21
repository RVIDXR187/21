namespace DataStructuresLibrary.Interfaces
{
    public interface IQueue<T> : ICollection<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}
