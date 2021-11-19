using System;

namespace Task_5
{
    internal class VideoFile
    {
        private readonly string _name;
        private readonly int _duration;
        private readonly int _quality;

        public VideoFile(string name, int duration, int quality)
        {
            _name = name;
            _duration = duration;
            _quality = quality;
        }

        public int Size => _duration * _quality;

        public override string ToString()
        {
            return $"Name - {_name}\n" +
                   $"Duration - {_duration} sec. | Quality - {_quality}\n" +
                   $"Size - {Size}";
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите название видеофайла, продолжительность и качество в одну строку, через пробел");
            Console.WriteLine("///ПРИМЕР ВВОДА: FileName 90 1080");
            var input = Console.ReadLine().Split(" ");
            
            var userVideoFile = new VideoFile(input[0], int.Parse(input[1]), int.Parse(input[2]));
            var rnd = new Random();
            
            var N = rnd.Next(5, 15 + 1);
            Console.WriteLine($"Размер массива видеофайлов == {N}");
            var arrayOfVideos = new VideoFile[N];

            for (var i = 0; i < arrayOfVideos.Length; i++)
            {
                arrayOfVideos[i] = new VideoFile(RandomFileName(rnd.Next(1, 9 + 1)), rnd.Next(60, 360 + 1),
                    rnd.Next(100, 1000 + 1));
            }

            var count = 0;
            foreach (var video in arrayOfVideos)
            {
                if (video.Size > userVideoFile.Size)
                {
                    Console.WriteLine(video);
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Нет файлов разамеров больше данного :( ");
            }
            
            Escape();
        }

        private static string RandomFileName(int length)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var symbols = new char[length];
            var result = "";
            var rnd = new Random();
            foreach (var i in symbols)
            {
                symbols[i] = alphabet[rnd.Next(0, alphabet.Length)];
                result += symbols[i];
            }

            return result;
        }

        private static void Escape()
        {
            Console.WriteLine("\n\tЖелаете завершить программу?\n");
            Console.WriteLine("Нажмите [ENTER] чтобы завершить программу...");
            Console.WriteLine("Нажмите [SPACE] чтобы продолжить...\n");
            // Чтение клавиши с проверкой.
            var userChoice = Console.ReadKey();
            while (userChoice.Key != ConsoleKey.Spacebar && userChoice.Key != ConsoleKey.Enter)
            {
                userChoice = Console.ReadKey();
            }
            
            if (userChoice.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("(^ - ^) Пока! (^ - ^)\n");
                Environment.Exit(0);
            }
            else
            {
                Main();
            }
        }
    }
}