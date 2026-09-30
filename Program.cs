using System;

class Program
{
    static void ArcherDemo()
    {
        var archer01 = new Archer(0, "First Archer", 0, 0, 100f);
        var archer02 = new Archer(1, "Second Archer", 1, 1, 5f);
        archer01.Move(1, 1);
        archer01.Attack(archer02);
        Console.WriteLine($"Первый лучник жив: {archer01.IsAlive()}, Второй лучник жив: {archer02.IsAlive()}");
        Console.WriteLine(new string('-', 30));
    }

    static void FortDemo()
    {
        var fort01 = new Fort(0, "First Fort", 0, 0, true);
        var archer03 = new Archer(3, "Third Archer", 2, 2, 30f);
        fort01.Attack(archer03);
        Console.WriteLine($"Лучник {archer03.GetName()} жив: {archer03.IsAlive()}");
        Console.WriteLine(new string('-', 30));
    }

    static void MobileHouseDemo()
    {
        var house01 = new MobileHouse(0, "First MobileHouse", 0, 0, true);
        var house02 = new MobileHouse(1, "Second MobileHouse", 100, 100, true);
        house01.Move(10, 10);
        house02.Move(200, 100);
        Console.WriteLine($"Первый дом: ({house01.GetX()}, {house01.GetY()}), Второй дом: ({house02.GetX()}, {house02.GetY()})");
    }

    static void Main(string[] args)
    {
        ArcherDemo();
        FortDemo();
        MobileHouseDemo();
    }
}