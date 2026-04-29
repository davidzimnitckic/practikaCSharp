#pragma warning disable

using System;
using System.Collections.Generic;

interface ISystemObserver
{
    void Update(string message);
}

class Admin : ISystemObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"[Admin] Получено уведомление: {message}");
    }
}

class DevOps : ISystemObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"[DevOps] Реакция на событие: {message}");
    }
}

class ServerMonitor
{
    private List<ISystemObserver> observers = new List<ISystemObserver>();

    public void Subscribe(ISystemObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(ISystemObserver observer)
    {
        observers.Remove(observer);
    }

    private void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }

    public void CheckServer(int load)
    {
        Console.WriteLine($"Текущая нагрузка: {load}%");

        if (load > 80)
        {
            Notify("⚠️ Сервер перегружен!");
        }
        else
        {
            Console.WriteLine("Сервер работает нормально");
        }
    }
}

class Program
{
    static void Main()
    {
        ServerMonitor monitor = new ServerMonitor();

        Admin admin = new Admin();
        DevOps devOps = new DevOps();

        monitor.Subscribe(admin);
        monitor.Subscribe(devOps);

        monitor.CheckServer(50);
        monitor.CheckServer(90);

        Console.WriteLine("---- Один отписался ----");

        monitor.Unsubscribe(admin);

        monitor.CheckServer(95);
    }
}