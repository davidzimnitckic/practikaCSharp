using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер месяца (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите день месяца: ");
        int day = Convert.ToInt32(Console.ReadLine());

        int daysInMonth = 0;

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                daysInMonth = 31;
                break;

            case 4:
            case 6:
            case 9:
            case 11:
                daysInMonth = 30;
                break;

            case 2:
                daysInMonth = 28; 
                break;

            default:
                Console.WriteLine("Неверный месяц");
                return;
        }

        int remainingDays = daysInMonth - day;

        Console.WriteLine("Осталось дней: " + remainingDays);
    }
}