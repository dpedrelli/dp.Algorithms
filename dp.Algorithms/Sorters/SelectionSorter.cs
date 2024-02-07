using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Sorters
{
    public static class SelectionSorter
    {
        public static T[] SortArray<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                var min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (HelperMethods.Is2LessThan1(array[min], array[j]))
                    {
                        min = j;
                    }
                }
                HelperMethods.SwapArrayElements(array, i, min);
            }
            return array;
        }
    }
}
