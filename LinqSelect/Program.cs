using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqSelect;

// похож на метод map в JS 
public class Program
{
    public static void Main(string[] args)
    {
        // Исходная коллекция чисел
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Преобразование: умножаем каждое число на 2
        var doubledNumbers = numbers.Select(n => n * 2).ToList();

        // Вывод результата
        Console.WriteLine("Числа, умноженные на 2: " + string.Join(", ", doubledNumbers));


        // Исходная коллекция объектов
        var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 35 },
            new Person { Name = "Charlie", Age = 30 }
        };

        // Преобразование: извлекаем только имена
        var names = people.Select(p => p.Name).ToList();

        // Вывод результата
        Console.WriteLine("Имена: " + string.Join(", ", names));
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}