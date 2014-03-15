namespace MinPQ.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MinPQTest
    {
        private MinPQ<int> pq;

        [TestMethod]
        public void TestInitializeMinPQ()
        {
            this.pq = new MinPQ<int>();
        }

        [TestMethod]
        public void TestDeleteMin()
        {
            this.pq = new MinPQ<int>();
            this.pq.Insert(2);
            this.pq.Insert(1);

            Assert.AreNotEqual(this.pq.DeleteMin(), this.pq.DeleteMin());
        }
    }
}
