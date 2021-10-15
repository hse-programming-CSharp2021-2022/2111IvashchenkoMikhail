using System;
using System.Text.RegularExpressions;

namespace SeminarRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Бык тупогуб, тупогубенький бфчок, у быка губа бела";
            var regex = new Regex(@"туп\w*");
            var matches = regex.Matches(s);
            foreach (Match m in matches)
            {
                Console.WriteLine(m.Value);
            }

            s = regex.Replace(s, "11111");
            string s2 = "111-111-1111";
            var regex2 = new Regex(@"\d{3}-[0-9]{3}-\d{4}");
            Console.WriteLine(regex2.Match(s2));
            Console.WriteLine(Regex.IsMatch(s2,regex2.ToString()));
        }
    }
}