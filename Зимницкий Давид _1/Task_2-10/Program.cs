#pragma warning disable
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());

        double[] a = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i}] = ");
            a[i] = double.Parse(Console.ReadLine());
        }

        double max = Math.Abs(a[0]);

        for (int i = 1; i < n; i++)
        {
            double current = Math.Abs(a[i]);

            if (current > max)
            {
                max = current;
            }
        }

        Console.WriteLine($"Максимум по модулю = {max}");
    }
}