#pragma warning disable

using System;

public class UserEventArgs : EventArgs
{
    public string Username { get; set; }
}

public class UserLoginManager
{
    public event EventHandler<UserEventArgs> UserLoggedIn;

    public void Login(string username)
    {
        Console.WriteLine($"Пользователь {username} вошел в систему.");

        OnUserLoggedIn(username);
    }

    protected virtual void OnUserLoggedIn(string username)
    {
        UserLoggedIn?.Invoke(this, new UserEventArgs { Username = username });
    }
}

public class SecuritySystem
{
    public void CheckAccess(object sender, UserEventArgs e)
    {
        Console.WriteLine($"🔐 Проверка доступа для пользователя: {e.Username}");
    }
}

public class NotificationService
{
    public void SendNotification(object sender, UserEventArgs e)
    {
        Console.WriteLine($"📢 Уведомление: пользователь {e.Username} вошел в систему.");
    }
}

public class LoginObserver
{
    public LoginObserver(UserLoginManager manager)
    {
        SecuritySystem security = new SecuritySystem();
        NotificationService notification = new NotificationService();

        manager.UserLoggedIn += security.CheckAccess;
        manager.UserLoggedIn += notification.SendNotification;
    }
}

class Program
{
    static void Main()
    {
        UserLoginManager manager = new UserLoginManager();

        LoginObserver observer = new LoginObserver(manager);

        manager.Login("David");
    }
}