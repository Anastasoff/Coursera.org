namespace Tester
{
    using SymbolTables;
    using System;

    public class Tester
    {
        private static string[] keys = { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L", "E" };
        private static string[] expectedKeys = { "A", "C", "E", "H", "L", "M", "P", "R", "S", "X" };
        private static int[] expectedValues = { 8, 4, 12, 5, 11, 9, 10, 3, 0, 7 };

        public static void Main()
        {
            TestBinarySearchTree();
            TestBinarySearchST();
            TestSequentialSearchST();
        }

        public static void TestBinarySearchTree()
        {
            var st = new BinarySearchTree<string, int>();
            for (int i = 0; i < keys.Length; i++)
            {
                st.Put(keys[i], i);
            }

            Console.WriteLine(">BinarySearchTree");
            PrintOutput(st);
        }

        public static void TestBinarySearchST()
        {
            var st = new BinarySearchST<string, int>();
            for (int i = 0; i < keys.Length; i++)
            {
                st.Put(keys[i], i);
            }

            Console.WriteLine(">BinarySearchST");
            PrintOutput(st);
        }

        public static void TestSequentialSearchST()
        {
            var st = new SequentialSearchST<string, int>();
            for (int i = 0; i < keys.Length; i++)
            {
                st.Put(keys[i], i);
            }

            Console.WriteLine(">SequentialSearchST");
            PrintOutput(st);
        }

        public static void PrintOutput<TKey, TValue>(ISymbolTable<TKey, TValue> st)
        {
            Console.Write("| Actual |");
            Console.WriteLine("Expected|");
            Console.WriteLine(new string('-', 19));
            int i = 0;
            foreach (var s in st.Keys())
            {
                Console.Write("| {0} | {1,2} |", s, st.Get(s));
                Console.WriteLine(" {0} | {1,2} |", expectedKeys[i], expectedValues[i]);
                i++;
            }

            Console.WriteLine(new string('#', 19));
            Console.WriteLine();
        }
    }
}