using System;
using System.Reflection;

namespace StructVsClassExample
{
    // Определение структуры
    public struct MyStruct
    {
        public int X;
        public int Y;

        // Конструктор структуры
        public MyStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Метод структуры
        public void Display()
        {
            Console.WriteLine($"Struct: X = {X}, Y = {Y}");
        }
    }

    // Определение класса
    public class MyClass
    {
        public int X;
        public int Y;

        // Конструктор класса
        public MyClass(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Метод класса
        public void Display()
        {
            Console.WriteLine($"Class: X = {X}, Y = {Y}");
        }

        // Метод для сравнения значений всех полей в объекте (без использования this)
        public static bool CompareValues(MyClass obj1, MyClass obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                return false;
            }

            // Получаем тип объекта
            Type type = obj1.GetType();

            // Получаем все поля объекта
            FieldInfo[] fields1 = type.GetFields();
            FieldInfo[] fields2 = type.GetFields();

            // Если количество полей не совпадает, то объекты не равны
            if (fields1.Length != fields2.Length)
            {
                return false;
            }

            // Сравниваем все поля
            for (int i = 0; i < fields1.Length; i++)
            {
                var value1 = fields1[i].GetValue(obj1);
                var value2 = fields2[i].GetValue(obj2);

                // Если хотя бы одно значение не совпадает, возвращаем false
                if (!object.Equals(value1, value2))
                {
                    return false;
                }
            }

            return true; // Если все значения одинаковы, возвращаем true
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляра структуры
            MyStruct structObj1 = new MyStruct(10, 20);
            MyStruct structObj2 = structObj1; // Копирование структуры

            // Изменяем значения в structObj1, это не повлияет на structObj2
            structObj1.X = 100;
            structObj1.Y = 200;

            // Вывод значений для структуры
            Console.WriteLine("Struct Example:");
            structObj1.Display(); // Выводит: Struct: x = 100, y = 200
            structObj2.Display(); // Выводит: Struct: x = 10, y = 20
            Console.WriteLine();


            // нельзя сравнить Struct
            // if (structObj1 == structObj2) { } - будет ошибка

            if (structObj1.Equals(structObj2)) // сравнивать значения, а не ссылки
            {
                Console.WriteLine("structObj1 равен structObj2");
            }
            else
            {
                Console.WriteLine("structObj1 не равен structObj2");
            }


            // Создание экземпляра класса
            MyClass classObj1 = new MyClass(10, 20);
            MyClass classObj2 = classObj1; // classObj2 и classObj1 указывают на один и тот же объект
      
            // Изменяем значения в classObj1, это также изменяет classObj2, потому что они ссылаются на один объект
            classObj1.X = 100;
            classObj1.Y = 200;
            
            MyClass classObj3 = new MyClass(100, 200);
            // Вывод значений для класса
            Console.WriteLine("Class Example:");
            classObj1.Display(); // Выводит: Class: x = 100, y = 200
            classObj2.Display(); // Выводит: Class: x = 100, y = 200

            if (classObj1.Equals(classObj2)) // сравнивать ссылки, а не значения
            {
                Console.WriteLine("classObj1 равен classObj2");
            }
            else
            {
                Console.WriteLine("classObj1 не равен classObj2");
            }

            if (classObj1.Equals(classObj3)) // сравнивать ссылки, а не значения
            {
                Console.WriteLine("classObj1 равен classObj3");
            }
            else
            {
                Console.WriteLine("classObj1 не равен classObj3");
            }

            // Сравниваем значения классов
            if (MyClass.CompareValues(classObj1, classObj2)) // Сравниваем значения полей
            {
                Console.WriteLine("CompareValues: classObj1 равен classObj2 (по значениям)");
            }
            else
            {
                Console.WriteLine("CompareValues: classObj1 не равен classObj2 (по значениям)");
            }

            // Сравниваем значения классов
            if (MyClass.CompareValues(classObj1, classObj3)) // Сравниваем значения полей
            {
                Console.WriteLine("CompareValues:classObj1 равен classObj3 (по значениям)");
            }
            else
            {
                Console.WriteLine("CompareValues: classObj1 не равен classObj3 (по значениям)");
            }


            Console.ReadKey();
        }
    }
}