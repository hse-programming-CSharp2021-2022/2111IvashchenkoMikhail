using System;

namespace Seminar_7._10
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "abc";
 
            foreach (var sym in str)
                Console.WriteLine((int)sym);
 
            string str2 = string.Empty; // ""
 
            for (int i = 0; i < str.Length; i++)
            {
                str2 += (char)(str[i] + 1);
                Console.WriteLine(str[i]);
            }
 
            Console.WriteLine(str2);
 
            string str3 = new string(new char[] { 'a', 'b', 'c'});
            Console.WriteLine(str3);
 
            string str4 = new string('a', 10);
            Console.WriteLine(str4);
 
            string str5 = string.Concat(str3, str4);
            Console.WriteLine(str5);
 
            Console.WriteLine(str5.Contains("c"));
            Console.WriteLine(str5.Contains("d"));
 
            string[] strs = new string[] { "aaa", "bbb", "ccc"};
            Console.WriteLine(string.Join(";", strs));
        }
    }
}

