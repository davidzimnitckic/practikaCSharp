class Program
{
    static void Main()
    {
        Console.Write("Введите N (1 <= N <= 20): ");
        int N = Convert.ToInt32(Console.ReadLine());

        double sum = 0;

        for (int i = 1; i <= N; i++)
        {
            sum += 1.0 / i;
        }

        Console.WriteLine("Сумма = " + sum.ToString("F4"));
    }
}