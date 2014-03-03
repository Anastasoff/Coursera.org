namespace Stacks
{
    public interface IGenericStack<T>
    {
        bool IsEmpty();

        void Push(T item);

        T Pop();
    }
}