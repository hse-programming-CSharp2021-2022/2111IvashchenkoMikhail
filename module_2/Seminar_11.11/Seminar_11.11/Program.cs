using System;
abstract class Figure {
    public static int b = 0;
    public int Side { get; protected set; }
    static Figure() => Console.WriteLine(4);
    public Figure(int side) {
        Console.WriteLine(1);
        Side = side;
    }
    public abstract double Area { get; }
    public abstract int P();
    public override string ToString() => $"{GetType()} Side = {Side} S = {Area} P = {P()}";
}
class Triangle : Figure {
    static Triangle() => Console.WriteLine(5);
    public Triangle(int side) : base(side) { Console.WriteLine(2); }
    public override double Area => Side * Side * Math.Sqrt(3) / 4;
    public override int P() => 3 * Side;
}
class Square : Figure {
    static Square() => Console.WriteLine(6);
    public Square(int side) : base(side) { Console.WriteLine(3); }
    public override double Area => Side * Side;
    public override int P() => 4 * Side;
}
class Program {
    public static void Main() {
        //Triangle triangle = new Triangle(10);
        //Square square = new Square(10);
        //Triangle triangle = new Triangle(10);
        //Square square = new Square(10);
        //Console.WriteLine(triangle);
        //Console.WriteLine(triangle.Area);
        //Console.WriteLine(square);
        //Console.WriteLine(square.Area);
        //Figure triangle2 = new Triangle(10);
        //Figure square2 = new Square(10);
        //Console.WriteLine(triangle2);
        //Console.WriteLine(triangle2.Area);
        //Console.WriteLine(square2);
        //Console.WriteLine(square2.Area);
        int n = 10;
        Figure[] figures = new Figure[n];
        Random random = new Random();
        for (int i = 0; i < n / 2; i++)
            figures[i] = new Triangle(random.Next(1, 10));
        for (int i = n / 2; i < n; i++)
            figures[i] = new Square(random.Next(1, 10));
        for (int i = 0; i < n; i++)
            Console.WriteLine(figures[i]);
        Array.Sort(figures, (f1, f2) => f1.Area.CompareTo(f2.Area));
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(figures[i]);
        }
    }
}