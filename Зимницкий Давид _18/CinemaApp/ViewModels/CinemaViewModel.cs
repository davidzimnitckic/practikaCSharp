using CinemaApp.Commands;
using CinemaApp.Models;
using CinemaApp.Repositories;
using CinemaApp.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CinemaApp.ViewModels
{
    public class CinemaViewModel
    {
        private readonly CinemaService
            service;

        private readonly SessionRepository
            sessionRepository;

        private readonly TicketRepository
            ticketRepository;

        public ObservableCollection<MovieSession>
            Sessions
        { get; set; }

        public ObservableCollection<TicketModel>
            Tickets
        { get; set; }

        public ObservableCollection<SeatModel>
            Seats
        { get; set; }

        public MovieSession SelectedSession
        {
            get;
            set;
        }

        public TicketModel SelectedTicket
        {
            get;
            set;
        }

        public ICommand BookSeatCommand
        {
            get;
            set;
        }

        public ICommand CancelTicketCommand
        {
            get;
            set;
        }

        public CinemaViewModel()
        {
            service =
                new CinemaService();

            sessionRepository =
                new SessionRepository();

            ticketRepository =
                new TicketRepository();

            Sessions =
                new ObservableCollection<MovieSession>();

            Tickets =
                new ObservableCollection<TicketModel>();

            Seats =
                new ObservableCollection<SeatModel>();

            LoadData();

            BookSeatCommand =
                new RelayCommand(async (seat) =>
                {
                    await BookSeat(
                        seat as SeatModel
                    );
                });

            CancelTicketCommand =
                new RelayCommand(async (_) =>
                {
                    await CancelTicket();
                });
        }

        private async void LoadData()
        {
            var sessions =
                await sessionRepository
                .GetAllAsync();

            if (sessions.Count == 0)
            {
                var data =
                    service.LoadCinemaData();

                foreach (var s in data.Sessions)
                {
                    await sessionRepository
                        .AddAsync(s);
                }

                await sessionRepository
                    .SaveAsync();

                sessions =
                    await sessionRepository
                    .GetAllAsync();
            }

            Sessions.Clear();

            foreach (var session in sessions)
            {
                Sessions.Add(session);
            }

            var tickets =
                await ticketRepository
                .GetAllAsync();

            Tickets.Clear();

            foreach (var ticket in tickets)
            {
                Tickets.Add(ticket);
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

        private async Task BookSeat(
            SeatModel seat)
        {
            if (seat == null)
            {
                return;
            }

            if (SelectedSession == null)
            {
                MessageBox.Show(
                    "Выберите сеанс"
                );

                return;
            }

            if (seat.IsBooked)
            {
                MessageBox.Show(
                    "Место уже занято"
                );

                return;
            }

            seat.IsBooked = true;

            TicketModel ticket =
                new TicketModel
                {
                    MovieTitle =
                        SelectedSession
                        .Movie
                        .Title,

                    SeatNumber =
                        seat.Number
                };

            await ticketRepository
                .AddAsync(ticket);

            await ticketRepository
                .SaveAsync();

            Tickets.Add(ticket);

            await service
                .BookSeatAsync(seat);

            BookingInfoWindow info =
                new BookingInfoWindow(
                    seat.Number
                );

            info.ShowDialog();
        }

        private async Task CancelTicket()
        {
            if (SelectedTicket == null)
            {
                return;
            }

            await ticketRepository
                .DeleteAsync(
                    SelectedTicket
                );

            await ticketRepository
                .SaveAsync();

            Tickets.Remove(
                SelectedTicket
            );

            MessageBox.Show(
                "Билет отменен"
            );
        }
    }
}