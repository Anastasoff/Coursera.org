namespace MaxPQ.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MaxPQTest
    {
        private MaxPQ<int> pq;

        [TestMethod]
        public void TestInitialize()
        {
            this.pq = new MaxPQ<int>();
        }

        [TestMethod]
        public void TestPeekShouldReturnMinimumItem()
        {
            this.pq = new MaxPQ<int>();
            this.pq.Insert(2);
            this.pq.Insert(1);

            Assert.AreNotEqual(this.pq.DeleteMax(), this.pq.DeleteMax());
        }

    }
}
