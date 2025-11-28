using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using DBConnector; // <-- uses your interface

namespace DbPinger.ConsoleApp.Adapters
{
    public class MongoPinger : IDbPinger
    {
        public async Task<(bool Success, string Message)> PingAsync(string connectionString)
        {
            try
            {
                var client = new MongoClient(connectionString);
                var db = client.GetDatabase("admin");

                var result = await db.RunCommandAsync<BsonDocument>(new BsonDocument { { "ping", 1 } });

                return (true, "Ping successful: " + result.ToJson());
            }
            catch (Exception ex)
            {
                return (false, $"Ping failed: {ex.Message}");
            }
        }
    }
}
