#pragma warning disable
using System;
using System.Collections;

public class HotelRoom
{
    public int RoomNumber { get; set; }
    public string GuestName { get; set; }

    public HotelRoom(int roomNumber, string guestName)
    {
        RoomNumber = roomNumber;
        GuestName = guestName;
    }

    public override string ToString()
    {
        return $"Room: {RoomNumber}, Guest: {GuestName}";
    }
}

public class HotelReservationSystem
{
    private Hashtable rooms = new Hashtable();

    public void AddReservation(int roomNumber, string guestName)
    {
        if (rooms.ContainsKey(roomNumber))
        {
            Console.WriteLine("Этот номер уже занят!");
            return;
        }

        rooms.Add(roomNumber, new HotelRoom(roomNumber, guestName));
        Console.WriteLine("Бронирование добавлено.");
    }

    public void RemoveReservation(int roomNumber)
    {
        if (!rooms.ContainsKey(roomNumber))
        {
            Console.WriteLine("Номер не найден.");
            return;
        }

        rooms.Remove(roomNumber);
        Console.WriteLine("Бронирование удалено.");
    }

    public void FindReservation(int roomNumber)
    {
        if (rooms.ContainsKey(roomNumber))
        {
            HotelRoom room = (HotelRoom)rooms[roomNumber];
            Console.WriteLine(room);
        }
        else
        {
            Console.WriteLine("Номер не найден.");
        }
    }

    public void ShowAll()
    {
        if (rooms.Count == 0)
        {
            Console.WriteLine("Нет бронирований.");
            return;
        }

        foreach (DictionaryEntry entry in rooms)
        {
            HotelRoom room = (HotelRoom)entry.Value;
            Console.WriteLine(room);
        }
    }

    public void FindByGuest(string guestName)
    {
        bool found = false;

        foreach (DictionaryEntry entry in rooms)
        {
            HotelRoom room = (HotelRoom)entry.Value;

            if (room.GuestName.ToLower().Contains(guestName.ToLower()))
            {
                Console.WriteLine(room);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Гость не найден.");
        }
    }
}

class Program
{
    static void Main()
    {
        HotelReservationSystem system = new HotelReservationSystem();

        while (true)
        {
            Console.WriteLine("1. Добавить");
            Console.WriteLine("2. Удалить");
            Console.WriteLine("3. Найти номер");
            Console.WriteLine("4. Показать все");
            Console.WriteLine("5. Найти по имени");
            Console.WriteLine("0. Выход");

            Console.Write("Выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Номер комнаты: ");
                    int room = int.Parse(Console.ReadLine());

                    Console.Write("Имя гостя: ");
                    string name = Console.ReadLine();

                    system.AddReservation(room, name);
                    break;

                case "2":
                    Console.Write("Номер комнаты: ");
                    system.RemoveReservation(int.Parse(Console.ReadLine()));
                    break;

                case "3":
                    Console.Write("Номер комнаты: ");
                    system.FindReservation(int.Parse(Console.ReadLine()));
                    break;

                case "4":
                    system.ShowAll();
                    break;

                case "5":
                    Console.Write("Имя: ");
                    system.FindByGuest(Console.ReadLine());
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}