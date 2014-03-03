namespace Stacks.Dynamic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class GenericStack<T> : IGenericStack<T>, IEnumerable<T>
    {
        private int size;
        private Node<T> first;

        public GenericStack()
        {
            this.first = null;
            this.Size = 0;
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                this.size = value;
            }
        }

        public bool IsEmpty()
        {
            return this.first == null;
        }

        public void Push(T item)
        {
            Node<T> oldfirst = this.first;
            this.first = new Node<T>();
            this.first.Item = item;
            this.first.Next = oldfirst;
            this.Size++;
        }

        public T Pop()
        {
            if (this.IsEmpty() == true)
            {
                throw new ArgumentOutOfRangeException("Stack underflow");
            }

            T item = this.first.Item;
            this.first = this.first.Next;
            this.Size--;

            return item;
        }

        public T Peek()
        {
            if (this.IsEmpty() == true)
            {
                throw new ArgumentOutOfRangeException("Stack underflow");
            }

            return this.first.Item;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var item in this)
            {
                result.Append(item + " ");
            }
            result.Length -= 1;

            return result.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = this.first;
            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node<K>
        {
            public K Item { get; set; }

            public Node<K> Next { get; set; }
        }
    }
}