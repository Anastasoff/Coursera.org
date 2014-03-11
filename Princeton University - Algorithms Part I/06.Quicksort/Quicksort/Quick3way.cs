namespace Quicksort
{
    using System;
    using Shuffle;

    /// <summary>
    /// The Quick3way class provides static methods for sorting an array using quicksort with 3-way partitioning.
    /// </summary>
    public class Quick3way
    {
        // This class should not be instantiated.
        private Quick3way()
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

        // quicksort the subarray array[low ... high] using 3-way partitioning
        private static void Sort<T>(T[] array, int low, int high) where T:IComparable<T>
        {
            if (high <= low)
            {
                return;
            }

            int lt = low;
            int gt = high;
            T value = array[low];
            int i = low;
            while (i <= gt)
            {
                int cmp = array[i].CompareTo(value);
                if (cmp < 0)
                {
                    Swap(array, lt++, i++);
                }
                else if (cmp > 0)
                {
                    Swap(array, i, gt--);
                }
                else
                {
                    i++;
                }
            }

            // array[low ... lt - 1] < value = array[lt ... gt] < array[gt + 1 ... high]
            Sort(array, low, lt - 1);
            Sort(array, gt + 1, high);
        }

        private static void Swap<T>(T[] array, int a, int b) where T:IComparable<T>
        {
            T swap = array[a];
            array[a] = array[b];
            array[b] = swap;
        }
    }
}
