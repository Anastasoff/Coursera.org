namespace Stacks.Static
{
    public class FixedCapacityStackOfStrings : IStack
    {
        private string[] arrayOfStrings;
        private int index;

        public FixedCapacityStackOfStrings(int capacity)
        {
            this.arrayOfStrings = new string[capacity];
        }

        public bool IsEmpty()
        {
            return this.index == 0;
        }

        public void Push(string item)
        {
            this.arrayOfStrings[this.index++] = item;
        }

        public string Pop()
        {
            string item = this.arrayOfStrings[--this.index];
            this.arrayOfStrings[this.index] = null;
            return item;
        }
    }
}