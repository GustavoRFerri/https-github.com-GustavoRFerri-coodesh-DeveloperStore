using DeveloperStore.src.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DeveloperStore.src.service
{
    public class SearchProductService
    {
        public List<Product> GetSale()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            // Acessar banco e coleção
            var database = client.GetDatabase("Sale");
            var colecao = database.GetCollection<Product>("Product");

            List<Product> Sle = colecao.Find(new BsonDocument()).ToList();
            //foreach (var prod in Sle)
            //{
            //    Console.WriteLine($"Produto: {prod.Kind} - R$ {prod.Price}");
            //}

            if (Sle is not null)
            {
                return Sle;
            }
            else
            {
                return new List<Product>();
            }            
        }
    }
}
