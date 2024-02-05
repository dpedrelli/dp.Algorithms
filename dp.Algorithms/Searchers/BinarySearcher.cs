using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Searchers
{
    public static class BinarySearcher
    {
        public static int Find<T>(T[] array, T value) where T : struct, IComparable<T>
        {
            return Find(array, value, 0, array.Length - 1);
        }

        public static int Find<T>(T[] array, T value, int start, int end) where T : struct, IComparable<T>
        {
            if (start > end) { return -1; }
            var middle = (start + end) / 2;
            if (HelperMethods.Is1EqualTo2(array[middle], value))
            {
                return middle;
            }
            else if (HelperMethods.Is2GreaterThan1(array[middle], value))
            {
                return Find(array, value, middle + 1, end);
            }
            else if (HelperMethods.Is2LessThan1(array[middle], value))
            {
                return Find(array, value, start, middle - 1);
            }
            return -1;
        }
    }
}
