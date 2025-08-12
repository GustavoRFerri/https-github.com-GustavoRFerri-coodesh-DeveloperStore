using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DeveloperStore.src.Domain
{
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }      
        public string Kind { get; set; }        
        public decimal Price { get; set; }
        
        
    }
}
