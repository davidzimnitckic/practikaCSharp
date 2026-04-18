int n = 3;
int[,] matrix = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

int G = 4;
int k = 1; 

double sum = 0;
int count = 0;

foreach (int x in matrix)
{
    if (x > G)
    {
        sum += x;
        count++;
    }
}

double avg = sum / count;

int evenCount = 0;
for (int j = 0; j < n; j++)
{
    if (matrix[k, j] % 2 == 0)
        evenCount++;
}

Console.WriteLine($"Среднее: {avg}, Четных в строке: {evenCount}");