using System;
using System.Numerics;

namespace OperatorsOverloading
{
    public class Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        //  Список операторов которые можно перегружать:
        //  унарные операторы +, -, !, ~, ++, --
        //  бинарные операторы +, -, *, /, %
        //  операции сравнения ==, -!, <, >, <=, >=
        //  логические операторы &&, ||

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator *(Vector2 a, int b)
        {
            return new Vector2(a.X * b, a.Y * b);
        }

        public void Print()
        {
            Console.WriteLine($"X={X}, Y={Y}");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var heroPosition = new Vector2(0, 0);
            var speedPerSecond = new Vector2(1, 0);
            var destination = heroPosition + speedPerSecond;
            var destination2 = heroPosition + speedPerSecond;
            destination.Print();
            destination2.Print();
        }
    }
}