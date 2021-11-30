using System;
using FigureLibrary;

namespace Seminar_18._11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.WriteLine("Введите размер массива фигур (число > 0) :");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            var array = new Figure[n];

            
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = GetFigure();
            }

            var count = 1;
            foreach (var f in array)
            {
                Console.WriteLine($"{count++}) {f}Area = {f.Area:F3}");
            }
            Console.WriteLine();
            
            var someFigure = GetFigure();
            Console.WriteLine("Еще одна фигура:");
            Console.WriteLine($"{someFigure}Area = {someFigure.Area:F3}");

            GetCrossings(array,someFigure);
            AverageTriangleArea(array);
            MinimumSquareArea(array);
        }

        static Figure GetFigure()
        {
            Random rand = new();
            var flag = false;
            Figure result = null;
            while(!flag)
            {
                try
                {
                    if (rand.Next(0, 2) == 1)
                    {
                        result = new Square(new Point(rand.Next(-50, 51), rand.Next(-50, 51)), rand.Next(-25, 26));
                        flag = true;
                        continue;
                    }

                    result = new EqTriangle(new Point(rand.Next(-50, 51), rand.Next(-50, 51)), rand.Next(-25, 26));
                    flag = true;
                }
                catch (ArgumentException e)
                {
                    flag = false;
                }
            }

            return result;
        }

        static void GetCrossings(Figure[] arrayOfFigures, Figure comparableFigure)
        {
            Console.WriteLine("Пересечения с этой фигурой (true - пересекает; false - не пересекает)");
            for (var i = 0; i < arrayOfFigures.Length; i++)
            {
                if (arrayOfFigures[i].IsCrossing(arrayOfFigures[i], comparableFigure))
                {
                    Console.WriteLine($"{i + 1}-я фигура True");
                    continue;
                }

                Console.WriteLine($"{i + 1}-я фигура False");
            }

            Console.WriteLine();
        }

        static void AverageTriangleArea(Figure[] array)
        {
            double sum = 0;
            var count = 0;
            foreach (var t in array)
            {
                if (t is Square) 
                    continue;

                sum += t.Area;
                count++;
            }

            if (count == 0)
            {
                Console.WriteLine("В массиве нет треугольников!");
                return;
            }
            
            Console.WriteLine($"Среднее значение площади треугольников из массива = {sum / count:F3}\n");
        }

        static void MinimumSquareArea(Figure[] array)
        {
            var min = double.MaxValue;
            Figure minSquare = null;
            var count = 0;
            foreach (var t in array)
            {
                if (t is EqTriangle)
                    continue;

                count++;
                if (min > t.Area)
                {
                    min = t.Area;
                    minSquare = t;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("В массиве нет квадратов!");
                Console.WriteLine("Минимальное значение площади квадрата = null.");
                return;
            }
            Console.WriteLine($"Минимальное значение площади квадрата = {min:F3}");
            Console.WriteLine(minSquare);
        }
    }
}