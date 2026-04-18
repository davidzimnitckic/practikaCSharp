int[,] matrix = {
    {1, 2},
    {3, 4},
    {5, 6}
};

int rows = matrix.GetLength(0);
int cols = matrix.GetLength(1);

int sumFirst = 0, sumPreLast = 0;

for (int j = 0; j < cols; j++)
{
    sumFirst += matrix[0, j];
    sumPreLast += matrix[rows - 2, j];
}

if (sumFirst > sumPreLast)
    Console.WriteLine("Первая больше");
else
    Console.WriteLine("Предпоследняя больше");