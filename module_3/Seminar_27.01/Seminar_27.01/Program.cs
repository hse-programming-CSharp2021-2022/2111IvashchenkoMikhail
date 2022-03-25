using System;

namespace Seminar_27._01
{
    class Program
    {
        static void Main(string[] args)
        {
            G g = new(x => x * x - 4, Math.Sin);

            Console.WriteLine("X\t|  F(x)");

            for (int i = 0; i < 20; i++)
                Console.Write('-');
            Console.WriteLine();
            
            for (double i = 0; i <= Math.PI; i += Math.PI/16)
            {
                Console.WriteLine($"{i:f4}\t|  {g.GF(i):f4}");
            }
        }
    }
}