#pragma warning disable
using System;
using System.IO;
using System.Text.Json;

public interface ISerializer<T>
{
    string Serialize(T item);
    T Deserialize(string data);
}

public class JsonSerializerCustom<T> : ISerializer<T>
{
    public string Serialize(T item)
    {
        return JsonSerializer.Serialize(item);
    }

    public T Deserialize(string data)
    {
        return JsonSerializer.Deserialize<T>(data);
    }
}

public class SerializerManager<T>
{
    private ISerializer<T> serializer;

    public SerializerManager(ISerializer<T> serializer)
    {
        this.serializer = serializer;
    }

    public void SaveToFile(T item, string filename)
    {
        string json = serializer.Serialize(item);
        File.WriteAllText(filename, json);
        Console.WriteLine("Сохранено в файл.");
    }

    public T LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Файл не найден.");
            return default(T);
        }

        string json = File.ReadAllText(filename);
        return serializer.Deserialize(json);
    }
}

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }

    public override string ToString()
    {
        return $"Игрок: {Name}, Уровень: {Level}";
    }
}

public class PlayerService
{
    private SerializerManager<Player> manager;

    public PlayerService()
    {
        manager = new SerializerManager<Player>(new JsonSerializerCustom<Player>());
    }

    public void SavePlayer(Player player)
    {
        manager.SaveToFile(player, "player.json");
    }

    public void LoadPlayer()
    {
        Player player = manager.LoadFromFile("player.json");

        if (player != null)
            Console.WriteLine(player);
    }
}

class Program
{
    static void Main()
    {
        PlayerService service = new PlayerService();

        while (true)
        {
            Console.WriteLine("1. Сохранить игрока");
            Console.WriteLine("2. Загрузить игрока");
            Console.WriteLine("0. Выход");

            Console.Write("Выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Имя: ");
                    string name = Console.ReadLine();

                    Console.Write("Уровень: ");
                    int level = int.Parse(Console.ReadLine());

                    Player player = new Player { Name = name, Level = level };
                    service.SavePlayer(player);
                    break;

                case "2":
                    service.LoadPlayer();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Ошибка.");
                    break;
            }
        }
    }
}