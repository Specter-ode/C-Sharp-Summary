using System;
using System.Linq;
using System.Collections.Generic;


namespace LinqOrderBy;

public class Program
{
    public static void Main(string[] args)
    {
        // Исходная коллекция чисел
        var numbers = new List<int> { 6, 5, 1, 4, 2, 3 };

        // Сортировка по возрастанию
        var sortedNumbers = numbers.OrderBy(n => n).ToList();

        // Вывод результата
        Console.WriteLine("Отсортированные числа по возрастанию: " + string.Join(", ", sortedNumbers));

        var sortedNumbersDescending = numbers.OrderByDescending(n => n).ToList();

        // Вывод результата
        Console.WriteLine("Отсортированные числа по убыванию: " + string.Join(", ", sortedNumbersDescending));

        var words = new List<string> { "apple", "Banana", "cherry" };
        //сортивку с игнорированием регистра
        var sortedWords = words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase).ToList();
        // Вывод результата
        Console.WriteLine("Отсортированные числа по убыванию: " + string.Join(", ", sortedWords));


        // Исходная коллекция объектов
        var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 35 },
            new Person { Name = "Charlie", Age = 30 }
        };

        // Сортировка по возрасту
        var sortedPeople = people.OrderBy(p => p.Age).ToList();

        // Вывод результата
        foreach (var person in sortedPeople)
        {
            Console.WriteLine($"{person.Name}, {person.Age} лет");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}