using DeveloperStore.src.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

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
            }
            catch (Exception ex)
            {
                ;
            }
        }


        public async Task<Sale> UpDate(string id)
        {
            try
            {
                var prod = _colecao.Find(filter: sale => sale._id == id).FirstOrDefault();
                prod.Discount = 3300;
                _colecao.ReplaceOne(filter: sale => prod._id == sale._id, prod);

                Sale prodChanged = await _colecao.Find(filter: sale => sale._id == id).FirstOrDefaultAsync();

                return prodChanged;
            }
            catch (Exception ex)
            {
               
               

            }
            Sale sale = new Sale();
           return sale;
        }

        public async Task<Sale> SaleCancelled(string id)
        {
            try
            {
                var prod = _colecao.Find(filter: sale => sale._id == id).FirstOrDefault();
                prod.Cancelled = true;
                _colecao.ReplaceOne(filter: sale => prod._id == sale._id, prod);

                Sale sale = await _colecao.Find(filter: sale => sale._id == id).FirstOrDefaultAsync();

                return sale;
            }
            catch (Exception ex)
            {
                Sale sale = new Sale();
                return sale;
            }

         
        }

   
    }
}
