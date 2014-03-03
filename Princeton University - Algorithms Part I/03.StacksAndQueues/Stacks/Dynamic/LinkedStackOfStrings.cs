namespace Stacks.Dynamic
{
    public class LinkedStackOfStrings : IStackOfStrings
    {
        private Node first;

        public bool IsEmpty()
        {
            return first == null;
        }

        public void Push(string item)
        {
            Node oldfirst = this.first;
            this.first = new Node();
            this.first.Item = item;
            this.first.Next = oldfirst;
        }

        public string Pop()
        {
            string item = this.first.Item;
            this.first = this.first.Next;
            return item;
        }
    }
}