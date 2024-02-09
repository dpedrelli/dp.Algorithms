using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Sorters
{
    public struct DualPivot
    {
        public int Left; public int Right;
    }

    public static class DualPivotQuickSorter
    {
        public static T[] SortArray<T>(T[] array) where T : IComparable
        {
            return SortArray<T>(array, 0, array.Length - 1);
        }

        private static T[] SortArray<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex < rightIndex)
            {
                DualPivot pivot = PartitionArray(array, leftIndex, rightIndex);
                SortArray(array, leftIndex, pivot.Left - 1);
                SortArray(array, pivot.Left + 1, pivot.Right - 1);
                SortArray(array, pivot.Right + 1, rightIndex);
            }

            return array;
        }

        private static DualPivot PartitionArray<T>(T[] array, int lowPivotIndex, int highPivotIndex) where T : IComparable
        {
            if (HelperMethods.Is2LessThan1(array[lowPivotIndex], array[highPivotIndex]))
            {
                HelperMethods.SwapArrayElements(array, lowPivotIndex, highPivotIndex);
            }

            var leftIndex = lowPivotIndex + 1;
            var rightIndex = highPivotIndex - 1;
            var i = leftIndex;
            var lowPivot = array[lowPivotIndex];
            var highPivot = array[highPivotIndex];
            while (i <= rightIndex) // (i < highPivotIndex) results in additional iterations on rightIndex.
            {
                if (HelperMethods.Is1LessThan2(array[i], lowPivot))
                {
                    HelperMethods.SwapArrayElements(array, i++, leftIndex++);
                }
                else if (HelperMethods.Is1GreaterThan2(array[i], highPivot))
                {
                    HelperMethods.SwapArrayElements(array, i, rightIndex--);
                }
                else
                {
                    i++;
                }
            }
            HelperMethods.SwapArrayElements(array, lowPivotIndex, --leftIndex);
            HelperMethods.SwapArrayElements(array, highPivotIndex, ++rightIndex);

            return new DualPivot { Left = leftIndex, Right = rightIndex };
        }
    }
}
