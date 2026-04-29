#pragma warning disable
using System;

public interface ICommand
{
    void Execute();
}

public class Printer
{
    public void Print()
    {
        Console.WriteLine("Document is printing...");
    }

    public void Cancel()
    {
        Console.WriteLine("Printing cancelled.");
    }
}

public class PrintDocumentCommand : ICommand
{
    private Printer _printer;

    public PrintDocumentCommand(Printer printer)
    {
        _printer = printer;
    }

    public void Execute()
    {
        _printer.Print();
    }
}

public class CancelPrintCommand : ICommand
{
    private Printer _printer;

    public CancelPrintCommand(Printer printer)
    {
        _printer = printer;
    }

    public void Execute()
    {
        _printer.Cancel();
    }
}

public class PrintManager
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}

class Program
{
    static void Main()
    {
        Printer printer = new Printer();

        ICommand printCommand = new PrintDocumentCommand(printer);
        ICommand cancelCommand = new CancelPrintCommand(printer);

        PrintManager manager = new PrintManager();

        manager.SetCommand(printCommand);
        manager.ExecuteCommand();

        manager.SetCommand(cancelCommand);
        manager.ExecuteCommand();
    }
}