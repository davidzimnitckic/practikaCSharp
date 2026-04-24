#pragma warning disable
using System;
using System.IO;

public delegate void FileHandler(string path);

public class FileReader
{
    public void ReadFile(string path)
    {
        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("Файл не найден!");
        }
    }
}

public class FileWriter
{
    public void WriteFile(string path)
    {
        Console.WriteLine("Введите текст для записи:");
        string text = Console.ReadLine();

        File.WriteAllText(path, text);
        Console.WriteLine("Файл успешно записан!");
    }
}

class Program
{
    static void Main()
    {
        string path = "test.txt";

        FileReader reader = new FileReader();
        FileWriter writer = new FileWriter();

        FileHandler handler;

        handler = writer.WriteFile;
        handler(path);

        Console.WriteLine();

        handler = reader.ReadFile;
        handler(path);
    }
}