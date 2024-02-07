using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Sorters
{
    public static class BubbleSorter
    {
        public static T[] SortArray<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++) 
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    //if (array[j].CompareTo(array[j-1]) < 0)
                    if (HelperMethods.Is2GreaterThan1(array[j], array[j-1]))
                    {
                        HelperMethods.SwapArrayElements(array, j, j - 1);
                    }
                }
            }
            return array;
        }
    }
}
