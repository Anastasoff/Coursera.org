using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeapSort.Tests
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSort()
        {
            string[] array = { "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E" };
            Heap.Sort(array);
            if (IsSorted(array))
            {
                throw new InvalidOperationException("The array is NOT sorted.");
            }
        }

        public static bool IsSorted<T>(T[] array) where T : IComparable<T>
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
