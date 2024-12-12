using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

// Определение перечисления с атрибутами для метаданных
public enum DaysOfWeek
{
    [Description("Воскресенье - День отдыха")]
    Sunday = 1,
    
    [Description("Понедельник - Первый рабочий день")]
    Monday = 2,
    
    [Description("Вторник - День для задач")]
    Tuesday = 3,
    
    [Description("Среда - Середина недели")]
    Wednesday = 4,
    
    [Description("Четверг - Почти выходные")]
    Thursday = 5,
    
    [Description("Пятница - День расслабления")]
    Friday = 6,
    
    [Description("Суббоат - Выходной день")]
    Saturday = 7
}

// Пример использования битовых флагов с атрибутом [Flags]
[Flags]
public enum Permissions
{
    None = 0,          // Нет прав
    Read = 1,          // Чтение
    Write = 2,         // Запись
    Execute = 4,       // Выполнение
    Delete = 8,        // Удаление
    Admin = 16,        // Админские права
    All = Read | Write | Execute | Delete | Admin // Все права
}

public static class EnumExtensions
{
    // Метод для получения описания (атрибута Description) для enum
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
        return attribute == null ? value.ToString() : attribute.Description;
    }

    // Метод для преобразования строки в значение enum с обработкой ошибок
    public static bool TryParseEnum<T>(string value, out T result) where T : struct
    {
        return Enum.TryParse(value, out result);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Пример 1: Получаем описание с атрибутами
        DaysOfWeek today = DaysOfWeek.Monday;
        Console.WriteLine($"Сегодня: {today.GetDescription()}"); // "Сегодня: Первый рабочий день"

        // Пример 2: Сравнение флагов с помощью битовых операций
        Permissions userPermissions = Permissions.Read | Permissions.Write;

        Console.WriteLine($"Права пользователя: {userPermissions}"); // Выводит: Права пользователя: Read, Write

        // Пример 3: Проверка, есть ли права на выполнение
        if ((userPermissions & Permissions.Execute) == Permissions.Execute)
        {
            Console.WriteLine("Пользователь имеет права на выполнение");
        }
        else
        {
            Console.WriteLine("Пользователь не имеет прав на выполнение");
        }

        // Пример 4: Преобразование строки в enum с обработкой ошибок
        string input = "Sunday";
        if (EnumExtensions.TryParseEnum(input, out DaysOfWeek parsedDay))
        {
            Console.WriteLine($"Преобразованный день: {parsedDay}"); // Sunday
        }
        else
        {
            Console.WriteLine("Невозможно преобразовать строку в день недели");
        }

        // Пример 5: Перебор всех значений enum и вывод их описания
        Console.WriteLine("Все дни недели:");
        foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
        {
            Console.WriteLine($"{day}: {day.GetDescription()}");
        }

        // Пример 6: Использование enum в коллекциях и LINQ
        List<Permissions> permissionsList = new List<Permissions>
        {
            Permissions.Read,
            Permissions.Write,
            Permissions.Execute,
            Permissions.Admin
        };

        // Сортировка и фильтрация с помощью LINQ
        var filteredPermissions = permissionsList.Where(p => (p & Permissions.Write) == Permissions.Write);
        Console.WriteLine("Права на запись:");
        foreach (var permission in filteredPermissions)
        {
            Console.WriteLine(permission); // Выводит: Write
        }

        // Пример 7: Проверка всех прав пользователя с использованием флагов
        Permissions allPermissions = Permissions.All;

        // Если у пользователя есть хотя бы одно право:
        if (allPermissions.HasFlag(Permissions.Read))
        {
            Console.WriteLine("Пользователь имеет права на чтение.");
        }

        if (allPermissions.HasFlag(Permissions.Execute))
        {
            Console.WriteLine("Пользователь имеет права на выполнение.");
        }

        Console.ReadKey();
    }
}
