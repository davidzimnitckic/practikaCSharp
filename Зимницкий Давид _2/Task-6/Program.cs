string text = "abc 1234 test 56";

string[] words = text.Split(' ');

foreach (var word in words)
{
    if (word.All(char.IsDigit))
    {
        Console.WriteLine(word);
        break;
    }
}