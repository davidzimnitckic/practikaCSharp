#pragma warning disable

using System;

public class DeserializationException : Exception
{
    public DeserializationException()
        : base("Ошибка десериализации")
    {
    }

    public DeserializationException(string message)
        : base(message)
    {
    }

    public DeserializationException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class XmlDeserializer
{
    public void Deserialize(string xml)
    {
        if (string.IsNullOrEmpty(xml) || !xml.Contains("<") || !xml.Contains(">"))
        {
            throw new InvalidOperationException("Неверный формат XML");
        }

        Console.WriteLine("XML успешно обработан ✅");
    }
}

public class XmlProcessor
{
    private XmlDeserializer _deserializer = new XmlDeserializer();

    public void Process(string xml)
    {
        try
        {
            _deserializer.Deserialize(xml);
        }
        catch (Exception ex)
        {
            throw new DeserializationException("Ошибка при обработке XML", ex);
        }
    }
}
class Program
{
    static void Main()
    {
        XmlProcessor processor = new XmlProcessor();

        Console.Write("Введите XML: ");
        string xml = Console.ReadLine();

        try
        {
            processor.Process(xml);
        }
        catch (DeserializationException ex)
        {
            Console.WriteLine("Ошибка ❌: " + ex.Message);

            Console.WriteLine("--- ЛОГ ---");
            Console.WriteLine("StackTrace:");
            Console.WriteLine(ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.WriteLine("\nInner Exception:");
                Console.WriteLine("Тип: " + ex.InnerException.GetType().Name);
                Console.WriteLine("Сообщение: " + ex.InnerException.Message);
                Console.WriteLine("StackTrace:");
                Console.WriteLine(ex.InnerException.StackTrace);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Другая ошибка: " + ex.Message);
        }
    }
}