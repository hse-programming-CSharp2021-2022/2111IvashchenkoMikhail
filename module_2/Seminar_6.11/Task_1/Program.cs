using System;
using System.Collections.Concurrent;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RedisClient.Connect();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            int i = 0;
            while (i++ < 5)
            {
                Console.WriteLine("input: ");
                var query = Console.ReadLine();

                var inputLines = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var name = inputLines[0];
                var newVersion = inputLines[1];

                if (RedisClient.Exist(name))
                {
                    Console.WriteLine(RedisClient.Get(name));
                    Console.WriteLine(RedisClient.GetSet(name, newVersion));
                }
                else
                {
                    RedisClient.Set(name, newVersion);
                    Console.WriteLine("New version set");
                }
            }
        }
    }
}