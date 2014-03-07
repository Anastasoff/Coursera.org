namespace InsertionSort
{
    using System;

    public class InsertionX
    {
        private InsertionX()
        {
        }

        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;

            for (int i = n - 1; i > 0; i--)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
                {
                    Swap(array, i, i - 1);
                }
            }

            for (int i = 2; i < n; i++)
            {
                T value = array[i];
                int j = i;
                while (value.CompareTo(array[j - 1]) < 0)
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = value;
            }
        }

        private static void Swap<T>(T[] array, int j, int x)
        {
            T swap = array[j];
            array[j] = array[x];
            array[x] = swap;
        }
    }
}