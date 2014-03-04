namespace SelectionSort
{
    using System;

    public class SelectionSort
    {
        private SelectionSort()
        {
        }

        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j].CompareTo(array[min]) < 0)
                    {
                        min = j;
                    }
                }

                Swap(array, i, min);
            }
        }

        private static void Swap<T>(T[] array, int i, int min)
        {
            T swap = array[i];
            array[i] = array[min];
            array[min] = swap;
        }
    }
}