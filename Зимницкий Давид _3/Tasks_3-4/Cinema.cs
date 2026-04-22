using System;

class Cinema
{
    private Movie[] movies;

    public Cinema(Movie[] movies)
    {
        this.movies = movies;
    }

    // 1. Самый длинный фильм
    public Movie GetLongestMovie()
    {
        Movie longest = movies[0];

        foreach (var movie in movies)
        {
            if (movie.Duration > longest.Duration)
            {
                longest = movie;
            }
        }

        return longest;
    }

    // 2. Фильмы по режиссеру
    public Movie[] GetMoviesByDirector(string director)
    {
        int count = 0;

        foreach (var movie in movies)
        {
            if (movie.Director == director)
                count++;
        }

        Movie[] result = new Movie[count];
        int index = 0;

        foreach (var movie in movies)
        {
            if (movie.Director == director)
            {
                result[index++] = movie;
            }
        }

        return result;
    }

    public void ShowAll()
    {
        foreach (var movie in movies)
        {
            movie.ShowInfo();
        }
        Console.WriteLine();
    }
}