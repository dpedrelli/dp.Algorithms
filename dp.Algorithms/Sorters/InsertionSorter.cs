using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Sorters
{
    public static class InsertionSorter
    {
        public static T[] SortArray<T>(T[] array) where T : struct, IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j].CompareTo(array[j - 1]) < 0)
                    {
                        HelperMethods.SwapArrayElements(array, j, j - 1);
                    }
                }
            }

            return array;
        }
    }
}
