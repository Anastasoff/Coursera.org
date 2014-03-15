using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeapSort.Tests
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        public void TestSortingArrayOfStrings()
        {
            string[] array = { "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E" };
            Heap.Sort(array);
            if (!IsSorted(array))
            {
                throw new InvalidOperationException("The array is NOT sorted.");
            }
        }

        [TestMethod]
        public void TestSortingArrayOfIntegers()
        {
            int[] array = { 5, 2, 7, 1, 0, 3, 9, 4, 6, 8 };
            Heap.Sort(array);
            if (!IsSorted(array))
            {
                throw new InvalidOperationException("The array is NOT sorted.");
            }
        }

        [TestMethod]
        public void TestSortingArrayOfOneInteger()
        {
            int[] array = { 0 };
            Heap.Sort(array);
            if (!IsSorted(array))
            {
                throw new InvalidOperationException("The array is NOT sorted.");
            }
        }

        private static bool IsSorted<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
