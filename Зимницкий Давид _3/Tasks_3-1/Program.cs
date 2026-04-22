#pragma warning disable
using System;

class A
{
    private int a;
    private int b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public double CalculateExpression()
    {
        return (Math.Sin(b) + 4) / (2 * a);
    }

    public int SquareSum()
    {
        return (a + b) * (a + b);
    }

    public void Show()
    {
        Console.WriteLine($"a = {a}, b = {b}");
    }
}

class Program
{
    static void Main()
    {
        A obj = new A(2, 3);

        obj.Show();

        double result1 = obj.CalculateExpression();
        int result2 = obj.SquareSum();

        Console.WriteLine($"Результат выражения: {result1}");
        Console.WriteLine($"Квадрат суммы: {result2}");
    }
}