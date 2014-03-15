/*
 * This code implements priority queue which uses min-heap as underlying storage.
 */

namespace PriorityQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Priority queue based on binary heap,
    /// Elements with minimum priority dequeued first
    /// </summary>
    /// <typeparam name="TPriority">Type of priorities</typeparam>
    /// <typeparam name="TValue">Type of values</typeparam>
    public class PriorityQueue<TPriority, TValue> : ICollection<KeyValuePair<TPriority, TValue>>
    {
        private List<KeyValuePair<TPriority, TValue>> baseHeap;
        private IComparer<TPriority> comparer;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of priority queue with default initial capacity and default priority comparer
        /// </summary>
        public PriorityQueue()
            : this(Comparer<TPriority>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of priority queue with specified initial capacity and default priority comparer
        /// </summary>
        /// <param name="capacity">initial capacity</param>
        public PriorityQueue(int capacity)
            : this(capacity, Comparer<TPriority>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of priority queue with specified initial capacity and specified priority comparer
        /// </summary>
        /// <param name="capacity">initial capacity</param>
        /// <param name="comparer">priority comparer</param>
        public PriorityQueue(int capacity, IComparer<TPriority> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            this.baseHeap = new List<KeyValuePair<TPriority, TValue>>(capacity);
            this.comparer = comparer;
        }

        /// <summary>
        /// Initializes a new instance of priority queue with default initial capacity and specified priority comparer
        /// </summary>
        /// <param name="comparer">priority comparer</param>
        public PriorityQueue(IComparer<TPriority> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException();
            }

            this.baseHeap = new List<KeyValuePair<TPriority, TValue>>();
            this.comparer = comparer;
        }

        /// <summary>
        /// Initializes a new instance of priority queue with specified data and default priority comparer
        /// </summary>
        /// <param name="data">data to be inserted into priority queue</param>
        public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data)
            : this(data, Comparer<TPriority>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of priority queue with specified data and specified priority comparer
        /// </summary>
        /// <param name="data">data to be inserted into priority queue</param>
        /// <param name="comparer">priority comparer</param>
        public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data, IComparer<TPriority> comparer)
        {
            if (data == null || comparer == null)
            {
                throw new ArgumentNullException();
            }

            this.comparer = comparer;
            this.baseHeap = new List<KeyValuePair<TPriority, TValue>>(data);

            // heapify data
            for (int pos = (this.baseHeap.Count / 2) - 1; pos >= 0; pos--)
            {
                this.HeapifyFromBeginningToEnd(pos);
            }
        }

        #endregion Constructors

        #region Merging

        /// <summary>
        /// Merges two priority queues
        /// </summary>
        /// <param name="pq1">first priority queue</param>
        /// <param name="pq2">second priority queue</param>
        /// <returns>resultant priority queue</returns>
        /// <remarks>
        /// source priority queues must have equal comparers,
        /// otherwise <see cref="InvalidOperationException"/> will be thrown
        /// </remarks>
        public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> pq1, PriorityQueue<TPriority, TValue> pq2)
        {
            if (pq1 == null || pq2 == null)
            {
                throw new ArgumentNullException();
            }

            if (pq1.comparer != pq2.comparer)
            {
                throw new InvalidOperationException("Priority queues to be merged must have equal comparers");
            }

            return MergeQueues(pq1, pq2, pq1.comparer);
        }

        /// <summary>
        /// Merges two priority queues and sets specified comparer for resultant priority queue
        /// </summary>
        /// <param name="pq1">first priority queue</param>
        /// <param name="pq2">second priority queue</param>
        /// <param name="comparer">comparer for resultant priority queue</param>
        /// <returns>resultant priority queue</returns>
        public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> pq1, PriorityQueue<TPriority, TValue> pq2, IComparer<TPriority> comparer)
        {
            if (pq1 == null || pq2 == null || comparer == null)
            {
                throw new ArgumentNullException();
            }

            // merge data
            PriorityQueue<TPriority, TValue> result = new PriorityQueue<TPriority, TValue>(pq1.Count + pq2.Count, pq1.comparer);
            result.baseHeap.AddRange(pq1.baseHeap);
            result.baseHeap.AddRange(pq2.baseHeap);

            // heapify data
            for (int pos = (result.baseHeap.Count / 2) - 1; pos >= 0; pos--)
            {
                result.HeapifyFromBeginningToEnd(pos);
            }

            return result;
        }

        #endregion Merging

        #region Priority queue operations

        /// <summary>
        /// Enqueues element into priority queue
        /// </summary>
        /// <param name="priority">element priority</param>
        /// <param name="value">element value</param>
        public void Enqueue(TPriority priority, TValue value)
        {
            this.Insert(priority, value);
        }

        /// <summary>
        /// Dequeues element with minimum priority and return its priority and value as <see cref="KeyValuePair{TPriority,TValue}"/>
        /// </summary>
        /// <returns>priority and value of the dequeued element</returns>
        /// <remarks>
        /// Method throws <see cref="InvalidOperationException"/> if priority queue is empty
        /// </remarks>
        public KeyValuePair<TPriority, TValue> Dequeue()
        {
            if (!this.IsEmpty)
            {
                KeyValuePair<TPriority, TValue> result = this.baseHeap[0];
                this.DeleteRoot();

                return result;
            }
            else
            {
                throw new InvalidOperationException("Priority queue is empty");
            }
        }

        /// <summary>
        /// Dequeues element with minimum priority and return its value
        /// </summary>
        /// <returns>value of the dequeued element</returns>
        /// <remarks>
        /// Method throws <see cref="InvalidOperationException"/> if priority queue is empty
        /// </remarks>
        public TValue DequeueValue()
        {
            return this.Dequeue().Value;
        }

        /// <summary>
        /// Returns priority and value of the element with minimum priority, without removing it from the queue
        /// </summary>
        /// <returns>priority and value of the element with minimum priority</returns>
        /// <remarks>
        /// Method throws <see cref="InvalidOperationException"/> if priority queue is empty
        /// </remarks>
        public KeyValuePair<TPriority, TValue> Peek()
        {
            if (!this.IsEmpty)
            {
                return this.baseHeap[0];
            }
            else
            {
                throw new InvalidOperationException("Priority queue is empty");
            }
        }

        /// <summary>
        /// Returns value of the element with minimum priority, without removing it from the queue
        /// </summary>
        /// <returns>value of the element with minimum priority</returns>
        /// <remarks>
        /// Method throws <see cref="InvalidOperationException"/> if priority queue is empty
        /// </remarks>
        public TValue PeekValue()
        {
            return this.Peek().Value;
        }

        /// <summary>
        /// Gets whether priority queue is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return this.baseHeap.Count == 0;
            }
        }

        #endregion Priority queue operations

        #region Heap operations

        private void ExchangeElements(int pos1, int pos2)
        {
            KeyValuePair<TPriority, TValue> val = this.baseHeap[pos1];
            this.baseHeap[pos1] = this.baseHeap[pos2];
            this.baseHeap[pos2] = val;
        }

        private void Insert(TPriority priority, TValue value)
        {
            KeyValuePair<TPriority, TValue> val = new KeyValuePair<TPriority, TValue>(priority, value);
            this.baseHeap.Add(val);

            // heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

            // heapify after insert, from end to beginning
            this.HeapifyFromEndToBeginning(this.baseHeap.Count - 1);
        }

        private int HeapifyFromEndToBeginning(int pos)
        {
            if (pos >= this.baseHeap.Count)
            {
                return -1;
            }

            while (pos > 0)
            {
                int parentPos = (pos - 1) / 2;
                if (this.comparer.Compare(this.baseHeap[parentPos].Key, this.baseHeap[pos].Key) > 0)
                {
                    this.ExchangeElements(parentPos, pos);
                    pos = parentPos;
                }
                else
                {
                    break;
                }
            }

            return pos;
        }

        private void DeleteRoot()
        {
            if (this.baseHeap.Count <= 1)
            {
                this.baseHeap.Clear();

                return;
            }

            this.baseHeap[0] = this.baseHeap[this.baseHeap.Count - 1];
            this.baseHeap.RemoveAt(this.baseHeap.Count - 1);

            // heapify
            this.HeapifyFromBeginningToEnd(0);
        }

        private void HeapifyFromBeginningToEnd(int pos)
        {
            if (pos >= this.baseHeap.Count)
            {
                return;
            }

            //// heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

            while (true)
            {
                // on each iteration exchange element with its smallest child
                int smallest = pos;
                int left = (2 * pos) + 1;
                int right = (2 * pos) + 2;
                if (left < this.baseHeap.Count && this.comparer.Compare(this.baseHeap[smallest].Key, this.baseHeap[left].Key) > 0)
                {
                    smallest = left;
                }

                if (right < this.baseHeap.Count && this.comparer.Compare(this.baseHeap[smallest].Key, this.baseHeap[right].Key) > 0)
                {
                    smallest = right;
                }

                if (smallest != pos)
                {
                    this.ExchangeElements(smallest, pos);
                    pos = smallest;
                }
                else
                {
                    break;
                }
            }
        }

        #endregion Heap operations

        #region ICollection<KeyValuePair<TPriority, TValue>> implementation

        /// <summary>
        /// Enqueues element into priority queue
        /// </summary>
        /// <param name="item">element to add</param>
        public void Add(KeyValuePair<TPriority, TValue> item)
        {
            this.Enqueue(item.Key, item.Value);
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        public void Clear()
        {
            this.baseHeap.Clear();
        }

        /// <summary>
        /// Determines whether the priority queue contains a specific element
        /// </summary>
        /// <param name="item">The object to locate in the priority queue</param>
        /// <returns><c>true</c> if item is found in the priority queue; otherwise, <c>false.</c> </returns>
        public bool Contains(KeyValuePair<TPriority, TValue> item)
        {
            return this.baseHeap.Contains(item);
        }

        /// <summary>
        /// Gets number of elements in the priority queue
        /// </summary>
        public int Count
        {
            get
            {
                return this.baseHeap.Count;
            }
        }

        /// <summary>
        /// Copies the elements of the priority queue to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from the priority queue. The Array must have zero-based indexing. </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <remarks>
        /// It is not guaranteed that items will be copied in the sorted order.
        /// </remarks>
        public void CopyTo(KeyValuePair<TPriority, TValue>[] array, int arrayIndex)
        {
            this.baseHeap.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        /// <remarks>
        /// For priority queue this property returns <c>false</c>.
        /// </remarks>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the priority queue.
        /// </summary>
        /// <param name="item">The object to remove from the ICollection <(Of <(T >)>). </param>
        /// <returns><c>true</c> if item was successfully removed from the priority queue.
        /// This method returns false if item is not found in the collection. </returns>
        public bool Remove(KeyValuePair<TPriority, TValue> item)
        {
            // find element in the collection and remove it
            int elementIdx = this.baseHeap.IndexOf(item);
            if (elementIdx < 0)
            {
                return false;
            }

            // remove element
            this.baseHeap[elementIdx] = this.baseHeap[this.baseHeap.Count - 1];
            this.baseHeap.RemoveAt(this.baseHeap.Count - 1);

            // heapify
            int newPos = this.HeapifyFromEndToBeginning(elementIdx);
            if (newPos == elementIdx)
            {
                this.HeapifyFromBeginningToEnd(elementIdx);
            }

            return true;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>Enumerator</returns>
        /// <remarks>
        /// Returned enumerator does not iterate elements in sorted order.</remarks>
        public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
        {
            return this.baseHeap.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>Enumerator</returns>
        /// <remarks>
        /// Returned enumerator does not iterate elements in sorted order.</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion ICollection<KeyValuePair<TPriority, TValue>> implementation
    }
}