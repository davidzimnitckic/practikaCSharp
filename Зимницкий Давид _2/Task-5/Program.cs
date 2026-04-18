int[][] arr = {
    new int[] {1, 2, 3},
    new int[] {3, 2, 1},
    new int[] {2, 1, 3}
};

bool isPermutation = true;

var sorted = arr[0].OrderBy(x => x).ToArray();

foreach (var row in arr)
{
    if (!row.OrderBy(x => x).SequenceEqual(sorted))
    {
        isPermutation = false;
        break;
    }
}

Console.WriteLine(isPermutation ? "Да" : "Нет");