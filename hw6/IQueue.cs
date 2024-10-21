namespace DataStructuresLibrary.Interfaces
{
    public interface IQueue : ICollection
    {
        void Enqueue(object item);
        object Dequeue();
        object Peek();
    }
}