using System;
using System.Linq;
using StackExchange.Redis;

namespace Task_4
{
    public class RedisClient
    {
        private static ConnectionMultiplexer _redis;
        private static IDatabase _database;
        private static IServer _server;

        public static void Connect()
        {
            _redis = ConnectionMultiplexer.Connect(
                $"redis-17578.c289.us-west-1-2.ec2.cloud.redislabs.com:17578," + 
                $"password=uXKBmCNT3EVCKyvXgxQb9lmaZAGo6Vkl,ConnectTimeout=10000,allowAdmin=true");
            _database = _redis.GetDatabase();
            _server = _redis.GetServer("redis-17578.c289.us-west-1-2.ec2.cloud.redislabs.com", 17578);
        }

        public static string Get(string key)
        {
            if (!_database.KeyExists(key))
            {
                throw new ArgumentException("Invalid storage name!");
            }

            return _database.SetMembers(key).Aggregate("", (current, value) => current + $"{value}\n");
        }

        public static void Add(string key, string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException("No product name!");
            }
            
            _database.SetAdd(key, productName);
        }

        public static bool Exist(string key, string productName)
        {
            if (!_database.KeyExists(key))
            {
                throw new ArgumentException("There is no storage with this name!");
            }
            return _database.SetContains(key, productName);
        }
    }
}