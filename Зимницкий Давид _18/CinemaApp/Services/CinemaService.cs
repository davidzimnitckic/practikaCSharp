using System.IO;
using CinemaApp.Models;

using System.Text.Json;

namespace CinemaApp.Services
{
    public class CinemaService
    {
        public CinemaDataModel LoadCinemaData()
        {
            string json =
                File.ReadAllText(
                    "Data/cinema.json"
                );

            return JsonSerializer.Deserialize
                <CinemaDataModel>(json);
        }

        public async Task<bool> BookSeatAsync(
            SeatModel seat)
        {
            await Task.Delay(2000);

            seat.IsBooked = true;

            return true;
        }
    }
}