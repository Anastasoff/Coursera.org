namespace Quicksort
{
    using System;

    public class QuickX
    {
        // cutoff to insertion sort, must be >= 1
        private const int CUTOFF = 8;

        // This class should not be instantiated.
        private QuickX()
        {
        }

        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// </summary>
        /// <param name="array">The array to be sorted</param>
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            int n = high - (low + 1);

            // cutoff to insertion sort
            if (n <= CUTOFF)
            {
                InsertionSort(array, low, high);
                return;
            }
            // use median-of-3 as partitioning element
            else if (n <= 40)
            {
                int m = MediadThree(array, low, low + (n / 2), high);
                Swap(array, m, low);
            }
            // use Tukey ninther as partitioning element
            else
            {
                int eps = n / 8;
                int mid = low + n / 2;
                int m1 = MediadThree(array, low, low + eps, low + eps + eps);
                int m2 = MediadThree(array, mid - eps, mid, mid + eps);
                int m3 = MediadThree(array, high - eps - eps, high - eps, high);
                int ninther = MediadThree(array, m1, m2, m3);
                Swap(array, ninther, low);
            }

            // Bentley-MCIlroy 3-way partitioning
            int i = low;
            int j = high + 1;
            int p = low;
            int q = high + 1;
            T value = array[low];
            while (true)
            {
                while (Less(array[++i], value))
                {
                    if (i == high)
                    {
                        break;
                    }
                }

                while (Less(value, array[--j]))
                {
                    if (j == low)
                    {
                        break;
                    }
                }

                // pointer cross
                if (i == j && array[i].Equals(value))
                {
                    Swap(array, ++p, i);
                }

                if (i >= j)
                {
                    break;
                }

                Swap(array, i, j);
                if (array[i].Equals(value))
                {
                    Swap(array, ++p, i);
                }

                if (array[j].Equals(value))
                {
                    Swap(array, --q, j);
                }

                i = j + 1;
                for (int k = low; k <= p; k++)
                {
                    Swap(array, k, j--);
                }

                for (int k = high; k >= q; k--)
                {
                    Swap(array, k, i++);
                }

                Sort(array, low, j);
                Sort(array, i, high);
            }
        }

        // sort from array[low] to array[high] using insertion sort
        private static void InsertionSort<T>(T[] array, int low, int high) where T : IComparable<T>
        {
            for (int i = low; i <= high; i++)
            {
                for (int j = i; j > low && Less(array[j], array[j - 1]); j--)
                {
                    Swap(array, j, j - 1);
                }
            }
        }

        // return the index of the median element among array[i], array[j] and array[k]
        private static int MediadThree<T>(T[] array, int i, int j, int k) where T : IComparable<T>
        {
            return (Less(array[i], array[j]) ? (Less(array[j], array[k]) ? j : Less(array[i], array[k]) ? k : i) : (Less(array[k], array[j]) ? j : Less(array[k], array[i]) ? k : i));
        }

        private static void Swap<T>(T[] array, int a, int b) where T : IComparable<T>
        {
            T swap = array[a];
            array[a] = array[b];
            array[b] = swap;
        }

        private static bool Less<T>(T v, T w) where T : IComparable<T>
        {
            return (v.CompareTo(w) < 0);
        }
    }
}