using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Tests
{
    public class HashTableBasedSetTester
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 })]
        public void Add_PassValues_ConfirmGetNext(int[] values)
        {
            var set = new HashTableBasedSet();
            foreach (var value in values)
            {
                set.Add(value);
            }
            set.Reset();
            foreach (var value in values)
            {
                Assert.Equal(value, set.GetNext());
            }
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 6, false)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, true)]
        public void Contains_PassSets_ConfirmResult(int[] values, int confirm, bool expected)
        {
            var set = new HashTableBasedSet();
            foreach (var value in values)
            {
                set.Add(value);
            }
            Assert.Equal(expected, set.Contains(confirm));
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 6, false)]
        public void Remove_PassValues_ConfirmGetNext(int[] values, int remove, bool expected)
        {
            var set = new HashTableBasedSet();
            foreach (var value in values)
            {
                set.Add(value);
            }
            Assert.Equal(expected, set.Remove(remove));
            Assert.False(set.Contains(remove));
        }

        [Fact]
        public void Intersection_PassTwoSets_ConfirmResult()
        {
            var array1 = new int[] { 1, 2, 3, 4, 5 };
            var array2 = new int[] { 4, 5, 6, 7, 8 };

            var set1 = new HashTableBasedSet();
            foreach (var value in array1)
            {
                set1.Add(value);
            }

            var set2 = new HashTableBasedSet();
            foreach (var value in array2)
            {
                set2.Add(value);
            }

            var result = set1.Intersection(set2);
            result.Reset();
            Assert.Equal(2, result.Size);
            Assert.Equal(4, result.GetNext());
            Assert.Equal(5, result.GetNext());
        }

        [Fact]
        public void Union_PassTwoSets_ConfirmResult()
        {
            var array1 = new int[] { 1, 2, 3 };
            var array2 = new int[] { 4, 5, 6 };

            var set1 = new HashTableBasedSet();
            foreach (var value in array1)
            {
                set1.Add(value);
            }

            var set2 = new HashTableBasedSet();
            foreach (var value in array2)
            {
                set2.Add(value);
            }

            var result = set1.Union(set2);
            result.Reset();
            Assert.Equal(6, result.Size);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 7, 8 }, false)]
        public void IsSubset_PassSets_ConfirmSubset(int[] array1, int[] array2, bool expected)
        {
            var set1 = new HashTableBasedSet();
            foreach (var value in array1)
            {
                set1.Add(value);
            }

            var set2 = new HashTableBasedSet();
            foreach (var value in array2)
            {
                set2.Add(value);
            }

            Assert.Equal(expected, set1.IsSubset(set2));
        }
    }
}
