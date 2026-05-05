using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CinemaBooking.Commands;
using CinemaBooking.Models;
using CinemaBooking.Services;

namespace CinemaBooking.ViewModels
{
    public class CinemaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SeatModel> Seats { get; set; }

        public RelayCommand BookSeatCommand { get; set; }

        private CinemaService _service;

        public CinemaViewModel()
        {
            _service = new CinemaService();

            Seats = new ObservableCollection<SeatModel>();

            for (int i = 1; i <= 20; i++)
            {
                Seats.Add(new SeatModel { Number = i });
            }

            BookSeatCommand = new RelayCommand(async (param) =>
            {
                var seat = param as SeatModel;

                if (seat == null) return;

                bool result = await _service.BookSeatAsync(seat);

                if (result)
                    MessageBox.Show($"Место {seat.Number} успешно забронировано!");
                else
                    MessageBox.Show("Место уже занято!");
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}