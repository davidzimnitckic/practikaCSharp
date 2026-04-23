#pragma warning disable
using System;
class Program
{
    static void Main()
    {
        int D1 = 120, D2 = 75, D3 = 200;

        PrintResult(D1);
        PrintResult(D2);
        PrintResult(D3);
    }
    static void DistanceToHours(int KM, out int H, out int M)
    {
        H = KM / 60;          // целые часы
        M = KM % 60;          // остаток = минуты
    }
    static void PrintResult(int distance)
    {
        DistanceToHours(distance, out int h, out int m);
        Console.WriteLine($"{distance} км = {h} ч {m} мин");
    }
}