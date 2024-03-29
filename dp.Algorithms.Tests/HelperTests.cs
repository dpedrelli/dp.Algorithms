﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Tests
{
    public class HelperTests
    {
        [Fact]
        public void SwapArray_1To2()
        {
            int[] original = { 1, 2 };
            int[] expected = { 2, 1 };
            HelperMethods.SwapArrayElements(original, 0, 1);
            Assert.Equal(expected, original);
        }

        [Fact]
        public void Compare_2LessThan1_True()
        {
            Assert.True(HelperMethods.Is2LessThan1(2, 1));
        }

        [Fact]
        public void Compare_GreaterThan1_True()
        {
            Assert.True(HelperMethods.Is2GreaterThan1(1, 2));
        }

        [Fact]
        public void Compare_1EqualTo2_True()
        {
            Assert.True(HelperMethods.Is1EqualTo2(1, 1));
        }
    }
}
