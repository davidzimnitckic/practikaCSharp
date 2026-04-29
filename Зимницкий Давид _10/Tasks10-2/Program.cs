#pragma warning disable
using System;
using System.Collections.Generic;

interface ICacheStrategy
{
    void Add(string key, string value);
    string Get(string key);
}

class InMemoryCache : ICacheStrategy
{
    private Dictionary<string, string> cache = new Dictionary<string, string>();

    public void Add(string key, string value)
    {
        cache[key] = value;
        Console.WriteLine($"[InMemoryCache] Добавлено: {key}");
    }

    public string Get(string key)
    {
        if (cache.ContainsKey(key))
            return cache[key];

        return "[InMemoryCache] Нет данных";
    }
}

class DistributedCache : ICacheStrategy
{
    public void Add(string key, string value)
    {
        Console.WriteLine($"[DistributedCache] Отправлено на сервер: {key}");
    }

    public string Get(string key)
    {
        return $"[DistributedCache] Получено с сервера: {key}";
    }
}

class NoCache : ICacheStrategy
{
    public void Add(string key, string value)
    {
        Console.WriteLine("[NoCache] Кэширование отключено");
    }

    public string Get(string key)
    {
        return "[NoCache] Данные не сохраняются";
    }
}

class CacheManager
{
    private ICacheStrategy strategy;

    public CacheManager(ICacheStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(ICacheStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void Add(string key, string value)
    {
        strategy.Add(key, value);
    }

    public string Get(string key)
    {
        return strategy.Get(key);
    }
}

class Program
{
    static void Main()
    {
        CacheManager cache = new CacheManager(new InMemoryCache());

        cache.Add("user1", "David");
        Console.WriteLine(cache.Get("user1"));

        Console.WriteLine("---- Меняем стратегию ----");

        cache.SetStrategy(new DistributedCache());
        cache.Add("user2", "Alex");
        Console.WriteLine(cache.Get("user2"));

        Console.WriteLine("---- Отключаем кэш ----");

        cache.SetStrategy(new NoCache());
        cache.Add("user3", "John");
        Console.WriteLine(cache.Get("user3"));
    }
}
