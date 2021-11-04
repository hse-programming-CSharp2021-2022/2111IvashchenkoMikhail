using System;
using System.Text;

namespace Tusk_1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string str = "Let it be; All you need is love; Dizzy Miss Lizzy";
            var strings = str.Split(';');

            foreach (var t in strings)
            {
                var length = t.Length;
                var words = t.Split(' ');
                for (var j = 0; j < length-1; j++)
                {
                    var length2 = words[j].Length;
                    for (var k = 0; k < length; k++)
                    {
                        if(words[k])
                    }
                }
                Console.WriteLine();
            }
        }
    }
}