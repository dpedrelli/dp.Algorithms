namespace dp.Algorithms.Sorters
{
    public static class QuickSorter
    {
        public static T[] SortArray<T>(T[] array, int leftIndex, int rightIndex) where T : struct, IComparable<T>
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

        private static int PartitionArray<T>(T[] array, int p, int r) where T : struct, IComparable<T>
        {
            var pivot = array[r];
            var i = p - 1;
            for (int j = p; j < r; j++)
            {
                //if (array[j] <= pivot)
                if (!IsPrivotGreater(pivot, array[j]))
                {
                    i++;
                    HelperMethods.SwapArrayElements(array, i, j);
                }
            }
            HelperMethods.SwapArrayElements(array, i + 1, r);
            return i + 1;
        }

        private static bool IsPrivotGreater<T>(T pivot, T compare) where T : struct, IComparable<T>
        {
            if (pivot.GetType() == typeof(int))
            {
                return compare.CompareTo(pivot) > 0;
            }
            return false;
        }
    }
}
