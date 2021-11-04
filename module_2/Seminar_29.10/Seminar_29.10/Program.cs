using System;

namespace Seminar_29._10
{ 
    class MyComplex   
    {
        private double re, im;

        public MyComplex(double xre, double xim)
        {
            re = xre; 
            im = xim;
        }
        
        public static MyComplex operator ++(MyComplex mc)
        {
            return new MyComplex(mc.re + 1, mc.im + 1);
        }

        public static MyComplex operator --(MyComplex mc)
        {
            return new MyComplex(mc.re - 1, mc.im - 1);
        }
        
        private double Mod()
        {
            return Math.Abs(re * re + im * im);
        }
        
        public static bool operator true(MyComplex f)
        {
            return f.Mod() > 1.0;
        }
        
        public static bool operator false(MyComplex f)
        {
            return f.Mod() <= 1.0;
        }

        public static MyComplex operator +(MyComplex f, MyComplex m)
        {
            return new MyComplex(f.re + m.re, f.im + m.im);
        }
        
        public static MyComplex operator -(MyComplex f, MyComplex m)
        {
            return new MyComplex(f.re - m.re, f.im - m.im);
        }
        
        public static MyComplex operator *(MyComplex f, MyComplex m)
        {
            return new MyComplex(f.re * m.re - f.im * m.im, f.im * m.re + f.re * m.im);
        }

        public static MyComplex operator /(MyComplex f, MyComplex m)
        {
            return new MyComplex((f.re * m.re + f.im * m.im) / (m.re * m.re + m.im * m.im),
                                  (f.im * m.re - f.re * m.im) / ((m.re * m.re + m.im * m.im)));
        }

        public override string ToString()
        {
            return re + " + " + im + "i";
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var a = new MyComplex(5, 1);
            var b = new MyComplex(10, 2);
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            Console.WriteLine($"a + b = {a + b}");
            Console.WriteLine($"a - b = {a - b}");
            Console.WriteLine($"a * b = {a * b}");
            Console.WriteLine($"a / b = {a / b}");
        }
    }
}