using System;

namespace Polymorphism
{
    public class Task
    {
        public static void Main(string[] args)
        {
            var rectangle = new Rectangle(2, 3);
            Console.WriteLine(rectangle.GetSquare()); // 6
            Console.WriteLine(rectangle.GetPerimeter()); // 10

            var rhombus = new Rhombus(4, 5);
            Console.WriteLine(rhombus.GetSquare()); // 10
            Console.WriteLine(rhombus.GetPerimeter()); // 16

            var sphere = new Sphere(5);
            Console.WriteLine(Math.Round(sphere.GetSquare())); // 314
            Console.WriteLine(Math.Round(sphere.GetVolume())); // 524

            var cube = new Cube(4);
            Console.WriteLine(Math.Round(cube.GetSquare())); // 96
            Console.WriteLine(Math.Round(cube.GetVolume())); // 64
        }
    }

    // Базовый абстрактный класс Shape
    public abstract class Shape
    {
        private double _square;

        protected Shape(double square)
        {
            _square = square;
        }

        public double GetSquare()
        {
            return _square;
        }
    }

    // Абстрактный класс для плоских фигур
    public abstract class FlatShape : Shape
    {
        private double _perimeter;

        protected FlatShape(double square, double perimeter) : base(square)
        {
            _perimeter = perimeter;
        }

        public double GetPerimeter()
        {
            return _perimeter;
        }
    }

    // Класс прямоугольника
    public class Rectangle : FlatShape
    {
        private double _sideA;
        private double _sideB;

        public Rectangle(double sideA, double sideB) : base(sideA * sideB, 2 * (sideA + sideB))
        {
            _sideA = sideA;
            _sideB = sideB;
        }
    }

    // Класс ромба
    public class Rhombus : FlatShape
    {
        private double _side;
        private double _height;

        public Rhombus(double side, double height) : base((side * height) / 2, 4 * side)
        {
            _side = side;
            _height = height;
        }
    }

    // Абстрактный класс для объемных фигур
    public abstract class VolumetricShape : Shape
    {
        private double _volume;

        protected VolumetricShape(double square, double volume) : base(square)
        {
            _volume = volume;
        }

        public double GetVolume()
        {
            return _volume;
        }
    }

    // Класс сферы
    public class Sphere : VolumetricShape
    {
        private double _radius;

        public Sphere(double radius) : base(4 * Math.PI * Math.Pow(radius, 2), 4.0 / 3.0 * Math.PI * Math.Pow(radius, 3))
        {
            _radius = radius;
        }
    }

    // Класс куба
    public class Cube : VolumetricShape
    {
        private double _side;

        public Cube(double side) : base(6 * Math.Pow(side, 2), Math.Pow(side, 3))
        {
            _side = side;
        }
    }

}