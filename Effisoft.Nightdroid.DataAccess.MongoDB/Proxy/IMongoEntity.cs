using MongoDB.Bson;

namespace Effisoft.Nightdroid.DataAccess.MongoDB.Proxy
{
    internal interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}