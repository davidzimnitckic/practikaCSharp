#pragma warning disable
using System;
using System.Collections.Generic;

public class OutOfStockException : Exception
{
    public OutOfStockException()
        : base("Товар отсутствует на складе")
    {
    }

    public OutOfStockException(string message)
        : base(message)
    {
    }

    public OutOfStockException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class Inventory
{
    private List<string> items = new List<string>
    {
        "Ноутбук",
        "Телефон",
        "Мышка"
    };

    public void CheckStock(string item)
    {
        if (!items.Contains(item))
        {
            throw new OutOfStockException($"Товар \"{item}\" отсутствует на складе");
        }

        Console.WriteLine($"Товар \"{item}\" есть в наличии ✅");
    }
}

class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory();

        Console.Write("Введите название товара: ");
        string item = Console.ReadLine();

        try
        {
            inventory.CheckStock(item);
        }
        catch (OutOfStockException ex)
        {
            Console.WriteLine("Ошибка ❌: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Другая ошибка: " + ex.Message);
        }
    }
}