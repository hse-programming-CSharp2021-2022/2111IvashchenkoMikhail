using System;
using System.Collections.Generic;

namespace Task3
{
    class RegularPolygon
    {
        private int NumberOfSides { get; set; }

        private double Radius { get; set; }
        
        public RegularPolygon(int num, double radius)
        {
            NumberOfSides = num;
            Radius = radius;
        }

        public double Angle => (double)(NumberOfSides - 2) / NumberOfSides * 180;
        
        public double Sides => 2 * Radius * Math.Sin(Math.PI / NumberOfSides);

        public double RadiusInscribed => Radius * Math.Cos(Math.PI / NumberOfSides);

        public double Area => 0.5 * Perimiter * RadiusInscribed;
        
        public double Perimiter => NumberOfSides * Sides;

        public string PolygonData() =>
            $"Polygon Data:\nSides = {Math.Round(Sides,3)}\n" +
            $"Angle = {Math.Round(Angle,3)}\n" +
            $"Radius of inscribed circle = {Math.Round(RadiusInscribed,3)}\n" +
            $"Area = {Math.Round(Area,3)}\n" +
            $"Perimeter = {Math.Round(Perimiter,3)}";
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MainTask1();
            MainTask2();
        }

        public static void MainTask1()
        {
            var polygon = new RegularPolygon(4,10);
            Console.WriteLine(polygon.PolygonData());
        }

        public static void MainTask2()
        {
            var list = new List<RegularPolygon>();
            Console.WriteLine("\tEntering elements of list");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Elements with meaningless values won't be added to the list!");
            Console.ResetColor();
            int num;
            double radius;
            var count = 1;
            do
            {
                Console.WriteLine($"{count}.Polygon");
                do
                    Console.Write("Num = ");
                while (!int.TryParse(Console.ReadLine(), out num) || num is > 0 and < 3);
                do
                    Console.Write("Radius = ");
                while (!double.TryParse(Console.ReadLine(), out radius) || radius < 0);
                if (num == 0 || radius == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Meaninless values!");
                    Console.ResetColor();
                    continue;
                }
                
                list.Add(new RegularPolygon(num, radius));
                Console.WriteLine(list[count - 1].PolygonData());
                count++;
                
            } while (!(num == 0 && radius == 0));

            Console.WriteLine("\t*Polygons' info*");
            var min = list[0];
            var max = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Area < min.Area)
                    min = list[i];
                
                if (list[i].Area > max.Area)
                    max = list[i];
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Max Area value = {max.Area}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Min Area value = {min.Area}");
            Console.ResetColor();
        }
    }
}