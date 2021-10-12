using System;

namespace Exercise_6
{
    class Program
    {
        private static double GetFactorial(int n)
        {
            double factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        private static double SumOfRowsFirst(double x)
        {
            int n = 3;
            double sum = x * x;
            double sumElement;
            do
            {
                double factorial = GetFactorial(n + 1);
                sumElement = (Math.Pow(2, n) * Math.Pow(x, n + 1)) / factorial;
                sum -= sumElement;
                n += 2;
                sumElement = (Math.Pow(2, n) * Math.Pow(x, n + 1)) / factorial;
                sum += sumElement;
            } while (sumElement > 0);

            return sum;
        }

        private static double SumOfRowsSecond(double x)
        {
            double sum = 1;
            int n = 1;
            double sumElement;
            do
            {
                sumElement = Math.Pow(x, n) / GetFactorial(n);
                sum += sumElement;
                n++;
            } while (sumElement > 0);

            return sum;
        }

        static void Main()
        {
            Console.Write("Hello!\nEnter the x value: ");
            if (!double.TryParse(Console.ReadLine(), out double x))
            {
                Console.WriteLine("Incorrect input");
            }

            Console.WriteLine(SumOfRowsFirst(x));
            Console.WriteLine(SumOfRowsSecond(x));
        }
    }
}    