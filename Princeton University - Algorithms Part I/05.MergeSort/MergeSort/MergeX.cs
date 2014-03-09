namespace MergeSort
{
    using System;

    /// <summary>
    /// The MergeX class provides static methods for sorting an array using an optimized version of mergesort.
    /// </summary>
    public class MergeX
    {
        // cutoff to insertion sort
        private const int CUTOFF = 7;

        /// <summary>
        /// This class should not be instantiated.
        /// </summary>
        private MergeX()
        {
        }

        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// </summary>
        /// <param name="array">The array to be sorted</param>
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            T[] aux = new T[n];
            for (int i = 0; i < n; i++)
            {
                aux[i] = array[i];
            }

            TopDownSplitMergeX(aux, array, 0, n - 1);
        }

        private static void TopDownMergeX<T>(T[] src, T[] dst, int low, int middle, int high) where T : IComparable<T>
        {
            int i = low;
            int j = middle + 1;
            for (int k = low; k <= high; k++)
            {
                if (i > middle)
                {
                    dst[k] = src[j++];
                }
                else if (j > high)
                {
                    dst[k] = src[i++];
                }
                else if (src[j].CompareTo(src[i]) < 0) // to ensure stability
                {
                    dst[k] = src[j++];
                }
                else
                {
                    dst[k] = src[i++];
                }
            }
        }

        private static void TopDownSplitMergeX<T>(T[] src, T[] dst, int low, int high) where T : IComparable<T>
        {
            if (high <= low + CUTOFF)
            {
                InsertionSort(dst, low, high);
                return;
            }

            int middle = low + ((high - low) / 2);
            TopDownSplitMergeX(dst, src, low, high);
            TopDownSplitMergeX(dst, src, middle + 1, high);
            if (!(src[middle + 1].CompareTo(src[middle]) < 0))
            {
                Array.Copy(src, low, dst, low, high - low + 1);
                return;
            }

            TopDownMergeX(src, dst, low, middle, high);
        }

        // sort from array[low] to array[high] using insertion sort
        private static void InsertionSort<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            for (int i = low; i <= high; i++)
            {
                for (int j = i; j > low && (array[j].CompareTo(array[j - 1]) < 0); j--)
                {
                    T swap = array[i];
                    array[i] = array[j];
                    array[j] = swap;
                }
            }
        }
    }
}