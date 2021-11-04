using System;
using System.Text;
namespace Sem{
    class Program    {
        private static Random rnd = new();
        static string DigitToString(char digit)
        {
            string[] digitString = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            return digitString[digit - '0'];
        }
        static char[] Series(int n, int per)
        {
            char[] arr = new char[n];
            int nLetterAmount = (int) (n * per / 100.0);
            for (int i = 0; i < nLetterAmount; i++)
                arr[i] = (char) rnd.Next('a', 'z' + 1);
            for (int i = nLetterAmount; i < n; i++)
                arr[i] = (char) rnd.Next('0', '9' + 1);
            return arr;
        }
        static string Line(char[] series)
        {
            StringBuilder sb = new();
            for (int i = 0; i < series.Length; i++)
            {
                if (series[i] >= '0' && series[i] <= '9') 
                    sb.Append(DigitToString(series[i]) + " ");
                else                    sb.Append(series[i] + " ");
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            int n;
            // процент букв в массиве
            int per;
            do            {
                Console.WriteLine("Введите размер массива:");
            } while (!(int.TryParse(Console.ReadLine(), out n) && n > 1));
            do            {
                Console.WriteLine("Введите процент букв:");
            } while (!(int.TryParse(Console.ReadLine(), out per) && per >= 0));
            char[] arr = Series(n, per);
            Array.ForEach(arr, x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine(Line(arr));
        }
    }
}