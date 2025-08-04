using DeveloperStore.src.Domain;
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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "BracingABVCBV", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SaleProductController> _logger;      

        [HttpGet(Name = "GetSale")]
        public List<Product> GetSale()
        {
            SearchProductService searchProductService = new SearchProductService();

            var result = searchProductService.GetSale();
            return result;
        }            

        [HttpPut]
        public decimal CreateSale(List<Product> products, Sale dataSale)
        {
            DiscountService sale = new DiscountService();

            decimal valueDiscount = products.Count switch
            {
                <= 4 => 0,
                > 4 and < 10 => sale.DiscountAboveFourProducts(products),
                >= 10 and <= 20 => sale.DiscountBeteween_10_20_Products(products),                
            };




           return valueDiscount;

        }

    }
}
