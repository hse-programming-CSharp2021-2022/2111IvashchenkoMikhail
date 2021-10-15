using System;
using System.Collections.Generic;
using System.Linq;

namespace Seminar_15._10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = {"Adadada", "adfrdada", " ", "adqweqdq"};
            // Создание переменной List
            var str = new List<string>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].ToUpper().StartsWith("A"))
                {
                    str.Add(array[i]);
                }
            }

            foreach (var t in str)
            {
                Console.Write(t + " ");
            }

            var str2 = from s in array
                where s.ToUpper().StartsWith("A")
                // По убыванию orderby s descending
                select s;
            Console.WriteLine();
            foreach (var i in str2)
            {
                Console.Write(i + " ");
            }

            array[1] = "eewwwf";
            array[3] = "AADASaf";
            Console.WriteLine();
            foreach(var i in str2)
                Console.Write(i + " ");
        }
    }
}