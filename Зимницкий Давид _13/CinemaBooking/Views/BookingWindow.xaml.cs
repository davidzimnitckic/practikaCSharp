using System.Windows;

namespace CinemaBooking.Views
{
    public partial class BookingWindow : Window
    {
        public BookingWindow()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (MoviesList.SelectedItem == null)
            {
                MessageBox.Show("Выберите фильм!");
                return;
            }

            string movie = MoviesList.SelectedItem.ToString();

            MessageBox.Show($"Вы выбрали: {movie}");

            new HallWindow().ShowDialog();
        }
    }
}