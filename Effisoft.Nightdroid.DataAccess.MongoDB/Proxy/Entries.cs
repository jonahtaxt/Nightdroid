using MongoDB.Bson.Serialization.Attributes;

namespace Effisoft.Nightdroid.DataAccess.MongoDB.Proxy
{
    internal class Entries : MongoEntity
    {
        [BsonElement("sgv")]
        public int Sgv { get; set; }

        [BsonElement("date")]
        public double Date { get; set; }

        [BsonElement("dateString")]
        public string DateString { get; set; }

        [BsonElement("trend")]
        public int Trend { get; set; }

        [BsonElement("direction")]
        public string Direction { get; set; }

        [BsonElement("device")]
        public string Device { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }
    }
}