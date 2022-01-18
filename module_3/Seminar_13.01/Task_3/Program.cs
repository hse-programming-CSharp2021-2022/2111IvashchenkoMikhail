using System;

namespace Task_3
{
    delegate double DelegateConvertTemperature(double x);

    class TemperatureConverterImp
    {
        public double CelsiusToFahrenheit(double tempC) => (double) 9 / 5 * tempC + 32;
        
        public double FahrenheitToCelsius(double tempF) => (double) 5 / 9 * (tempF - 32);
    }

    class StaticTempConverters
    {
        public static double СelsiusToKelvin(double tempC) => tempC + 273.15;
        
        public static double KelvinToCelsius(double tempK) => tempK - 273.15;
        
        public static double CelsiusToRankine(double tempC) => (double) 9 / 5 * tempC + 491.67;
        
        public static double RankineToCelsius(double tempR) => (double) 5 / 9 * (tempR - 491.67);

        public static double CelsiusToReaumur(double tempC) => tempC * 4 / 5;

        public static double ReaumurToCelsius(double tempRe) => tempRe * 5 / 4;
    }
    class Program
    {
        static void Main(string[] args)
        {
            DelegateConvertTemperature cast1 = new TemperatureConverterImp().CelsiusToFahrenheit;
            DelegateConvertTemperature cast2 = new TemperatureConverterImp().FahrenheitToCelsius;
            // Console.WriteLine(cast1.Invoke(14.1));
            // Console.WriteLine(cast2.Invoke(14.1));

            DelegateConvertTemperature[] castArr = {cast1, cast2};
            DelegateConvertTemperature cast3 = StaticTempConverters.СelsiusToKelvin;
            DelegateConvertTemperature cast4 = StaticTempConverters.CelsiusToRankine;
            DelegateConvertTemperature cast5 = StaticTempConverters.CelsiusToReaumur;
            DelegateConvertTemperature cast6 = x => x;
            castArr = new[] {cast6, cast1, cast3, cast4, cast5};
            
            double n;
            do
            {
                Console.Write("Введите значение в градусах Цельсия: ");
            } while (!double.TryParse(Console.ReadLine(), out n));

            var strArr = new[] {"C", "F", "K", "R", "RE"};
            foreach (var s in strArr)
            {
                Console.Write(s + "\t");
            }
            Console.WriteLine();
            
            foreach (var del  in castArr)
            {
                Console.Write($"{del(n):f2}\t");
            }
        }
    }
}