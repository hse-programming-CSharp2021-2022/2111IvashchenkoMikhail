/*
 *          Домашнее задание со второго очного семинара.
 *      Необходимо вывести на экран спиральную матрицу вида:
 * ==========================================================
 *       1   2   3   4   5            1   2   3   4   5   6
 *       16  17  18  19  6            20  21  22  23  24  7
 *       15  24  25  20  7     или    19  32  33  34  25  8
 *       14  23  22  21  8            18  31  36  35  26  9
 *       13  12  11  10  9            17  30  29  28  27  10
 *                                    16  15  14  13  12  11
 * ==========================================================
 *      Размер матрицы задается пользователем.
 */
using System;

namespace Homework
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var matrix = GetMatrix();
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            for (var i = 0; i < matrix.GetLength(0); i++)
            for (var j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = 0;

            PrintMatrix(matrix);
        }
        
        /// <summary>
        /// Метод, создающий матрицу пользовательского размера.
        /// </summary>
        /// <returns>Матрица m x n.</returns>
        private static int[,] GetMatrix()
        {
            Console.WriteLine("\tВведите размер матрицы m * n");
            Console.Write("Введите m > 0: ");
            var input = Console.ReadLine();
            int m;
            while (!int.TryParse(input, out m) || m <= 0)
            {
                Console.WriteLine("\tIncorrect input!");
                Console.Write("Введите m > 0: ");
                input = Console.ReadLine();
            }

            Console.Write("Введите n > 0: ");
            input = Console.ReadLine();
            int n;
            while (!int.TryParse(input,out n) || n <= 0)
            {
                Console.Write("Введите n > 0: ");
                input = Console.ReadLine();
                Console.WriteLine("Incorrect input");   
            }
            
            return new int[m, n];
        }
        
        /// <summary>
        /// Вывод матрицы на экран.
        /// </summary>
        /// <param name="matrix">Матрица для вывода.</param>
        private static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,5}",matrix[i,j].ToString()); 
                }

                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Выход из программы.
        /// </summary>
        /// <returns>Возвращает значение bool:
        /// "True" - завершить программу.
        /// "False" - продолжить работу программы.</returns>
        private static bool Escape()
        {
            Console.WriteLine("Нажмите Escape для выхода.");
            Console.WriteLine("Нажмите любую клавишу,");
            var press = Console.ReadKey();
            return press.Key == ConsoleKey.Escape;
        }
    }
}