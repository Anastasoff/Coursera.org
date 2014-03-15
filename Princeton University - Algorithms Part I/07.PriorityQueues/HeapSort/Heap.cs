namespace HeapSort
{
    using System;

    /// <summary>
    /// The Heap class provides a static methods for heapsorting an array.
    /// </summary>
    public class Heap
    {
        // This class should not be instantiated.
        private Heap()
        {
        }

        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// </summary>
        /// <param name="array">The array to be sorted</param>
        public static void Sort<T>(T[] pq) where T : IComparable<T>
        {
            int n = pq.Length;
            for (int k = n / 2; k >= 1; k--)
            {
                Sink(pq, k, n);
            }

            while (n > 1)
            {
                Swap(pq, 1, n--);
                Sink(pq, 1, n);
            }
        }

        private static void Sink<T>(T[] pq, int k, int n) where T : IComparable<T>
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && Less(pq, j, j + 1))
                {
                    j++;
                }

                if (!Less(pq, k, j))
                {
                    break;
                }

                Swap(pq, k, j);
                k = j;
            }
        }

        private static void Swap<T>(T[] array, int a, int b) where T : IComparable<T>
        {
            T swap = array[a];
            array[a] = array[b];
            array[b] = swap;
        }

        private static bool Less<T>(T[] array, int i, int j) where T : IComparable<T>
        {
            return (array[i - 1].CompareTo(array[j - 1]) < 0);
        }

        private static bool Less<T>(T v, T w) where T : IComparable<T>
        {
            return (v.CompareTo(w) < 0);
        }
    }
}