namespace Stacks
{
    public interface IStackOfStrings
    {
        bool IsEmpty();

        void Push(string item);

        string Pop();
    }
}