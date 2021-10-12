using System;

namespace Exercise_1
{
    internal static class Program
    {
        private static bool Shift(char input, ref char ch)
        {
            if (!char.TryParse(input.ToString(), out var letter) || !(letter >= 'a' && letter <= 'z'))
            {
                return false;
            }
            switch (letter)
            {
                case 'a':
                    letter += (char) 4;
                    break;
                case <= 'z' when letter >= 'z' - (char) 4:
                    letter -= (char) 4;
                    break;
                default:
                    letter += (char) 4;
                    break;
            }
            ch = letter;
            return true;
        }

        private static void Main()
        {
            Console.WriteLine("Введите символ латинской строчной буквы: ");
            char input = Console.ReadKey().KeyChar;
            var ch = ' ';
            if (Shift(input, ref ch) == false)
            {
                Console.WriteLine();
                Console.WriteLine("Параметр задан неверно.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Полученная буква – " + ch + ".");
            }
        }
    }
}
