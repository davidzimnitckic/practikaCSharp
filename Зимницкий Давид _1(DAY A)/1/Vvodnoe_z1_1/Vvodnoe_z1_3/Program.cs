#pragma warning disable
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите m: ");
        double m = double.Parse(Console.ReadLine());

        double z1 = Math.Sqrt(Math.Pow(3 * m + 2, 2) - 24 * m) /
                    (3 * Math.Sqrt(m) - 2 / Math.Sqrt(m));

        double z2 = -Math.Sqrt(m);

        Console.WriteLine("z1 = {0:F4}", z1);
        Console.WriteLine("z2 = {0:F4}", z2);
    }
}