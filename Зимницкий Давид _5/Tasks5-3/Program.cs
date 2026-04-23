#pragma warning disable
using System;

abstract class TeamMember
{
    public string Name { get; set; }

    public TeamMember(string name)
    {
        Name = name;
    }

    public abstract void ShowInfo();
}


interface IBasketballPlayer
{
    void Shoot();
}

interface IFootballPlayer
{
    void Kick();
}

class Basketballer : TeamMember, IBasketballPlayer
{
    public Basketballer(string name) : base(name) { }

    public void Shoot()
    {
        Console.WriteLine($"{Name} бросает мяч в корзину.");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Баскетболист: {Name}");
    }
}

class Footballer : TeamMember, IFootballPlayer
{
    public Footballer(string name) : base(name) { }

    public void Kick()
    {
        Console.WriteLine($"{Name} бьёт по мячу.");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Футболист: {Name}");
    }
}

class Program
{
    static void Main()
    {
        TeamMember[] players = new TeamMember[]
        {
            new Basketballer("Иван"),
            new Footballer("Алексей"),
            new Basketballer("Дмитрий"),
            new Footballer("Максим")
        };

        Console.WriteLine("Все игроки:");
        foreach (var player in players)
        {
            player.ShowInfo();
        }

        Console.WriteLine("Только баскетболисты:");

        foreach (var player in players)
        {
            if (player is IBasketballPlayer basketballPlayer)
            {
                basketballPlayer.Shoot();
            }
        }
    }
}