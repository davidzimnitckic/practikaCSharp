using System;

partial class Movie
{
    public void ShowInfo()
    {
        Console.WriteLine($"{Title} | Режиссер: {Director} | {Duration} мин | Жанр: {Genre}");
    }
}