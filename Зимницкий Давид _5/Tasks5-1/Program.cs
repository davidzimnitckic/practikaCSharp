#pragma warning disable
using System;

abstract class Worker
{
    public abstract void DoWork();
}

class Welder : Worker
{
    public override void DoWork()
    {
        Console.WriteLine("Сварщик выполняет сварку деталей.");
    }
}

class Assembler : Worker
{
    public override void DoWork()
    {
        Console.WriteLine("Сборщик собирает изделия.");
    }
}

class Electrician : Worker
{
    public override void DoWork()
    {
        Console.WriteLine("Электрик проводит электрические работы.");
    }
}

class Program
{
    static void Main()
    {
        Worker[] workers = new Worker[]
        {
            new Welder(),
            new Assembler(),
            new Electrician()
        };

        foreach (Worker worker in workers)
        {
            worker.DoWork();
        }
    }
}