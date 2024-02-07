using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public static class HelperMethods
    {
        public static void SwapArrayElements<T>(T[] array, int elementOne, int elementTwo)
        {
            var temp = array[elementOne];
            array[elementOne] = array[elementTwo];
            array[elementTwo] = temp;
        }

        public static bool Is2LessThan1<T>(T element1,  T element2) where T : IComparable
        {
            return element1.CompareTo(element2) > 0;
        }

        public static bool Is2GreaterThan1<T>(T element1,  T element2) where T : IComparable
        {
            return element1.CompareTo(element2) < 0;
        }

        public static bool Is1EqualTo2<T>(T element1,  T element2) where T : IComparable
        {
            return element1.CompareTo(element2) == 0;
        }
    }
}
