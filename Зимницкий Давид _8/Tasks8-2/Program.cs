#pragma warning disable
using System;
using System.Collections.Generic;

public class MyBag<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public bool Remove(T item)
    {
        return items.Remove(item);
    }

    public bool Contains(T item)
    {
        return items.Contains(item);
    }

    public int Count()
    {
        return items.Count;
    }

    public void ShowAll()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Мешок пуст.");
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void Sort()
    {
        items.Sort();
    }
}

public class BagManager<T>
{
    private MyBag<T> bag = new MyBag<T>();

    public void AddItem(T item)
    {
        bag.Add(item);
        Console.WriteLine("Предмет добавлен.");
    }

    public void RemoveItem(T item)
    {
        if (bag.Remove(item))
            Console.WriteLine("Предмет удалён.");
        else
            Console.WriteLine("Предмет не найден.");
    }

    public void CheckItem(T item)
    {
        if (bag.Contains(item))
            Console.WriteLine("Предмет есть.");
        else
            Console.WriteLine("Предмета нет.");
    }

    public void ShowInventory()
    {
        Console.WriteLine("Инвентарь:");
        bag.ShowAll();
    }

    public void SortInventory()
    {
        try
        {
            bag.Sort();
            Console.WriteLine("Отсортировано.");
        }
        catch
        {
            Console.WriteLine("Нельзя сортировать этот тип.");
        }
    }
}

class Program
{
    static void Main()
    {
        BagManager<string> manager = new BagManager<string>();

        while (true)
        {
            Console.WriteLine("1. Добавить предмет");
            Console.WriteLine("2. Удалить предмет");
            Console.WriteLine("3. Проверить предмет");
            Console.WriteLine("4. Показать инвентарь");
            Console.WriteLine("5. Сортировать");
            Console.WriteLine("0. Выход");

            Console.Write("Выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите предмет: ");
                    manager.AddItem(Console.ReadLine());
                    break;

                case "2":
                    Console.Write("Введите предмет: ");
                    manager.RemoveItem(Console.ReadLine());
                    break;

                case "3":
                    Console.Write("Введите предмет: ");
                    manager.CheckItem(Console.ReadLine());
                    break;

                case "4":
                    manager.ShowInventory();
                    break;

                case "5":
                    manager.SortInventory();
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