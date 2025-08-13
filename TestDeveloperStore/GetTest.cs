using DeveloperStore.src.Application.service;
using DeveloperStore.src.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDeveloperStore
{
    public class GetTest
    {       
     

        [Fact]    
        public async Task GetData()
        {
            SearchProductService searchProductService = new SearchProductService();
            List<Sale> lProducts = await searchProductService.GetAllSale();

            //SaleProductController saleProductController = new SaleProductController();
            //List<Sale> lProducts = await saleProductController.GetSale();

            // Then
           // Assert.NotEmpty(lProducts);
        }
    }
}
