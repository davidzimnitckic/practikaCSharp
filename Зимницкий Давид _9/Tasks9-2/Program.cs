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
}

// Класс записи клиентов в файл
public class CustomerFileWriter
{
    private string filePath = "file.data";

    public void WriteUniqueCustomers(List<Customer> customers)
    {
        // Читаем существующие записи из файла
        HashSet<int> existingIds = new HashSet<int>();
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length >= 2 && int.TryParse(parts[0], out int id))
                    existingIds.Add(id);
            }
        }

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (var customer in customers)
            {
                if (!existingIds.Contains(customer.Id))
                {
                    writer.WriteLine($"{customer.Id};{customer.Name}");
                    existingIds.Add(customer.Id); // Добавляем в множество, чтобы избежать дубликатов в текущем списке
                    Console.WriteLine($"Записан клиент: Id={customer.Id}, Name={customer.Name}");
                }
                else
                {
                    Console.WriteLine($"Клиент с Id={customer.Id} уже существует, пропущен.");
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Иванов" },
            new Customer { Id = 2, Name = "Петров" },
            new Customer { Id = 3, Name = "Сидоров" },
            new Customer { Id = 1, Name = "Иванов" }, // дубликат
            new Customer { Id = 4, Name = "Зайцев" }
        };

        CustomerFileWriter writer = new CustomerFileWriter();
        writer.WriteUniqueCustomers(customers);

        // Проверяем содержимое файла
        Console.WriteLine("\nСодержимое file.data:");
        if (File.Exists("file.data"))
        {
            var lines = File.ReadAllLines("file.data");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}