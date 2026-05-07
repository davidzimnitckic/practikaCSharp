using CinemaApp.Commands;
using CinemaApp.Models;
using CinemaApp.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class CinemaViewModel
    {
        private readonly CinemaService service;

        public ObservableCollection<MovieSession>
            Sessions
        { get; set; }

        public ObservableCollection<SeatModel>
            Seats
        { get; set; }

        public ICommand BookSeatCommand
        {
            get;
            set;
        }

        public int TicketCount
        {
            get;
            set;
        }

        private string filterTime;

        public string FilterTime
        {
            get
            {
                return filterTime;
            }

            set
            {
                filterTime = value;

                FilterSessions();
            }
        }

        public CinemaViewModel()
        {
            service = new CinemaService();

            Sessions =
                new ObservableCollection<MovieSession>();

            Seats =
                new ObservableCollection<SeatModel>();

            LoadData();

            BookSeatCommand =
                new RelayCommand(async (seat) =>
                {
                    await BookSeat(seat as SeatModel);
                });
        }

        private void LoadData()
        {
            var data =
                service.LoadCinemaData();

            foreach (var session in data.Sessions)
            {
                Sessions.Add(session);
            }

            for (int i = 1; i <= 30; i++)
            {
                Seats.Add(
                    new SeatModel
                    {
                        Number = i,
                        IsBooked = false
                    });
            }
        }

        private void FilterSessions()
        {
            Sessions.Clear();

            var data =
                service.LoadCinemaData();

            var filtered =
                data.Sessions.Where(
                    s => s.Time.Contains(
                        FilterTime ?? ""
                    ));

            foreach (var session in filtered)
            {
                Sessions.Add(session);
            }
        }

        private async Task BookSeat(
            SeatModel seat)
        {
            if (seat.IsBooked)
            {
                MessageBox.Show(
                    "Место занято"
                );

                return;
            }

            await service.BookSeatAsync(seat);

            MessageBox.Show(
                $"Место {seat.Number} забронировано"
            );
        }
    }
}