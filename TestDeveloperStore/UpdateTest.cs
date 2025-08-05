using DeveloperStore.Controllers;
using DeveloperStore.src.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDeveloperStore
{
    public class UpdateTest
    {
        Sale sale = new Sale();
        List<Product> listProduct = new List<Product>();

        [Theory]
        [InlineData("68912a3fc3a9d6526c0bf901")]
        public async Task Test_Change_Sale(string id)
        {
            // Given           

            // when
            SaleProductController saleProductController = new SaleProductController();
            Sale sale = await saleProductController.SaleModified(id);

            //DiscountService discountService = new DiscountService();
            //decimal discountFourProducts = discountService.DiscountAboveFourProducts(listProduct);

            // then
            // Assert.NotEmpty(sale); ;
        }

        [Theory]
        [InlineData("68912f04c3a9d6526c0bf907")]
        [InlineData("68916a1cf0443c3df837c43e")]
        public async Task Test_Cancell_Sale(string id)
        {
            // Given

            // when
            SaleProductController saleProductController = new SaleProductController();
            Sale sale = await saleProductController.SaleCancelled(id);

            //DiscountService discountService = new DiscountService();
            //decimal discountFourProducts = discountService.DiscountAboveFourProducts(listProduct);

            // then
            // Assert.NotEmpty(sale); ;
        }
    }
}
