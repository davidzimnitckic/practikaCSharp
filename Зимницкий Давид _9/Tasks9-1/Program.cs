#pragma warning disable
using System;
using System.IO;

public class FileManager
{
    public void CreateFile(string path, string content)
    {
        File.WriteAllText(path, content);
        Console.WriteLine($"Файл {path} создан и записан.");
    }

    public void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine($"Файл {path} удален.");
        }
        else
        {
            Console.WriteLine($"Файл {path} не существует, удалить невозможно.");
        }
    }

    public void CopyFile(string sourcePath, string destPath)
    {
        File.Copy(sourcePath, destPath, true);
        Console.WriteLine($"Файл скопирован из {sourcePath} в {destPath}.");
    }

    public void MoveFile(string sourcePath, string destPath)
    {
        try
        {
            if (File.Exists(destPath))
                File.Delete(destPath); // удаляем, чтобы избежать ошибки

            File.Move(sourcePath, destPath);
            Console.WriteLine($"Файл перемещен из {sourcePath} в {destPath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при перемещении файла: {ex.Message}");
        }
    }

    public void RenameFile(string sourcePath, string newName)
    {
        string dir = Path.GetDirectoryName(sourcePath);
        string newPath = Path.Combine(dir, newName);

        try
        {
            if (File.Exists(newPath))
                File.Delete(newPath); // удаляем если есть файл с новым именем

            File.Move(sourcePath, newPath);
            Console.WriteLine($"Файл переименован в {newPath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при переименовании файла: {ex.Message}");
        }
    }

    public void SetReadOnly(string path)
    {
        File.SetAttributes(path, FileAttributes.ReadOnly);
        Console.WriteLine($"Файл {path} теперь доступен только для чтения.");
    }

    public void DeleteFilesByPattern(string directory, string pattern)
    {
        var files = Directory.GetFiles(directory, pattern);
        foreach (var file in files)
        {
            File.Delete(file);
            Console.WriteLine($"Файл {file} удален по шаблону {pattern}.");
        }
    }

    public void ListFiles(string directory)
    {
        var files = Directory.GetFiles(directory);
        Console.WriteLine($"Список файлов в {directory}:");
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }

    public void CheckFileAccess(string path)
    {
        bool canRead = false, canWrite = false, canExecute = false;

        try
        {
            using (var fs = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                canRead = true;
            }
        }
        catch { }

        try
        {
            using (var fs = File.Open(path, FileMode.Open, FileAccess.Write))
            {
                canWrite = true;
            }
        }
        catch { }

        try
        {
            canExecute = (File.GetAttributes(path) & FileAttributes.ReadOnly) == 0;
        }
        catch { }

        Console.WriteLine($"Права для {path}: Чтение={canRead}, Запись={canWrite}, Выполнение={canExecute}");
    }
}

public class FileInfoProvider
{
    public void ShowFileInfo(string path)
    {
        if (File.Exists(path))
        {
            FileInfo info = new FileInfo(path);
            Console.WriteLine($"Информация о файле {path}:");
            Console.WriteLine($"Размер: {info.Length} байт");
            Console.WriteLine($"Дата создания: {info.CreationTime}");
            Console.WriteLine($"Дата последнего изменения: {info.LastWriteTime}");
        }
        else
        {
            Console.WriteLine($"Файл {path} не найден.");
        }
    }

    public void CompareFilesBySize(string path1, string path2)
    {
        if (File.Exists(path1) && File.Exists(path2))
        {
            long size1 = new FileInfo(path1).Length;
            long size2 = new FileInfo(path2).Length;

            Console.WriteLine(size1 == size2
                ? "Файлы одинакового размера."
                : $"Файлы разного размера: {size1} vs {size2}");
        }
        else
        {
            Console.WriteLine("Один или оба файла не существуют.");
        }
    }
}

class Program
{
    static void Main()
    {
        string directory = Directory.GetCurrentDirectory();
        string fileName = "zimnitski.dv";
        string fileCopy = "zimnitski_copy.dv";
        string newDir = Path.Combine(directory, "NewFolder");
        Directory.CreateDirectory(newDir);
        string movedFile = Path.Combine(newDir, fileName);

        FileManager fm = new FileManager();
        FileInfoProvider fi = new FileInfoProvider();

        // 1. Создать файл, записать текст и прочитать
        fm.CreateFile(fileName, "Привет, мир!");
        Console.WriteLine(File.ReadAllText(fileName));

        // 2. Проверка существования перед удалением
        fm.DeleteFile("nonexistent.dv");

        // 3. Получить информацию о файле
        fi.ShowFileInfo(fileName);

        // 4. Копирование файла
        fm.CopyFile(fileName, fileCopy);
        Console.WriteLine(File.Exists(fileCopy) ? "Копия существует." : "Копия не создана.");

        // 5. Перемещение файла
        fm.MoveFile(fileName, movedFile);

        // 6. Переименование файла
        fm.RenameFile(fileCopy, "zimnitski.io");

        // 7. Обработка ошибки при удалении несуществующего файла
        fm.DeleteFile("nonexistent.dv");

        // 8. Сравнение двух файлов по размеру
        fi.CompareFilesBySize(Path.Combine(newDir, fileName), "zimnitski.io");

        // 9. Удаление файлов по шаблону
        fm.DeleteFilesByPattern(directory, "*.dv");

        // 10. Вывод списка файлов в директории
        fm.ListFiles(directory);

        // 11. Запрет записи и попытка записи
        fm.SetReadOnly("zimnitski.io");
        try
        {
            File.AppendAllText("zimnitski.io", "Попытка записи");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при записи в файл: " + ex.Message);
        }

        // 12. Проверка доступных прав
        fm.CheckFileAccess("zimnitski.io");
    }
}