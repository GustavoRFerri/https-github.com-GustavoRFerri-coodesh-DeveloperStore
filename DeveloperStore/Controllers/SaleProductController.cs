using DeveloperStore.src.Domain;
using DeveloperStore.src.repositories;
using DeveloperStore.src.service;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

namespace DeveloperStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleProductController : ControllerBase
    {      

        private readonly ILogger<SaleProductController> _logger;

        [HttpGet(Name = "GetSale")]
        public List<Sale> GetSale()
        {
            SearchProductService searchProductService = new SearchProductService();

            var result = searchProductService.GetSale();
            return result;
        }

        [HttpPost]
        public decimal SaleCreated(List<Product> products, string customer)
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

        [HttpPut]
        public Sale SaleModified(string id)
        {
            DataBaseSale dataBaseSale = new DataBaseSale();
            return dataBaseSale.UpDate(id);

            //return valuesSale.Discount;
        }


        [HttpPut]
        public Sale SaleCancelled(string id)
        {
            DataBaseSale dataBaseSale = new DataBaseSale();
            return dataBaseSale.SaleCancelled(id);

            //return valuesSale.Discount;
        }




    }
}
