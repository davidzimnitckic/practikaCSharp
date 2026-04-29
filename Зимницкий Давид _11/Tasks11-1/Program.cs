#pragma warning disable

using System;

public interface IAnimal
{
    void MakeSound();
}

public class Dog : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Dog says: Woof");
    }
}

public class Cat : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Cat says: Meow");
    }
}

public class Bird : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Bird says: Tweet");
    }
}

public abstract class AnimalFactory
{
    public abstract IAnimal CreateAnimal();
}

public class DogFactory : AnimalFactory
{
    public override IAnimal CreateAnimal()
    {
        return new Dog();
    }
}

public class CatFactory : AnimalFactory
{
    public override IAnimal CreateAnimal()
    {
        return new Cat();
    }
}

public class BirdFactory : AnimalFactory
{
    public override IAnimal CreateAnimal()
    {
        return new Bird();
    }
}

class Program
{
    static void Main()
    {
        AnimalFactory factory;

        factory = new DogFactory();
        IAnimal dog = factory.CreateAnimal();
        dog.MakeSound();

        factory = new CatFactory();
        IAnimal cat = factory.CreateAnimal();
        cat.MakeSound();

        factory = new BirdFactory();
        IAnimal bird = factory.CreateAnimal();
        bird.MakeSound();
    }
}