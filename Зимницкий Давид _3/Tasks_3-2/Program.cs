using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} ({Age})";
    }
}

static class PersonArrayUtils
{
    public static void ShuffleArray(Person[] people)
    {
        Random rand = new Random();

        for (int i = people.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);

            Person temp = people[i];
            people[i] = people[j];
            people[j] = temp;
        }
    }

    public static void PrintArray(Person[] people)
    {
        foreach (var p in people)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[]
        {
            new Person("Иван", 20),
            new Person("Анна", 22),
            new Person("Олег", 19),
            new Person("Мария", 21)
        };

        Console.WriteLine("До перемешивания:");
        PersonArrayUtils.PrintArray(people);

        PersonArrayUtils.ShuffleArray(people);

        Console.WriteLine("После перемешивания:");
        PersonArrayUtils.PrintArray(people);
    }
}