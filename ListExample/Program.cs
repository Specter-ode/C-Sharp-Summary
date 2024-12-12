using System;
using System.Collections.Generic; // Для использования List

namespace ListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Создание списка
            // List - это динамическая коллекция, которая автоматически увеличивает размер.
            List<int> numbers = new List<int>();

            // 2. Добавление элементов в список
            numbers.Add(10); // Добавляет 10 в список
            numbers.Add(20);
            numbers.Add(30);
            Console.WriteLine("Начальный список:");
            PrintList(numbers);

            // 3. Добавление нескольких элементов через AddRange
            numbers.AddRange(new List<int> { 40, 50, 60 });
            Console.WriteLine("После AddRange:");
            PrintList(numbers);

            // 4. Вставка элемента по индексу
            numbers.Insert(2, 25); // Вставляет 25 на позицию с индексом 2
            Console.WriteLine("После Insert:");
            PrintList(numbers);

            // 5. Удаление элемента
            numbers.Remove(20); // Удаляет первое вхождение числа 20
            Console.WriteLine("После Remove(20):");
            PrintList(numbers);

            // 6. Удаление элемента по индексу
            numbers.RemoveAt(0); // Удаляет элемент с индексом 0
            Console.WriteLine("После RemoveAt(0):");
            PrintList(numbers);

            // 7. Поиск элемента
            int index = numbers.IndexOf(30); // Возвращает индекс первого вхождения 30
            Console.WriteLine($"Индекс числа 30: {index}");

            // 8. Сортировка списка
            numbers.Sort();
            Console.WriteLine("После сортировки:");
            PrintList(numbers);

            // 8.1. Сортировка списка в обратном порядке
            numbers.Sort((a, b) => b.CompareTo(a)); // Используем лямбда-выражение для сортировки по убыванию
            Console.WriteLine("После сортировки в обратном порядке:");
            PrintList(numbers);

            // 8.2. Сортировка строк
            List<string> words = new List<string> { "Apple", "Orange", "Banana", "Cherry" };
            Console.WriteLine("Список строк до сортировки:");
            PrintList(words);

            words.Sort(); // Сортировка в алфавитном порядке
            Console.WriteLine("Список строк после сортировки:");
            PrintList(words);

            words.Sort((a, b) => b.CompareTo(a)); // Сортировка в обратном алфавитном порядке
            Console.WriteLine("Список строк после сортировки в обратном порядке:");
            PrintList(words);

            // 8.3. Сортировка массивов
            List<int[]> arrays = new List<int[]>
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5 },
                new int[] { 6, 7, 8, 9 }
            };

            arrays.Sort((a, b) => a.Length.CompareTo(b.Length)); // Сортировка по длине массива
            Console.WriteLine("Массивы после сортировки по длине:");
            foreach (var array in arrays)
            {
                Console.WriteLine($"[{string.Join(", ", array)}]");
            }

            // 9. Проверка наличия элемента
            bool contains50 = numbers.Contains(50); // Проверяет, есть ли число 50 в списке
            Console.WriteLine($"Список содержит число 50: {contains50}");

            // 10. Очистка списка
            numbers.Clear();
            Console.WriteLine("После Clear (очистка списка):");
            PrintList(numbers);
        }

        // Вспомогательный метод для печати элементов списка
        static void PrintList<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                Console.WriteLine(string.Join(", ", list)); // Вывод всех элементов через запятую
            }
        }
    }
}