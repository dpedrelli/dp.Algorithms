// C# program to implement 
// dual pivot QuickSort 
using System;

public class GFG
{
    [Theory]
    [InlineData(new int[] { 73, 57, 49, 99, 133, 20, 1 }, new int[] { 1, 20, 49, 57, 73, 99, 133 })]
    [InlineData(new int[] { 52, 96, 67, 71, 42, 38, 39, 40, 14 }, new int[] { 14, 38, 39, 40, 42, 52, 67, 71, 96 })]
    [InlineData(new int[] { 8, 1, 10, 5, 5, 3 }, new int[] { 1, 3, 5, 5, 8, 10 })]
    [InlineData(new int[] { 2, 1, 3, 4, 5, 7, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
    public void Test(int[] array, int[] expected)
    {
        dualPivotQuickSort(array, 0, array.Length - 1);
        Assert.Equal(expected, array);
    }

    static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }


    static void dualPivotQuickSort(int[] arr,
                            int low, int high)
    {
        if (low < high)
        {

            // piv[] stores left pivot and right pivot. 
            // piv[0] means left pivot and 
            // piv[1] means right pivot 
            int[] piv;
            piv = partition(arr, low, high);

            dualPivotQuickSort(arr, low, piv[0] - 1);
            dualPivotQuickSort(arr, piv[0] + 1, piv[1] - 1);
            dualPivotQuickSort(arr, piv[1] + 1, high);
        }
    }

    static int[] partition(int[] arr, int low, int high)
    {
        if (arr[low] > arr[high])
            swap(arr, low, high);

        // p is the left pivot, and q 
        // is the right pivot. 
        int leftIndex = low + 1;
        int rightIndex = high - 1, iterator = low + 1,
            leftPivot = arr[low], rightPivot = arr[high];

        while (iterator <= rightIndex)
        {

            // If elements are less than the left pivot 
            if (arr[iterator] < leftPivot)
            {
                swap(arr, iterator, leftIndex);
                leftIndex++;
            }

            // If elements are greater than or equal 
            // to the right pivot 
            else if (arr[iterator] >= rightPivot)
            {
                while (arr[rightIndex] > rightPivot && iterator < rightIndex)
                    rightIndex--;

                swap(arr, iterator, rightIndex);
                rightIndex--;

                if (arr[iterator] < leftPivot)
                {
                    swap(arr, iterator, leftIndex);
                    leftIndex++;
                }
            }
            iterator++;
        }
        leftIndex--;
        rightIndex++;

        // Bring pivots to their appropriate positions. 
        swap(arr, low, leftIndex);
        swap(arr, high, rightIndex);

        // Returning the indices of the pivots 
        // because we cannot return two elements 
        // from a function, we do that using an array. 
        return new int[] { leftIndex, rightIndex };
    }

}

// This code is contributed by Pushpesh Raj 
