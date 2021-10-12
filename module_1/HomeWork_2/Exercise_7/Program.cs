using System;
using System.Xml;

namespace Exercise_7
{
    class Program
    {
        public static void Method(int a, int b, out int nod, out int nok)
        {
            nod = 0;
            nok = a*b;
            for (int i = 1; i <= Math.Max(a, b); i++)
            {
                if (nod < i && a % i == 0 && b % i == 0)
                {
                    nod = i;
                }
            }

            for (int i = Math.Max(a, b); i <= a*b; i++)
            {
                if (nok > i && i % a == 0 && i % b == 0)
                {
                    nok = i;
                }
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число А: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            Console.WriteLine("Введите число В: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            Method(a,b,out int nod, out int nok);
            Console.WriteLine($"НОД - " + nod);
            Console.WriteLine($"НОК - " + nok);
        }
    }
}