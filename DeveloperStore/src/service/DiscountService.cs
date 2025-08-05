using DeveloperStore.src.Domain;
using DeveloperStore.src.repositories;
using DeveloperStore.src.service.@interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DeveloperStore.src.service
{
    public class DiscountService : IDiscountService
    {
        decimal discount = 0;
        public decimal totalValue = 0;

        public Sale DiscountAboveFourProducts(List<Product> saleProduct)
        {
            bool identical = true;
            string beforeKind = saleProduct[0].Kind;

            for (int i = 1; i < saleProduct.Count; i++)
            {
                if (beforeKind != saleProduct[i].Kind)
                {
                    identical = false;
                    break;
                }
            }

            if (identical)
            {
                totalValue = SumValues(saleProduct);
                discount = ApplyDezPercDiscount(totalValue);
            }

            var saleTotalDisc = new Sale
            {
                FinalTotal = totalValue,
                Discount = discount
            };

            return saleTotalDisc;
        }


        public Sale DiscountBeteween_10_20_Products(List<Product> saleProduct)
        {
            string beforeKind = saleProduct[0].Kind;
            int countItems = 0;

            for (int i = 1; i < saleProduct.Count; i++)
            {
                if (beforeKind == saleProduct[i].Kind)
                {
                    countItems++;
                }
            }
            if (countItems >= 10 && countItems <= 20)
            {
                totalValue = SumValues(saleProduct);
                discount = Apply20PercDiscount(totalValue);
            }            
            
            var saleTotalDisc = new Sale
            {
                FinalTotal = totalValue,
                Discount = discount
            };

            return saleTotalDisc;           
        }


        public decimal SumValues(List<Product> saleProduct)
        {
            decimal totalValue = 0;

            foreach (var product in saleProduct)
            {
                totalValue += product.Price;
            }
            return totalValue;
        }

        public decimal ApplyDezPercDiscount(decimal totalValue)
        {
            decimal valueDiscount = 10;
            decimal totalValueDiscount = (totalValue * valueDiscount) / 100;
            return totalValue - totalValueDiscount;
        }

        public decimal Apply20PercDiscount(decimal totalValue)
        {
            decimal valueDiscount = 20;
            decimal totalValueDiscount = (totalValue * valueDiscount) / 100;
            return totalValue - totalValueDiscount;
        }
    }
}
