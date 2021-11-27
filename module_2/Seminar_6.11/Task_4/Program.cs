using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine("Input command (add/get/exist)\n" +
                              "Or type \"exit\" to exit");
            while ((command = Console.ReadLine()) != "exit")
            {
                if (command is null or "")
                {
                    Console.WriteLine("Input command (add/get/exist)\n" +
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
                            RedisClient.Add($"Task4_{inputLine[1]}", inputLine[2]);
                            Console.WriteLine($"{inputLine[2]} was added to {inputLine[1]}");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Input example: add <storage_name> <product_name>");
                        }

                        break;
                    case "exist":
                        try
                        {
                            if (RedisClient.Exist($"Task4_{inputLine[1]}", inputLine[2]))
                            {
                                Console.WriteLine($"Product \"{inputLine[2]}\" is in the storage {inputLine[1]}");
                                continue;
                            }

                            Console.WriteLine($"There's no \"{inputLine[2]}\" in the storage {inputLine[1]}");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Input example: exist <storage_name> <product_name>");
                        }

                        break;
                    case "get":
                        try
                        {
                            Console.WriteLine($"List of products in {inputLine[1]}:");
                            Console.Write(RedisClient.Get($"Task4_{inputLine[1]}"));
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Input example: get <storage_name> <product_name>");
                        }
                        
                        break;
                    case "exit":
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}