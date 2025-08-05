using DeveloperStore.Controllers;
using DeveloperStore.src.Domain;
using DeveloperStore.src.service;
using System.Globalization;
using System.Net.Http.Headers;

namespace TestDeveloperStore
{
    public class UnitTest1
    {
        Sale sale = new Sale();
        List<Product> listProduct = new List<Product>();

        [Theory]
        [InlineData(5)]
        public void Test_Create_Sale_Above_Four_Product(int quantity)
        {
            // Given
            for (int i = 0; i < quantity; i++)
            {
                var Sale = new Product
                {
                    Kind = "XCV",
                    Price = 10
                };
                listProduct.Add(Sale);
            }
            
            var dataSale = new Sale
            {
                 Customer = "joao",
                 Quantities = quantity,
            };



            // when
            SaleProductController saleProductController = new SaleProductController();
            decimal discountFourProducts = saleProductController.SaleCreated(listProduct, "joao");

            //DiscountService discountService = new DiscountService();
            //decimal discountFourProducts = discountService.DiscountAboveFourProducts(listProduct);

            // then
            Assert.Equal(81, discountFourProducts);
        }

        [Theory]
        [InlineData(15)]
        public void Test_Create_Sale_Between_10_20_More_Product(int quantity)
        {
            // Given
            for (int i = 0; i < quantity; i++)
            {
                var Sale = new Product
                {
                    Kind = "XCV",
                    Price = 10
                };
                listProduct.Add(Sale);
            }

            // when
            SaleProductController saleProductController = new SaleProductController();
            decimal discountFourProducts = saleProductController.SaleCreated(listProduct,"Joao");

            //DiscountService discountService = new DiscountService();
            //decimal discountFourProducts = discountService.DiscountBeteween_10_20_Products(listProduct);

            // then
            Assert.Equal(120, discountFourProducts);
        }


        [Theory]
        [InlineData(3)]
        public void Test_Create_Sale_below_four(int quantity)
        {
            // Given
            for (int i = 0; i < quantity; i++)
            {
                var sale = new Product
                {
                    Kind = "XCV",
                    Price = 10
                };
                listProduct.Add(sale);
            }

            // when
            SaleProductController saleProductController = new SaleProductController();
            decimal discountFourProducts = saleProductController.SaleCreated(listProduct, "Joao");
         
            // then
            Assert.Equal(0, discountFourProducts);
        }


    }
}