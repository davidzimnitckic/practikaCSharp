using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CinemaBooking.Models;

namespace CinemaBooking.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MovieSession> AllSessions { get; set; }
        public ObservableCollection<MovieSession> Sessions { get; set; }

        private string _selectedTime;
        public string SelectedTime
        {
            get => _selectedTime;
            set
            {
                _selectedTime = value;
                FilterSessions();
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Times { get; set; }

        private MovieSession _selectedSession;
        public MovieSession SelectedSession
        {
            get => _selectedSession;
            set
            {
                _selectedSession = value;
                OnPropertyChanged();
            }
        }

        private int _ticketCount;
        public int TicketCount
        {
            get => _ticketCount;
            set
            {
                _ticketCount = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            AllSessions = new ObservableCollection<MovieSession>
            {
                new MovieSession { MovieTitle = "Avatar", Time = "12:00", AvailableSeats = 50 },
                new MovieSession { MovieTitle = "Avatar", Time = "18:00", AvailableSeats = 40 },
                new MovieSession { MovieTitle = "Inception", Time = "15:00", AvailableSeats = 30 },
                new MovieSession { MovieTitle = "Interstellar", Time = "18:00", AvailableSeats = 20 }
            };

            Sessions = new ObservableCollection<MovieSession>(AllSessions);

            Times = new ObservableCollection<string>
            {
                "Все",
                "12:00",
                "15:00",
                "18:00"
            };

            SelectedTime = "Все";
        }

        private void FilterSessions()
        {
            Sessions.Clear();

            var filtered = SelectedTime == "Все"
                ? AllSessions
                : new ObservableCollection<MovieSession>(
                    AllSessions.Where(s => s.Time == SelectedTime));

            foreach (var item in filtered)
                Sessions.Add(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}