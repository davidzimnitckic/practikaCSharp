using CinemaBooking.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CinemaBooking.Views
{
    public partial class HallWindow : Window
    {
        public HallWindow()
        {
            InitializeComponent();
            CreateSeats();
        }

        private void CreateSeats()
        {
            for (int i = 1; i <= 25; i++)
            {
                Button seat = new Button();
                seat.Content = i;
                seat.Margin = new Thickness(5);

                UpdateSeatColor(seat, i);

                seat.Click += Seat_Click;

                SeatsGrid.Children.Add(seat);
            }
        }

        private void UpdateSeatColor(Button seat, int number)
        {
            if (HallState.BookedSeats.Contains(number))
            {
                seat.Background = Brushes.Red; // занято
            }
            else
            {
                seat.Background = Brushes.LightGreen; // свободно
            }
        }

        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int seatNumber = int.Parse(btn.Content.ToString());

            // если уже занято
            if (HallState.BookedSeats.Contains(seatNumber))
            {
                MessageBox.Show("Место уже занято!");
                return;
            }

            // подтверждение брони
            var result = MessageBox.Show(
                $"Забронировать место {seatNumber}?",
                "Подтверждение",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                HallState.BookedSeats.Add(seatNumber);

                btn.Background = Brushes.Red;

                MessageBox.Show("Место успешно забронировано!");
            }
        }
    }
}