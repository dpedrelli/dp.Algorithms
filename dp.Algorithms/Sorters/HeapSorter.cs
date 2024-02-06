using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Sorters
{
    public static class HeapSorter
    {
        public static T[] SortArray<T>(T[] array) where T : struct, IComparable<T>
        {
            var n = array.Length;

            for (var i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }
            for (int i = n-1; i >= 0; i--)
            {
                HelperMethods.SwapArrayElements(array, i, 0);
                Heapify(array, i, 0);
            }
            return array;
        }

        private static void Heapify<T>(T[] array, int n, int i) where T : struct, IComparable<T>
        {
            int largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if ((left < n) && HelperMethods.Is2GreaterThan1(array[i], array[left]))
            {
                largest = left;
            }
            if ((right < n) && HelperMethods.Is2GreaterThan1(array[largest], array[right]))
            {
                largest = right;
            }

            if (largest != i)
            {
                HelperMethods.SwapArrayElements(array, i, largest);
                Heapify(array, n, largest);
            }
        }

    }
}
