#pragma warning disable
using System;

class Program
{
    static void Main()
    {
        string text = "Привет как дела";
        int count = CountWords(text);
        Console.WriteLine(count); // 3
    }

    public static int CountWords(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return 0;

        string[] words = input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}