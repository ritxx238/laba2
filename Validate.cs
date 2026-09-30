using System;

public static class Validate
{
    public static void TypeValid(object obj, Type expectedType)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj), "Объект не может быть null");
        if (!expectedType.IsInstanceOfType(obj))
            throw new ArgumentException($"Ожидался тип {expectedType.Name}, получен {obj.GetType().Name}");
    }

    public static void HpValid(float hp)
    {
        if (hp < 0)
            throw new ArgumentException("HP не может быть отрицательным");
    }

    public static void DamageValid(float damage)
    {
        if (damage < 0)
            throw new ArgumentException("Урон не может быть отрицательным");
    }
}