
using DeveloperStore.src.Application.service;
using DeveloperStore.src.Domain.entities;
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
        [InlineData(7, "Jhon")]
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
            //SaleProductController saleProductController = new SaleProductController();
            //decimal discountFourProducts = await saleProductController.SaleCreated(listProduct, name);

            // with Service
            DiscountService discountService = new DiscountService();
           // Sale discountFourProducts = discountService.DiscountAboveFourProducts2(listProduct);

            // then
            //Assert.Equal(63, discountFourProducts.Discount);
        }

        [Theory]
        [InlineData(7,"Anna")]
        public async Task Test_Create_Sale_Between_10_20_More_Product(int quantity, string name)
        {
            // Given
            for (int i = 0; i < quantity; i++)
            {
                var Sale = new Product
                {
                    Kind = "Computer",
                    Price = 50
                };
                listProduct.Add(Sale);
            }

            for (int i = 0; i < 6; i++)
            {
                var Sale = new Product
                {
                    Kind = "Shoes",
                    Price = 30
                };
                listProduct.Add(Sale);
            }

            for (int i = 0; i < 13; i++)
            {
                var Sale = new Product
                {
                    Kind = "Bag",
                    Price = 15
                };
                listProduct.Add(Sale);
            }


            for (int i = 0; i < 23; i++)
            {
                var Sale = new Product
                {
                    Kind = "Gloves",
                    Price = 25
                };
                listProduct.Add(Sale);
            }
            // when
            //SaleProductController saleProductController = new SaleProductController();
            //Sale discountFourProducts = await saleProductController.SaleCreated(listProduct, name);

            // with Service
            QuantityProductService quantityProductService = new QuantityProductService();
            Sale newSale = quantityProductService.CountProduct(listProduct, name);

            //DiscountService discountService = new DiscountService();
            //Sale discountFourProducts = discountService.DiscountBeteween_10_20_Products(listProduct);

            // then
            //Assert.Equal(120, discountFourProducts.Discount);
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
            //SaleProductController saleProductController = new SaleProductController();
            //decimal discountFourProducts = await saleProductController.SaleCreated(listProduct, name);

            // with Service
            DiscountService discountService = new DiscountService();
            //Sale discountFourProducts = discountService.DiscountBeteween_10_20_Products(listProduct);

            // then
            //Assert.Equal(0, discountFourProducts.Discount);
        }


    }
}