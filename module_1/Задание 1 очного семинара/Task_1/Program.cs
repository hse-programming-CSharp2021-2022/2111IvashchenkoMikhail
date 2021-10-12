using System;

namespace Task_1
{
    class Program
    {
        public static void CompressingOfArray(int[] a)
        {
            int size = a.Length;
            for (int i = 0; i < a.Length-1; i++)
            {
                if ((a[i] + a[i + 1]) % 3 != 0) continue;

                a[i] *= a[i + 1];
                for (int j = i + 1; j < size-1; j++)
                {
                    (a[j], a[j + 1]) = (a[j + 1], a[j]);
                }

                size--;
                Array.Resize(ref a, size);
            }
            
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]+" ");
            }
        }
        
        static void Main()
        {
            int n = 10;
            var rnd = new Random();
            int[] mas = new int[n];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(1, 10);
            }

            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine();
            
            CompressingOfArray(mas);
        }
    }
}