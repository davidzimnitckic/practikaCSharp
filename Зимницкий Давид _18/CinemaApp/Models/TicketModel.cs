namespace CinemaApp.Models
{
    public class TicketModel
    {
        public int Id
        {
            get;
            set;
        }

        public string MovieTitle
        {
            get;
            set;
        }

        public int SeatNumber
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"{MovieTitle} | Место {SeatNumber}";
        }
    }
}