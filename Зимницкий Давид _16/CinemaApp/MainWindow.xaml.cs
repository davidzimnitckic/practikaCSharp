using CinemaApp.Services;
using CinemaApp.ViewModels;
using System.Windows;

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

            StartPipeServer();
        }

        private async void StartPipeServer()
        {
            await pipeServer.StartServer();
        }
    }
}