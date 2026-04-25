#pragma warning disable

using System;

public class InvalidEmailFormatException : Exception
{
    public InvalidEmailFormatException()
        : base("Неверный формат email")
    {
    }

    public InvalidEmailFormatException(string message)
        : base(message)
    {
    }

    public InvalidEmailFormatException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class EmailValidator
{
    public void ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new InvalidEmailFormatException("Email не может быть пустым");
        }

        if (!email.Contains("@") || email.Contains(".."))
        {
            throw new InvalidEmailFormatException(
                "Email должен содержать '@' и не должен содержать '..'"
            );
        }
    }
}

class Program
{
    static void Main()
    {
        EmailValidator validator = new EmailValidator();

        Console.Write("Введите email: ");
        string email = Console.ReadLine();

        try
        {
            validator.ValidateEmail(email);
            Console.WriteLine("Email корректный");
        }
        catch (InvalidEmailFormatException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Другая ошибка: " + ex.Message);
        }
    }
}