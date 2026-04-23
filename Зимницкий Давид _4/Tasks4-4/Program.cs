#pragma warning disable
using System;

static class StringExtensions
{
    public static string FirstLetters(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        string[] words = input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        string result = "";

        foreach (var word in words)
        {
            result += word[0];
        }

        return result;
    }
}
class Program
{
    static void Main()
    {
        string text = "Hello world from CSharp";
        string result = text.FirstLetters();

        Console.WriteLine(result); 
    }
}