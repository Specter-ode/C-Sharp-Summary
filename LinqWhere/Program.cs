using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqWhere;
// похож на метод filter в JS 

public class Program
{
    public static void Main(string[] args)
    {
        // Исходная коллекция чисел
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Использование метода Where для фильтрации четных чисел
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

        // Вывод результата
        Console.WriteLine("Четные числа: " + string.Join(", ", evenNumbers));


        // Исходная коллекция строк
        var words = new List<string> { "Apple", "Banana", "Avocado", "Blueberry", "Apricot" };

        // Использование метода Where для фильтрации строк, начинающихся на "A"
        var wordsStartingWithA = words.Where(w => w.StartsWith("A")).ToList();

        // Вывод результата
        Console.WriteLine("Слова, начинающиеся на A: " + string.Join(", ", wordsStartingWithA));
        // Исходная коллекция объектов
        var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 35 },
            new Person { Name = "Charlie", Age = 30 },
            new Person { Name = "David", Age = 40 }
        };

        // Использование Where для фильтрации людей старше 30 лет
        var adults = people.Where(p => p.Age > 30).ToList();

        // Вывод результата
        foreach (var person in adults)
        {
            Console.WriteLine(person.Name);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}