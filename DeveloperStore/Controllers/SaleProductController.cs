using DeveloperStore.src.Domain;
using DeveloperStore.src.repositories;
using DeveloperStore.src.service;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DeveloperStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleProductController : ControllerBase
    {

        //private readonly ILogger<SaleProductController> _logger;

        public SaleProductController() {         
        
        }

        [HttpGet(Name = "GetSale")]
        public async Task<List<Sale>> GetSale()
        {
            SearchProductService searchProductService = new SearchProductService();
            var result = await searchProductService.GetAllSale();
            return result;
        }      

        [HttpPost(Name = "CreateSale")]
        public async Task<decimal> SaleCreated(List<Product> products, string customer)
        {
            Sale valuesSale;
            DiscountService saleService = new DiscountService();           

            if (products.Count < 4)
            {
                valuesSale = new Sale()
                {
                    Discount = 0,
                    FinalTotal = saleService.SumValues(products)
                };
            }
            else
            {                
                valuesSale = products.Count switch
                {
                    > 4 and < 10 => saleService.DiscountAboveFourProducts(products),
                    >= 10 and <= 20 => saleService.DiscountBeteween_10_20_Products(products),
                };              
            }

            var sale = new Sale
            {
                Customer = customer,
                FinalTotal = valuesSale.FinalTotal,
                Discount = valuesSale.Discount,
                Quantities = products.Count,
                //SaleNumber = Guid.NewGuid(),
                Product = products,
            };

            DataBaseSale dataBaseSale = new DataBaseSale();
            dataBaseSale.Input(sale);
            return valuesSale.Discount;
        }

        [HttpPut("SaleModified/{id}")]
        public async Task<Sale> SaleModified(string id)
        {
            DataBaseSale dataBaseSale = new DataBaseSale();
            return await dataBaseSale.UpDate(id);            
        }


        [HttpPut("SaleCancell/{id}")]
        public async Task<Sale> SaleCancelled(string id)
        {
            DataBaseSale dataBaseSale = new DataBaseSale();
            return await dataBaseSale.SaleCancelled(id);           
        }

    }
}
