using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите цену за 1 кг: ");
        int A = Convert.ToInt32(Console.ReadLine());

        for (int kg = 1; kg <= 10; kg++)
        {
            int cost = kg * A;
            Console.WriteLine(kg + " кг = " + cost);
        }
    }
}