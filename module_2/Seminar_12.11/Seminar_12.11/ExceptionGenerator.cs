using System;
using System.Collections.Generic;
using System.IO;

namespace Seminar_12._11
{
    public static class ExceptionGenerator
    {
        public static void IndexOutOfRangeException()
        {
            try
            {
                var someArray = new int[10];
                foreach (var i in someArray)
                {
                    someArray[i] = 10;
                }

                Console.WriteLine(someArray[11]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void FileNotFoundException()
        {
            try
            {
                using var streamReader = new StreamReader("wrongPath.txt");
                string line = streamReader.ReadLine();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void NullReferenceException(string line)
        {
            try
            {
                var n = line.Length;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DivideByZeroException()
        {
            try
            {
                var n = 1; 
                var m = n / 0;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static void InvalidCastException()
        {
            try
            {
                object obj = "Hello world!";
                var num = (int) obj;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ArgumentOutOfRangeException()
        {
            try
            {
                var rand = new Random();
                int n = rand.Next(10, 0);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void StackOverflowException()
        {
            try
            {
                StackOverflowException();
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void FormatException()
        {
            try
            {
                var line = "qwe";
                var n = int.Parse(line);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void OverflowException()
        {
            try
            {
                var a = Convert.ToByte(-4);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void OutOfMemoryException()
        {
            try
            {
                var hugeList = new List<string>(int.MaxValue);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void CustomException()
        {
            try
            {
                Console.WriteLine("Type any animal");
                var line = Console.ReadLine();
                
                if (line != "dragon" && line != "Dragon")
                {
                    throw new NotADragonException($"{line} is not a Dragon");
                }

                Console.WriteLine($"Congrats! {line} is a dragon!");
            }
            catch (NotADragonException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}