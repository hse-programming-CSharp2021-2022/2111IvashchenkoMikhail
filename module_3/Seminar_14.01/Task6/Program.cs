using System;

namespace Task6
{
    class Plant
    {
        private readonly double _growth;
        private readonly double _photosensivity;
        private readonly double _frostresistance;
 
        public Plant(double growth, double photosensivity, double frostresistance)
        {
            Growth = growth;
            Photosensivity = photosensivity;
            Frostresistance = frostresistance;
        }

        public double Growth
        {
            get => _growth;
            private init
            {
                if (value is >= 25 and <= 100)
                    _growth = value;
                else
                    _growth = 0;
            }
        }

        public double Photosensivity
        {
            get => _photosensivity;
            private init
            {
                if (value is >= 0 and <= 100)
                    _photosensivity = value;
                else
                    _photosensivity = 0;
            }
        }
        
        public double Frostresistance
        {
            get => _frostresistance;
            private init
            {
                if (value is >= 0 and <= 100)
                    _frostresistance = value;
                else
                    _frostresistance = 0;
            }
        }

        public override string ToString()
        {
            return $"Gr = {_growth:f1},\t Ph = {_photosensivity:f1},\t Fr = {_frostresistance:f1};";
        }
    }

    class Program
    {
        private static void PrintArray(Plant[] arr)
        {
            Array.ForEach(arr,Console.WriteLine);
            Console.WriteLine();
        }

        private static int SortByParity(Plant plant, Plant plant1)
        {
            var num1 = (int) (plant.Photosensivity * 10);
            var num2 = (int) (plant1.Photosensivity * 10);
            
            // Ловим целые.
            {
                if (num1 % 10 == 0)
                    num1 /= 10;
                if (num2 % 10 == 0)
                    num2 /= 10;
            }
            
            if (num2 % 2 == 0 && (num1 % 2 != 0 || num1 > num2)) 
                return 1;
            
            if (num1 == num2)
                return 0;

            return -1;
        }
        
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.WriteLine("Введите n: ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 0);

            var array = new Plant[n];
            Random rand = new();
            for (int i = 0; i < n; i++)
            {
                array[i] = new Plant(rand.Next(250, 1001) / 10.0, rand.Next(0, 1001) / 10.0,
                    rand.Next(0, 801) / 10.0);
            }

            Console.WriteLine("Исходный массив:");
            PrintArray(array);
            
            Console.WriteLine("По убыванию роста:");
            Array.Sort(array, delegate(Plant plant, Plant plant1)
            {
                if (plant.Growth < plant1.Growth) 
                    return 1;
                
                if (Math.Abs(plant.Growth - plant1.Growth) < 10e-7) 
                    return 0;
                
                return -1;
            });
            PrintArray(array);
            
            Console.WriteLine("По возрастанию морозоустойчивости:");
            Array.Sort(array, (plant, plant1) =>
            {
                if (plant.Frostresistance > plant1.Frostresistance) 
                    return 1;
                
                if (Math.Abs(plant.Frostresistance - plant1.Frostresistance) < 10e-7) 
                    return 0;
                
                return -1;
            });
            PrintArray(array);

            Console.WriteLine("По четности светочувствительности:");
            Array.Sort(array,SortByParity);
            PrintArray(array);

            Console.WriteLine("Изменение морозоустойчивости:");
            array = Array.ConvertAll(array, plant =>
            {
                var num = (int) plant.Frostresistance * 10;
                
                // Проверка на целое.
                if (num % 10 == 0)
                    num /= 10;

                return num % 2 == 0 
                    ? new Plant(plant.Growth, plant.Photosensivity, plant.Frostresistance / 3) 
                    : new Plant(plant.Growth, plant.Photosensivity, plant.Frostresistance / 2);
            });
            PrintArray(array);
        }
    }
}