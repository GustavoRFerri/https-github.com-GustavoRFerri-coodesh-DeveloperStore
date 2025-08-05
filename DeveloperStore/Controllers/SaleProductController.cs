using DeveloperStore.src.Domain;
using DeveloperStore.src.repositories;
using DeveloperStore.src.service;
using DeveloperStore.src.service.@interface;
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
        private  IDiscountService _discountService;
        private  ISearchProductService _searchProductService;
        private  IDataBaseSale _dataBaseSale; 

        // TO DO TESTS

        //public SaleProductController()
        //{
            
        //}

        public SaleProductController(IDiscountService discountService, ISearchProductService searchProductService, IDataBaseSale dataBaseSale)
        {
            _discountService = discountService;
            _searchProductService = searchProductService;
            _dataBaseSale = dataBaseSale;
            
        }

        [HttpGet(Name = "GetSale")]
        public async Task<List<Sale>> GetSale()
        {
            var result = await _searchProductService.GetAllSale();
            return result;
        }

        [HttpPost(Name = "CreateSale")]
        public async Task<decimal> SaleCreated(List<Product> products, string customer)
        {
            ///  TO DO
            ///  Get the quantity all products automatically
            ///  QuantityProductService();
            ///  

            Sale valuesSale;          

            if (products.Count < 4)
            {
                valuesSale = new Sale
                {
                    Discount = 0,
                    FinalTotal = _discountService.SumValues(products)
                };
            }
            else
            {
                valuesSale = products.Count switch
                {
                    > 4 and < 10 => _discountService.DiscountAboveFourProducts(products),
                    >= 10 and <= 20 => _discountService.DiscountBeteween_10_20_Products(products),
                };
            }
            Guid guid = new Guid();
            valuesSale.Customer = customer;
            valuesSale.Quantities = products.Count;
            valuesSale.Product = products;
            valuesSale.DateTime = DateTime.Now;
           

            _dataBaseSale.Input(valuesSale);
            return valuesSale.Discount;
        }

        [HttpPut("SaleModifiedDiscount/{id}")]
        public async Task<Sale> SaleModified(string id, decimal disc)
        {
            return await _dataBaseSale.UpDate(id, disc);
        }


        [HttpPut("SaleCancell/{id}")]
        public async Task<Sale> SaleCancelled(string id)
        {
            // Cancell the product and the values
            return await _dataBaseSale.SaleCancelled(id);
        }

        //[HttpDelete("Delete/{id}")]
        //public void Del(string id)
        //{
        //    //_dataBaseSale.Delete(id);
        //}

    }
}
