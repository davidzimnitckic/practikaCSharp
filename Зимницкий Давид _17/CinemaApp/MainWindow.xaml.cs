using CinemaApp.Services;
using CinemaApp.ViewModels;
using System.Windows;
using System.Windows.Media.Animation;

namespace CinemaApp
{
    public partial class MainWindow : Window
    {
        private readonly PipeServerService
            pipeServer;

        public MainWindow()
        {
            InitializeComponent();

            DataContext =
                new CinemaViewModel();

            pipeServer =
                new PipeServerService();

            Loaded += MainWindow_Loaded;

            StartPipeServer();
        }

        private void MainWindow_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            Storyboard sb =
                (Storyboard)Resources[
                    "FadeInAnimation"
                ];

            sb.Begin(SeatsPanel);
        }

        private async void StartPipeServer()
        {
            await pipeServer.StartServer();
        }
    }
}