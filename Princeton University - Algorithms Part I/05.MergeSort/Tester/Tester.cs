namespace Tester
{
    using MergeSort;
    using System;
    using System.Diagnostics;

    internal class Tester
    {
        private const int SIZE = 20000;

        public static void Main()
        {
            PerformanceTestBuildInSort();

            PerformanceTestMergeSort();
            PerformanceTestMergeXSort();
            PerformanceTestMergeBUSort();
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

        private static int[] RandomIntegerGenerator(int size)
        {
            Random rnd = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(0, 1111);
            }

            return array;
        }

        private static void PerformanceTestBuildInSort()
        {
            int[] array = RandomIntegerGenerator(SIZE);
            Console.WriteLine("Build in sort:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Array.Sort(array);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("- = end = - \n");
        }

        private static void PerformanceTestMergeSort()
        {
            int[] mergeSortArray = RandomIntegerGenerator(SIZE);
            Console.WriteLine("Merge sort:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Merge.Sort(mergeSortArray);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("IsSorted: {0}", IsSorted(mergeSortArray));
            Console.WriteLine("- = end = - \n");
        }

        private static void PerformanceTestMergeXSort()
        {
            int[] mergeXSortArray = RandomIntegerGenerator(SIZE);
            Console.WriteLine("MergeX sort:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Merge.Sort(mergeXSortArray);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("IsSorted: {0}", IsSorted(mergeXSortArray));
            Console.WriteLine("- = end = - \n");
        }

        private static void PerformanceTestMergeBUSort()
        {
            int[] mergeBUSortArray = RandomIntegerGenerator(SIZE);
            Console.WriteLine("MergeBU sort:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Merge.Sort(mergeBUSortArray);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("IsSorted: {0}", IsSorted(mergeBUSortArray));
            Console.WriteLine("- = end = - \n");
        }
    }
}