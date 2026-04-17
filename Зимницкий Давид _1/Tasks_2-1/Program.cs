using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите радиус: ");
        double r = Convert.ToDouble(Console.ReadLine());

        double C = 2 * Math.PI * r;
        double S = Math.PI * r * r;

        Console.WriteLine("Длина окружности: " + C);
        Console.WriteLine("Площадь круга: " + S);
    }
}