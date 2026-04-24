#pragma warning disable

using System;

public delegate void BatteryLowHandler(int level);

public class BatteryMonitor
{
    public event BatteryLowHandler BatteryLow;

    public void CheckBattery(int level)
    {
        Console.WriteLine($"Текущий заряд: {level}%");

        if (level < 20)
        {
            Console.WriteLine("⚠️ Низкий заряд батареи!");

            BatteryLow?.Invoke(level);
        }
    }
}

public class PowerSaver
{
    public void EnablePowerSaving(int level)
    {
        Console.WriteLine("🔋 Включен режим энергосбережения.");
    }
}

public class UserNotifier
{
    public void NotifyUser(int level)
    {
        Console.WriteLine($"📢 Уведомление: заряд батареи {level}%. Подключите зарядку!");
    }
}
class Program
{
    static void Main()
    {
        BatteryMonitor monitor = new BatteryMonitor();

        PowerSaver saver = new PowerSaver();
        UserNotifier notifier = new UserNotifier();

        monitor.BatteryLow += saver.EnablePowerSaving;
        monitor.BatteryLow += notifier.NotifyUser;

        monitor.CheckBattery(50);
        Console.WriteLine();

        monitor.CheckBattery(15); 
    }
}