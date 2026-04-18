int[] arr = { -5, 3, -2, 7, -1, 0 };
int count = 0;

foreach (int x in arr)
{
    if (x < 0)
        count++;
}

Console.WriteLine("Количество отрицательных: " + count);