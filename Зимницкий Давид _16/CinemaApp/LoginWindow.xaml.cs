using CinemaApp.Services;
using System.Windows;

namespace CinemaApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            AuthService auth =
                new AuthService();

            var user = auth.Login(
                LoginBox.Text,
                PasswordBox.Password
            );

            if (user != null)
            {
                MessageBox.Show(
                    $"Добро пожаловать {user.Role}"
                );

                MainWindow main =
                    new MainWindow();

                main.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Неверный логин или пароль"
                );
            }
        }
    }
}