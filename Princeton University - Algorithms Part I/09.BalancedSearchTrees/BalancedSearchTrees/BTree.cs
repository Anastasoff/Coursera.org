namespace BalancedSearchTrees
{
    using System;

    /// <summary>
    /// B-tree
    /// </summary>
    public class BTree<Key, Value> where Key : IComparable<Key>
    {
        private const int Max = 4; // max children per B-tree node = M-1

        private Node root;      // root of the B-tree
        private int ht;         // height of the B-tree
        private int n;          // number of key-value pairs in the B-tree

        /// <summary>
        /// Helper B-tree node data type
        /// </summary>
        private class Node
        {
            // Create a node with k children
            internal Node(int k)
            {
                this.M = k;
                this.Children = new Entry[M];
            }

            public int M { get; set; }              // number of children

            public Entry[] Children { get; set; }   // the array of children
        }

        /// <summary>
        /// Internal nodes: only use key and next
        /// External nodes: only use key and value
        /// </summary>
        private class Entry
        {
            internal Entry(IComparable<Key> key, Value value, Node next)
            {
                this.Key = key;
                this.Value = value;
                this.Next = next;
            }

            public IComparable<Key> Key { get; set; }

            public Value Value { get; set; }

            public Node Next { get; set; } // helper field to iterate over array entries
        }

        public BTree()
        {
            this.root = new Node(0);
            this.ht = 0;
            this.n = 0;
        }

        /// <summary>
        /// Return number of key-value pairs in the B-tree
        /// </summary>
        public int Size()
        {
            return this.n;
        }

        /// <summary>
        /// Return height of B-tree
        /// </summary>
        public int Height()
        {
            return this.ht;
        }

        /// <summary>
        /// Search for given key, return associated value; return null if no such key
        /// </summary>
        public Value Get(Key key)
        {
            return this.Search(this.root, key, this.ht);
        }

        private Value Search(Node x, Key key, int ht)
        {
            Entry[] children = x.Children;

            // external node
            if (this.ht == 0)
            {
                for (int j = 0; j < x.M; j++)
                {
                    if (Equals(key, children[j].Key))
                    {
                        return children[j].Value;
                    }
                }
            }
            else
            {
                for (int j = 0; j < x.M; j++)
                {
                    if (j + 1 == x.M || this.Less(key, children[j + 1].Key)) // ! bad type casting
                    {
                        return this.Search(children[j].Next, key, ht - 1);
                    }
                }
            }

            return default(Value);
        }

        /// <summary>
        /// Insert key-value pair; ad code to check for duplicate keys
        /// </summary>
        public void Put(Key key, Value value)
        {
            Node u = this.Insert(this.root, key, value, this.ht);
            this.n++;

            if (u == null)
            {
                return;
            }

            // need to split root
            Node t = new Node(2);
            t.Children[0] = new Entry(this.root.Children[0].Key, default(Value), this.root);
            t.Children[1] = new Entry(u.Children[0].Key, default(Value), u);
            this.root = t;
            this.ht++;
        }

        private Node Insert(Node h, Key key, Value value, int ht)
        {
            int j;
            Entry t = new Entry(key, value, null);

            // external node
            if (ht == 0)
            {
                for (j = 0; j < h.M; j++)
                {
                    if (this.Less(key, h.Children[j].Key))
                    {
                        break;
                    }
                }
            }
            // internal node
            else
            {
                for (j = 0; j < h.M; j++)
                {
                    if ((j + 1 == h.M) || this.Less(key, h.Children[j + 1].Key))
                    {
                        Node u = this.Insert(h.Children[j++].Next, key, value, ht - 1);
                        if (u == null)
                        {
                            return null;
                        }

                        t.Key = u.Children[0].Key;
                        t.Next = u;
                        break;
                    }
                }
            }

            for (int i = h.M; i > j; i--)
            {
                h.Children[i] = h.Children[i - 1];
            }

            h.Children[j] = t;
            h.M++;
            if (h.M < Max)
            {
                return null;
            }
            else
            {
                return this.Split(h);
            }
        }

        // Split node in half
        private Node Split(Node h)
        {
            Node t = new Node(Max / 2);
            h.M = Max / 2;
            for (int j = 0; j < Max / 2; j++)
            {
                t.Children[j] = h.Children[Max / 2 + j];
            }

            return t;
        }

        private bool Less(IComparable<Key> k1, IComparable<Key> k2)
        {
            return k1.CompareTo((Key)k2) < 0;
        }

        public override string ToString()
        {
            return this.ToString(this.root, this.ht, "") + "\r\n";
        }

        private String ToString(Node h, int ht, string indent)
        {
            string s = string.Empty;
            Entry[] children = h.Children;

            if (ht == 0)
            {
                for (int j = 0; j < h.M; j++)
                {
                    s += indent + children[j].Key + " " + children[j].Value + Environment.NewLine;
                }
            }
            else
            {
                for (int j = 0; j < h.M; j++)
                {
                    if (j > 0)
                    {
                        s += indent + "(" + children[j].Key + ")" + Environment.NewLine;
                    }

                    s += this.ToString(children[j].Next, ht - 1, indent + "     ");
                }
            }

            return s;
        }
    }
}