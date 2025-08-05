using DeveloperStore.Controllers;
using DeveloperStore.src.Domain;
using DeveloperStore.src.service;
using System.Globalization;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestDeveloperStore
{
    public class CreateTest
    {
        Sale sale = new Sale();
        List<Product> listProduct = new List<Product>();

        [Theory]
        [InlineData(5, "Jhon")]
        public async Task Test_Create_Sale_Above_Four_Product(int quantity, string name)
        {
            // Given
            for (int i = 0; i < quantity; i++)
            {
                var Sale = new Product
                {
                    Kind = "Shoes",
                    Price = 10
                };
                listProduct.Add(Sale);
            }            
          
            // when
            SaleProductController saleProductController = new SaleProductController();
            decimal discountFourProducts = await saleProductController.SaleCreated(listProduct, name);

            //DiscountService discountService = new DiscountService();
            //decimal discountFourProducts = discountService.DiscountAboveFourProducts(listProduct);

            // then
            Assert.Equal(45, discountFourProducts);
        }

        [Theory]
        [InlineData(15,"Anna")]
        public async Task Test_Create_Sale_Between_10_20_More_Product(int quantity, string name)
        {
            // Given
            for (int i = 0; i < quantity; i++)
            {
                var Sale = new Product
                {
                    Kind = "Computer",
                    Price = 10
                };
                listProduct.Add(Sale);
            }

            // when
            SaleProductController saleProductController = new SaleProductController();
            decimal discountFourProducts = await saleProductController.SaleCreated(listProduct, name);

            //DiscountService discountService = new DiscountService();
            //decimal discountFourProducts = discountService.DiscountBeteween_10_20_Products(listProduct);

            // then
            Assert.Equal(120, discountFourProducts);
        }


        [Theory]
        [InlineData(3,"Erick")]
        public async Task Test_Create_Sale_below_four(int quantity, string name)
        {
            // Given
            for (int i = 0; i < quantity; i++)
            {
                var sale = new Product
                {
                    Kind = "Bag",
                    Price = 10
                };
                listProduct.Add(sale);
            }

            // when
            SaleProductController saleProductController = new SaleProductController();
            decimal discountFourProducts = await saleProductController.SaleCreated(listProduct, name);
         
            // then
            Assert.Equal(0, discountFourProducts);
        }


    }
}