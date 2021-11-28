using System;
using Task04Lib_Shape;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var N1 = rand.Next(3, 6);
            var N2 = rand.Next(3, 6);
            var N3 = rand.Next(3, 6);
            var array = new Shape[N1 + N2 + N3];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < N1)
                {
                    array[i] = new Circle(rand.Next(1, 20));
                }
                
                if (i < N1 + N2 && i > N1 - 1)
                {
                    array[i] = new Cylinder(rand.Next(1, 20), rand.Next(1, 20));
                }

                if (i < N1 + N2 + N3 && i > N1 + N2 - 1)
                {
                    array[i] = new Sphere(rand.Next(1, 20));
                }
            }
            
            Array.Sort(array, delegate(Shape shape, Shape shape1)
            {
                return shape switch
                {
                    Circle when shape1 is Cylinder or Sphere => -1,
                    Cylinder or Sphere when shape1 is Circle => 1,
                    Cylinder when shape1 is Sphere => -1,
                    Sphere when shape1 is Cylinder => 1,
                    _ => 0
                };
            });

            Console.WriteLine("Array after sorting:");
            for (int count = 0; count < array.Length; count++)
            {
                if (array[count] is Circle)
                {
                    Console.WriteLine($"{count + 1}) Circle, Area = {array[count].Area():F2}");
                }

                if (array[count] is Cylinder)
                {
                    Console.WriteLine($"{count + 1}) Cylinder, Area = {array[count].Area():F2}");
                }

                if (array[count] is Sphere)
                {
                    Console.WriteLine($"{count + 1}) Sphere, Area = {array[count].Area():F2}");
                }
            }
        }
    }
}