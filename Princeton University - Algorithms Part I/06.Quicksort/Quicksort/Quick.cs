namespace Quicksort
{
    using System;
    using Shuffle;

    /// <summary>
    /// The Quick class provides static methods for sorting an array and selecting the ith smallest element in an array using quicksort.
    /// </summary>
    public class Quick
    {
        // This class should not be instantiated.
        private Quick()
        {
        }

        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// </summary>
        /// <param name="array">The array to be sorted</param>
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            array.Shuffle();
            Sort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Rearranges the array so that array[k] contains the kth smallest key;
        /// array[0] through array[k - 1] are less than (or equal to) array[k];
        /// array[k + 1] through array[N - 1] are greater than (or equal to) array[k].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IComparable<T> Select<T>(T[] array, int k) where T : IComparable<T>
        {
            if (k < 0 || k >= array.Length)
            {
                throw new IndexOutOfRangeException("Selected element is out of range.");
            }

            int low = 0;
            int high = array.Length - 1;
            while (high > low)
            {
                int i = Partition(array, low, high);
                if (i > k)
                {
                    high = i - 1;
                }
                else if (i < k)
                {
                    low = i + 1;
                }
                else
                {
                    return array[i];
                }
            }

            return array[low];
        }

        /// Quicksort the subarray from array[low] to array[high]
        private static void Sort<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            if (high <= low)
            {
                return;
            }

            int j = Partition(array, low, high);
            Sort(array, low, j - 1);
            Sort(array, j + 1, high);
        }

        // Partition the subarray array[low ... high] so that array[low ... j - 1] <= array[j] <= array[j + 1 ... high] and return the index j.
        private static int Partition<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            int i = low;
            int j = high + 1;
            T value = array[low];
            while (true)
            {
                // find item on low to swap
                while (array[++i].CompareTo(value) < 0)
                {
                    if (i == high)
                    {
                        break;
                    }
                }

                // find item on high to swap
                while (value.CompareTo(array[--j]) < 0)
                {
                    // redundant since array[low] acts as sentinel
                    if (j == low)
                    {
                        break;
                    }
                }

                // check if pointers cross
                if (i >= j)
                {
                    break;
                }

                Swap(array, i, j);
            }

            // put partitioning item value at array[j]
            Swap(array, low, j);

            // now, array[low ... j - 1] <= array[j] <= array{j + 1 ... high]
            return j;
        }

        private static void Swap<T>(T[] array, int i, int j) where T : IComparable<T>
        {
            T swap = array[i];
            array[i] = array[j];
            array[j] = swap;
        }
    }
}