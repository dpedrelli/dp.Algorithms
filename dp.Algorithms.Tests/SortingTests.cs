using dp.Algorithms.Sorters;

namespace dp.Algorithms.Tests
{
    public class SortingTests
    {
        [Theory]
        [InlineData(new int[] { 73, 57, 49, 99, 133, 20, 1 }, new int[] { 1, 20, 49, 57, 73, 99, 133 })]
        [InlineData(new int[] { 52, 96, 67, 71, 42, 38, 39, 40, 14 }, new int[] { 14, 38, 39, 40, 42, 52, 67, 71, 96 })]
        public void QuickSorter_SortIntegerArray_SortsArray(int[] array, int[] expected)
        {
            var result = QuickSorter.SortArray(array);

            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 73, 57, 49, 99, 133, 20, 1 }, new int[] { 1, 20, 49, 57, 73, 99, 133 })]
        [InlineData(new int[] { 52, 96, 67, 71, 42, 38, 39, 40, 14 }, new int[] { 14, 38, 39, 40, 42, 52, 67, 71, 96 })]
        public void BubbleSorter_SortIntegerArray_SortsArray(int[] array, int[] expected)
        {
            var result = BubbleSorter.SortArray(array);

            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 73, 57, 49, 99, 133, 20, 1 }, new int[] { 1, 20, 49, 57, 73, 99, 133 })]
        [InlineData(new int[] { 52, 96, 67, 71, 42, 38, 39, 40, 14 }, new int[] { 14, 38, 39, 40, 42, 52, 67, 71, 96 })]
        public void InsertionSorter_SortIntegerArray_SortsArray(int[] array, int[] expected)
        {
            var result = InsertionSorter.SortArray(array);

            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 73, 57, 49, 99, 133, 20, 1 }, new int[] { 1, 20, 49, 57, 73, 99, 133 })]
        [InlineData(new int[] { 52, 96, 67, 71, 42, 38, 39, 40, 14 }, new int[] { 14, 38, 39, 40, 42, 52, 67, 71, 96 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [InlineData(new int[] { 7, 2, 3, 4, 5, 6, 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [InlineData(new int[] { 5, 6, 7, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void SelectionSorter_SortIntegerArray_SortsArray(int[] array, int[] expected)
        {
            var result = SelectionSorter.SortArray(array);

            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }
    }
}