namespace Stacks
{
    public interface IStackOfStrings
    {
        void Push(string item);

        string Pop();

        bool IsEmpty();
    }
}