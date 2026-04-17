#pragma warning disable
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите начальную скорость v0: ");
        double v0 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите ускорение a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите время t: ");
        double t = Convert.ToDouble(Console.ReadLine());

        double v = v0 + a * t;
        double S = v0 * t + 0.5 * a * t * t;

        Console.WriteLine("Скорость v = " + v.ToString("F2"));
        Console.WriteLine("Расстояние S = " + S.ToString("F2"));

        Console.ReadKey();
    }
}