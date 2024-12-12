using System;

namespace ArrayOfArraysExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Инициализация массива массивов
            int[][] jaggedArray = new int[3][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 11, 22, 33 },
                new int[] { 111, 222, 333 }
            };
            // или
            // int[][] jaggedArray = new int[3][];
            // jaggedArray[0] = new int[] { 1, 2, 3 };
            // jaggedArray[1] = new int[] { 4, 5 };
            // jaggedArray[2] = new int[] { 6, 7, 8, 9 };

            // Вывод значений массива массивов
            Console.WriteLine("Массив массивов:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write("Элемент " + i + ": ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // Пример изменения значений
            jaggedArray[0][0] = 10;
            jaggedArray[1][1] = 20;

            Console.WriteLine("Измененный массив массивов:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write("Элемент " + i + ": ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
            
            
            // Инициализация двумерного массива для Шахматной доски
            string[,] chessBoard = new string[8, 8];

            // Заполнение массива значениями
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    chessBoard[row, col] = (row + col) % 2 == 0 ? "White" : "Black";
                }
            }

            // Вывод шахматной доски
            Console.WriteLine("Chess Board:");
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Console.Write(chessBoard[row, col].Substring(0, 1) + " "); // W для White, B для Black
                }
                Console.WriteLine();
            }

            Console.ReadKey();

            
            
            
            
            int rows = 5;

            // Инициализация треугольного массива
            int[][] pascalTriangle = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                pascalTriangle[i] = new int[i + 1];
                pascalTriangle[i][0] = 1; // Первый элемент каждой строки
                pascalTriangle[i][i] = 1; // Последний элемент каждой строки

                for (int j = 1; j < i; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                }
            }

            // Вывод треугольника Паскаля
            Console.WriteLine("Pascal's Triangle:");
            for (int i = 0; i < rows; i++)
            {
                Console.Write(new string(' ', (rows - i) * 2));
                foreach (var value in pascalTriangle[i])
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}