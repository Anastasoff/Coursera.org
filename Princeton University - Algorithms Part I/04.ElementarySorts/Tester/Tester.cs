namespace Tester
{
    using System;
    using System.Diagnostics;

    using BubbleSort;
    using InsertionSort;
    using SelectionSort;
    using ShellSort;

    internal class Tester
    {
        private static void Main(string[] args)
        {
            SelectionSort();
            InsertionSort();
            InsertionXSort();
            ShellSort();
            BubbleSort();

            PerformanceTestSelectionSort();
            PerformanceTestInsertionSort();
            PerformanceTestInsertionXSort();
            PerformanceTestShellSort();
            PerformanceTestBubbleSort();
            PerformanceTestBuildInSort();
        }

        #region Performance tests

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

        private static void PerformanceTestSelectionSort()
        {
            Console.WriteLine("Selection sort:");
            int[] selectionSortArray = RandomIntegerGenerator(10000);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Selection.Sort(selectionSortArray);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("- = end = - \n");
        }

        private static void PerformanceTestInsertionSort()
        {
            Console.WriteLine("Insertion sort:");
            int[] insertionSortArray = RandomIntegerGenerator(10000);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Insertion.Sort(insertionSortArray);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("- = end = - \n");
        }

        private static void PerformanceTestInsertionXSort()
        {
            Console.WriteLine("InsertionX sort:");
            int[] insertionXSortArray = RandomIntegerGenerator(10000);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Insertion.Sort(insertionXSortArray);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("- = end = - \n");
        }

        private static void PerformanceTestShellSort()
        {
            Console.WriteLine("Shell sort:");
            int[] shellSortArray = RandomIntegerGenerator(10000);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Insertion.Sort(shellSortArray);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("- = end = - \n");
        }

        private static void PerformanceTestBubbleSort()
        {
            Console.WriteLine("Bubble sort:");
            int[] bubbleSortArray = RandomIntegerGenerator(10000);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Bubble.Sort(bubbleSortArray);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("- = end = - \n");
        }

        private static void PerformanceTestBuildInSort()
        {
            Console.WriteLine("Build in sort:");
            int[] array = RandomIntegerGenerator(10000);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Array.Sort(array);
            stopwatch.Stop();
            Console.WriteLine("Time taken: {0}ms;", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("- = end = - \n");
        }

        #endregion Performance tests

        #region Test Methods

        private static void SelectionSort()
        {
            Console.WriteLine("Selection sort:");
            int[] arrayOfIntegers = new int[] { 7, 10, 5, 3, 8, 4, 2, 9, 6, 1 };
            double[] arrayOfDoubles = new double[] { 1.5, 6.8, 3.6, 5.5, 1.5, 0.2 };
            var cars = new Car[]
            {
                new Car("BMW", "E12", 1972),
                new Car("BMW", "E28", 1981),
                new Car("BMW", "E34", 1988),
                new Car("BMW", "E39", 1995),
                new Car("BMW", "E60", 2003),
                new Car("BMW", "F10", 2010)
            };

            Selection.Sort(arrayOfIntegers);
            Console.WriteLine(string.Join(", ", arrayOfIntegers));

            Selection.Sort(arrayOfDoubles);
            Console.WriteLine(string.Join(", ", arrayOfDoubles));

            Selection.Sort(cars);
            foreach (var car in cars)
            {
                Console.WriteLine("-> " + car);
            }

            Console.WriteLine(" - = end = - \n");
        }

        private static void InsertionSort()
        {
            Console.WriteLine("Insertion sort:");
            int[] arrayOfIntegers = new int[] { 7, 10, 5, 3, 8, 4, 2, 9, 6, 1 };
            double[] arrayOfDoubles = new double[] { 1.5, 6.8, 3.6, 5.5, 1.5, 0.2 };
            var cars = new Car[]
            {
                new Car("BMW", "E12", 1972),
                new Car("BMW", "E28", 1981),
                new Car("BMW", "E34", 1988),
                new Car("BMW", "E39", 1995),
                new Car("BMW", "E60", 2003),
                new Car("BMW", "F10", 2010)
            };

            Insertion.Sort(arrayOfIntegers);
            Console.WriteLine(string.Join(", ", arrayOfIntegers));

            Insertion.Sort(arrayOfDoubles);
            Console.WriteLine(string.Join(", ", arrayOfDoubles));

            Insertion.Sort(cars);
            foreach (var car in cars)
            {
                Console.WriteLine("-> " + car);
            }

            Console.WriteLine(" - = end = - \n");
        }

        private static void InsertionXSort()
        {
            Console.WriteLine("InsertionX sort:");
            int[] arrayOfIntegers = new int[] { 7, 10, 5, 3, 8, 4, 2, 9, 6, 1 };
            double[] arrayOfDoubles = new double[] { 1.5, 6.8, 3.6, 5.5, 1.5, 0.2 };
            var cars = new Car[]
            {
                new Car("BMW", "E12", 1972),
                new Car("BMW", "E28", 1981),
                new Car("BMW", "E34", 1988),
                new Car("BMW", "E39", 1995),
                new Car("BMW", "E60", 2003),
                new Car("BMW", "F10", 2010)
            };

            InsertionX.Sort(arrayOfIntegers);
            Console.WriteLine(string.Join(", ", arrayOfIntegers));

            InsertionX.Sort(arrayOfDoubles);
            Console.WriteLine(string.Join(", ", arrayOfDoubles));

            InsertionX.Sort(cars);
            foreach (var car in cars)
            {
                Console.WriteLine("-> " + car);
            }

            Console.WriteLine(" - = end = - \n");
        }

        private static void ShellSort()
        {
            Console.WriteLine("Shell sort:");
            int[] arrayOfIntegers = new int[] { 7, 10, 5, 3, 8, 4, 2, 9, 6, 1 };
            double[] arrayOfDoubles = new double[] { 1.5, 6.8, 3.6, 5.5, 1.5, 0.2 };
            var cars = new Car[]
            {
                new Car("BMW", "E12", 1972),
                new Car("BMW", "E28", 1981),
                new Car("BMW", "E34", 1988),
                new Car("BMW", "E39", 1995),
                new Car("BMW", "E60", 2003),
                new Car("BMW", "F10", 2010)
            };

            Shell.Sort(arrayOfIntegers);
            Console.WriteLine(string.Join(", ", arrayOfIntegers));

            Shell.Sort(arrayOfDoubles);
            Console.WriteLine(string.Join(", ", arrayOfDoubles));

            Shell.Sort(cars);
            foreach (var car in cars)
            {
                Console.WriteLine("-> " + car);
            }

            Console.WriteLine(" - = end = - \n");
        }

        private static void BubbleSort()
        {
            Console.WriteLine("Bubble sort:");
            int[] arrayOfIntegers = new int[] { 7, 10, 5, 3, 8, 4, 2, 9, 6, 1 };
            double[] arrayOfDoubles = new double[] { 1.5, 6.8, 3.6, 5.5, 1.5, 0.2 };
            var cars = new Car[]
            {
                new Car("BMW", "E12", 1972),
                new Car("BMW", "E28", 1981),
                new Car("BMW", "E34", 1988),
                new Car("BMW", "E39", 1995),
                new Car("BMW", "E60", 2003),
                new Car("BMW", "F10", 2010)
            };

            Bubble.Sort(arrayOfIntegers);
            Console.WriteLine(string.Join(", ", arrayOfIntegers));

            Bubble.Sort(arrayOfDoubles);
            Console.WriteLine(string.Join(", ", arrayOfDoubles));

            Bubble.Sort(cars);
            foreach (var car in cars)
            {
                Console.WriteLine("-> " + car);
            }

            Console.WriteLine(" - = end = - \n");
        }

        #endregion Test Methods
    }
}