using DeveloperStore.src.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DeveloperStore.src.repositories
{
    public class DataBaseSale
    {
        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly IMongoCollection<Sale> _colecao;
        //private readonly IMongoCollection<Sale> _sale;

        public DataBaseSale()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Sale");
            _colecao = database.GetCollection<Sale>("Product");
        }

        public async Task<List<Sale>> GetSale()
        {
            List<Sale> Sle = await _colecao.Find(new BsonDocument()).ToListAsync();            

            if (Sle is not null)
            {
                return Sle;
            }
            else
            {
                return new List<Sale>();
            }
        }


        public void Input(Sale sale)
        {
            try
            {
                _colecao.InsertOne(sale);
                //_colecao.UpdateOne
            }
            catch (Exception ex)
            {
                ;

            }

        }


        public Sale UpDate(string id)
        {
            try
            {
                var prod = _colecao.Find(filter:sale => sale._id == id).FirstOrDefault();
                prod.Discount = 3300;
                _colecao.ReplaceOne(filter:sale => prod._id == sale._id,prod );

                Sale sale =  _colecao.Find(filter: sale => sale._id == id).FirstOrDefault();

                return sale;
            }
            catch (Exception ex)
            {
                Sale sale = new Sale();
                return sale;

            }
        }

        public Sale SaleCancelled(string id)
        {
            try
            {
                var prod = _colecao.Find(filter: sale => sale._id == id).FirstOrDefault();
                prod.Cancelled = true;
                _colecao.ReplaceOne(filter: sale => prod._id == sale._id, prod);

                Sale sale = _colecao.Find(filter: sale => sale._id == id).FirstOrDefault();

                return sale;
            }
            catch (Exception ex)
            {
                Sale sale = new Sale();
                return sale;

            }

        }

        public async Task Input2(List<Product> produto)
        {
            try
            {
                //await _colecao.InsertManyAsync(produto);
            }
            catch (Exception ex)
            {
                ;                
            }
            
            
        }
    }
}
