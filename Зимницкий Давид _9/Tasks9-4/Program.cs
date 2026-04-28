#pragma warning disable
using System;
using System.IO;

public class FileWatcher
{
    private readonly string _directoryPath;
    private FileSystemWatcher _watcher;

    public FileWatcher(string directoryPath)
    {
        _directoryPath = directoryPath;

        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
            Console.WriteLine($"Папка {_directoryPath} создана.");
        }

        _watcher = new FileSystemWatcher(_directoryPath);
        _watcher.IncludeSubdirectories = false;
        _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size;

        _watcher.Created += OnCreated;
        _watcher.Deleted += OnDeleted;
        _watcher.Changed += OnChanged;
        _watcher.Renamed += OnRenamed;
    }

    public void Start()
    {
        _watcher.EnableRaisingEvents = true;
        Console.WriteLine($"Начато отслеживание папки: {_directoryPath}");
    }

    public void Stop()
    {
        _watcher.EnableRaisingEvents = false;
        Console.WriteLine("Отслеживание остановлено.");
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Файл создан: {e.Name}");
        ShowFileCount();
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Файл удален: {e.Name}");
        ShowFileCount();
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Файл изменен: {e.Name}");
        ShowFileCount();
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"Файл переименован: {e.OldName} -> {e.Name}");
        ShowFileCount();
    }

    private void ShowFileCount()
    {
        int count = Directory.GetFiles(_directoryPath).Length;
        Console.WriteLine($"Общее количество файлов в папке: {count}");
    }
}

class Program
{
    static void Main()
    {
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "WatchFolder");

        FileWatcher watcher = new FileWatcher(folderPath);
        watcher.Start();

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();

        watcher.Stop();
    }
}