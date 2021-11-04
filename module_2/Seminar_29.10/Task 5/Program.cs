using System;

namespace Task_5
{
    public class ConsolePlate
    {
        // Поля.
        private char _plateChar = 'A';
        private ConsoleColor _plateColor = Console.ForegroundColor;
        private ConsoleColor _bgColor = Console.BackgroundColor;
        // Конструкторы.
        public ConsolePlate()
        {
            PlateChar = _plateChar;
            PlateColor = _plateColor;
        }

        public ConsolePlate(char plateChar)
        {
            PlateChar = plateChar;
            PlateColor = _plateColor;
        }
        
        public ConsolePlate(char plateChar, ConsoleColor plateColor)
        {
            PlateChar = plateChar;
            PlateColor = plateColor;
        }
        
        public ConsolePlate(char plateChar, ConsoleColor plateColor, ConsoleColor bgColor)
        {
            PlateChar = plateChar;
            PlateColor = plateColor;
            BgColor = bgColor;
        }
        // Объявление свойств.
        public char PlateChar
        {
            get => _plateChar;
            set => _plateChar = value >= 65 && value <= 90 ? value : 'A';
        }
        
        public ConsoleColor PlateColor { get; set; }

        public ConsoleColor BgColor
        {
            get => _bgColor;
            set
            { 
                ConsoleColor[] arr = 
                { value, ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue};
                var flag = false;
                foreach (var t in arr)
                {
                    if (t == PlateColor || flag) continue;
                    
                    _bgColor = t;
                    flag = true;
                }
            }
        }

        public void Print()
        {
            Console.ForegroundColor = PlateColor;
            Console.BackgroundColor = BgColor;
            Console.Write(PlateChar);
            Console.ResetColor();
        }
    }
    
    class Program
    {
        static void Main( )
        {
            MainTask1();
            MainTask2();
        }

        private static void MainTask1()
        {
            ConsolePlate[] somePlates = 
            { 	   
                new ConsolePlate(),
                new ConsolePlate('L'),
                new ConsolePlate('O', ConsoleColor.Red),
                new ConsolePlate('H', ConsoleColor.Green), 
                new ConsolePlate('!', ConsoleColor.Blue, ConsoleColor.Blue)
            };

            foreach(var conPl in somePlates)
            {
                Console.ForegroundColor = conPl.PlateColor;
                Console.BackgroundColor = conPl.BgColor;
                Console.Write(conPl.PlateChar);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        private static void MainTask2()
        {
            ConsolePlate obj1 = new('X',ConsoleColor.White,ConsoleColor.Red);
            ConsolePlate obj2 = new('O',ConsoleColor.White,ConsoleColor.Magenta);
            int n;
            do
            {
                Console.Write("N = ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n is not (>= 2 and < 35));

            Random rand = new();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rand.Next(0, 2) == 0)
                    { 
                        obj1.Print();
                    }
                    else
                    {
                        obj2.Print();
                    }
                }

                Console.WriteLine();
            }
        }
    }
}