using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Effisoft.Nightdroid.DataAccess.MongoDB.Proxy
{
    internal class MongoEntity : IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}