namespace HashSymbolTables
{
    using System.Collections.Generic;

    public class LinearProbingHashST<TKey, TValue>
    {
        private const int INIT_CAPACITY = 4;

        private int n;              // number of key-value pairs in the symbol table
        private int m;              // size of linear probing table
        private TKey[] keys;        // the keys
        private TValue[] values;    // the values

        /// <summary>
        /// Create an empty hash table - use 16 as default size
        /// </summary>
        public LinearProbingHashST()
            : this(INIT_CAPACITY)
        {
        }

        /// <summary>
        /// Create linear probing hash table of given capacity
        /// </summary>
        public LinearProbingHashST(int capacity)
        {
            this.m = capacity;
            this.keys = new TKey[this.m];
            this.values = new TValue[this.m];
        }

        /// <summary>
        /// Return the number of key-value pairs in the symbol table
        /// </summary>
        public int Size()
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
        /// Does a key-value pair with the given key exist in the symbol table?
        /// </summary>
        public bool Contains(TKey key)
        {
            return this.Get(key) != null;
        }

        /// <summary>
        /// Hash method for keys - returns value between 0 and M - 1
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) & this.m;
        }

        // Resize the hash table to the given capacity by re-hashing all of the keys
        private void Resize(int capacity)
        {
            var temp = new LinearProbingHashST<TKey, TValue>(capacity);

            for (int i = 0; i < this.m; i++)
            {
                if (this.keys[i] != null)
                {
                    temp.Put(this.keys[i], this.values[i]);
                }
            }

            this.keys = temp.keys;
            this.values = temp.values;
            this.m = temp.m;
        }

        /// <summary>
        /// Insert the key-value pair into the symbol table
        /// </summary>
        public void Put(TKey key, TValue value)
        {
            if (value == null)
            {
                this.Delete(key);
            }

            // double table size if 50% full
            if (this.n >= this.m / 2)
            {
                this.Resize(2 * this.m);
            }

            int i = 0;
            for (i = this.Hash(key); this.keys[i] != null; i = (i + 1) % this.m)
            {
                if (this.keys[i].Equals(key))
                {
                    this.values[i] = value;
                    return;
                }
            }

            this.keys[i] = key;
            this.values[i] = value;
            this.n++;
        }

        /// <summary>
        /// Return the value associated with the given key, null if no such value
        /// </summary>
        public TValue Get(TKey key)
        {
            for (int i = this.Hash(key); this.keys[i] != null; i = (i + 1) % this.m)
            {
                if (this.keys[i].Equals(key))
                {
                    return this.values[i];
                }
            }

            return default(TValue);
        }

        /// <summary>
        /// Delete the key (and associated value) from the symbol table
        /// </summary>
        public void Delete(TKey key)
        {
            if (!this.Contains(key))
            {
                return;
            }

            // find position i of key
            int i = this.Hash(key);
            while (!key.Equals(this.keys[i]))
            {
                i = (i + 1) % this.m;
            }

            // delete key and associated value
            this.keys[i] = default(TKey);
            this.values[i] = default(TValue);

            // rehash all keys in same cluster
            i = (i + 1) % this.m;
            while (this.keys[i] != null)
            {
                // delete keys[i] an values[i] and reinsert
                TKey keyToRehash = this.keys[i];
                TValue valueToRehash = this.values[i];
                this.keys[i] = default(TKey);
                this.values[i] = default(TValue);
                this.n--;
                this.Put(keyToRehash, valueToRehash);
                i = (i + 1) % this.m;
            }

            this.n--;

            // halves size of the array if it's 12.5% full or less
            if (this.n > 0 && this.n <= this.m / 8)
            {
                this.Resize(this.m / 2);
            }
        }

        /// <summary>
        /// Return all of the keys as in IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TKey> Keys()
        {
            Queue<TKey> queue = new Queue<TKey>();

            for (int i = 0; i < this.m; i++)
            {
                if (this.keys[i] != null)
                {
                    queue.Enqueue(this.keys[i]);
                }
            }

            return queue;
        }
    }
}