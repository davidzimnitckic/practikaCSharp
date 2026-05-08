using CinemaApp.ViewModels;
using System.Windows;

namespace CinemaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext =
                new CinemaViewModel();
        }
    }
}