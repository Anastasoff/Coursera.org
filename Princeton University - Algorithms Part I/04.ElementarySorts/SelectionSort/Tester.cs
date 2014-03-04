using System;
using System.Collections.Generic;

namespace SelectionSort
{
    internal class Tester
    {
        private static void Main()
        {
            int[] arrayOfIntegers = new int[] { 7, 10, 5, 3, 8, 4, 2, 9, 6 };
            SelectionSort.Sort(arrayOfIntegers);
            Console.WriteLine(string.Join(", ", arrayOfIntegers));

            double[] arrayOfDoubles = new double[] { 1.5, 6.8, 3.6, 5.5, 1.5, 0.2 };
            SelectionSort.Sort(arrayOfDoubles);
            Console.WriteLine(string.Join(", ", arrayOfDoubles));

            var cars = new Car[] 
            {
               new Car("BMW", "E34", 1989),
               new Car("BMW", "E39", 1998),
               new Car("BMW", "E60", 2003)
            };
            SelectionSort.Sort(cars);
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}