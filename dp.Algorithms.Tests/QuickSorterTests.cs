using dp.Algorithms.Sorters;

namespace dp.Algorithms.Tests
{
    public class QuickSorterTests
    {
        [Theory]
        [InlineData(new int[] { 73, 57, 49, 99, 133, 20, 1 }, new int[] { 1, 20, 49, 57, 73, 99, 133 })]
        [InlineData(new int[] { 52, 96, 67, 71, 42, 38, 39, 40, 14 }, new int[] { 14, 38, 39, 40, 42, 52, 67, 71, 96 })]
        public void QuickSorter_SortIntegerArray_SortsArray(int[] array, int[] expected)
        {
            var result = QuickSorter.SortArray(array, 0, array.Length - 1);

            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }
    }
}