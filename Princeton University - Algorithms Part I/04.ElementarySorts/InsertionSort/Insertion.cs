namespace InsertionSort
{
    using System;

    public class Insertion
    {
        private Insertion()
        {
        }

        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j].CompareTo(array[j - 1]) < 0)
                    {
                        Swap(array, j, j - 1);
                    }
                    else
                    {
                        break;
                    }
                }
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