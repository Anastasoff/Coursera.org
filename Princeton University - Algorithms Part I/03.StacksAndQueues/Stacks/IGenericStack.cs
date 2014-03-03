namespace Stacks
{
    public interface IGenericStack<T>
    {
        void Push(T item);

        T Pop();

        bool IsEmpty();
    }
}