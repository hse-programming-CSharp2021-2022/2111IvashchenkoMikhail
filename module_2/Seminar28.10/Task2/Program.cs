using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public Point() : this(0, 0) { }

            private double Ro => Math.Sqrt(Math.Pow(Y, 2) + Math.Pow(X, 2));

            private double Fi
            {
                get
                {
                    return X switch
                    {
                        > 0 when Y >= 0 => Math.Atan(Y / X),
                        > 0 when Y < 0 => Math.Atan(Y / X) + 2 * Math.PI,
                        < 0 when Y == 0 => Math.Atan(Y / X) + Math.PI,
                        0 when Y > 0 => Math.PI / 2,
                        0 when Y < 0 => 3 * Math.PI / 2,
                        _ => 0
                    };
                }
            }

            public string PointData
            {
                get
                {
                    var maket = "X = {0:F2}; Y = {1:F2}; Ro = {2:F2}; Fi = {3:F2}";
                    return string.Format(maket, X, Y, Ro, Fi);
                }
            }

            public double DistanceFromZeroPoint()
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }

        static void Main()
        {
            Point a, b, c;
            var pointsList = new List<Point>();
            
            a = new Point(3, 4);
            pointsList.Add(a);
            Console.WriteLine(a.PointData);
            
            b = new Point(0, 3);
            pointsList.Add(b);
            Console.WriteLine(b.PointData);
            
            c = new Point();
            double x;
            double y;

            do
            {
                Console.Write("x = ");
                double.TryParse(Console.ReadLine(), out x);
                Console.Write("y = ");
                double.TryParse(Console.ReadLine(), out y);

                c.X = x;
                c.Y = y;
            } while (x == 0 && y == 0);
            pointsList.Add(c);
            pointsList = ListSortedByDistance(pointsList);

            foreach (var point in pointsList)
            {
                Console.WriteLine(point.PointData);
            }
        }

        private static List<Point> ListSortedByDistance(List<Point> list)
        { 
            var sortedPoints = from point in list
                orderby point.DistanceFromZeroPoint()
                select point;
            
            return sortedPoints.ToList();
        }
    }
}