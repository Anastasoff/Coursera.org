namespace Stacks
{
    using System;
    using System.IO;
    using System.Text;

    using Stacks.Dynamic;
    using Stacks.Static;

    internal class Program
    {
        private static void Main(string[] args)
        {
            TestClient(new LinkedStackOfStrings());
            TestClient(new FixedCapacityStackOfStrings(10));
            TestClient(new ResizingArrayStackOfStrings());
        }

        private static void TestClient(IStack stack)
        {
            string[] str = File.ReadAllText(@"../../tobe.txt").Split(' ');

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                string current = str[i];
                if (current == "-")
                {
                    result.Append(stack.Pop() + " ");
                }
                else
                {
                    stack.Push(current);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}