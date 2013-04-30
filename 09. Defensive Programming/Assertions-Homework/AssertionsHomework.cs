using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null !");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        // post condiotions
        for (int index = 0; index < arr.Length - 2; index++)
        {
            Debug.Assert(arr[index].CompareTo(arr[index + 1]) <= 0, "Array is not sorted!");
        }
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(startIndex < arr.Length, "Start index is bigger than count of array elements !");
        Debug.Assert(startIndex >= 0, "Start index is less than 0 !");
        Debug.Assert(endIndex < arr.Length, "End index is bigger than count of array elements !");
        Debug.Assert(endIndex >= 0, "End index is less than 0 !");
        Debug.Assert(startIndex <= endIndex, "Start index should be less than end index");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        // post conditions
        for (int i = startIndex; i <= endIndex; i++)
        {
            Debug.Assert(arr[minElementIndex].CompareTo(arr[i]) <= 0, arr[minElementIndex] + " is not minimum element");
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        // preconditions
        Debug.Assert(arr != null, "Array is null !");
        Debug.Assert(value != null, "Value cannot be null !");

        for (int index = 0; index < arr.Length - 2; index++)
        {
            Debug.Assert(arr[index].CompareTo(arr[index + 1]) <= 0, "Array is not sorted!");
        }

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(value != null, "Value cannot be null!");
        Debug.Assert(startIndex < arr.Length, "Start index is bigger than count of array elements !");
        Debug.Assert(startIndex >= 0, "Start index is less than 0 !");
        Debug.Assert(endIndex < arr.Length, "End index is bigger than count of array elements !");
        Debug.Assert(endIndex >= 0, "End index is less than 0 !");
        Debug.Assert(startIndex <= endIndex, "Start index should be less/ or equal than end index");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));

        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
