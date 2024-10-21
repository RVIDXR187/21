namespace DataStructuresLibrary.Interfaces
{
    public interface IStack : ICollection
    {
        void Push(object item);
        object Pop();
        object Peek();
    }
}