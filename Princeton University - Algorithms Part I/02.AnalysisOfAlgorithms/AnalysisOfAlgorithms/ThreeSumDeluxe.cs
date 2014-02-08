namespace AnalysisOfAlgorithms
{
    using System;

    internal class ThreeSumDeluxe
    {
        public static int Count(int[] array)
        {
            int n = array.Length;
            Array.Sort(array);
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int k = Array.BinarySearch(array, -(array[i] - array[j]));

                    if (k >= 0 && k > j)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}