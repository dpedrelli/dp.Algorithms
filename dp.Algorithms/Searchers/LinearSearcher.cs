using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Searchers
{
    public static class LinearSearcher
    {
        public static int FindFirst<T>(T[] array, T value) where T : IComparable<T>
        {
            var result = -1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (value.CompareTo(array[i]) == 0)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public static int FindLast<T>(T[] array, T value) where T : IComparable<T>
        {
            var result = -1;
            for (int i = array.Length - 1; i > -1; i--)
            {
                if (value.CompareTo(array[i]) == 0)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public static int FindNext<T>(T[] array, T value, int current) where T : IComparable<T>
        {
            var result = -1;
            for (int i = current + 1; i < array.Length - 1; i++)
            {
                if (value.CompareTo(array[i]) == 0)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public static int RecursiveFind<T>(T[] array, T value) where T : IComparable<T>
        {
            return RecursiveFind(array, value, 0);
        }
        private static int RecursiveFind<T>(T[] array, T value, int index) where T : IComparable<T>
        {
            var result = -1;
            if (index > array.Length - 1)
            {

            }
            else if (value.CompareTo(array[index]) == 0)
            {
                result = index;
            }
            else
            {
                result = RecursiveFind(array, value, ++index);
            }
            return result;
        }
    }
}
