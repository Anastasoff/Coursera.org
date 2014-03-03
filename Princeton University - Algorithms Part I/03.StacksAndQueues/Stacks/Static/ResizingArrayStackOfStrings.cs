namespace Stacks.Static
{
    internal class ResizingArrayStackOfStrings : IStackOfStrings
    {
        private string[] arrayOfStrings;
        private int index;

        public ResizingArrayStackOfStrings()
        {
            this.arrayOfStrings = new string[4];
        }

        public bool IsEmpty()
        {
            return this.index == 0;
        }

        public void Push(string item)
        {
            if (this.index == this.arrayOfStrings.Length)
            {
                this.Resize(2 * this.arrayOfStrings.Length);
            }

            this.arrayOfStrings[this.index++] = item;
        }

        public string Pop()
        {
            string item = this.arrayOfStrings[--this.index];
            this.arrayOfStrings[this.index] = null;
            if (this.index > 0 && this.index == (this.arrayOfStrings.Length / 4))
            {
                this.Resize(this.arrayOfStrings.Length / 2);
            }

            return item;
        }

        private void Resize(int capacity)
        {
            string[] copy = new string[capacity];
            for (int i = 0; i < this.index; i++)
            {
                copy[i] = this.arrayOfStrings[i];
            }

            this.arrayOfStrings = copy;
        }
    }
}