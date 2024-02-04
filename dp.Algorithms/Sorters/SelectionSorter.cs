using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Sorters
{
    public static class SelectionSorter
    {
        public static T[] SortArray<T>(T[] array) where T : struct, IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                var k = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    //if (array[j].CompareTo(array[k]) < 0)
                    if (HelperMethods.Is2GreaterThan1(array[j], array[k]))
                    {
                        k = j;
                    }
                    HelperMethods.SwapArrayElements(array, i, k);
                }
            }
            return array;
        }
    }
}
