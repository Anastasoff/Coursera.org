using System;
using System.Diagnostics;

namespace AnalysisOfAlgorithms
{
    internal class ThreeSum
    {
        public static int Count(int[] a)
        {
            int n = a.Length;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (a[i] + a[j] + a[k] == 0)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
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

        private static void Main(string[] args)
        {
            int[] a = Input();

            Stopwatch sw = Stopwatch.StartNew();
            int count = Count(a);
            sw.Stop();
            Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);

            Console.WriteLine("Result:");
            Console.WriteLine(count);
        }
    }
}