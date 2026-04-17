#pragma warning disable
using System;

//Вычислить расстояние между населенными пунктами по карте.
class Program
{
    static void Main()
    {
        Console.WriteLine("Вычисление расстояния между населенными пунктами");

        Console.Write("Масштаб карты (км в 1 см): ");
        //m — масштаб (км в 1 см)
        double m = double.Parse(Console.ReadLine());

        Console.Write("Расстояние на карте (см): ");
        //d — расстояние на карте (см)
        double d = double.Parse(Console.ReadLine());

        double S = m * d;

        Console.WriteLine("Расстояние между населенными пунктами: {0:F2} км", S);
    }
}