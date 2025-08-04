using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DeveloperStore.src.Domain
{
    public class Product
    {
        //public string ObjectId { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        //public int Id { get; set; }
        public string Kind { get; set; }
        //public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
