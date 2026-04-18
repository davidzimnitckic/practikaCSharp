using System.Text.RegularExpressions;

string text = "Hello Привет";

bool hasRussian = Regex.IsMatch(text, "[А-Яа-я]");

Console.WriteLine(hasRussian);