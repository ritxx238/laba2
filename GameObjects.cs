using System;
using System.ComponentModel.DataAnnotations;

public interface IAttacker
{
    void Attack(Unit unit);
}

public interface IMoveable
{
    void Move(int x, int y);
}

public abstract class GameObject
{
    private int _id;
    private string _name;
    private int _x;
    private int _y;

    public GameObject(int id, string name, int x, int y)
    {
        Validate.TypeValid(id, typeof(int));
        Validate.TypeValid(name, typeof(string));
        Validate.TypeValid(x, typeof(int));
        Validate.TypeValid(y, typeof(int));

        _id = id;
        _name = name;
        _x = x;
        _y = y;
    }

    public int GetId() => _id;
    public string GetName() => _name;
    public int GetX() => _x;
    public int GetY() => _y;

    protected void SetX(int x) => _x = x;
    protected void SetY(int y) => _y = y;
}

public class Building : GameObject
{
    private bool _isBuilt;

    public Building(int id, string name, int x, int y, bool isBuilt)
        : base(id, name, x, y)
    {
        Validate.TypeValid(isBuilt, typeof(bool));
        _isBuilt = isBuilt;
    }

    public bool IsBuilt() => _isBuilt;
}

public class Unit : GameObject
{
    private float _hp;

    public Unit(int id, string name, int x, int y, float hp)
        : base(id, name, x, y)
    {
        Validate.HpValid(hp);
        _hp = hp;
    }

    public float GetHp() => _hp;
    public bool IsAlive() => _hp > 0;

    public void ReceiveDamage(float damage)
    {
        Validate.DamageValid(damage);
        _hp = Math.Max(0f, _hp - damage);
    }
}

public class Fort : Building, IAttacker
{
    private float _damage;

    public Fort(int id, string name, int x, int y, bool isBuilt, float damage = 50f)
        : base(id, name, x, y, isBuilt)
    {
        Validate.DamageValid(damage);
        _damage = damage;
    }

    public void Attack(Unit unit)
    {
        if (!IsBuilt())
        {
            Console.WriteLine($"Форт {GetName()} не построен!");
            return;
        }
        if (!unit.IsAlive())
        {
            Console.WriteLine($"{unit.GetName()} уже мертв.");
            return;
        }
        Console.WriteLine($"Форт {GetName()} атакует {unit.GetName()} на {_damage} урона!");
        unit.ReceiveDamage(_damage);
    }
}

public class MobileHouse : Building, IMoveable
{
    public MobileHouse(int id, string name, int x, int y, bool isBuilt)
        : base(id, name, x, y, isBuilt) { }

    public void Move(int x, int y)
    {
        if (!IsBuilt())
        {
            Console.WriteLine($"Дом {GetName()} не построен!");
            return;
        }
        SetX(x);
        SetY(y);
        Console.WriteLine($"Дом {GetName()} переехал на ({x}, {y})");
    }
}

public class Archer : Unit, IAttacker, IMoveable
{
    private float _damage;

    public Archer(int id, string name, int x, int y, float hp, float damage = 10f)
        : base(id, name, x, y, hp)
    {
        Validate.DamageValid(damage);
        _damage = damage;
    }

    public void Attack(Unit unit)
    {
        if (!IsAlive())
        {
            Console.WriteLine($"{GetName()} мертв и не может атаковать.");
            return;
        }
        if (!unit.IsAlive())
        {
            Console.WriteLine($"{unit.GetName()} уже мертв.");
            return;
        }
        Console.WriteLine($"{GetName()} атакует {unit.GetName()} на {_damage} урона!");
        unit.ReceiveDamage(_damage);
    }

    public void Move(int x, int y)
    {
        if (!IsAlive())
        {
            Console.WriteLine($"{GetName()} мертв и не может двигаться.");
            return;
        }
        SetX(x);
        SetY(y);
        Console.WriteLine($"{GetName()} переместился на ({x}, {y})");
    }
}