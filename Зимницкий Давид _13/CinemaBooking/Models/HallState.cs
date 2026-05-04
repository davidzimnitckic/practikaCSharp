using System.Collections.Generic;

namespace CinemaBooking.Models
{
    public static class HallState
    {
        // занятые места
        public static HashSet<int> BookedSeats = new HashSet<int>();
    }
}