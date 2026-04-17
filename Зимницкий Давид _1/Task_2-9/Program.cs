using System;

class Program
{
    static void Main()
    {
        double A = 0;
        double B = Math.PI / 2;
        int M = 20;

        double H = (B - A) / M;
        double x = A;

        for (int i = 0; i <= M; i++)
        {
            double y = Math.Sin(x) - Math.Cos(x);

            Console.WriteLine($"x = {x:F3}   y = {y:F3}");

            x += H;
        }
    }
}