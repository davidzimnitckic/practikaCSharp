using System;

delegate int Del(int a, bool f);

class Program
{
    static int Test1(int a, bool f)

    {
        Console.WriteLine("Метод Test1");
        return 1;
    }

    static int Test2(int a, bool f)
    {
        Console.WriteLine("Метод Test2");
        return 2;
    }

    static void Main()
    {
        // 1. Создайте делегат и привяжите к нему метод Test1 через new
        // TODO: напишите код
        Del del = new Del(Test1);
        // 2. Добавьте к делегату метод Test2
        del += new Del(Test2);
        del -= new Del(Test1);
        del();
        // 3. Вызовите делегат

        // 4. Удалите из делегата метод Test1

        // 5. Снова вызовите делегат
        // 6. Объясните (в комментарии ниже):
        // - что такое делегат
        // - что делает +=
        // - что делает -=
        // - какой будет вывод программы на каждом этапе
    }
}