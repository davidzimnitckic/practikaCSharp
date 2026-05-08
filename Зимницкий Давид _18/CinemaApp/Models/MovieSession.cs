namespace CinemaApp.Models
{
    public class MovieSession
    {
        public int Id
        {
            get;
            set;
        }

        public MovieModel Movie
        {
            get;
            set;
        }

        public string Time
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"{Movie.Title} - {Time}";
        }
    }
}