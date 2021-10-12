using System;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5, m = 3;
            int[,] a = new int[n, m];
            Random random = new Random();
            for (int i = 0; i < a.GetLength(0); i++, Console.WriteLine())
            for (int j = 0; j < a.GetLength(1); j++)
            {
                a[i, j] = random.Next(-10, 10);
                Console.Write(a[i, j] + " ");
            }

            int[][] b = new int[n][];
            Console.WriteLine();
            for (int i = 0; i < b.Length; i++)
                b[i] = new int[random.Next(5, 10)];

            for (int i = 0; i < b.Length; i++, Console.WriteLine())
            for (int j = 0; j < b[i].Length; j++)
            {
                b[i][j] = random.Next(-10, 10);
                Console.Write(b[i][j] + " ");
            }

        }
    }
}