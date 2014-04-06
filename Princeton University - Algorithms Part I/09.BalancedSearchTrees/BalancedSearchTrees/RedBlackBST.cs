namespace BalancedSearchTrees
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A symbol table implemented using a left-leaning red-black BST.
    /// This is the 2-3 version.
    /// </summary>
    public class RedBlackBST<Key, Value> where Key : IComparable<Key>
    {
        private const bool RED = true;
        private const bool BLACK = false;

        private Node root; // root of the BST

        /// <summary>
        /// BST helper node data type
        /// </summary>
        private class Node
        {
            public Node(Key key, Value value, bool color, int n)
            {
                this.Key = key;
                this.Value = value;
                this.Color = color;
                this.N = n;
            }

            public Key Key { get; set; }        // key

            public Value Value { get; set; }    // value

            public Node Left { get; set; }      // link to left subtrees

            public Node Right { get; set; }     // link to right subtrees

            public bool Color { get; set; }     // color of parent link

            public int N { get; set; }          // subtree count
        }

        #region Node helper methods

        // Is node x red; false if x is null?
        private bool IsRed(Node x)
        {
            if (x == null)
            {
                return false;
            }

            return (x.Color == RED);
        }

        // Number of node is subtree rooted at x; 0 if x is null
        private int Size(Node x)
        {
            if (x == null)
            {
                return 0;
            }
            return x.N;
        }

        #endregion Node helper methods

        #region Size methods

        /// <summary>
        /// Return number of key-value pairs in this symbol table
        /// </summary>
        public int Size()
        {
            return this.Size(root);
        }

        /// <summary>
        /// Is this symbol table empty?
        /// </summary>
        public bool IsEmpty()
        {
            return this.root == null;
        }

        #endregion Size methods

        #region Standard BST search

        /// <summary>
        /// Value associated with the given key; null if no such key
        /// </summary>
        public Value Get(Key key)
        {
            return this.Get(root, key);
        }

        // value associated with the given key in subtree rooted at x; null if no such key
        private Value Get(Node x, Key key)
        {
            while (x != null)
            {
                int cmp = key.CompareTo(x.Key);

                if (cmp < 0)
                {
                    x = x.Left;
                }
                else if (cmp > 0)
                {
                    x = x.Right;
                }
                else
                {
                    return x.Value;
                }
            }

            return default(Value);
        }

        /// <summary>
        /// Is there a key-value pair with the given key?
        /// </summary>
        public bool Contains(Key key)
        {
            return (this.Get(key) != null);
        }

        // Is there a key-value pair with the given key in the subtree rooted at x?
        private bool Contains(Node x, Key key)
        {
            return (this.Get(x, key) != null);
        }

        #endregion Standard BST search

        #region Red-black insertion

        /// <summary>
        /// Insert the key-value pair; overwrite the old value with the new value if the key is already present
        /// </summary>
        public void Put(Key key, Value value)
        {
            this.root = this.Put(root, key, value);
            this.root.Color = BLACK;
        }

        // Insert the key-value pair in the subtree rooted at h
        private Node Put(Node h, Key key, Value value)
        {
            if (h == null)
            {
                return new Node(key, value, RED, 1);
            }

            int cmp = key.CompareTo(h.Key);
            if (cmp < 0)
            {
                h.Left = this.Put(h.Left, key, value);
            }
            else if (cmp > 0)
            {
                h.Right = this.Put(h.Right, key, value);
            }
            else
            {
                h.Value = value;
            }

            // fix-up any right-leaning links
            if (this.IsRed(h.Right) && !this.IsRed(h.Left))
            {
                h = this.RotateLeft(h);
            }

            if (this.IsRed(h.Left) && this.IsRed(h.Left.Left))
            {
                h = this.RotateRight(h);
            }

            if (this.IsRed(h.Left) && this.IsRed(h.Right))
            {
                this.FlipColors(h);
            }

            h.N = this.Size(h.Left) + this.Size(h.Right) + 1;

            return h;
        }

        #endregion Red-black insertion

        #region Red-black deletion

        /// <summary>
        /// Delete the key-value pair with the minimum key
        /// </summary>
        public void DeleteMin()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentException("BST underflow");
            }

            // if both children of root are black, set root to red
            if (!this.IsRed(this.root.Left) && !this.IsRed(this.root.Right))
            {
                this.root.Color = RED;
            }

            this.root = this.DeleteMin(this.root);

            if (!this.IsEmpty())
            {
                this.root.Color = BLACK;
            }
        }

        // Delete the key-value pair with the minimum key rooted at h
        private Node DeleteMin(Node h)
        {
            if (h.Left == null)
            {
                return null;
            }

            if (!this.IsRed(h.Left) && !this.IsRed(h.Left.Left))
            {
                h = this.MoveRedLeft(h);
            }

            h.Left = this.DeleteMin(h.Left);

            return this.Balance(h);
        }

        /// <summary>
        /// Delete the key-value pair with the maximum key
        /// </summary>
        public void DeleteMax()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentException("BST underflow");
            }

            // if both children of root are black, set root to red
            if (!this.IsRed(this.root.Left) && !this.IsRed(this.root.Right))
            {
                this.root.Color = RED;
            }

            this.root = this.DeleteMax(this.root);

            if (!this.IsEmpty())
            {
                this.root.Color = BLACK;
            }
        }

        // Delete the key-value pair with the maximum key rooted at h
        private Node DeleteMax(Node h)
        {
            if (this.IsRed(h.Left))
            {
                h = this.RotateRight(h);
            }

            if (h.Right == null)
            {
                return null;
            }

            if (!this.IsRed(h.Right) && !this.IsRed(h.Right.Left))
            {
                h = this.MoveRedLeft(h);
            }

            return this.Balance(h);
        }

        /// <summary>
        /// Delete the key-value pair with the given key
        /// </summary>
        public void Delete(Key key)
        {
            if (!this.Contains(key))
            {
                throw new ArgumentException("Symbol table does not contain " + key);
            }

            // if both children of root are black, set root to red
            if (!this.IsRed(this.root.Left) && !this.IsRed(this.root.Right))
            {
                this.root.Color = RED;
            }

            this.root = this.Delete(this.root, key);

            if (!this.IsEmpty())
            {
                this.root.Color = BLACK;
            }
        }

        // Delete the key-value pair with the given key rooted at h
        private Node Delete(Node h, Key key)
        {
            if (key.CompareTo(h.Key) < 0)
            {
                if (!this.IsRed(h.Left) && !this.IsRed(h.Left.Left))
                {
                    h = this.MoveRedLeft(h);
                }

                h.Left = this.Delete(h.Left, key);
            }
            else
            {
                if (this.IsRed(h.Left))
                {
                    h = this.RotateRight(h);
                }

                if (key.CompareTo(h.Key) == 0 && h.Right == null)
                {
                    return null;
                }

                if (!this.IsRed(h.Right) && !this.IsRed(h.Right.Left))
                {
                    h = this.MoveRedRight(h);
                }

                if (key.CompareTo(h.Key) == 0)
                {
                    Node x = this.Min(h.Right);
                    h.Key = x.Key;
                    h.Value = x.Value;
                    h.Right = this.DeleteMin(h.Right);
                }
                else
                {
                    h.Right = this.Delete(h.Right, key);
                }
            }

            return this.Balance(h);
        }

        #endregion Red-black deletion

        #region Red-black tree helper functions

        // Make a left-leaning link lean to the right
        private Node RotateRight(Node h)
        {
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = x.Right.Color;
            x.Right.Color = RED;
            x.N = h.N;
            h.N = this.Size(h.Left) + this.Size(h.Right) + 1;

            return x;
        }

        // Make right-leaning link lean to the left
        private Node RotateLeft(Node h)
        {
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = x.Left.Color;
            x.Left.Color = RED;
            x.N = h.N;
            h.N = this.Size(h.Left) + this.Size(h.Right) + 1;

            return x;
        }

        // Flip the colors of a node and its two children
        private void FlipColors(Node h)
        {
            h.Color = !h.Color;
            h.Left.Color = !h.Left.Color;
            h.Right.Color = !h.Right.Color;
        }

        // Assuming that h is red and both h.Left and h.Left.Left are black, make h.Left or one of its children red.
        private Node MoveRedLeft(Node h)
        {
            this.FlipColors(h);
            if (this.IsRed(h.Right.Left))
            {
                h.Right = this.RotateRight(h.Right);
                h = this.RotateLeft(h);
            }

            return h;
        }

        // Assuming that h is red and both h.Right and h.Right are black, make h.Right or one of its children red.
        private Node MoveRedRight(Node h)
        {
            this.FlipColors(h);
            if (this.IsRed(h.Left.Left))
            {
                h = this.RotateRight(h);
            }

            return h;
        }

        // Restore red-black tree invariant
        private Node Balance(Node h)
        {
            if (this.IsRed(h.Right))
            {
                h = this.RotateLeft(h);
            }

            if (this.IsRed(h.Left) && this.IsRed(h.Left.Left))
            {
                h = this.RotateRight(h);
            }

            if (this.IsRed(h.Left) && this.IsRed(h.Right))
            {
                this.FlipColors(h);
            }

            h.N = this.Size(h.Left) + this.Size(h.Right) + 1;

            return h;
        }

        #endregion Red-black tree helper functions

        #region Utility functions

        /// <summary>
        /// Height of the tree (1-node tree has hight 0)
        /// </summary>
        /// <returns></returns>
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

        #endregion Utility functions

        #region Ordered Symbol table methods

        /// <summary>
        /// The smallest key; null if no such key
        /// </summary>
        public Key Min()
        {
            if (this.IsEmpty())
            {
                return default(Key);
            }

            return this.Min(this.root).Key;
        }

        // The smallest key in subtree rooted at x; null if no such key
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

        /// <summary>
        /// The largest key; null if no such key
        /// </summary>
        public Key Max()
        {
            if (this.IsEmpty())
            {
                return default(Key);
            }

            return this.Max(this.root).Key;
        }

        // The largest key in the subtree rooted at z; null if no such key
        private Node Max(Node x)
        {
            if (x.Right == null)
            {
                return x;
            }
            else
            {
                return this.Max(x.Right);
            }
        }

        /// <summary>
        /// The largest key less than or equal to the given key
        /// </summary>
        public Key Floor(Key key)
        {
            Node x = this.Floor(this.root, key);

            if (x == null)
            {
                return default(Key);
            }
            else
            {
                return x.Key;
            }
        }

        // The largest key in the subtree rooted at x less than or equal to the given key
        private Node Floor(Node x, Key key)
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

        /// <summary>
        /// The smallest key greater than or equal to the given key
        /// </summary>
        public Key Ceiling(Key key)
        {
            Node x = this.Ceiling(this.root, key);

            if (x == null)
            {
                return default(Key);
            }
            else
            {
                return x.Key;
            }
        }

        // The smallest key in the subtree rooted at x greater than or equal to the given key
        private Node Ceiling(Node x, Key key)
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

            if (cmp > 0)
            {
                return this.Ceiling(x.Right, key);
            }

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

        /// <summary>
        /// The key of rank k
        /// </summary>
        public Key Select(int k)
        {
            if (k < 0 || k >= this.Size())
            {
                return default(Key);
            }

            Node x = this.Select(this.root, k);

            return x.Key;
        }

        // The key of rank k in the subtree rooted at x
        private Node Select(Node x, int k)
        {
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

        /// <summary>
        /// Number of keys less than key
        /// </summary>
        public int Rank(Key key)
        {
            return this.Rank(key, this.root);
        }

        // Number of keys less than key in the subtree rooted at x
        private int Rank(Key key, Node x)
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

        #endregion Ordered Symbol table methods

        #region Range count and range search

        /// <summary>
        /// All of the keys, as an IEnumerable
        /// </summary>
        public IEnumerable<Key> Keys()
        {
            return this.Keys(this.Min(), this.Max());
        }

        /// <summary>
        /// The keys between low and high, as an IEnumerable
        /// </summary>
        public IEnumerable<Key> Keys(Key low, Key high)
        {
            Queue<Key> queue = new Queue<Key>();
            this.Keys(this.root, queue, low, high);
            return queue;
        }

        // Add the keys between lo and hi in the subtree rooted at x to the queue
        private void Keys(Node x, Queue<Key> queue, Key low, Key high)
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

        /// <summary>
        /// Number keys between low and high
        /// </summary>
        public int Size(Key low, Key high)
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

        #endregion Range count and range search
    }
}