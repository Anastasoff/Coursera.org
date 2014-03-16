namespace Tester
{
    using SymbolTables;
    using System;

    public class Tester
    {
        private static string[] Keys = { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L", "E" };
        private static string[] ExpectedKeys = { "A", "C", "E", "H", "L", "M", "P", "R", "S", "X" };
        private static int[] ExpectedValues = { 8, 4, 12, 5, 11, 9, 10, 3, 0, 7 };

        public static void Main()
        {
            TestBinarySearchST();
            TestSequentialSearchST();
        }

        public static void TestBinarySearchST()
        {
            var st = new BinarySearchST<string, int>();
            for (int i = 0; i < Keys.Length; i++)
            {
                st.Put(Keys[i], i);
            }

            PrintOutput(st);
        }

        public static void TestSequentialSearchST()
        {
            var st = new SequentialSearchST<string, int>();
            for (int i = 0; i < Keys.Length; i++)
            {
                st.Put(Keys[i], i);
            }

            PrintOutput(st);
        }

        public static void PrintOutput<Key, Value>(ISymbolTable<Key, Value> st)
        {
            Console.WriteLine("> Output <");
            Console.WriteLine(new string('-', 10));
            foreach (var s in st.Keys())
            {
                Console.WriteLine("| {0} | {1,2} |", s, st.Get(s));
            }

            Console.WriteLine(new string('#', 10));
        }
    }
}