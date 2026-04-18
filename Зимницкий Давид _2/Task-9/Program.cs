using System.Text;

StringBuilder sb = new StringBuilder("Hello");

string str = sb.ToString();

StringBuilder sb2 = new StringBuilder(str);

Console.WriteLine(sb2);