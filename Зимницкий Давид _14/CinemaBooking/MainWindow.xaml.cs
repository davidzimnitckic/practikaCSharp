using System.Windows;
using CinemaBooking.ViewModels;

namespace CinemaBooking
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}