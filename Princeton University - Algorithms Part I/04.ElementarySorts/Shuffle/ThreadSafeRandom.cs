namespace Shuffle
{
    using System;
    using System.Threading;

    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random instance;

        public static Random ThisThreadsRandom
        {
            get
            {
                if (instance == null)
                {
                    instance = new Random(unchecked((Environment.TickCount * 31) + Thread.CurrentThread.ManagedThreadId));
                }

                return instance;
            }
        }
    }
}