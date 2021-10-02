using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KDHack.Api.DbModels
{
    public class DogDbModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public string Name { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int Trainability { get; set; }
    }
}
