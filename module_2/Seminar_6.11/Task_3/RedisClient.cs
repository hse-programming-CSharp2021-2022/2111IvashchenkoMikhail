using System;
using System.Linq;
using StackExchange.Redis;

namespace Task_3
{
    public class RedisClient
    {
        public const uint MaxCount = 5; 
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
            if (!Exist(key))
            {
                throw new ArgumentException("App with this name does not exist!");
            }
            
            return _database.ListGetByIndex(key, -1);
        }

        public static void Add(string key, string value)
        {
            if (value is null or "")
            {
                throw new ArgumentException("Invalid version data!");
            }
            
            if (_database.ListLength(key) >= MaxCount)
            {
                _database.ListLeftPop(key);
            }
            
            _database.ListRightPush(key, value);
        }

        private static bool Exist(string key)
        {
            return _database.KeyExists(key);
        }
        
        public static string Back(string key)
        {
            if (!Exist(key))
            {
                throw new ArgumentException("App with this name does not exist!");
            }
            
            if (_database.ListLength(key) < 2)
            {
                _database.KeyDelete(key);
                return $"Application \"{key.Replace("Task3_","")}\" was deleted";
            }
            
            _database.ListRightPop(key);
            return $"Application \"{key.Replace("Task3_","")}\" was set to the privious version";
        }
        
        public static long GetAsLong(string key)
        {
            return _database.ListLength(key);
        }
        
        /// <summary>
        /// Get keys in Redis server with special beginning.
        /// </summary>
        /// <param name="keyBeginning"> Special beginning. </param>
        public static string[] GetKeys(string keyBeginning = "")
        {
            return _server.Keys(pattern: $"{keyBeginning}*")
                .Select(x => x.ToString())
                .ToArray();
        }
    }
}