using System;
using System.Xml.Linq;

namespace SeminarOch2
{
    class Program
    {
        static void PrintArray(int[][] mas)
        {
            for (int i = 0; i < mas.Length; i++,Console.WriteLine())
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write(mas[i][j] + " ");
                }
            }
        }
        
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine();
            int n = int.Parse(input);
            int[][] mas = new int[n][];
            Random rand = new();
            for (int i = 0; i < mas.Length; i++)
            {
                int m = rand.Next(5, 16);
                mas[i]= new int [m];
            }
            
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    mas[i][j] = rand.Next(-10, 11);
                }
            }
            
            PrintArray(mas);
            Console.WriteLine();

            foreach (int[] t in mas)
            {
                Array.Sort(t, (x, y) => y.CompareTo(x));
            }
            PrintArray(mas);
            Console.WriteLine();
            
            Array.Sort(mas,(x,y)=>y.Length.CompareTo(x.Length));
            PrintArray(mas);
            Console.WriteLine();
        }
    }
}