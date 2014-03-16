namespace SymbolTables
{
    using System.Collections.Generic;

    /// <summary>
    /// The SequentialSearchST class represents an (unordered) symbol table of generic key-value pairs.
    /// </summary>
    public class SequentialSearchST<Key, Value> : ISymbolTable<Key, Value>
    {
        private int n;      // number of key-value pairs
        private Node first; // the linked list of key-value pairs

        // A helper linked list data type
        private class Node
        {
            public Node(Key key, Value value, Node next)
            {
                this.Key = key;
                this.Value = value;
                this.Next = next;
            }

            public Key Key { get; set; }

            public Value Value { get; set; }

            public Node Next { get; set; }
        }

        /// <summary>
        /// Initializes an empty symbol table.
        /// </summary>
        public SequentialSearchST()
        {
        }

        /// <summary>
        /// Returns the number of key-value pairs in this symbol table.
        /// </summary>
        /// <returns>The number of key-value pairs in this symbol table.</returns>
        public int Size()
        {
            return this.n;
        }

        /// <summary>
        /// Is this symbol table empty?
        /// </summary>
        /// <returns>True if this symbol table is empty and false otherwise.</returns>
        public bool IsEmpty()
        {
            return this.Size() == 0;
        }

        /// <summary>
        /// Does this symbol table contain the given key?
        /// </summary>
        /// <param name="key">key the key</param>
        /// <returns>True if the symbol table contains key and false otherwise.</returns>
        public bool Contains(Key key)
        {
            return this.Get(key) != null;
        }

        /// <summary>
        /// Returns the value associated with the given key.
        /// </summary>
        /// <param name="key">key the key</param>
        /// <returns>
        /// The value associated with the given key if the key is in the symbol table
        /// and null if the key is not in the symbol table
        /// </returns>
        public Value Get(Key key)
        {
            for (Node x = this.first; x != null; x = x.Next)
            {
                if (key.Equals(x.Key))
                {
                    return x.Value;
                }
            }

            return default(Value);
        }

        /// <summary>
        /// Inserts the key-value pair into the symbol table, overwriting the old value
        /// with the new value if the key is already in the symbol table.
        /// If the value is null, this effectively deletes the key from the symbol table.
        /// </summary>
        /// <param name="key">key the key</param>
        /// <param name="value">value the value</param>
        public void Put(Key key, Value value)
        {
            if (value == null)
            {
                this.Delete(key);
                return;
            }

            for (Node x = this.first; x != null; x = x.Next)
            {
                if (key.Equals(x.Key))
                {
                    x.Value = value;
                    return;
                }
            }

            this.first = new Node(key, value, this.first);
            this.n++;
        }

        /// <summary>
        /// Removes the key and associated value from the symbol table (if the key is in the symbol table).
        /// </summary>
        /// <param name="key">key the key</param>
        public void Delete(Key key)
        {
            this.first = this.Delete(this.first, key);
        }

        /// <summary>
        /// Returns all keys in the symbol table as an IEnumerable.
        /// To iterate over all of the keys in the symbol table named "st",
        /// use the foreach notation: for (Key key : st.keys()).
        /// </summary>
        /// <returns>All keys in the symbol table as an IEnumerable</returns>
        public IEnumerable<Key> Keys()
        {
            Queue<Key> queue = new Queue<Key>();
            for (Node x = this.first; x != null; x = x.Next)
            {
                queue.Enqueue(x.Key);
            }

            return queue;
        }

        // Delete key in linked list beginning at Node x
        // WARNING: method call stack too large if table is large
        private Node Delete(Node x, Key key)
        {
            if (x == null)
            {
                return null;
            }

            if (key.Equals(x.Key))
            {
                this.n--;
                return x.Next;
            }

            x.Next = this.Delete(x.Next, key);

            return x;
        }
    }
}