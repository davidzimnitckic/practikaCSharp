using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CinemaBooking
{
    public partial class MainWindow : Window
    {
        int rows = 5;
        int cols = 8;

        Button[,] seats;

        // данные по фильмам (занятые места)
        Dictionary<string, bool[,]> cinemaData = new Dictionary<string, bool[,]>();

        public MainWindow()
        {
            InitializeComponent();

            InitCinemaData();
            CreateSeats();

            FilmComboBox.SelectionChanged += FilmChanged;
            FilmComboBox.SelectedIndex = 0;
        }

        // создаем разные залы для фильмов
        void InitCinemaData()
        {
            string[] films = { "Аватар", "Интерстеллар", "Джокер" };
            Random rand = new Random();

            foreach (var film in films)
            {
                bool[,] hall = new bool[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        hall[i, j] = rand.Next(0, 4) == 0; // случайно занято
                    }
                }

                cinemaData[film] = hall;
            }
        }

        // создаем кнопки мест
        void CreateSeats()
        {
            seats = new Button[rows, cols];

            for (int i = 0; i < rows; i++)
                SeatsGrid.RowDefinitions.Add(new RowDefinition());

            for (int j = 0; j < cols; j++)
                SeatsGrid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btn = new Button();

                    btn.Width = 65;
                    btn.Height = 45;
                    btn.Margin = new Thickness(5);

                    btn.Content = $"{(char)('A' + i)}{j + 1}";

                    btn.Click += Seat_Click;

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);

                    SeatsGrid.Children.Add(btn);
                    seats[i, j] = btn;
                }
            }
        }

        // смена фильма
        void FilmChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSeats();
        }

        // обновление зала
        void UpdateSeats()
        {
            string film = (FilmComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            var hall = cinemaData[film];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (hall[i, j])
                    {
                        seats[i, j].Background = Brushes.Red;
                        seats[i, j].IsEnabled = false;
                    }
                    else
                    {
                        seats[i, j].Background = Brushes.Gray;
                        seats[i, j].IsEnabled = true;
                    }
                }
            }
        }

        // выбор места
        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Background == Brushes.Gray)
                btn.Background = Brushes.LimeGreen;
            else if (btn.Background == Brushes.LimeGreen)
                btn.Background = Brushes.Gray;
        }

        // бронирование
        private void Book_Click(object sender, RoutedEventArgs e)
        {
            string film = (FilmComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var hall = cinemaData[film];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (seats[i, j].Background == Brushes.LimeGreen)
                    {
                        seats[i, j].Background = Brushes.Red;
                        seats[i, j].IsEnabled = false;

                        hall[i, j] = true; // сохраняем
                    }
                }
            }

            MessageBox.Show("Билеты успешно забронированы!");
        }
    }
}