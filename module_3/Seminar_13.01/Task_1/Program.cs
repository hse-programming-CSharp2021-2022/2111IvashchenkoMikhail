using System;

namespace Task_1
{
    delegate int Cast(double x);
    class Program
    { 
        static int SomeMethod2 (double x) => (int) Math.Log10(x) + 1;

        static void Main(string[] args)
        {
            Cast cast1 = x => (int) (Math.Round(x / 2) * 2);
            Cast cast2 = x => (int) Math.Log10(x) + 1;
            Console.WriteLine(cast1(3.4));
            Console.WriteLine(cast2(3.4));
            double[] test1 = {3.4, 2.5, 4.9};
            Array.ForEach(test1, d => Console.Write(cast1(d) + " "));
            Console.WriteLine();
            Array.ForEach(test1, d => Console.Write(cast2(d) + " "));
            Console.WriteLine("\n-----------------");

            Cast cast3 = cast1 + cast2;
            Array.ForEach(test1, d => Console.Write(cast3(d) + " "));
            Console.WriteLine("\n-----------------");

            Array.ForEach(test1, d => Console.Write(cast3.Invoke(d) + " "));
            Console.WriteLine("\n-----------------");

            cast3 -= x => (int) Math.Log10(x) + 1;
            Array.ForEach(test1, d => Console.Write(cast3.Invoke(d) + " "));
            Console.WriteLine("\n-----------------");
            Console.WriteLine("Список методов cast3:");
            foreach (var del in cast3.GetInvocationList())
            {
                Console.WriteLine(del.Method);
            }
            Console.WriteLine("\n-----------------");
              
            cast3 -= SomeMethod2;
            Array.ForEach(test1, d => Console.Write(cast3.Invoke(d) + " "));
            Console.WriteLine("\n-----------------");
            Console.WriteLine("Список методов cast3:");
            foreach (var del in cast3.GetInvocationList())
            {
                Console.WriteLine(del.Method);
            }
            
            // Список вызовов cast3 не изменяется при -= SomeMethod и при -= x => выражение, потому что
            // в cast3 лежит список вызовов составных делегатов, а не список вызовов методов из составных делегатов.
            // Таким образом, операторы += и -= для multicast-делегата определены только в контексте делегатов.
            // Например: cast3 -= cast2 изменит список вызовов cast3.
        }
    }
}