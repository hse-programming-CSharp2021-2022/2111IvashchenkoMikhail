using System;
namespace _1
{
    internal class Polygon
    {
        private int Num { get; set; }

        private double Radius { get; set; }

        public Polygon(int num = 0, double radius = 0)
        {
            Num = num; 
            Radius = radius;
        }
        public double Perimeter 
            => Num * 2 * Radius / Math.Cos(Math.PI/Num) * Math.Sin(Math.PI/Num);
        public double Area 
            => 0.5 * Num * 2 * Radius / Math.Cos(Math.PI / Num) * Math.Sin(Math.PI / Num) * Radius;
        public string PolygonData()
        {
            return "Num = " + Num + "; Radius = " + Radius + "; Perimeter = " + Perimeter + "; Area = " + Area;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            var p = new Polygon(4, 4);
            Console.WriteLine(p.Perimeter);
            Console.WriteLine(p.Area);
            Console.WriteLine(p.PolygonData());
        }
    }
}