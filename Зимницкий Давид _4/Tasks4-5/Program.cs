#pragma warning disable
using System;

abstract class Food
{
    public abstract void Cook();

    public virtual void Serve()
    {
        Console.WriteLine("Food is served");
    }
}

class Pizza : Food
{
    public override void Cook()
    {
        Console.WriteLine("Pizza is cooking");
    }

    public override void Serve()
    {
        Console.WriteLine("Pizza is served");
    }
}

class Pasta : Food
{
    public override void Cook()
    {
        Console.WriteLine("Pasta is cooking");
    }

    public override void Serve()
    {
        Console.WriteLine("Pasta is served");
    }
}

class Program
{
    static void Main()
    {
        Food pizza = new Pizza();
        Food pasta = new Pasta();

        pizza.Cook();
        pizza.Serve();

        pasta.Cook();
        pasta.Serve();
    }
}