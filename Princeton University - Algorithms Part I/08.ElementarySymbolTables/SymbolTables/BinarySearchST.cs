namespace SymbolTables
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Symbol table implementation with binary search in an ordered array.
    /// </summary>
    public class BinarySearchST<TKey, TValue> : ISymbolTable<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        private const int CAPACITY = 2;
        private TKey[] keys;
        private TValue[] values;
        private int n;

        /// <summary>
        /// Create an empty symbol table with default initial capacity.
        /// </summary>
        public BinarySearchST()
            : this(CAPACITY)
        {
        }

        /// <summary>
        /// Create an empty symbol table with default initial capacity.
        /// </summary>
        /// <param name="capacity">capacity the capacity</param>
        public BinarySearchST(int capacity)
        {
            this.keys = new TKey[capacity];
            this.values = new TValue[capacity];
        }

        /// <summary>
        /// Is the key in the table
        /// </summary>
        /// <param name="key">key the key</param>
        /// <returns></returns>
        public bool Contains(TKey key)
        {
            return this.Get(key) != null;
        }

        /// <summary>
        /// Number of key-value pairs in the table
        /// </summary>
        /// <returns>Key-value pairs size.</returns>
        public int Size()
        {
            return this.n;
        }

        /// <summary>
        /// Is the symbol table empty?
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.Size() == 0;
        }

        /// <summary>
        /// Return the value associated with the given key, or null if no such key.
        /// </summary>
        /// <param name="key">key the key</param>
        /// <returns></returns>
        public TValue Get(TKey key)
        {
            if (this.IsEmpty())
            {
                return default(TValue);
            }

            int i = this.Rank(key);
            if (i < this.n && this.keys[i].CompareTo(key) == 0)
            {
                return this.values[i];
            }

            return default(TValue);
        }

        /// <summary>
        /// Return the number of keys in the table that are smaller than given key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(TKey key)
        {
            int low = 0;
            int high = this.n - 1;
            while (low <= high)
            {
                int middle = low + ((high - low) / 2);
                int cmp = key.CompareTo(this.keys[middle]);
                if (cmp < 0)
                {
                    high = middle - 1;
                }
                else if (cmp > 0)
                {
                    low = middle + 1;
                }
                else
                {
                    return middle;
                }
            }

            return low;
        }

        /// <summary>
        /// Search for key, Update value if found; grow table if new.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(TKey key, TValue value)
        {
            if (value == null)
            {
                this.Delete(key);
                return;
            }

            int i = this.Rank(key);

            // key is already in table
            if (i < this.n && this.keys[i].CompareTo(key) == 0)
            {
                this.values[i] = value;
                return;
            }

            // insert new key-value pair
            if (this.n == this.keys.Length)
            {
                this.Resize(2 * this.keys.Length);
            }

            for (int j = this.n; j > i; j--)
            {
                this.keys[j] = this.keys[j - 1];
                this.values[j] = this.values[j - 1];
            }

            this.keys[i] = key;
            this.values[i] = value;
            this.n++;
        }

        /// <summary>
        /// Remove the key-value pair if present
        /// </summary>
        /// <param name="key"></param>
        public void Delete(TKey key)
        {
            if (this.IsEmpty())
            {
                return;
            }

            // compute rank
            int i = this.Rank(key);

            // key not in table
            if (i == this.n || this.keys[i].CompareTo(key) != 0)
            {
                return;
            }

            for (int j = i; j < this.n - 1; j++)
            {
                this.keys[j] = this.keys[j + 1];
                this.values[j] = this.values[j + 1];
            }

            this.n--;
            this.keys[this.n] = default(TKey); // to avoid loitering
            this.values[this.n] = default(TValue);

            // resize if 1/4 full
            if (this.n > 0 && this.n == this.keys.Length / 4)
            {
                this.Resize(this.keys.Length / 2);
            }
        }

        /// <summary>
        /// Delete the minimum key and its associated value
        /// </summary>
        public void DeleteMin()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentOutOfRangeException("Symbol table underflow error.");
            }

            this.Delete(this.Min());
        }

        /// <summary>
        /// Delete the maximum key and its associated value
        /// </summary>
        public void DeleteMax()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentOutOfRangeException("Symbol table underflow error.");
            }

            this.Delete(this.Max());
        }

        #region Ordered symbol table methods

        public TKey Min()
        {
            if (this.IsEmpty())
            {
                return default(TKey);
            }

            return this.keys[0];
        }

        public TKey Max()
        {
            if (this.IsEmpty())
            {
                return default(TKey);
            }

            return this.keys[this.n - 1];
        }

        public TKey Select(int k)
        {
            if (k < 0 || k >= this.n)
            {
                return default(TKey);
            }

            return this.keys[k];
        }

        public TKey Floor(TKey key)
        {
            int i = this.Rank(key);
            if (i < this.n && key.CompareTo(this.keys[i]) == 0)
            {
                return this.keys[i];
            }

            if (i == 0)
            {
                return default(TKey);
            }
            else
            {
                return this.keys[i - 1];
            }
        }

        public TKey Ceiling(TKey key)
        {
            int i = this.Rank(key);
            if (i == this.n)
            {
                return default(TKey);
            }
            else
            {
                return this.keys[i];
            }
        }

        public int Size(TKey low, TKey high)
        {
            if (low.CompareTo(high) > 0)
            {
                return 0;
            }

            if (this.Contains(high))
            {
                return this.Rank(high) - this.Rank(low) + 1;
            }
            else
            {
                return this.Rank(high) - this.Rank(low);
            }
        }

        public IEnumerable<TKey> Keys()
        {
            return this.Keys(this.Min(), this.Max());
        }

        public IEnumerable<TKey> Keys(TKey low, TKey high)
        {
            Queue<TKey> queue = new Queue<TKey>();
            if (low == null && high == null)
            {
                return queue;
            }

            if (low == null)
            {
                throw new NullReferenceException("'low' is null in keys()");
            }

            if (high == null)
            {
                throw new NullReferenceException("'high' is null in keys()");
            }

            if (low.CompareTo(high) > 0)
            {
                return queue;
            }

            for (int i = this.Rank(low); i < this.Rank(high); i++)
            {
                queue.Enqueue(this.keys[i]);
            }

            if (this.Contains(high))
            {
                queue.Enqueue(this.keys[this.Rank(high)]);
            }

            return queue;
        }

        #endregion Ordered symbol table methods

        // Resize the underlying arrays
        private void Resize(int capacity)
        {
            if (capacity < this.n)
            {
                throw new ArgumentOutOfRangeException("Cannot shrink the array.");
            }

            TKey[] tempK = new TKey[capacity];
            TValue[] tempV = new TValue[capacity];
            for (int i = 0; i < this.n; i++)
            {
                tempK[i] = this.keys[i];
                tempV[i] = this.values[i];
            }

            this.keys = tempK;
            this.values = tempV;
        }
    }
}