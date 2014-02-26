namespace Queues
{
    public class LinkedQueueOfStrings
    {
        private Node first;
        private Node last;

        public bool IsEmpty()
        {
            return this.first == null;
        }

        public void Enqueue(string item)
        {
            Node oldlast = this.last;
            this.last = new Node();
            this.last.Item = item;
            this.last.Next = null;
            if (IsEmpty() == true)
            {
                this.first = this.last;
            }
            else
            {
                oldlast.Next = this.last;
            }
        }

        public string Dequeue()
        {
            string item = this.first.Item;
            this.first = this.first.Next;
            if (IsEmpty() == true)
            {
                this.last = null;
            }

            return item;
        }
    }
}