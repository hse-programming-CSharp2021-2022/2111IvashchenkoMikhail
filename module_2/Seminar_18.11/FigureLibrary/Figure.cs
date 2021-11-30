using System;

namespace FigureLibrary
{
    public abstract class Figure
    {
        private Point[] Points { get; }
        protected double Length { get; set; }

        public abstract double Area { get; }

        protected Figure(Point[] array)
        {
            if (array.Length <= 2)
            {
                throw new ArgumentException("Not a regular polygon");
            }
            Points = new Point[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Points[i] = array[i];
            }
        }
        
        protected abstract double Radius();
        
        public bool IsCrossing(Figure first, Figure second)
        {
            var centerOfTheFirst = first.GetCenterPoint();
            var centerOfTheSecond = second.GetCenterPoint();
            var distance = Math.Sqrt(Math.Pow(centerOfTheFirst.X - centerOfTheSecond.Y, 2) +
                                     Math.Pow(centerOfTheFirst.Y - centerOfTheSecond.Y, 2));
            
            const double eps = 10e-5;

            if (distance < first.Radius() + second.Radius() ||
                Math.Abs(distance - (first.Radius() + second.Radius())) <= eps)
            {
                return true;
            }

            return false;
        }

        private Point GetCenterPoint()
        {
            var numberOfSides = Points.Length;

            double sumX = 0;
            double sumY = 0;
            foreach (var p in Points)
            {
                sumX += p.X;
                sumY += p.Y;
            }

            var centerX = sumX / numberOfSides;
            var centerY = sumY / numberOfSides;
            
            return new Point(centerX, centerY);
        }

        public override string ToString()
        {
            var output = $"{GetType().ToString().Replace("FigureLibrary.","")}: side = {Length}\nPoints:\n";
            foreach (var p in Points)
            {
                output += $"  {p};\n";
            }

            return output;
        }
    }
}