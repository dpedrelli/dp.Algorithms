using dp.Algorithms.Recursion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dp.Algorithms.Tests
{
    public class RecursionTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        public void Fibonacci_PassCount_ReturnsCorrect(int count, int expected)
        {
            var result = FibonacciGenerator.GenerateNumber(count);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, new int[0])]
        [InlineData(1, new int[1] { 0 })]
        [InlineData(2, new int[2] { 0, 1 })]
        [InlineData(3, new int[3] { 0, 1, 1 })]
        [InlineData(4, new int[4] { 0, 1, 1, 2 })]
        [InlineData(5, new int[5] { 0, 1, 1, 2, 3 })]
        [InlineData(6, new int[6] { 0, 1, 1, 2, 3, 5 })]
        public void FibonacciArray_PassCount_ReturnsCorrect(int count, int[] expected)
        {
            var result = FibonacciGenerator.GenerateArray(count);
            Assert.Equal(expected, result);
        }
    }
}
