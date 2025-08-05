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
        private readonly IDiscountService _discountService;
        private readonly ISearchProductService _searchProductService;
        private readonly IDataBaseSale _dataBaseSale;

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
            Sale valuesSale;

            if (products.Count < 4)
            {
                valuesSale = new Sale()
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

            var sale = new Sale
            {
                Customer = customer,
                FinalTotal = valuesSale.FinalTotal,
                Discount = valuesSale.Discount,
                Quantities = products.Count,
                //SaleNumber = Guid.NewGuid(),
                Product = products,
            };

            _dataBaseSale.Input(sale);
            return valuesSale.Discount;
        }

        [HttpPut("SaleModified/{id}")]
        public async Task<Sale> SaleModified(string id, decimal disc)
        {
            return await _dataBaseSale.UpDate(id, disc);
        }


        [HttpPut("SaleCancell/{id}")]
        public async Task<Sale> SaleCancelled(string id)
        {
            return await _dataBaseSale.SaleCancelled(id);
        }

    }
}
