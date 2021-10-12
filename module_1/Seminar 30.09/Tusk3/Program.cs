using System;

namespace Tusk3
{
    internal static class Program
    {
        private static void Print(int[] mas)
        {
            for (var i = 0;i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            const int n = 99;
            var random = new Random();
            int deletePosition = random.Next(1, 100);
            int[] mas = new int[n];
            
            for (var i = 0; i < n; i++)
                mas[i] = i + 1;
            
            for (var i = 0; i < n; i++)
            {
                var rnd = random.Next(0, 99);
                (mas[i], mas[rnd]) = (mas[rnd], mas[i]);
            }

            for (var i = 0; i < n; i++)
                if (deletePosition == i)
                    mas[i] = 0;

            for (var i = 0; i < n-1; i++)
                if (mas[i] == 0)
                    (mas[i], mas[i+1]) = (mas[i+1], mas[i]);
            
            Array.Resize(ref mas,98);
            Print(mas);
            
            // Вывод числа, которое было убрано.
            var sum = (n*(n + 1)) / 2;
            var sum2 = 0;
            for (var i = 0; i < mas.Length; i++)
            {
                sum2 += mas[i];
            }
            Console.WriteLine(sum-sum2);
        }
    }
}