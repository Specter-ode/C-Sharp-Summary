using System;
using System.Collections.Generic; // Для использования Queue

namespace QueueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Создание очереди
            Queue<int> queue = new Queue<int>();

            // 2. Добавление элементов в очередь
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine("Начальная очередь:");
            PrintQueue(queue);

            // 3. Удаление элемента из очереди
            int dequeued = queue.Dequeue();
            Console.WriteLine($"Извлечён элемент: {dequeued}");
            Console.WriteLine("Очередь после извлечения:");
            PrintQueue(queue);

            // 4. Получение элемента без удаления
            int peeked = queue.Peek();
            Console.WriteLine($"Первый элемент без удаления: {peeked}");

            // 5. Проверка количества элементов
            Console.WriteLine($"Количество элементов в очереди: {queue.Count}");

            // 6. Очистка очереди
            queue.Clear();
            Console.WriteLine("Очередь после очистки:");
            PrintQueue(queue);

            // 7. Проверка наличия элемента
            queue.Enqueue(10);
            queue.Enqueue(20);
            Console.WriteLine($"Содержит ли очередь 10? {queue.Contains(10)}");

            // 8. Перебор элементов очереди
            Console.WriteLine("Перебор элементов:");
            foreach (int item in queue)
            {
                Console.WriteLine(item);
            }

            // 9. Использование очереди строк
            Queue<string> stringQueue = new Queue<string>();
            stringQueue.Enqueue("First");
            stringQueue.Enqueue("Second");
            stringQueue.Enqueue("Third");
            Console.WriteLine("Очередь строк:");
            PrintQueue(stringQueue);

            // 10. Копирование очереди в массив
            int[] array = queue.ToArray();
            Console.WriteLine("Копия очереди в массиве:");
            Console.WriteLine(string.Join(", ", array));

            // 11. Создание очереди с инициализацией
            Queue<int> initializedQueue = new Queue<int>(new[] { 1, 2, 3, 4 });
            Console.WriteLine("Инициализированная очередь:");
            PrintQueue(initializedQueue);

            // 12. Сортировка элементов очереди (путём преобразования)
            var sortedQueue = new Queue<int>(new SortedSet<int>(initializedQueue));
            Console.WriteLine("Сортированная очередь:");
            PrintQueue(sortedQueue);

            // 13. Очередь с пользовательскими объектами
            Queue<Person> personQueue = new Queue<Person>();
            personQueue.Enqueue(new Person { Name = "Alice", Age = 30 });
            personQueue.Enqueue(new Person { Name = "Bob", Age = 25 });
            Console.WriteLine("Очередь объектов:");
            foreach (var person in personQueue)
            {
                Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age}");
            }

            // 14. Многопоточная очередь ConcurrentQueue
            var concurrentQueue = new System.Collections.Concurrent.ConcurrentQueue<int>();
            concurrentQueue.Enqueue(1);
            concurrentQueue.Enqueue(2);
            concurrentQueue.TryDequeue(out int concurrentItem);
            Console.WriteLine($"Элемент из ConcurrentQueue: {concurrentItem}");

            // 15. Очередь с приоритетом (Priority Queue через SortedSet)
            var priorityQueue = new SortedSet<(int Priority, string Task)>
            {
                (1, "Low priority task"),
                (0, "High priority task")
            };
            Console.WriteLine("Очередь с приоритетом:");
            foreach (var task in priorityQueue)
            {
                Console.WriteLine($"Приоритет: {task.Priority}, Задача: {task.Task}");
            }
        }

        // Вспомогательный метод для печати очереди
        static void PrintQueue<T>(Queue<T> queue)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Очередь пуста.");
            }
            else
            {
                Console.WriteLine(string.Join(", ", queue));
            }
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
