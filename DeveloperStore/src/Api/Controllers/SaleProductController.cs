using DeveloperStore.src.Domain.entities;
using DeveloperStore.src.infrastructure.repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using System.Threading.Tasks; 

namespace DeveloperStore.src.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleProductController : ControllerBase
    {
        private readonly ILogger<SaleProductController> _logger;
       
        private  ISearchProductService _searchProductService;
        private  IDataBaseSale _dataBaseSale; 
        private IQuantityProductService _quantityProductService;

        // TO DO TESTS

        //public SaleProductController()
        //{

        //}

        public SaleProductController(ILogger<SaleProductController> logger, IQuantityProductService quantityProductService, ISearchProductService searchProductService, IDataBaseSale dataBaseSale)
        {
            _logger = logger;
            _quantityProductService = quantityProductService;
            _searchProductService = searchProductService;
            _dataBaseSale = dataBaseSale;
        }

        [HttpGet(Name = "GetSale")]
        public async Task<IActionResult> GetSale()
        {
            var result = await _searchProductService.GetAllSale();
            return Ok(result);
        }

        [HttpPost(Name = "CreateSale")]
        public async Task<IActionResult> SaleCreated(List<Product> products, string customer)
        {
            ///  TO DO
            ///  Get the quantity all products automatically
            ///  QuantityProductService();
            ///  

            _logger.LogInformation("INICIANDO Creating of Sale ");

            Sale valuesSale =  _quantityProductService.CountProduct(products,customer);
            DataBaseSale _dataBaseSale = new DataBaseSale();

            _dataBaseSale.Input(valuesSale);
            return CreatedAtAction(nameof(GetSale), new { id = valuesSale._id }, valuesSale);      
        }

        [HttpPut("SaleModifiedDiscount/{id}")]
        public async Task<IActionResult> SaleModified(string id, decimal disc)
        {
            return Ok(await _dataBaseSale.UpDate(id, disc));
        }


        [HttpPut("SaleCancell/{id}")]
        public async Task<IActionResult> SaleCancelled(string id)
        {
            // Cancell the product and the values
            return Ok(await _dataBaseSale.SaleCancelled(id));
        }

        //[HttpDelete("Delete/{id}")]
        //public void Del(string id)
        //{
        //    //_dataBaseSale.Delete(id);
        //}

    }
}
