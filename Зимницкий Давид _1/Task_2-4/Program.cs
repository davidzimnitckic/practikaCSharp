using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        double y;

        if (x <= Math.PI)
        {
            y = x + 2 * x * Math.Sin(3 * x);
        }
        else
        {
            y = Math.Cos(x) + 2;
        }

        Console.WriteLine("y = " + y);
    }
}