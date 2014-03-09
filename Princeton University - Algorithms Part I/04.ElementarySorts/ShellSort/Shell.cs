namespace ShellSort
{
    using System;

    public class Shell
    {
        private Shell()
        {
        }

        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            int n = array.Length;

            int h = 1;
            while (h < n / 2)
            {
                h = (3 * h) + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j >= h && (array[j].CompareTo(array[j - h]) < 0); j -= h)
                    {
                        Swap(array, j, j - h);
                    }
                }

                h /= 3;
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