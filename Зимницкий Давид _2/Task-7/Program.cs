string s = "abcabcbb";
int maxLength = 0;

for (int i = 0; i < s.Length; i++)
{
    HashSet<char> set = new HashSet<char>();
    for (int j = i; j < s.Length; j++)
    {
        if (set.Contains(s[j]))
            break;

        set.Add(s[j]);
        maxLength = Math.Max(maxLength, j - i + 1);
    }
}

Console.WriteLine(maxLength);