#pragma warning disable
using System;

class Program
{
    static void Main()
    {
        int[] arr = { 5, 3, 9, 1 };
        int min = FindMin(arr, 0);
        Console.WriteLine(min); // 1
    }
    static int FindMin(int[] arr, int index)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Массив пустой");

        if (index == arr.Length - 1)
            return arr[index];

        int minOfRest = FindMin(arr, index + 1);

        return arr[index] < minOfRest ? arr[index] : minOfRest;
    }
}