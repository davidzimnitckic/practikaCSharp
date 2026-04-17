#pragma warning disable
using System;

class Program
{
    static void Main()
    {
        double x = 2.7;

        double y = Math.Log(x + Math.Sqrt(x * x + 9))
                   - (x + 1) / Math.Atan(Math.Pow(x, 3));

        Console.WriteLine("y = " + y.ToString("F4"));

        Console.ReadKey();
    }
}