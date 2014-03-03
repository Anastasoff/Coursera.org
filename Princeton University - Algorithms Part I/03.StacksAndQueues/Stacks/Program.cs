namespace Stacks
{
    using Stacks.Dynamic;
    using Stacks.Static;
    using System;
    using System.IO;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            TestClient(new LinkedStackOfStrings());
            TestClient(new FixedCapacityStackOfStrings(10));
            TestClient(new ResizingArrayStackOfStrings());
            var stack = new GenericStack<string>();
            TestGenericsClient(stack);
            Console.WriteLine("(\"{0}\" left on stack)", stack.ToString());
        }

        private static void TestClient(IStackOfStrings stack)
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

        private static void TestGenericsClient<T>(IGenericStack<T> stack)
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
                    stack.Push((dynamic)current);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}