using System;
using System.Linq;

namespace LinqCombined;

public class Program
{
    public static void Main(string[] args)
    {
        // Создание массива объектов типа Person
        var people = new[]
        {
            new Person(1) { Name = "Alice", Age = 25 },
            new Person(2) { Name = "Bob", Age = 35 },
            new Person(3) { Name = "Charlie", Age = 19 },
            new Person(4) { Name = "David", Age = 40 },
            new Person(5) { Name = "Fred", Age = 40 },
            new Person(6) { Name = "George", Age = 19 },
            new Person(7) { Name = "Henry", Age = 19 },
        };

        // Применение FirstOrDefault для нахождения первого человека старше 30 лет
        var personOver30 = people.FirstOrDefault(p => p.Age > 30);
        if (personOver30 != null)
        {
            Console.WriteLine($"Первый человек старше 30 лет: {personOver30.Name}, возраст {personOver30.Age}");
        }
        else
        {
            Console.WriteLine("Нет людей старше 30 лет.");
        }

        // Применение Any для проверки, есть ли хотя бы один человек младше 20 лет
        bool hasUnder20 = people.Any(p => p.Age < 20);
        Console.WriteLine($"Есть ли кто-то младше 20 лет? {(hasUnder20 ? "Да" : "Нет")}");


        // Применение FirstOrDefault для нахождения самого молодого человека
        var youngestPerson = people.OrderBy(p => p.Age).FirstOrDefault();
        if (youngestPerson != null)
        {
            Console.WriteLine($"Самый молодой человек: {youngestPerson.Name}, возраст {youngestPerson.Age}");
        }


        // Группируем людей по возрасту
        var groupedByAge = people.GroupBy(p => p.Age);

        Console.WriteLine("Группировка по возрасту:");
        foreach (var group in groupedByAge)
        {
            Console.WriteLine($"Возраст: {group.Key}");
            foreach (var person in group)
            {
                Console.WriteLine($"  {person.Name}");
            }
        }


        var orders = new[]
        {
            new { PersonId = 1, OrderId = "f1", orderSum = 100 },
            new { PersonId = 2, OrderId = "g5", orderSum = 200 },
            new { PersonId = 3, OrderId = "h3", orderSum = 100 },
            new { PersonId = 4, OrderId = "i7", orderSum = 200 },
            new { PersonId = 1, OrderId = "f2", orderSum = 500 },
            new { PersonId = 2, OrderId = "g6", orderSum = 400 }
        };


        // Объединяем коллекции people и orders по ключу PersonId
        var joinResult = people.Join(orders,
            person => person.PersonId,
            order => order.PersonId,
            (person, order) => new
            {
                person.Name,
                order.OrderId
            });

        Console.WriteLine("Результат объединения:");
        foreach (var item in joinResult)
        {
            Console.WriteLine($"Name: {item.Name}, OrderId: {item.OrderId}");
        }


        // Объединяем коллекции people и orders по ключу PersonId с сохранением OrderId и суммированием orderSum
        var groupJoinResult = people
            .GroupJoin(orders,
                person => person.PersonId,
                order => order.PersonId,
                (person, ordersGroup) => new
                {
                    person.Name,
                    TotalOrderValue = ordersGroup.Sum(o => o.orderSum), // Суммируем orderSum
                    OrderIds = ordersGroup.Select(o => o.OrderId).ToArray() // Собираем все OrderId
                });

        Console.WriteLine("Результат объединения с суммой и OrderIds:");
        foreach (var item in groupJoinResult)
        {
            // Выводим имя, сумму заказов и все OrderId
            Console.WriteLine(
                $"Name: {item.Name}, Total Order Value: {item.TotalOrderValue}, OrderIds: {string.Join(", ", item.OrderIds)}");
        }


        var numbers = new[] { 1, 2, 3, 4, 5, 1, 2, 3, 1, 5 };

        // Убираем дублирующиеся элементы
        var distinctNumbers = numbers.Distinct();

        Console.WriteLine("Уникальные элементы:");
        foreach (var number in distinctNumbers)
        {
            Console.WriteLine(number);
        }


        //  Skip и Take — Пропуск и выбор первых элементов
        // Пропускаем первые 3 элемента и берем следующие 4
        var result = numbers.Skip(3).Take(4);

        Console.WriteLine("Результат после применения Skip и Take:");
        foreach (var number in result)
        {
            Console.WriteLine(number);
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        // Сделать PersonId доступным только для инициализации
        public readonly int PersonId;

        // Конструктор для инициализации PersonId при создании объекта
        public Person(int personId)
        {
            PersonId = personId;
        }
    }
}