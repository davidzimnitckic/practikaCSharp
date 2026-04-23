#pragma warning disable

using System;

class Movie
{
    public string Title { get; set; }

    public Movie(string title)
    {
        Title = title;
    }
}

class Schedule
{
    public string Time { get; set; }

    public Schedule(string time)
    {
        Time = time;
    }
}

class Distributor
{
    public string Name { get; set; }

    public Distributor(string name)
    {
        Name = name;
    }
}

class Cinema
{
    public string Name { get; set; }

    public Movie[] Movies { get; set; }

    private Schedule schedule;

    public Distributor Distributor { get; set; }

    public Cinema(string name, Movie[] movies, Distributor distributor, string time)
    {
        Name = name;
        Movies = movies;
        Distributor = distributor;

        schedule = new Schedule(time);
    }

    public void ShowMovies()
    {
        Console.WriteLine($"Кинотеатр: {Name}");
        Console.WriteLine($"Дистрибьютор: {Distributor.Name}");
        Console.WriteLine($"Время сеансов: {schedule.Time}");

        Console.WriteLine("Фильмы:");
        foreach (var movie in Movies)
        {
            Console.WriteLine("- " + movie.Title);
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Movie m1 = new Movie("Интерстеллар");
        Movie m2 = new Movie("Матрица");
        Movie m3 = new Movie("Аватар");

        Distributor d1 = new Distributor("Warner Bros");
        Distributor d2 = new Distributor("Disney");

        Cinema[] cinemas = new Cinema[]
        {
            new Cinema("Cinema City", new Movie[] { m1, m2 }, d1, "18:00"),
            new Cinema("Mega Cinema", new Movie[] { m2, m3 }, d2, "20:00")
        };

        foreach (var cinema in cinemas)
        {
            cinema.ShowMovies();
        }
    }
}