using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите курс (руб за 1$): ");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- FOR ---");
        ForMethod(rate);

        Console.WriteLine("\n--- WHILE ---");
        WhileMethod(rate);

        Console.WriteLine("\n--- DO WHILE ---");
        DoWhileMethod(rate);
    }

    static void ForMethod(double rate)
    {
        for (int dollars = 5; dollars <= 500; dollars += 5)
        {
            Console.WriteLine(dollars + " $ = " + dollars * rate + " руб.");
        }
    }

    static void WhileMethod(double rate)
    {
        int dollars = 5;

        while (dollars <= 500)
        {
            Console.WriteLine(dollars + " $ = " + dollars * rate + " руб.");
            dollars += 5;
        }
    }

    static void DoWhileMethod(double rate)
    {
        int dollars = 5;

        do
        {
            Console.WriteLine(dollars + " $ = " + dollars * rate + " руб.");
            dollars += 5;
        }
        while (dollars <= 500);
    }
}