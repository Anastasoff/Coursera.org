namespace Stacks.Static
{
    using System;

    public class FixedCapacityStack<T> : IGenericStack<T>
    {
        private T[] array;
        private int index;

        public FixedCapacityStack(int capacity)
        {
            this.array = new T[capacity];
            this.index = 0;
        }

        public bool IsEmpty()
        {
            return this.index == 0;
        }

        public void Push(T item)
        {
            this.array[this.index++] = item;
        }

        public T Pop()
        {
            return this.array[--this.index];
        }
    }
}