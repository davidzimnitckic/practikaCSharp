using System;

class Program
{
    static void Main()
    {
        double amount = 100;

        ConvertCurrency(in amount, out double result1);
        Console.WriteLine($"Result 1: {result1}");

        ConvertCurrency(in amount, 1.2, out double result2);
        Console.WriteLine($"Result 2: {result2}");
    }

    static void ConvertCurrency(in double amount, out double convertedAmount)
    {
        double fixedRate = 1.1;
        convertedAmount = amount * fixedRate;
    }

    static void ConvertCurrency(in double amount, double exchangeRate, out double convertedAmount)
    {
        convertedAmount = amount * exchangeRate;
    }
}