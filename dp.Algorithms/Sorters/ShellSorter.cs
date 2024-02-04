using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Sorters
{
    public static class ShellSorter
    {
        public static T[] SortArray<T>(T[] array) where T : struct, IComparable<T>
        {
            for (int interval = array.Length / 2; interval > 0; interval /= 2)
            {
                for (int i = interval; i < array.Length; i++)
                {
                    int j;
                    var current = array[i]; // Store value for when j == i.
                    for (j = i; j >= interval && HelperMethods.Is2LessThan1(array[j - interval], current); j -= interval)
                    {
                        array[j] = array[j - interval];
                    }
                    array[j] = current;
                }
            }
            return array;
        }
    }
}
