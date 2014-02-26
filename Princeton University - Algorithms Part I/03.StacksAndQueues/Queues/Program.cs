namespace Queues
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            LinkedQueueOfStrings queue = new LinkedQueueOfStrings();
            Console.WriteLine("Is empty? " + queue.IsEmpty());
            queue.Enqueue("to");
            queue.Enqueue("be");
            queue.Enqueue("or");
            queue.Enqueue("not");
            queue.Enqueue("to");
            queue.Enqueue("be");
            Console.WriteLine("Is empty? " + queue.IsEmpty());
            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}