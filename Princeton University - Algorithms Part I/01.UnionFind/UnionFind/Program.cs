using System;

internal class Program
{
    private static void Main(string[] args)
    {
        //TestQuickFind();
        //TestQuickUnion();
        TestWeightedQuickUnionUF();
    }

    private static void TestWeightedQuickUnionUF()
    {
        int n = int.Parse(Console.ReadLine());
        WeightedQuickUnionUF uf = new WeightedQuickUnionUF(n);

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                break;
            }

            string[] objects = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int p = int.Parse(objects[0]);
            int q = int.Parse(objects[1]);

            if (!uf.Connected(p, q))
            {
                uf.Union(p, q);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("{0} {1} - not connected", p, q);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("{0} {1} - connected", p, q);
                Console.ResetColor();
            }
        }

        Console.WriteLine("{0} components.", uf.Count);
    }

    private static void TestQuickUnion()
    {
        int n = 10;
        QuickUnionUF uf = new QuickUnionUF(n);
        uf.Union(4, 3);
        uf.Union(3, 8);
        uf.Union(6, 5);
        uf.Union(9, 4);
        uf.Union(2, 1);
        Console.WriteLine(uf.Connected(8, 9)); // true
        Console.WriteLine(uf.Connected(5, 0)); // false
        uf.Union(5, 0);
        uf.Union(7, 2);
        uf.Union(6, 1);
        uf.Union(7, 3);
    }

    private static void TestQuickFind()
    {
        int n = int.Parse(Console.ReadLine());
        QuickFindUF uf = new QuickFindUF(n);

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                break;
            }

            string[] objects = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int p = int.Parse(objects[0]);
            int q = int.Parse(objects[1]);

            if (!uf.Connected(p, q))
            {
                uf.Union(p, q);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("{0} {1} - not connected", p, q);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("{0} {1} - connected", p, q);
                Console.ResetColor();
            }
        }
    }
}