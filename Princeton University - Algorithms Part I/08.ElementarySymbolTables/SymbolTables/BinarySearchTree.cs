﻿namespace SymbolTables
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A symbol table implemented with a binary search tree.
    /// </summary>
    public class BinarySearchTree<TKey, TValue> : ISymbolTable<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node root; // root of Binary Search Tree

        private class Node
        {
            public Node(TKey key, TValue value, int n)
            {
                this.Key = key;
                this.Value = value;
                this.N = n;
            }

            public TKey Key { get; set; }

            public TValue Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public int N { get; set; }
        }

        /// <summary>
        /// Is the symbol table empty?
        /// </summary>
        public bool IsEmpty()
        {
            return this.Size() == 0;
        }

        /// <summary>
        /// Return number of key-value pairs in BST
        /// </summary>
        public int Size()
        {
            return this.Size(this.root);
        }

        // Return number of key-value pairs in BST rooted at x.
        private int Size(Node x)
        {
            if (x == null)
            {
                return 0;
            }
            else
            {
                return x.N;
            }
        }

        /***********************************************************************
         *  Search BST for given key, and return associated value if found,
         *  return null if not found
         ***********************************************************************/

        /// <summary>
        /// Does there exist a key-value pair with given key?
        /// </summary>
        public bool Contains(TKey key)
        {
            return this.Get(key) != null;
        }

        /// <summary>
        /// Return value associated with the given key, or null if no such key exists.
        /// </summary>
        public TValue Get(TKey key)
        {
            return this.Get(this.root, key);
        }

        private TValue Get(Node x, TKey key)
        {
            if (x == null)
            {
                return default(TValue);
            }

            int cmp = key.CompareTo(x.Key);

            if (cmp < 0)
            {
                return this.Get(x.Left, key);
            }
            else if (cmp > 0)
            {
                return this.Get(x.Right, key);
            }
            else
            {
                return x.Value;
            }
        }

        /***********************************************************************
         *  Insert key-value pair into BST
         *  If key already exists, update with new value
         ***********************************************************************/

        public void Put(TKey key, TValue value)
        {
            if (value == null)
            {
                this.Delete(key);
                return;
            }

            this.root = this.Put(this.root, key, value);
        }

        private Node Put(Node x, TKey key, TValue value)
        {
            if (x == null)
            {
                return new Node(key, value, 1);
            }

            int cmp = key.CompareTo(x.Key);

            if (cmp < 0)
            {
                x.Left = this.Put(x.Left, key, value);
            }
            else if (cmp > 0)
            {
                x.Right = this.Put(x.Right, key, value);
            }
            else
            {
                x.Value = value;
            }

            x.N = 1 + this.Size(x.Left) + this.Size(x.Right);

            return x;
        }

        /***********************************************************************
         *  Delete
         ***********************************************************************/

        public void DeleteMin()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentOutOfRangeException("Symbol table underflow.");
            }

            this.root = this.DeleteMin(this.root);
        }

        private Node DeleteMin(Node x)
        {
            if (x.Left == null)
            {
                return x.Right;
            }

            x.Left = this.DeleteMin(x.Left);
            x.N = this.Size(x.Left) + this.Size(x.Right) + 1;

            return x;
        }

        public void DeleteMax()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentOutOfRangeException("Symbol table underflow.");
            }

            this.root = this.DeleteMax(this.root);
        }

        private Node DeleteMax(Node x)
        {
            if (x.Right == null)
            {
                return x.Left;
            }

            x.Right = this.DeleteMax(x.Right);
            x.N = this.Size(x.Left) + this.Size(x.Right) + 1;

            return x;
        }

        public void Delete(TKey key)
        {
            this.root = this.Delete(this.root, key);
        }

        private Node Delete(Node x, TKey key)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = key.CompareTo(x.Key);

            if (cmp < 0)
            {
                x.Left = this.Delete(x.Left, key);
            }
            else if (cmp > 0)
            {
                x.Right = this.Delete(x.Right, key);
            }
            else
            {
                if (x.Right == null)
                {
                    return x.Left;
                }

                if (x.Left == null)
                {
                    return x.Right;
                }

                Node t = x;
                x = this.Min(t.Right);
                x.Right = this.DeleteMin(t.Right);
                x.Left = t.Left;
            }

            x.N = this.Size(x.Left) + this.Size(x.Right) + 1;

            return x;
        }

        /***********************************************************************
         *  Min, max, floor, and ceiling
         ***********************************************************************/

        public TKey Min()
        {
            if (this.IsEmpty())
            {
                return default(TKey);
            }

            return this.Min(this.root).Key;
        }

        private Node Min(Node x)
        {
            if (x.Left == null)
            {
                return x;
            }
            else
            {
                return this.Min(x.Left);
            }
        }

        public TKey Max()
        {
            if (this.IsEmpty())
            {
                return default(TKey);
            }

            return this.Max(this.root).Key;
        }

        private Node Max(Node x)
        {
            if (x.Left == null)
            {
                return x;
            }
            else
            {
                return this.Max(x.Right);
            }
        }

        public TKey Floor(TKey key)
        {
            Node x = this.Floor(this.root, key);
            if (x == null)
            {
                return default(TKey);
            }
            else
            {
                return x.Key;
            }
        }

        private Node Floor(Node x, TKey key)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = key.CompareTo(x.Key);

            if (cmp == 0)
            {
                return x;
            }

            if (cmp < 0)
            {
                return this.Floor(x.Left, key);
            }

            Node t = this.Floor(x.Right, key);

            if (t != null)
            {
                return t;
            }
            else
            {
                return x;
            }
        }

        public TKey Ceiling(TKey key)
        {
            Node x = this.Ceiling(this.root, key);
            if (x == null)
            {
                return default(TKey);
            }
            else
            {
                return x.Key;
            }
        }

        private Node Ceiling(Node x, TKey key)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = key.CompareTo(x.Key);

            if (cmp == 0)
            {
                return x;
            }

            if (cmp < 0)
            {
                Node t = this.Ceiling(x.Left, key);
                if (t != null)
                {
                    return t;
                }
                else
                {
                    return x;
                }
            }

            return this.Ceiling(x.Right, key);
        }

        /***********************************************************************
         *  Rank and selection
         ***********************************************************************/

        public TKey Select(int k)
        {
            if (k < 0 || k >= this.Size())
            {
                return default(TKey);
            }

            Node x = this.Select(this.root, k);
            return x.Key;
        }

        private Node Select(Node x, int k)
        {
            if (x == null)
            {
                return null;
            }

            int t = this.Size(x.Left);

            if (t > k)
            {
                return this.Select(x.Left, k);
            }
            else if (t < k)
            {
                return this.Select(x.Right, k - t - 1);
            }
            else
            {
                return x;
            }
        }

        public int Rank(TKey key)
        {
            return this.Rank(key, this.root);
        }

        private int Rank(TKey key, Node x)
        {
            if (x == null)
            {
                return 0;
            }

            int cmp = key.CompareTo(x.Key);

            if (cmp < 0)
            {
                return this.Rank(key, x.Left);
            }
            else if (cmp > 0)
            {
                return 1 + this.Size(x.Left) + this.Rank(key, x.Right);
            }
            else
            {
                return this.Size(x.Left);
            }
        }

        /***********************************************************************
         *  Range count and range search.
         ***********************************************************************/

        public IEnumerable<TKey> Keys()
        {
            return this.Keys(this.Min(), this.Max());
        }

        public IEnumerable<TKey> Keys(TKey low, TKey high)
        {
            Queue<TKey> queue = new Queue<TKey>();
            this.Keys(this.root, queue, low, high);
            return queue;
        }

        private void Keys(Node x, Queue<TKey> queue, TKey low, TKey high)
        {
            if (x == null)
            {
                return;
            }

            int cmpLow = low.CompareTo(x.Key);
            int cmpHigh = high.CompareTo(x.Key);

            if (cmpLow < 0)
            {
                this.Keys(x.Left, queue, low, high);
            }

            if (cmpLow <= 0 && cmpHigh >= 0)
            {
                queue.Enqueue(x.Key);
            }

            if (cmpHigh > 0)
            {
                this.Keys(x.Right, queue, low, high);
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

        /// <summary>
        /// Height of this BST (one-node tree has height 0)
        /// </summary>
        public int Height()
        {
            return this.Height(this.root);
        }

        private int Height(Node x)
        {
            if (x == null)
            {
                return -1;
            }

            return 1 + Math.Max(this.Height(x.Left), this.Height(x.Right));
        }

        /// <summary>
        /// Level order traversal
        /// </summary>
        public IEnumerable<TKey> LevelOrder()
        {
            Queue<TKey> keys = new Queue<TKey>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                Node x = queue.Dequeue();
                if (x == null)
                {
                    continue;
                }

                keys.Enqueue(x.Key);
                queue.Enqueue(x.Left);
                queue.Enqueue(x.Right);
            }

            return keys;
        }
    }
}