using DeveloperStore.src.Domain;
using DeveloperStore.src.repositories;
using DeveloperStore.src.service.@interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Threading.Tasks;

namespace DeveloperStore.src.service
{
    public class SearchProductService : ISearchProductService
    {

       DataBaseSale dataSale = new DataBaseSale();    



        public async Task<List<Sale>> GetAllSale()
        {
          
            List<Sale> sales = await dataSale.GetSale();
            return sales;
        }

        
    }
}
