using System;

class Program
{
    static void Main()
    {
        Movie[] movies = new Movie[]
        {
            new Movie("Inception", "Nolan", 148, "Sci-Fi"),
            new Movie("Interstellar", "Nolan", 169, "Sci-Fi"),
            new Movie("Titanic", "Cameron", 195, "Drama"),
            new Movie("Avatar", "Cameron", 162, "Fantasy")
        };

        Cinema cinema = new Cinema(movies);

        Console.WriteLine("Все фильмы:");
        cinema.ShowAll();

        Console.WriteLine("Самый длинный фильм:");
        var longest = cinema.GetLongestMovie();
        longest.ShowInfo();

        Console.WriteLine();

        Console.WriteLine("Фильмы режиссера Nolan:");
        var result = cinema.GetMoviesByDirector("Nolan");

        foreach (var movie in result)
        {
            movie.ShowInfo();
        }
    }
}