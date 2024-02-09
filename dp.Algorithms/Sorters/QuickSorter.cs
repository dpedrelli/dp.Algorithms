namespace dp.Algorithms.Sorters
{
    //
    // Resources:
    // https://code-maze.com/csharp-quicksort-algorithm/
    // https://edutechlearners.com/download/Introduction_to_algorithms-3rd%20Edition.pdf

    public static class QuickSorter
    {
        public static T[] SortArray<T>(T[] array) where T : IComparable
        {
            return SortArray<T>(array, 0, array.Length - 1);
        }

        private static T[] SortArray<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            // Pseudo-code from Introduction to Algorithms, 3rd Edition, page 171.
            int q = 0;
            if (leftIndex < rightIndex)
            {
                q = PartitionArray(array, leftIndex, rightIndex);
                SortArray(array, leftIndex, q - 1);
                SortArray(array, q + 1, rightIndex);
            }

            return array;
        }

        private static int PartitionArray<T>(T[] array, int p, int r) where T : IComparable
        {
            var pivot = array[r];
            var i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (HelperMethods.Is2LessThan1(pivot, array[j]))
                {
                    i++;
                    HelperMethods.SwapArrayElements(array, i, j);
                }
            }
            HelperMethods.SwapArrayElements(array, i + 1, r);
            return i + 1;
        }
    }
}
