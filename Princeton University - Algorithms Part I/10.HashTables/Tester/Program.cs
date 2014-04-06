namespace Tester
{
    using System;

    public class Program
    {
        public static void Main()
        {
            GetValueTypesHashCode();
        }

        public static void GetValueTypesHashCode()
        {
            Console.WriteLine("Int32: \t123456 => " + (123456).GetHashCode());

            Console.WriteLine("Int64: \t1234567890 => " + (1234567890L).GetHashCode());

            Console.WriteLine("Single: 123.456F => " + (123.456F).GetHashCode());

            Console.WriteLine("Double: 123.456 => " + (123.456).GetHashCode());

            Console.WriteLine("Decimal: 123.456M => " + (123.456M).GetHashCode());

            Console.WriteLine("Boolean: True => " + (true).GetHashCode());

            Console.WriteLine("Char: \t'A' => " + ('A').GetHashCode());

            Console.WriteLine("String: \"String\" => " + ("String").GetHashCode());
        }
    }
}