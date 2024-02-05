using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Recursion
{
    public static class FibonacciGenerator
    {
        public static int GenerateNumber(int element)
        {
            if (element == 0)
            {
                return 0;
            }
            else if (element == 1)
            {
                return 1;
            }
            var value = GenerateNumber(element - 2) + GenerateNumber(element - 1);
            return value;
        }

        public static int[] GenerateArray(int count)
        {
            var array = new int[count];
            if (count < 1)
            {
                return array;
            }
            array[0] = 0;
            if (count < 2)
            {
                return array;
            }
            array[1] = 1;
            for (int i = 2; i < count; i++)
            {
                array[i] = array[i - 2] + array[i - 1];
            }
            return array;
        }
    }
}
