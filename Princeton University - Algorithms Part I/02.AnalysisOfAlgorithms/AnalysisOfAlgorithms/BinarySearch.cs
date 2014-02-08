namespace AnalysisOfAlgorithms
{
    internal class BinarySearch
    {
        public static int Recursive(int[] array, int key, int low, int high)
        {
            if (low > high)
            {
                return -1;
            }
            else
            {
                int middle = low + ((high - low) / 2);

                if (key < array[middle])
                {
                    return Recursive(array, key, low, middle - 1);
                }
                else if (key > array[middle])
                {
                    return Recursive(array, key, middle + 1, high);
                }
                else
                {
                    return middle;
                }
            }
        }

        public static int Iterative(int[] array, int key)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int middle = low + ((high - low) / 2);

                if (key < array[middle])
                {
                    high = middle - 1;
                }
                else if (key > array[middle])
                {
                    low = middle + 1;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }
    }
}