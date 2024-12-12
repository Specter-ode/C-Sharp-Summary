using System;
using System.Collections.Generic;

namespace MazeExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Определение лабиринта
            int[][] maze = new int[][]
            {
                new int[] { 0, 1, 0, 0, 0, 0, 1 },
                new int[] { 0, 1, 1, 0, 1, 0, 0 },
                new int[] { 0, 0, 0, 1, 1, 0, 1 },
                new int[] { 1, 1, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 1, 1, 0, 1, 0 },
                new int[] { 0, 1, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 1, 0, 0, 0 }
            };

            // Вывод начального лабиринта
            Console.WriteLine("Initial Maze:");
            PrintMaze(maze);

            // Поиск пути от стартовой точки до финишной
            var path = FindPath(maze, (0, 0), (6, 6));
            if (path != null)
            {
                Console.WriteLine("\nPath found:");
                foreach (var step in path)
                {
                    Console.WriteLine($"Step: ({step.Item1}, {step.Item2})");
                    maze[step.Item1][step.Item2] = 2; // Обозначаем путь в лабиринте
                }

                Console.WriteLine("\nMaze with path:");
                PrintMaze(maze);
            }
            else
            {
                Console.WriteLine("\nNo path found.");
            }

            // Пример изменения клетки в лабиринте
            Console.WriteLine("\nModifying maze: Setting cell (4, 4) to 0 (open).");
            SetCell(maze, 4, 4, 0);
            PrintMaze(maze);

            Console.ReadKey();
        }

        // Функция вывода лабиринта
        public static void PrintMaze(int[][] maze)
        {
            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    Console.Write(maze[i][j] == 1 ? "#" : maze[i][j] == 2 ? "." : " ");
                }
                Console.WriteLine();
            }
        }

        // Функция изменения клетки
        public static void SetCell(int[][] maze, int row, int col, int value)
        {
            if (row >= 0 && row < maze.Length && col >= 0 && col < maze[row].Length)
            {
                maze[row][col] = value;
            }
            else
            {
                Console.WriteLine("Invalid cell coordinates.");
            }
        }

        // Поиск пути с использованием алгоритма DFS
        public static List<(int, int)> FindPath(int[][] maze, (int, int) start, (int, int) end)
        {
            int rows = maze.Length;
            int cols = maze[0].Length;
            bool[,] visited = new bool[rows, cols];
            List<(int, int)> path = new List<(int, int)>();

            bool PathFinder(int x, int y)
            {
                if (x < 0 || y < 0 || x >= rows || y >= cols || maze[x][y] == 1 || visited[x, y])
                {
                    return false;
                }

                visited[x, y] = true;
                path.Add((x, y));

                if ((x, y) == end)
                {
                    return true;
                }

                // Рекурсивно ищем путь в соседние клетки (вверх, вниз, влево, вправо)
                if (PathFinder(x + 1, y) || PathFinder(x, y + 1) || PathFinder(x - 1, y) || PathFinder(x, y - 1))
                {
                    return true;
                }

                // Удаляем клетку из пути, если она не приводит к цели
                path.RemoveAt(path.Count - 1);
                return false;
            }

            return PathFinder(start.Item1, start.Item2) ? path : null;
        }
    }
}
