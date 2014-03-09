namespace MergeSort
{
    using System;

    /// <summary>
    /// The MergeBU class provides static methods for sorting an array using bottom-up mergesort.
    /// </summary>
    public class MergeBU
    {
        /// <summary>
        /// This class should not be instantiated.
        /// </summary>
        private MergeBU()
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
            for (int k = 1; k < n; k = k + k)
            {
                for (int i = 0; i < n - k; i += k + k)
                {
                    int low = i;
                    int middle = i + k - 1;
                    int high = Math.Min(i + k + k - 1, n - 1);
                    Merge(array, aux, low, middle, high);
                }
            }
        }

        /// <summary>
        /// Stable merge array[low ... high] with array[middle + 1 ... high] using aux[low ... high]
        /// </summary>
        private static void Merge<T>(T[] array, T[] aux, int low, int middle, int high) where T : IComparable<T>
        {
            // copy to aux[]
            for (int k = low; k <= high; k++)
            {
                aux[k] = array[k];
            }

            // merge back to array[]
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
    }
}