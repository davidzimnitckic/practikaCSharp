using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CinemaBooking.Models
{
    public class SeatModel : INotifyPropertyChanged
    {
        private bool _isBooked;

        public int Number { get; set; }

        public bool IsBooked
        {
            get => _isBooked;
            set
            {
                _isBooked = value;
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