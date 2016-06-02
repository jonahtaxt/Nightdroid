using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Effisoft.Nightdroid.DataAccess.MongoDB
{
    internal class MongoDataAccess
    {
        private readonly IMongoDatabase _database;

        public string EntityName { get; set; }

        public MongoDataAccess(string connection, string databaseName)
        {
            var client = new MongoClient(connection);
            _database = client.GetDatabase(databaseName);
        }

        public async Task<List<T>> GetEntities<T>()
        {
            var collection = _database.GetCollection<T>(EntityName);
            var result = await collection.FindAsync(_ => true);
            return result.ToList();
        }

        public async Task<List<T>> GetEntities<T>(string filter)
        {
            FilterDefinition<T> filterDefinition = filter;
            var collection = _database.GetCollection<T>(EntityName);
            var result = await collection.FindAsync(filterDefinition);
            return result.ToList();
        }

        public async Task<T> GetEntity<T>(string filter)
        {
            FilterDefinition<T> filterDefinition = filter;
            var collection = _database.GetCollection<T>(EntityName);
            var result = await collection.FindAsync(filterDefinition);
            return result.FirstOrDefault();
        }
    }
}