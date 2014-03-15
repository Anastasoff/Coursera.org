namespace MinPQ
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The MinPQ class represents a priority queue of generic keys.
    /// </summary>
    public class MinPQ<Key> : IEnumerable<Key> where Key : IComparable<Key>
    {
        private Key[] pq;                    // store items at indexes 1 to N
        private int n;                       // number of items on priority queue
        private IComparable<Key> comparator; // optional Comparator

        /// <summary>
        /// Initializes an empty priority queue with the given initial capacity.
        /// </summary>
        /// <param name="initCapacity">The initial capacity of the priority queue.</param>
        public MinPQ(int initCapacity)
        {
            this.pq = new Key[initCapacity + 1];
            this.n = 0;
        }

        /// <summary>
        /// Initializes an empty priority queue.
        /// </summary>
        public MinPQ()
            : this(1)
        {
        }

        /// <summary>
        /// Initializes an empty priority queue with the given initial capacity, using the given comparator.
        /// </summary>
        /// <param name="initCapacity">The initial capacity of the priority queue.</param>
        /// <param name="comparator">The order in which to compare the keys.</param>
        public MinPQ(int initCapacity, IComparable<Key> comparator)
            : this(initCapacity)
        {
            this.comparator = comparator;
        }

        /// <summary>
        /// Initializes an empty priority queue using the given comparator.
        /// </summary>
        /// <param name="comparator">The order in which to compare the keys.</param>
        public MinPQ(IComparable<Key> comparator)
            : this(1, comparator)
        {
        }

        /// <summary>
        /// Initializes a priority queue from the array of keys.
        /// Takes time proportional to the number of keys, using sink-based heap construction.
        /// </summary>
        /// <param name="keys">The array of keys.</param>
        public MinPQ(Key[] keys)
        {
            this.n = keys.Length;
            this.pq = new Key[keys.Length + 1];
            for (int i = 0; i < this.n; i++)
            {
                this.pq[i + 1] = keys[i];
            }

            for (int k = this.n / 2; k >= 1; k--)
            {
                this.Sink(k);
            }
        }

        /// <summary>
        /// Is the priority queue empty?
        /// </summary>
        /// <returns>True if the priority queue is empty; false otherwise.</returns>
        public bool IsEmpty()
        {
            return this.n == 0;
        }

        /// <summary>
        /// Returns the number of keys on the priority queue.
        /// </summary>
        /// <returns>The number of keys on the priority queue.</returns>
        public int Size()
        {
            return this.n;
        }

        /// <summary>
        /// Returns a smallest key on the priority queue.
        /// </summary>
        /// <returns>Smallest key on the priority queue.</returns>
        /// <exception cref="ArgumentException">Priority queue underflow.</exception>
        public Key Min()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentException("Priority queue underflow.");
            }

            return this.pq[1];
        }

        /// <summary>
        /// Adds a new key to the priority queue.
        /// </summary>
        /// <param name="x">The new key to add to the priority queue.</param>
        public void Insert(Key x)
        {
            // double size of the array if necessary
            if (this.n >= this.pq.Length - 1)
            {
                this.Resize(2 * this.pq.Length);
            }

            // add x, and percolate it up to maintain heap invariant
            this.pq[++this.n] = x;
            this.Swim(this.n);
        }

        /// <summary>
        /// Removes and returns a smallest key on the priority queue.
        /// </summary>
        /// <returns>Smallest key on the priority queue.</returns>
        /// <exception cref="ArgumentException">Priority queue underflow.</exception>
        public Key DeleteMin()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentException("Priority queue underflow.");
            }

            this.Swap(1, this.n);
            Key min = this.pq[this.n--];
            this.Sink(1);
            this.pq[this.n + 1] = default(Key); // to avoid loitering and help with garbage collection
            if ((this.n > 0) && (this.n == (this.pq.Length - 1) / 4))
            {
                this.Resize(this.pq.Length / 2);
            }

            return min;
        }

        public IEnumerator<Key> GetEnumerator()
        {
            for (int i = 1; i <= this.n; i++)
            {
                yield return this.pq[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Helper function to double the size of the heap array
        private void Resize(int capacity)
        {
            if (capacity < this.n)
            {
                throw new ArgumentOutOfRangeException("Cannot shrink the array.");
            }

            Key[] temp = new Key[capacity];
            for (int i = 1; i <= this.n; i++)
            {
                temp[i] = this.pq[i];
            }

            this.pq = temp;
        }

        #region Helper functions to restore the heap invariant.

        private void Swim(int k)
        {
            while (k > 1 && this.Greater(k / 2, k))
            {
                this.Swap(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= this.n)
            {
                int j = 2 * k;
                if (j < this.n && this.Greater(j, j + 1))
                {
                    j++;
                }

                if (!this.Greater(k, j))
                {
                    break;
                }

                this.Swap(k, j);
                k = j;
            }
        }

        #endregion Helper functions to restore the heap invariant.

        #region Helper functions for compares and swaps.

        private bool Greater(int i, int j)
        {
            if (this.comparator == null)
            {
                return this.pq[i].CompareTo(this.pq[j]) > 0;
            }
            else
            {
                // TODO: return comparator.compare(pq[i], pq[j]) < 0; <= Java
                throw new NotImplementedException();
            }
        }

        private void Swap(int i, int j)
        {
            Key swap = this.pq[i];
            this.pq[i] = this.pq[j];
            this.pq[j] = swap;
        }

        #endregion Helper functions for compares and swaps.
    }
}