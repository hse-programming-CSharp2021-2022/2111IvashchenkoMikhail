using System;

namespace Tusk2
{
    class Program
    {
        public static void Print(char[] mas)
        {
            for(int i = 0;i<mas.Length;i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] mas = new char[n];
            Random random = new Random();
            for (int i =0;i<mas.Length;i++)
            {
                mas[i] = (char) random.Next('A', 'Z' + 1);
            }

            Print(mas);
            char [] masCopy = mas;
            Array.Sort(masCopy,Comparelement);
            Print(masCopy);
            Array.Reverse(masCopy);
            Print(masCopy);
        }
        
        static int Comparelement(char a, char b)
        {
            if (a > b) return 1;
            if (a < b) return -1;
            return 0;
        }
    }
}