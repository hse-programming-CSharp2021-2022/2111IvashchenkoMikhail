using System;

namespace Seminar5
{
    class Program
    {
        public static void Print(int[] mas)
        {
            foreach (int i in mas)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void Main()
        {
            int n = 10;
            Random random = new Random();
            int[] mas;
            mas = new int[n];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = random.Next(-10,11);
            }

            Print(mas);
            Array.Sort(mas);
            Print(mas);
            Console.WriteLine(Array.BinarySearch(mas, -5));
            Array.Sort(mas,Comparelement);
            Print(mas);
            Array.Sort(mas, (a, b) =>
            {
                if (a % 2 == 1 & b % 2 == 0) return 1;
                if (a % 2 == 0 & b % 2 == 1) return -1;
                return 0;
            });
        }

        static int Comparelement(int a, int b)
        {
            if (a < b) return 1;
            if (a > b) return -1;
            return 0;
        }
    }
}