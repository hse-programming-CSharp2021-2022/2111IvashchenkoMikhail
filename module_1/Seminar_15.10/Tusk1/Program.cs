using System;
using System.Collections.Generic;
using System.Linq;

namespace Tusk1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Int32.Parse(Console.ReadLine());
            var array = new int[n];
            Random rand = new();
            
            for (var i = 0; i < array.Length; i++)
                array[i] = rand.Next(1, 10000 + 1);
            foreach (var y in array)
                Console.Write(y + " ");
            Console.WriteLine();
            
            var values = array.Select(i => array[i]).ToList();

            var valuesDiv3 = array.Where(s => s % 2 == 0);
            foreach (var i in valuesDiv3)
                Console.Write(i + " ");
            Console.WriteLine();
            
            var polindroms = new List<int>();
            foreach (var t in array)
            {
                var x = t;
                var count = 0;
                while (x > 0)
                {
                    count++;
                    x /= 10;
                }

                var reversedNum = 0;
                for (var j = 0; j < count; j++)
                {
                    reversedNum *= 10;
                    reversedNum += t % 10;
                }

                if (t == reversedNum)
                {
                    polindroms.Add(t);
                }
            }

            foreach (var t in polindroms)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();
        }
    }
}