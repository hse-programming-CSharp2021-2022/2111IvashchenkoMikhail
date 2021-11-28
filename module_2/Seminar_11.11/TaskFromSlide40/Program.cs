using System;
using System.Collections.Generic;
using System.Linq;
using Cinderella;

namespace TaskFromSlide40
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Enter N value : ");
            } while (!int.TryParse(Console.ReadLine(), out n));

            var array = new Something[n];
            Random rand = new();
            
            for (int i = 0; i < n; i++)
            {
                if (rand.Next(0, 2) == 0)
                {
                    array[i] = new Lentil();
                    continue;
                }

                array[i] = new Ashes();
            }

            Console.WriteLine("Array: ");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            
            var listOfLentil = array.OfType<Lentil>().ToList();
            var listOfAshes = array.OfType<Ashes>().ToList();

            Console.WriteLine("List of lentil:");
            foreach (var i in listOfLentil)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            Console.WriteLine("List of ashes:");
            foreach (var i in listOfAshes)
            {
                Console.WriteLine(i);
            }
        }
    }
}