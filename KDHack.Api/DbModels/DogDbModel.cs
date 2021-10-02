using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KDHack.Api.DbModels
{
    public class DogDbModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("height")]
        public int Height { get; set; }

        [BsonElement("weight")]
        public int Weight { get; set; }

        [BsonElement("trainability")]
        public int Trainability { get; set; }
    }
}
