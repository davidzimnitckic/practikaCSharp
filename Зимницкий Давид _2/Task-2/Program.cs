int[] arr = { 5, 2, 9, 1, 7 };

int min = arr.Min();
int max = arr.Max();

var result = arr.Where(x => x != min && x != max).ToArray();

Console.WriteLine(string.Join(" ", result));