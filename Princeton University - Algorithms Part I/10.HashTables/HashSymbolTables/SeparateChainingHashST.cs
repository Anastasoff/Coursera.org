namespace HashSymbolTables
{
    using System.Collections.Generic;

    using SymbolTables;

    /// <summary>
    /// A symbol table implementation with a separate-chaining hash table.
    /// </summary>
    public class SeparateChainingHashST<TKey, TValue>
    {
        private const int INIT_CAPACITY = 4;

        private int n;                                  // number of key-value pairs
        private int m;                                  // hash table size
        private SequentialSearchST<TKey, TValue>[] st;  // array of linked-list symbol tables

        // Create separate chaining hash table
        public SeparateChainingHashST()
            : this(INIT_CAPACITY)
        {
        }

        /// <summary>
        /// Create separate chaining hash table with M lists
        /// </summary>
        public SeparateChainingHashST(int m)
        {
            this.m = m;
            this.st = new SequentialSearchST<TKey, TValue>[this.m];

            for (int i = 0; i < this.m; i++)
            {
                this.st[i] = new SequentialSearchST<TKey, TValue>();
            }
        }

        // Resize the hash table to have the given number of chains b rehashing all of the keys
        private void Resize(int chains)
        {
            var temp = new SeparateChainingHashST<TKey, TValue>();

            for (int i = 0; i < this.m; i++)
            {
                foreach (var key in this.st[i].Keys())
                {
                    temp.Put(key, this.st[i].Get(key));
                }
            }

            this.m = temp.m;
            this.n = temp.n;
            this.st = temp.st;
        }

        // Hash value between 0 and M - 1
        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % this.m;
        }

        // Return number of key-value pairs in symbol table
        private int Size()
        {
            return this.n;
        }

        /// <summary>
        /// Is the symbol table empty?
        /// </summary>
        public bool IsEmpty()
        {
            return this.Size() == 0;
        }

        /// <summary>
        /// Is the key in the symbol table?
        /// </summary>
        public bool Contains(TKey key)
        {
            return this.Get(key) != null;
        }

        /// <summary>
        /// Return value associated with key, null if no such key
        /// </summary>
        public TValue Get(TKey key)
        {
            int i = this.Hash(key);
            return this.st[i].Get(key);
        }

        /// <summary>
        /// Insert key-value pair into the table
        /// </summary>
        public void Put(TKey key, TValue value)
        {
            if (value == null)
            {
                this.Delete(key);
                return;
            }

            // double table size if average length of list >= 10
            if (this.n >= 10 * this.m)
            {
                this.Resize(2 * this.m);
            }

            int i = this.Hash(key);
            if (!this.st[i].Contains(key))
            {
                this.n++;
            }

            this.st[i].Put(key, value);
        }

        /// <summary>
        /// Delete key (and associated value) if key is in the table
        /// </summary>
        public void Delete(TKey key)
        {
            int i = this.Hash(key);

            if (this.st[i].Contains(key))
            {
                this.n--;
            }

            this.st[i].Delete(key);

            // halve table size if average length of list <= 2
            if (this.m > INIT_CAPACITY && this.n <= 2 * this.m)
            {
                this.Resize(this.m / 2);
            }
        }

        public IEnumerable<TKey> Keys()
        {
            Queue<TKey> queue = new Queue<TKey>();

            for (int i = 0; i < this.m; i++)
            {
                foreach (var key in this.st[i].Keys())
                {
                    queue.Enqueue(key);
                }
            }

            return queue;
        }
    }
}