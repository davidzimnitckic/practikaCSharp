using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите четырехзначное число: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int a = num / 1000;          
        int b = (num / 100) % 10;    
        int c = (num / 10) % 10;     
        int d = num % 10;            

        if (a == d && b == c)
        {
            Console.WriteLine("Число читается одинаково (палиндром)");
        }
        else
        {
            Console.WriteLine("Число НЕ является палиндромом");
        }
    }
}