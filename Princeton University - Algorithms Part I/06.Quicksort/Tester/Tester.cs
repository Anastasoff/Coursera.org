namespace Tester
{
    using System;
    using Shuffle;
    using Quicksort;
    using System.Diagnostics;
    public class Tester
    {
        private const int SIZE = 1000;

        public static void Main()
        {
            PerformanceTestBuildInSort();
            PerformanceTestQuicksort();
        }

        private static int[] ShuffledArray()
        {
            int[] array = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                array[i] = i;
            }

            array.Shuffle();

            return array;
        }


        /// <summary>
        /// Check if array is sorted - useful for debugging
        /// </summary>
        private static bool IsSorted<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CompareTo(array[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static void PerformanceTestBuildInSort()
        {
            int[] array = ShuffledArray();
            Console.WriteLine("Build in sort:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Array.Sort(array);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("- = end = - \n");
        }

        private static void PerformanceTestQuicksort()
        {
            int[] quicksortArray = ShuffledArray();
            Console.WriteLine("Quick sort:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Quick.Sort(quicksortArray);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("IsSorted: {0}", IsSorted(quicksortArray));
            Console.WriteLine("- = end = - \n");
        }
    }
}