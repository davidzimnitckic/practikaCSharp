using CinemaBooking.Commands;
using CinemaBooking.Views;
using System.Windows;
using System.Windows.Input;

namespace CinemaBooking
{
    public partial class MainWindow : Window
    {
        public ICommand BookTicketCommand { get; set; }
        public ICommand EditTicketCommand { get; set; }
        public ICommand CancelTicketCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Создаем команды
            BookTicketCommand = new RelayCommand(OpenBooking);
            EditTicketCommand = new RelayCommand(OpenEdit);
            CancelTicketCommand = new RelayCommand(CancelBooking);

            DataContext = this;

            // Горячие клавиши
            InputBindings.Add(new KeyBinding(BookTicketCommand, new KeyGesture(Key.N, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(EditTicketCommand, new KeyGesture(Key.E, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(CancelTicketCommand, new KeyGesture(Key.D, ModifierKeys.Control)));
        }

        // ====== ЛОГИКА ======

        private void OpenBooking()
        {
            new BookingWindow().ShowDialog();
        }

        private void OpenEdit()
        {
            new EditWindow().ShowDialog();
        }

        private void CancelBooking()
        {
            if (CinemaBooking.Models.HallState.BookedSeats.Count == 0)
            {
                MessageBox.Show("Нет активных броней");
                return;
            }

            var result = MessageBox.Show(
                "Отменить ВСЕ брони?",
                "Подтверждение",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                CinemaBooking.Models.HallState.BookedSeats.Clear();
                MessageBox.Show("Все брони отменены");
            }
        }

        // ====== ОБРАБОТЧИКИ (по ТЗ) ======

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            OpenBooking();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            OpenEdit();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CancelBooking();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}