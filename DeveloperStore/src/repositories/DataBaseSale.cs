using DeveloperStore.src.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DeveloperStore.src.repositories
{
    public class DataBaseSale
    {
        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly IMongoCollection<Product> _colecao;

        public DataBaseSale()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Sale");
            _colecao = database.GetCollection<Product>("Product");
        }

        public async Task<List<Product>> GetSale()
        {
            List<Product> Sle = await _colecao.Find(new BsonDocument()).ToListAsync();            

            if (Sle is not null)
            {
                return Sle;
            }
            else
            {
                return new List<Product>();
            }
        }


        public void Input(List<Product> produto)
        {
            try
            {
                _colecao.InsertMany(produto);
            }
            catch (Exception ex)
            {
                ;

            }

          ;
        }

        public async Task Input2(List<Product> produto)
        {
            try
            {
                await _colecao.InsertManyAsync(produto);
            }
            catch (Exception ex)
            {
                ;
                
            }
            
            ;
        }
    }
}
