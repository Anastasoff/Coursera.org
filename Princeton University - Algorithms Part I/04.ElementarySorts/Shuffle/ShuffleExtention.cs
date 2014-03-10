namespace Shuffle
{
    using System;

    public static class ShuffleExtention
    {
        /// <summary>
        /// Fisher–Yates shuffle
        /// </summary>
        public static void Shuffle<T>(this T[] array) where T : IComparable<T>
        {
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
        }
    }
}