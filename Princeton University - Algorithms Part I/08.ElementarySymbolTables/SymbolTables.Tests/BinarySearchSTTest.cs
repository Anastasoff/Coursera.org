namespace SymbolTables.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinarySearchSTTest
    {
        private ISymbolTable<string, int> st;

        [TestMethod]
        public void TestInitializeBinarySearchST()
        {
            this.st = new BinarySearchST<string, int>();
        }

        [TestMethod]
        public void TestBinarySearchSTTrace()
        {
            this.st = new BinarySearchST<string, int>();
            string[] keys = { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L", "E" };
            for (int i = 0; i < keys.Length; i++)
            {
                st.Put(keys[i], i);
            }

            string[] expectedKeys = { "A", "C", "E", "H", "L", "M", "P", "R", "S", "X" };
            int[] expectedValues = { 8, 4, 12, 5, 11, 9, 10, 3, 0, 7 };

            for (int i = 0; i < expectedKeys.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], st.Get(expectedKeys[i]));
            }
        }
    }
}