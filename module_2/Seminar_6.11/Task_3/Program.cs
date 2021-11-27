using System;

namespace Task_3
{
    class Program
    {
        static void Main()
        {
            try
            {
                RedisClient.Connect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
            
            string command;
            Console.WriteLine("Input command (add/back/get/show)\n" +
                              "Or type \"exit\" to exit");
            Console.WriteLine("Maximum number of versions to store == 5");
            while ((command = Console.ReadLine()) != "exit")
            {
                if (command is null or "")
                {
                    Console.WriteLine("Input command (add/back/get/show)\n" +
                                      "Or type \"exit\" to exit");
                    Console.WriteLine("Enter any command");
                    continue;
                }
                
                var inputLine = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                switch (inputLine[0])
                {
                    case "add":
                        try
                        {
                            RedisClient.Add($"Task3_{inputLine[1]}", inputLine[2]);
                            Console.WriteLine($"New version of {inputLine[1]} was successfully added!");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("App name or version info is empty");
                        }
                        break;
                    case "back":
                        try
                        {
                            Console.WriteLine(RedisClient.Back($"Task3_{inputLine[1]}"));
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("App name or version info is empty");
                        }
                        break;
                    case "get":
                        try
                        {
                            Console.WriteLine(RedisClient.Get($"Task3_{inputLine[1]}"));
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("App name or version info is empty");
                        }
                        break;
                    case "exit":
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                    case "show":
                        var keys = RedisClient.GetKeys("Task3_");
                        if (keys.Length == 0)
                        {
                            Console.WriteLine("List of applications is empty");
                            continue;
                        }
                        
                        Console.WriteLine("List of applications:");
                        var index = 0;
                        foreach (var key in keys)
                        {
                            long count = RedisClient.GetAsLong(key);
                            Console.WriteLine($"{++index}. {key.Replace("Task3_","")} " +
                                              $"with {count} versions.");
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}