#pragma warning disable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Модельный класс клиента
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Переопределяем Equals и GetHashCode для удобного сравнения по Id
    public override bool Equals(object obj)
    {
        if (obj is Customer other)
            return this.Id == other.Id;
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"Id={Id}, Name={Name}";
    }
}

// Класс для чтения клиентов из файла
public class CustomerFileReader
{
    private string filePath = "file.data";

    public List<Customer> ReadCustomers()
    {
        List<Customer> customers = new List<Customer>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {filePath} не найден.");
            return customers;
        }

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (parts.Length >= 2 && int.TryParse(parts[0], out int id))
            {
                customers.Add(new Customer
                {
                    Id = id,
                    Name = parts[1]
                });
            }
        }

        return customers;
    }
}

// Класс для обработки клиентов (поиск дубликатов, фильтрация, сортировка)
public class CustomerProcessor
{
    private List<Customer> _customers;

    public CustomerProcessor(List<Customer> customers)
    {
        _customers = customers;
    }

    // Метод поиска дубликатов по Id
    public List<Customer> FindDuplicates()
    {
        var duplicates = _customers
            .GroupBy(c => c.Id)
            .Where(g => g.Count() > 1)
            .SelectMany(g => g)
            .ToList();

        return duplicates;
    }

    // Сортировка по имени
    public List<Customer> SortByName()
    {
        return _customers.OrderBy(c => c.Name).ToList();
    }

    // Фильтрация по условию (например, имя начинается с буквы)
    public List<Customer> FilterByNameStart(char startLetter)
    {
        return _customers.Where(c => c.Name.StartsWith(startLetter.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

class Program
{
    static void Main()
    {
        // Чтение клиентов из файла
        CustomerFileReader reader = new CustomerFileReader();
        var customers = reader.ReadCustomers();

        Console.WriteLine("Клиенты, загруженные из файла:");
        foreach (var c in customers)
        {
            Console.WriteLine(c);
        }

        // Обработка клиентов
        CustomerProcessor processor = new CustomerProcessor(customers);

        // Поиск дубликатов
        var duplicates = processor.FindDuplicates();
        Console.WriteLine("\nНайденные дубликаты по Id:");
        if (duplicates.Count == 0)
            Console.WriteLine("Дубликаты отсутствуют.");
        else
            duplicates.ForEach(c => Console.WriteLine(c));

        // Сортировка по имени
        var sorted = processor.SortByName();
        Console.WriteLine("\nКлиенты, отсортированные по имени:");
        sorted.ForEach(c => Console.WriteLine(c));

        // Фильтрация по имени
        var filtered = processor.FilterByNameStart('И'); // например, имена на "И"
        Console.WriteLine("\nКлиенты с именем на 'И':");
        filtered.ForEach(c => Console.WriteLine(c));
    }
}