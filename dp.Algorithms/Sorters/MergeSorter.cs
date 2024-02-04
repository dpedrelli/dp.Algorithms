using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Sorters
{
    // Introduction to Algorithms, 3rd Edition, page 31.
    // https://edutechlearners.com/download/Introduction_to_algorithms-3rd%20Edition.pdf
    public static class MergeSorter
    {
        public static T[] SortArray<T>(T[] array) where T : struct, IComparable<T>
        {
            SortArray(array, 0, array.Length - 1);
            return array;
        }

        private static T[] SortArray<T>(T[] array, int leftIndex, int rightIndex) where T : struct, IComparable<T>
        {
            if (leftIndex < rightIndex)
            {
                var middle = leftIndex + (rightIndex - leftIndex) / 2;
                SortArray(array, leftIndex, middle);
                SortArray(array, middle + 1, rightIndex);
                Merge(array, leftIndex, middle, rightIndex);
            }
            return array;
        }

        private static void Merge<T>(T[] array, int left, int middle, int right) where T : struct, IComparable<T>
        {
            var leftLength = (middle - left) + 1;
            var leftArray = new T[leftLength + 1];
            var rightLength = (right - middle);
            var rightArray = new T[rightLength + 1];

            Array.Copy(array, left, leftArray, 0, (middle - left) + 1);
            Array.Copy(array, middle + 1, rightArray, 0, right - middle);

            var i = 0; var j = 0;

            for (int k = left; k <= middle; k++)
            {
                // Out of bounds array[7], left=4, middle=5, right=6, leftArray[2], rightArray[1], i=0, j=1, k=5
                if ((i > leftArray.Length - 1) || (j > rightArray.Length - 1))
                {
                    continue;
                }
                if (!HelperMethods.Is2LessThan1(leftArray[i], rightArray[j]))
                {
                    array[k] = leftArray[i++];
                }
                else
                {
                    array[k] = rightArray[j++];
                }
            }
        }

        private static void Merge1<T>(T[] array, int left, int middle, int right) where T : struct, IComparable<T>
        {
            // https://code-maze.com/csharp-merge-sort/
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new T[leftArrayLength];
            var rightTempArray = new T[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                //if (leftTempArray[i] <= rightTempArray[j])
                if (!HelperMethods.Is2LessThan1(leftTempArray[i], rightTempArray[j]))
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }
    }
}
