using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public static class HelperMethods
    {
        public static void SwapArrayElements<T>(T[] array, int elementOne, int elementTwo) where T : struct
        {
            var temp = array[elementOne];
            array[elementOne] = array[elementTwo];
            array[elementTwo] = temp;
        }
    }
}
