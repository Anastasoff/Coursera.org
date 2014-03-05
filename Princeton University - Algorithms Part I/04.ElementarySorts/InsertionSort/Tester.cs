namespace InsertionSort
{
    using System;

    internal class Tester
    {
        private static void Main(string[] args)
        {
            int[] arrayOfIntegers = new int[] { 7, 10, 5, 3, 8, 4, 2, 9, 6 };
            Insertion.Sort(arrayOfIntegers);
            Console.WriteLine(string.Join(", ", arrayOfIntegers));
        }
    }
}