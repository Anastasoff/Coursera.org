namespace AnalysisOfAlgorithms
{
    using System;
    using System.Diagnostics;
    using System.IO;

    internal class Program
    {
        private static void TestBinarySearch()
        {
            int[] array = FileInput();
            int key = int.Parse(Console.ReadLine());

            Array.Sort(array);

            Stopwatch stopwatch = Stopwatch.StartNew();
            // int result = BinarySearch.Iterative(array, key);
            int result = BinarySearch.Recursive(array, key, 0, array.Length - 1);
            stopwatch.Stop();

            Console.WriteLine("Result: {0}", result);
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void TestThreeSumDeluxe()
        {
            int[] array = FileInput();

            Stopwatch stopwatch = Stopwatch.StartNew();
            int count = ThreeSumDeluxe.Count(array);
            stopwatch.Stop();

            Console.WriteLine("Result: {0:N0}", count);
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void TestThreeSum()
        {
            int[] array = FileInput();

            Stopwatch stopwatch = Stopwatch.StartNew();
            int count = ThreeSum.Count(array);
            stopwatch.Stop();

            Console.WriteLine("Result: {0:N0}", count);
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static int[] Input()
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');
            int[] integers = new int[n];
            for (int i = 0; i < n; i++)
            {
                integers[i] = int.Parse(inputs[i]);
            }

            return integers;
        }

        private static int[] FileInput()
        {
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(@"../../array.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File is not found. {0}", ex);
            }

            using (reader)
            {
                int n = int.Parse(reader.ReadLine());
                string[] inputs = reader.ReadLine().Split(' ');
                int[] integers = new int[n];
                for (int i = 0; i < n; i++)
                {
                    integers[i] = int.Parse(inputs[i]);
                }

                return integers;
            }
        }

        private static void Main(string[] args)
        {
            TestThreeSum();

            TestThreeSumDeluxe();

            TestBinarySearch();
        }
    }
}