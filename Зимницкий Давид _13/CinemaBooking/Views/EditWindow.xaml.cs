using System.Windows;

namespace CinemaBooking.Views
{
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Изменения сохранены");
            Close();
        }
    }
}