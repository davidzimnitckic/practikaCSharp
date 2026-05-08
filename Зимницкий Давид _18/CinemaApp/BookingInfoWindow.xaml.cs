using System.Windows;
using System.Windows.Media.Animation;

namespace CinemaApp
{
    public partial class BookingInfoWindow : Window
    {
        public BookingInfoWindow(
            int seatNumber)
        {
            InitializeComponent();

            InfoText.Text =
                $"Место {seatNumber}\nзабронировано";

            Loaded += BookingInfoWindow_Loaded;
        }

        private void BookingInfoWindow_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            Storyboard sb =
                (Storyboard)Resources[
                    "PopupAnimation"
                ];

            sb.Begin(MainGrid);
        }

        private void Button_Click(
            object sender,
            RoutedEventArgs e)
        {
            Close();
        }
    }
}