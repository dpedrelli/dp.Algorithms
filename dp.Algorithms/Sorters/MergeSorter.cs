﻿using System;
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
        public static T[] SortArray<T>(T[] array) where T : IComparable
        {
            SortArray(array, 0, array.Length - 1);
            return array;
        }

        private static T[] SortArray<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
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

        private static void Merge<T>(T[] array, int left, int middle, int right) where T : IComparable
        {
            var leftLength = (middle - left) + 1;
            var leftArray = new T[leftLength];
            var rightLength = (right - middle);
            var rightArray = new T[rightLength];

            Array.Copy(array, left, leftArray, 0, (middle - left) + 1);
            Array.Copy(array, middle + 1, rightArray, 0, right - middle);

            var i = 0; var j = 0; var k = left;

            //for (k = left; k < right; k++)
            while (i < leftLength && j < rightLength)
            {
                if (!HelperMethods.Is2LessThan1(leftArray[i], rightArray[j]))
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }
            while (i < leftLength && k < array.Length)
            {
                array[k++] = leftArray[i++];
            }
            while (j < rightLength && k < array.Length)
            {
                array[k++] = rightArray[j++];
            }
        }

        private static void Merge1<T>(T[] array, int left, int middle, int right) where T : IComparable
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
