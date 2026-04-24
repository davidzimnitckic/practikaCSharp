#pragma warning disable

using System;

public delegate void ImageProcessor(string imagePath);

public class ImageService
{
    public void ProcessImage(string path, ImageProcessor processor)
    {
        Console.WriteLine("Началась обработка изображения...");

        processor(path);

        Console.WriteLine("Обработка завершена!");
        Console.WriteLine();
    }

    public void ResizeImage(string path)
    {
        Console.WriteLine($"Изображение {path} изменено до нужного размера.");
    }

    public void ConvertToGrayscale(string path)
    {
        Console.WriteLine($"Изображение {path} переведено в черно-белый формат.");
    }
}

class Program
{
    static void Main()
    {
        ImageService service = new ImageService();

        string path = "image.jpg";

        service.ProcessImage(path, service.ResizeImage);

        service.ProcessImage(path, service.ConvertToGrayscale);
    }
}