using System;

namespace FigureLibrary
{
    public class EqTriangle : Figure
    {
        public EqTriangle(Point a, double length) : base(TriangleMethod(a,length))
        {
            if (length < 0)
            {
                throw new ArgumentException("Length can't be less than zero");
            }

            Length = length;
        }
        
        public override double Area => Math.Sqrt(3) * Math.Pow(Length, 2) / 4;

        protected override double Radius()
        {
            return 2 * Length / Math.Sqrt(3);
        }

        private static Point[] TriangleMethod(Point a, double length)
        {
            var height = Math.Sqrt(3) * length / 2;
            var b = new Point(a.X + length, a.Y);
            
            // Точка H - центр стороны AB правильного треугольника ABC.
            var pointH = new Point(a.X + length / 2, a.Y);

            var c = new Point(pointH.X, pointH.Y + height);

            return new[] {a, b, c};
        }
    }
}