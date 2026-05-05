using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CinemaBooking.Models
{
    public class MovieSession : INotifyPropertyChanged
    {
        private int _availableSeats;

        public string MovieTitle { get; set; }
        public string Time { get; set; }

        public int AvailableSeats
        {
            get => _availableSeats;
            set
            {
                _availableSeats = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}