#pragma warning disable

using System;

interface IErrorLogger
{
    void Log(string message);
}

interface IEventLogger
{
    void Log(string message);
}

class Logger : IErrorLogger, IEventLogger
{
    void IErrorLogger.Log(string message)
    {
        Console.WriteLine("ERROR: " + message);
    }

    void IEventLogger.Log(string message)
    {
        Console.WriteLine("EVENT: " + message);
    }
}

class Program
{
    static void Main()
    {
        Logger logger = new Logger();

        IErrorLogger errorLogger = logger;
        IEventLogger eventLogger = logger;

        errorLogger.Log("Произошла ошибка!");
        eventLogger.Log("Пользователь вошел в систему.");
    }
}