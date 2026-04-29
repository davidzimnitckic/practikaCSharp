#pragma warning disable
using System;
using System.Collections.Generic;

class GameResourceManager
{
    private static GameResourceManager instance;

    private Dictionary<string, string> resources;

    private GameResourceManager()
    {
        resources = new Dictionary<string, string>();
    }

    public static GameResourceManager GetInstance()
    {
        if (instance == null)
        {
            instance = new GameResourceManager();
        }
        return instance;
    }

    public void LoadResource(string name)
    {
        if (!resources.ContainsKey(name))
        {
            resources[name] = $"Ресурс {name} загружен";
            Console.WriteLine($"Загружен: {name}");
        }
        else
        {
            Console.WriteLine($"Ресурс {name} уже загружен");
        }
    }

    public string GetResource(string name)
    {
        if (resources.ContainsKey(name))
        {
            return resources[name];
        }
        else
        {
            return "Ресурс не найден";
        }
    }
}

class Program
{
    static void Main()
    {
        GameResourceManager manager1 = GameResourceManager.GetInstance();
        GameResourceManager manager2 = GameResourceManager.GetInstance();

        Console.WriteLine(manager1 == manager2); 

        manager1.LoadResource("Texture1");
        manager2.LoadResource("Sound1");

        Console.WriteLine(manager1.GetResource("Texture1"));
        Console.WriteLine(manager2.GetResource("Sound1"));
    }
}