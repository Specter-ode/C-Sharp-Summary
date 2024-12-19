using System;

namespace Interfaces;

public interface IMovable
{
    void Move();
}

public interface IBuilding
{
    void Build();
}

public abstract class Animal : IMovable
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public void Move()
    {
        Console.WriteLine($"{Name} is moving");
    }
}

public class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }
}

public class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }
}

public class Cow : Animal
{
    public Cow(string name) : base(name)
    {
    }
}

public class Tractor : IMovable
{
    public string Name { get; set; }

    public Tractor(string name)
    {
        Name = name;
    }

    public void Move()
    {
        Console.WriteLine($"{Name} is moving");
    }
}

public class House : IBuilding
{
    public void Build()
    {
        Console.WriteLine("Building a house");
    }
}

public class Garage : IBuilding
{
    public void Build()
    {
        Console.WriteLine("Building a garage");
    }
}

public class Farm
{
    // Публичное поле MovableObjects - массив подвижных объектов (IMovable)
    public IMovable[] MovableObjects { get; set; }

    // Публичное поле Buildings - массив зданий (IBuilding)
    public IBuilding[] Buildings { get; set; }

    public Farm()
    {
        // Инициализация массива подвижных объектов
        MovableObjects = new IMovable[]
        {
            new Cat("Cat"),
            new Dog("Dog"),
            new Cow("Cow"),
            new Tractor("Tractor")
        };

        // Инициализация массива зданий
        Buildings = new IBuilding[]
        {
            new House(),
            new Garage()
        };
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var farm = new Farm();

        Console.WriteLine($"На ферме {farm.MovableObjects.Length} подвижных объекта.");
        Console.WriteLine($"На ферме {farm.Buildings.Length} неподвижных объекта.");
    }
}