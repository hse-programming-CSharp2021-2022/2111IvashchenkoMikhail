using System.Linq;
using StackExchange.Redis;

namespace TaskInt
{
    public static class RedisClient
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

        public static void AddOne(string key)
        {
            if (Exist(key))
            {
                _database.StringIncrement(key);
            }
            else
            {
                _database.StringSet(key, 1);
            }
        }

        public static void RemoveOne(string key)
        {
            if (_database.StringDecrement(key) <= 0)
            {
                _database.KeyDelete(key);
            }
        }

        public static bool Exist(string key)
        {
            return _database.KeyExists(key);
        }

        public static long GetAsLong(string key)
        {
            return (long) _database.StringGet(key);
        }

        /// <summary>
        /// Get keys in Redis server with special beginning.
        /// </summary>
        /// <param name="keyBeginning"> Special beginning. </param>
        public static string[] GetKeys(string keyBeginning)
        {
            return _server.Keys(pattern: $"{keyBeginning}*")
                .Select(x => x.ToString())
                .ToArray();
        }
    }
}