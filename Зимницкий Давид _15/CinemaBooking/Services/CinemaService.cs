using System.Threading.Tasks;
using CinemaBooking.Models;

namespace CinemaBooking.Services
{
    public class CinemaService
    {
        public async Task<bool> BookSeatAsync(SeatModel seat)
        {
            await Task.Delay(2000); // имитация запроса

            if (seat.IsBooked)
                return false;

            seat.IsBooked = true;
            return true;
        }
    }
}