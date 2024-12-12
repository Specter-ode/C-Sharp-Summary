using System;
using System.Collections.Generic; // Для использования Dictionary
using System.Collections.Concurrent; // Для ConcurrentDictionary

namespace DictionaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Создание словаря
            // Dictionary хранит пары "ключ-значение" и обеспечивает быструю выборку по ключу.
            Dictionary<int, string> dict = new Dictionary<int, string>();

            // 2. Добавление элементов
            dict.Add(1, "One");
            dict.Add(2, "Two");
            dict.Add(3, "Three");
            Console.WriteLine("Начальный словарь:");
            PrintDictionary(dict);

            // 3. Доступ к элементам по ключу
            Console.WriteLine($"Значение для ключа 2: {dict[2]}"); // Вывод "Two"

            // 4. Изменение значения по ключу
            dict[2] = "Twenty";
            Console.WriteLine("После изменения значения для ключа 2:");
            PrintDictionary(dict);

            // 5. Проверка наличия ключа
            if (dict.ContainsKey(3))
            {
                Console.WriteLine("Ключ 3 найден в словаре.");
            }

            // 6. Проверка наличия значения
            if (dict.ContainsValue("One"))
            {
                Console.WriteLine("Значение 'One' найдено в словаре.");
            }

            // 7. Удаление элемента
            dict.Remove(1); // Удаляет элемент с ключом 1
            Console.WriteLine("После удаления ключа 1:");
            PrintDictionary(dict);

            // 8. Перебор всех элементов
            Console.WriteLine("Перебор ключей и значений:");
            foreach (var pair in dict)
            {
                Console.WriteLine($"Ключ: {pair.Key}, Значение: {pair.Value}");
            }

            // 9. Получение всех ключей и значений
            var keys = dict.Keys; // Все ключи
            var values = dict.Values; // Все значения
            Console.WriteLine("Все ключи: " + string.Join(", ", keys));
            Console.WriteLine("Все значения: " + string.Join(", ", values));

            // 10. Очистка словаря
            dict.Clear();
            Console.WriteLine("После очистки словаря:");
            PrintDictionary(dict);

            // 11. Использование словаря со сложными ключами и значениями
            Dictionary<string, List<int>> complexDict = new Dictionary<string, List<int>>
            {
                { "Odd", new List<int> { 1, 3, 5, 7 } },
                { "Even", new List<int> { 2, 4, 6, 8 } }
            };
            Console.WriteLine("Сложный словарь:");
            foreach (var pair in complexDict)
            {
                Console.WriteLine($"Ключ: {pair.Key}, Значения: [{string.Join(", ", pair.Value)}]");
            }

            // 12. Объединение словарей
            Dictionary<int, string> additionalDict = new Dictionary<int, string>
            {
                { 4, "Four" },
                { 5, "Five" },
                { 10, "Ten" }
            };
            foreach (var pair in additionalDict)
            {
                if (!dict.ContainsKey(pair.Key))
                {
                    dict.Add(pair.Key, pair.Value);
                }
            }

            Console.WriteLine("После объединения словарей:");
            PrintDictionary(dict);

            // 13. Безопасное получение значения с помощью TryGetValue
            if (dict.TryGetValue(2, out string value))
            {
                Console.WriteLine($"Значение для ключа 2: {value}");
            }
            else
            {
                Console.WriteLine("Ключ не найден.");
            }

            // 14. Сортировка словаря
            var sortedDict = new SortedDictionary<int, string>(dict);
            Console.WriteLine("Отсортированный словарь:");
            foreach (var pair in sortedDict)
            {
                Console.WriteLine($"Ключ: {pair.Key}, Значение: {pair.Value}");
            }

            // 15. Удаление элементов по условию
            foreach (var key in new List<int>(dict.Keys)) // Копируем ключи для безопасного удаления
            {
                if (dict[key].StartsWith("T"))
                {
                    dict.Remove(key);
                }
            }

            Console.WriteLine("После удаления элементов, начинающихся с 'T':");
            PrintDictionary(dict);

            // 16. Использование объектов в качестве ключей
            var customKeyDict = new Dictionary<CustomKey, string>
            {
                { new CustomKey { Id = 1 }, "Value1" },
                { new CustomKey { Id = 2 }, "Value2" }
            };
            Console.WriteLine("Словарь с пользовательскими ключами:");
            foreach (var pair in customKeyDict)
            {
                Console.WriteLine($"Ключ: {pair.Key.Id}, Значение: {pair.Value}");
            }

            // 17. ConcurrentDictionary для многопоточной безопасности
            var concurrentDict = new ConcurrentDictionary<int, string>();
            concurrentDict.TryAdd(1, "One");
            concurrentDict.TryUpdate(1, "UpdatedOne", "One");
            Console.WriteLine($"Значение для ключа 1: {concurrentDict[1]}");

            // 18. Словарь с несколькими значениями
            var multiValueDict = new Dictionary<string, List<string>>
            {
                { "Colors", new List<string> { "Red", "Blue", "Green" } },
                { "Fruits", new List<string> { "Apple", "Banana" } }
            };
            Console.WriteLine("Словарь с несколькими значениями:");
            foreach (var pair in multiValueDict)
            {
                Console.WriteLine($"Ключ: {pair.Key}, Значения: [{string.Join(", ", pair.Value)}]");
            }
        }

        // Вспомогательный метод для печати элементов словаря
        static void PrintDictionary<K, V>(Dictionary<K, V> dictionary)
        {
            if (dictionary.Count == 0)
            {
                Console.WriteLine("Словарь пуст.");
            }
            else
            {
                foreach (var pair in dictionary)
                {
                    Console.WriteLine($"Ключ: {pair.Key}, Значение: {pair.Value}");
                }
            }
        }

        class CustomKey
        {
            public int Id { get; set; }
            public override int GetHashCode() => Id.GetHashCode();
            public override bool Equals(object obj) => obj is CustomKey key && key.Id == Id;
        }
    }
}