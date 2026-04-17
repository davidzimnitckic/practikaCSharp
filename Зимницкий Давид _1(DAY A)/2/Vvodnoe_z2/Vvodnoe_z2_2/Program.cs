#pragma warning disable
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите трехзначное число: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int a = num / 100;        
        int b = (num / 10) % 10; 
        int c = num % 10;       

        Console.WriteLine("Перестановки:");

        Console.WriteLine($"{a}{b}{c}");
        Console.WriteLine($"{a}{c}{b}");
        Console.WriteLine($"{b}{a}{c}");
        Console.WriteLine($"{b}{c}{a}");
        Console.WriteLine($"{c}{a}{b}");
        Console.WriteLine($"{c}{b}{a}");

        Console.ReadKey();
    }
}