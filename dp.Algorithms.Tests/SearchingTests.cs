using dp.Algorithms.Searchers;
using dp.Algorithms.Sorters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp.Algorithms.Tests
{
    public class SearchingTests
    {
        [Fact]
        public void LinearSearcher_SearchNonExistingElement_ReturnNegativeOne()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            var result = LinearSearcher.FindFirst(array, 8);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void LinearSearcher_SearchForFirst_ReturnFirstIndex()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            var result = LinearSearcher.FindFirst(array, 3);

            Assert.Equal(2, result);
        }

        [Fact]
        public void LinearSearcher_SearchForLast_ReturnLastIndex()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6, 3 };
            var result = LinearSearcher.FindLast(array, 3);

            Assert.Equal(6, result);
        }

        [Fact]
        public void LinearSearcher_SearchForNext_ReturnNextIndex()
        {
            var array = new[] { 1, 2, 3, 4, 3, 5, 6, 3 };
            var result = LinearSearcher.FindNext(array, 3, 2);

            Assert.Equal(4, result);
        }

        [Fact]
        public void LinearSearcher_RecursiveSearch_ReturnIndex()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            var result = LinearSearcher.RecursiveFind(array, 6);

            Assert.Equal(5, result);
        }

        [Fact]
        public void BinarySearcher_SearchNonExistingElement_ReturnNegativeOne()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            var result = BinarySearcher.Find(array, 8);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void BinarySearcher_Search_ReturnIndex()
        {
            var array = new[] { 1, 2, 3, 4, 5, 6 };
            var result = BinarySearcher.Find(array, 3);

            Assert.Equal(2, result);
        }

    }
}
