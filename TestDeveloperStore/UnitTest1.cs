using DeveloperStore.src.Domain;
using DeveloperStore.src.service;
using System.Net.Http.Headers;

namespace TestDeveloperStore
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Create_Sale_Four_Product()
        {

            List<Product> listProduct = new List<Product>();
            // Given
            var Sale = new Product
            {
                Kind = "XCV",
                Price = 10
            };


            var Sale2 = new Product
            {
                Kind = "XCV",
                Price = 10
            };

            listProduct.Add(Sale);
            listProduct.Add(Sale2);


            // when
            DiscountService discountService = new DiscountService();
            decimal discountFourProducts = discountService.DiscountAboveFourProducts(listProduct);

            // then


            //decimal discount = 
            

        }
    }
}