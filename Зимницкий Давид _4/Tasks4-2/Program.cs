#pragma warning disable

using System;

class Program
{
    static void Main()
    {
        double A = 1, B = 2, C = 3, D = 4;

        Swap(ref A, ref B); // A <-> B
        Swap(ref C, ref D); // C <-> D
        Swap(ref B, ref C); // B <-> C

        Console.WriteLine($"A = {A}");
        Console.WriteLine($"B = {B}");
        Console.WriteLine($"C = {C}");
        Console.WriteLine($"D = {D}");
    }

    static void Swap(ref double X, ref double Y)
    {
        double temp = X;
        X = Y;
        Y = temp;
    }
}