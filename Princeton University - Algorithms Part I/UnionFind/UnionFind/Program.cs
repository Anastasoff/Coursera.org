using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // Question 1
           
        // (seed = 655038)
        // Give the id[] array that results from the following sequence of 6 union
        // operations on a set of 10 items using the quick-find algorithm.
           
        // 3-8 6-1 3-9 1-9 3-5 0-9
           
        // Recall: our quick-find convention for the union operation p-q is to change id[p]
        // (and perhaps some other entries) but not id[q].
        int n = 10;
        QuickFindUF qf = new QuickFindUF(n);
        qf.Union(3, 8);
        qf.Union(6, 1);
        qf.Union(3, 9);

        qf.Union(1, 9);
        qf.Union(3, 5);
        qf.Union(0, 9);

        Console.WriteLine("Question 1:");
        Console.WriteLine(string.Join(" ", qf.Id));

        // Question 2
           
        // (seed = 910282)
        // Give the id[] array that results from the following sequence of 9 union
        // operations on a set of 10 items using the weighted quick-union algorithm from lecture.
           
        // 8-9 3-2 7-4 5-9 6-1 8-6 7-3 2-5 8-0
           
        // Recall: when joining two trees of equal size, our weighted quick union convention is to
        // make the root of the second tree point to the root of the first tree. Also, our weighted
        // quick union algorithm uses union by size (number of nodes), not union by height.
        // int n = 10;
        WeightedQuickUnionUF uf = new WeightedQuickUnionUF(n);
        uf.Union(8, 9);
        uf.Union(3, 2);
        uf.Union(7, 4);

        uf.Union(5, 9);
        uf.Union(6, 1);
        uf.Union(8, 6);

        uf.Union(7, 3);
        uf.Union(2, 5);
        uf.Union(8, 0);

        Console.WriteLine("Question 2:");
        Console.WriteLine(string.Join(" ", uf.Id));
    }

    private static void PathCompressionQuickUnionUF()
    {
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