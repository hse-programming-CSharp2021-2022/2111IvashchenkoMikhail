using System;
namespace Task01
{
    class Point2D // internal
    {
        // private
        public int y;
        public int X { get; set; } // новое поле, мы не знаем какое поле, не знаем его
        // имени, как к нему обратиться и т.д.
        public int Y
        {
            get => y;
            set => y = value;
        }
        public double Distance => Math.Sqrt(X*X  + y*y);

        public Point2D(int x = 0, int y = 0)
        {
            X = x; this.y = y;
        }
        public double Distance2(Point2D p2)
        {
            return Math.Sqrt(Math.Pow(X + p2.X, 2) + Math.Pow(Y + p2.Y, 2));
        }
        public static string Name()
        {
            return "Point2D";
        }
        public override string ToString()
        {
            return X +" " + Y;
        }
        public static Point2D operator +(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point2D operator +(Point2D p1, int a)
        {
            return new Point2D(p1.X + a, p1.Y + a);
        }
        public static Point2D operator +(int a, Point2D p1)
        {
            return new Point2D(p1.X + a, p1.Y + a);
        }
        public static Point2D operator -(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.X - p2.X, p1.Y - p2.Y);
        }
        public override bool Equals(object obj)
        {
            Point2D p2 = (Point2D)obj;
            return X == p2.X && Y == p2.Y;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point2D point1 = new Point2D(10, 50);
            Point2D point2 = new Point2D(10, 50);
            Console.WriteLine(point1.X);
            Console.WriteLine(point1.Y);
            Console.WriteLine(point2.X);
            Console.WriteLine(point2.Y);
            Console.WriteLine(point1.Distance);
            Console.WriteLine(point2.Distance);
            Console.WriteLine(point1.Distance2(point2));
            Console.WriteLine(point2.Distance2(point1));
            Console.WriteLine(Point2D.Name());
            var a = new Point2D();
            Console.WriteLine("a = " + a);
            Console.WriteLine(point1);
            Console.WriteLine(point2);
            Console.WriteLine(point1 + point2);
            Console.WriteLine(point1 + 10);
            Console.WriteLine(10 + point1);
            Console.WriteLine(point2 - point1);
            Console.WriteLine(point1.X);
            Console.WriteLine(point1.Y);
            Console.WriteLine(point1.ToString());
            // https://javarush.ru/groups/posts/1989-kontraktih-equals-i-hashcode-ili-kak-ono-vsje-tam
            Console.WriteLine(point1.GetHashCode());
            Console.WriteLine(point2.GetHashCode());
            Console.WriteLine(point2.Equals(point1));
            Console.WriteLine(point2.GetType());
            //String s1 = "123";
            //string s2 = "123";
            //Console.WriteLine(s1.Equals(s2));
            //Console.WriteLine(s1.GetHashCode());
            //Console.WriteLine(s2.GetHashCode());
        }
    }
}