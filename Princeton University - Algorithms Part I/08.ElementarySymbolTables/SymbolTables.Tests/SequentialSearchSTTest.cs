using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SymbolTables.Tests
{
    [TestClass]
    public class SequentialSearchSTTest
    {
        private SequentialSearchST<string, int> st;

        [TestMethod]
        public void TestInitializeSequentialSearchST()
        {
            this.st = new SequentialSearchST<string, int>();
        }

        [TestMethod]
        public void TestTrace()
        {
            this.st = new SequentialSearchST<string, int>();
            string[] keys = { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L", "E" };
            for (int i = 0; i < keys.Length; i++)
            {
                st.Put(keys[i], i);
            }

            string[] expectedKeys = { "A", "C", "E", "H", "L", "M", "P", "R", "S", "X" };
            foreach (var s in this.st.Keys())
            {
                Console.WriteLine(s);
            }


            int[] expectedValues = { 8, 4, 12, 5, 11, 9, 10, 3, 0, 7 };
        }
    }
}
