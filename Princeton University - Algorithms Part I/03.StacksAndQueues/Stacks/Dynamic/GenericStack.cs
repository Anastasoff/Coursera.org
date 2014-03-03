namespace Stacks.Dynamic
{
    public class GenericStack<T> : IGenericStack<T>
    {
        private Node first;

        public GenericStack()
        {
            this.first = null;
        }

        public bool IsEmpty()
        {
            return this.first == null;
        }

        public void Push(T item)
        {
            Node oldfirst = this.first;
            this.first = new Node();
            this.first.Item = item;
            this.first.Next = oldfirst;
        }

        public T Pop()
        {
            T item = this.first.Item;
            this.first = this.first.Next;
            return item;
        }

        private class Node
        {
            public T Item { get; set; }

            public Node Next { get; set; }
        }
    }
}