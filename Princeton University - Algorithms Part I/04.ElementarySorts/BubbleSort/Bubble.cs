namespace BubbleSort
{
    using System;

    public class Bubble
    {
        private Bubble()
        {
        }

        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        private static void Swap<T>(T[] array, int x, int y)
        {
            T swap = array[x];
            array[x] = array[y];
            array[y] = swap;
        }
    }
}