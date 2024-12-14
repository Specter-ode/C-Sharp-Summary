using System;

namespace ClassBasicExample
{
    // Базовый абстрактный класс, который задает общие принципы для наследников
    public abstract class Animal
    {
        // Поле с модификатором protected доступно в классе и его наследниках
        protected string Name;

        // Конструктор для базового класса
        public Animal(string name)
        {
            Name = name;
        }

        // Абстрактный метод обязует наследников реализовать его
        public abstract void Speak();

        // Virtual метод - дает базовую реализацию, но позволяет переопределить
        public virtual void Eat()
        {
            Console.WriteLine($"{Name} eats food.");
        }

        // Метод без виртуальности: наследники могут использовать, но не менять поведение
        public void Sleep()
        {
            Console.WriteLine($"{Name} sleeps.");
        }
    }

    // Производный класс Dog, реализующий методы базового класса
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        // Обязательная реализация абстрактного метода из Animal
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Woof woof!");
        }

        // Переопределяем виртуальный метод Eat
        public override void Eat()
        {
            Console.WriteLine($"{Name} eats dog food.");
        }
    }

    // Производный класс Cat, который также реализует базовые требования
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        // Реализация абстрактного метода
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }

        // Используем базовый вариант виртуального метода, не переопределяя его
    }

    // Дополнительный пример с использованием sealed
    public class Parrot : Animal
    {
        public Parrot(string name) : base(name) { }

        public override void Speak()
        {
            Console.WriteLine($"{Name} says: I can mimic you!");
        }

        // Запрещаем дальнейшее переопределение Eat с помощью sealed
        public sealed override void Eat()
        {
            Console.WriteLine($"{Name} eats seeds and fruits.");
        }
    }

    // Производный класс от Parrot, который не может переопределить Eat
    public class SuperParrot : Parrot
    {
        public SuperParrot(string name) : base(name) { }

        // Переопределение Speak возможно
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: I am a super parrot!");
        }

        // Ошибка: метод Eat запечатан и не может быть переопределен
        // public override void Eat() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Полиморфизм: используем ссылки базового класса для объектов наследников
            Animal myDog = new Dog("Buddy");
            Animal myCat = new Cat("Whiskers");
            Animal myParrot = new Parrot("Polly");

            // Вызов методов
            myDog.Speak();  // Buddy says: Woof woof!
            myDog.Eat();    // Buddy eats dog food.
            myDog.Sleep();  // Buddy sleeps.

            myCat.Speak();  // Whiskers says: Meow!
            myCat.Eat();    // Whiskers eats food (виртуальный метод не переопределен)
            myCat.Sleep();  // Whiskers sleeps.

            myParrot.Speak(); // Polly says: I can mimic you!
            myParrot.Eat();   // Polly eats seeds and fruits.
            myParrot.Sleep(); // Polly sleeps.

            // Используем SuperParrot
            Animal mySuperParrot = new SuperParrot("SuperPolly");
            mySuperParrot.Speak(); // SuperPolly says: I am a super parrot!
            mySuperParrot.Eat();   // Polly eats seeds and fruits. (Eat запечатан в Parrot)
        }
    }
}
