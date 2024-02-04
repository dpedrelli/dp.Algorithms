using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms
{
    public static class DataGenerator
    {
        public static int[] GenerateRandomIntegerArray(int size)
        {
            int[] array = new int[size];
            var rand = new Random();

            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = rand.Next();
            }

            return array;
        }

        public static int[] GenerateSortedIntegerArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = i;
            }

            return array;
        }

        public static int[] GenerateReverseIntegerArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = Int32.MaxValue - i;
            }

            return array;
        }
    }
}
