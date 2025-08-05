using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DeveloperStore.src.Domain
{
    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public DateTime DateTime { get; set; }
        //public Guid SaleNumber { get; set; }
        public string Customer { get; set; }
        public int Quantities { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalTotal { get; set; }
        public bool Cancelled { get; set; }
        public List<Product> Product { get; set; }
    }
}
