using System;

namespace FigureLibrary
{
    public class Square : Figure
    {
        public Square(Point a, double length) : base(SquareMethod(a, length))
        {
            if (length < 0)
            {
                throw new ArgumentException("Length can't be less than zero");
            }

            Length = length;
        }

        public override double Area => Math.Pow(Length, 2);
        
        protected override double Radius()
        {
            return Length / Math.Sqrt(2);
        }

        private static Point[] SquareMethod(Point a, double length)
        {
            var b = new Point(a.X, a.Y + length);
            var c = new Point(a.X + length, b.Y);
            var d = new Point(c.X, a.Y);

            return new[] {a, b, c, d};
        }
    }
}