using DeveloperStore.src.Domain.entities;
using DeveloperStore.src.infrastructure.repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Threading.Tasks;

namespace DeveloperStore.src.Application.service
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
