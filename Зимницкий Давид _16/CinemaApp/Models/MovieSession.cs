namespace CinemaApp.Models
{
    public class MovieSession
    {
        public MovieModel Movie { get; set; }

        public string Time { get; set; }

        public decimal Price { get; set; }
    }
}