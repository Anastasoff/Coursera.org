namespace MergeSort
{
    using System;

    /// <summary>
    /// The Merge class provides static methods for sorting an array using mergesort.
    /// </summary>
    public class Merge
    {
        /// <summary>
        /// This class should not be instantiated.
        /// </summary>
        private Merge()
        {
        }

        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// </summary>
        /// <param name="array">Array to be sorted</param>
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            T[] aux = new T[array.Length];
            TopDownSplitMerge(array, aux, 0, array.Length - 1);
        }

        /// <summary>
        /// Stable merge array[low ... middle] with array[middle + 1 ... high] using  aux[low ... high].
        /// </summary>
        private static void TopDownMerge<T>(T[] array, T[] aux, int low, int middle, int high) where T : IComparable<T>
        {
            // Copy to aux[]
            for (int k = low; k <= high; k++)
            {
                aux[k] = array[k];
            }

            // Merge back to array[]
            int i = low;
            int j = middle + 1;
            for (int k = low; k <= high; k++)
            {
                if (i > middle)
                {
                    array[k] = aux[j++];
                }
                else if (j > high)
                {
                    array[k] = aux[i++];
                }
                else if (aux[j].CompareTo(aux[i]) < 0)
                {
                    array[k] = aux[j++];
                }
                else
                {
                    array[k] = aux[i++];
                }
            }
        }

        /// <summary>
        /// Merge sort array[low ... high] using auxiliary array aux[low ... high]
        /// </summary>
        private static void TopDownSplitMerge<T>(T[] array, T[] aux, int low, int high) where T : IComparable<T>
        {
            if (high <= low)
            {
                return;
            }

            int middle = low + ((high - low) / 2);
            TopDownSplitMerge(array, aux, low, middle);
            TopDownSplitMerge(array, aux, middle + 1, high);
            TopDownMerge(array, aux, low, middle, high);
        }
    }
}