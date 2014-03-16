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
    }
}
