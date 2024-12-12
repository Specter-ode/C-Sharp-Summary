using System;

namespace TwoDimensionalArrays
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Инициализация двумерного массива размером 2x3
            int[,] array = new int[2, 3]
            {
                { 5, 7, 9 },
                { 1, 9, 4 }
            };

            // Вывод элементов массива
            Console.WriteLine("Исходный массив:");
            for (int row = 0; row < array.GetLength(0); row++) // Перебор строк
            {
                for (int column = 0; column < array.GetLength(1); column++) // Перебор столбцов
                {
                    Console.Write(array[row, column] + "\t"); // Вывод значений с табуляцией
                }
                Console.WriteLine(); // Переход на новую строку после вывода каждого ряда
            }

            Console.WriteLine();

            // Пример манипуляций с массивом
            Console.WriteLine("Измененный массив (умножение всех элементов на 2):");
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    array[row, column] *= 2; // Умножаем каждый элемент на 2
                    Console.Write(array[row, column] + "\t"); // Выводим измененные значения
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // Пример транспонирования массива (для двумерных массивов)
            Console.WriteLine("Транспонированный массив:");
            int[,] transposedArray = TransposeMatrix(array);
            for (int row = 0; row < transposedArray.GetLength(0); row++)
            {
                for (int column = 0; column < transposedArray.GetLength(1); column++)
                {
                    Console.Write(transposedArray[row, column] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        // Метод для транспонирования массива
        public static int[,] TransposeMatrix(int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            int[,] transposed = new int[colCount, rowCount];

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    transposed[col, row] = matrix[row, col]; // Перемещаем элементы на место
                }
            }

            return transposed;
        }
    }
}
