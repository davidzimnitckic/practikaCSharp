#pragma warning disable
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double sum = a + b;

        Console.WriteLine(a + " + " + b + " = " + sum);

        Console.ReadKey();
    }
}