using StackExchange.Redis;

namespace Task_1
{
    public class RedisClient
    {
        private static ConnectionMultiplexer _redis;
        private static IDatabase _database;

        public static void Connect(
            string connectionString = "redis-17578.c289.us-west-1-2.ec2.cloud.redislabs.com")
        {
            _redis = ConnectionMultiplexer.Connect(
                "redis-17578.c289.us-west-1-2.ec2.cloud.redislabs.com:17578," +
                "password=uXKBmCNT3EVCKyvXgxQb9lmaZAGo6Vkl,ConnectTimeout=10000,allowAdmin=true");
            _database = _redis.GetDatabase();
            var server = _redis.GetServer(connectionString, 17578);
        }
        
        public static string GetSet(string key, string value)
        {
            return _database.StringGetSet(key,value);
        }

        public static bool Exist(string key)
        {
            return _database.KeyExists(key);
        }

        public static void Set(string key, string value)
        {
            _database.StringSet(key, value);
        }
        
        public static string Get(string key)
        {
            return _database.StringGet(key);
        }
    }
}