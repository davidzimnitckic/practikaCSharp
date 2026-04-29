#pragma warning disable

using System;

public interface IGameCharacter
{
    string GetAbilities();
}

public class BaseCharacter : IGameCharacter
{
    public string GetAbilities()
    {
        return "Basic attack";
    }
}

public abstract class CharacterDecorator : IGameCharacter
{
    protected IGameCharacter _character;

    public CharacterDecorator(IGameCharacter character)
    {
        _character = character;
    }

    public virtual string GetAbilities()
    {
        return _character.GetAbilities();
    }
}


public class StealthDecorator : CharacterDecorator
{
    public StealthDecorator(IGameCharacter character) : base(character) { }

    public override string GetAbilities()
    {
        return base.GetAbilities() + ", Stealth";
    }
}

public class PowerAttackDecorator : CharacterDecorator
{
    public PowerAttackDecorator(IGameCharacter character) : base(character) { }

    public override string GetAbilities()
    {
        return base.GetAbilities() + ", Power Attack";
    }
}

public class HealingDecorator : CharacterDecorator
{
    public HealingDecorator(IGameCharacter character) : base(character) { }

    public override string GetAbilities()
    {
        return base.GetAbilities() + ", Healing";
    }
}

class Program
{
    static void Main()
    {
        IGameCharacter character = new BaseCharacter();

        Console.WriteLine("Base: " + character.GetAbilities());

        character = new StealthDecorator(character);
        character = new PowerAttackDecorator(character);
        character = new HealingDecorator(character);

        Console.WriteLine("Upgraded: " + character.GetAbilities());
    }
}