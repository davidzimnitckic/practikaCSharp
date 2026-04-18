string text = "this is bad word";
string[] badWords = { "bad", "word" };

foreach (var w in badWords)
{
    text = text.Replace(w, "***");
}

Console.WriteLine(text);