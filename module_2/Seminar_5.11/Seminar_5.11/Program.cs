using System;

namespace Seminar_5._11
{
    class RightTriangle
    {
        private int a;
        public static int count = 0;
        public static readonly int count2 = 0;
        public const int count3 = 0;
        static RightTriangle()
        {
            count = 10;
            count2 = 100;
            //count3 = 1000;
        }
        public int A { get; set; }

        public RightTriangle(int a)
        {
            A = a;
            count++;
        }

        ~RightTriangle()
        {
            Console.WriteLine("destructor");
        }
        
        public RightTriangle() : this(0) { }

        public RightTriangle(int a, int b)
        {
            new RightTriangle();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RightTriangle.count);
            Console.WriteLine(RightTriangle.count2);
            Console.WriteLine(RightTriangle.count3);
            new RightTriangle(1);
            new RightTriangle(1);
            new RightTriangle(1);
            new RightTriangle(1);
            new RightTriangle(1);
            new RightTriangle(1);
            Console.WriteLine(RightTriangle.count);
        }
    }
}