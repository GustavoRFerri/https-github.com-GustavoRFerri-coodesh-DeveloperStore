using DeveloperStore.src.Domain;
using DeveloperStore.src.Domain.Dto;
using DeveloperStore.src.repositories;
using DeveloperStore.src.service.@interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DeveloperStore.src.service
{
    public enum PercentualDiscount
    {
        TenPercent = 10,
        TwentyPercent = 20
    }


    public class DiscountService : IDiscountService
    {
        private decimal discount = 0;
        private decimal totalValue = 0;


        public DiscountService()
        {

        }


        public decimal ApplyDiscount(int count, decimal eachPrice)
        {
            decimal valueEachDiscount = 0;

            valueEachDiscount = count switch
            {
                < 4 => 0,
                > 4 and < 10 => ApplyPercDiscount(eachPrice, (int)PercentualDiscount.TenPercent),
                >= 10 and <= 20 => ApplyPercDiscount(eachPrice, (int)PercentualDiscount.TwentyPercent)
            };

            return valueEachDiscount;
        }


        protected decimal ApplyPercDiscount(decimal totalValue, int Percent)
        {
            decimal totalValueDiscount = (totalValue * Percent) / 100;
            return totalValue - totalValueDiscount;
        }


        //public decimal ApplyDezPercDiscount(decimal totalValue)
        //{
        //    decimal valueDiscount = (decimal)PercentualDiscount.TenPercent;
        //    decimal totalValueDiscount = (totalValue * valueDiscount) / 100;
        //    return totalValue - totalValueDiscount;
        //}

        //public decimal ApplyTwentyPercDiscount(decimal totalValue)
        //{
        //    decimal valueDiscount = (decimal)PercentualDiscount.TwentyPercent;
        //    decimal totalValueDiscount = (totalValue * valueDiscount) / 100;
        //    return totalValue - totalValueDiscount;
        //}

        //public Sale DiscountBelowFourProducts(List<Product> saleProduct)
        //{
        //    totalValue = SumValues(saleProduct);

        //    var saleTotalDisc = new Sale
        //    {
        //         FinalTotal = totalValue,
        //         FinalDiscount = 0
        //    };          

        //    return saleTotalDisc;
        //}

        //public ProductDTO DiscountAboveFourProducts2(List<Product> saleProduct, string prd)
        //{
        //    var saleTotalDisc = new ProductDTO
        //    {
        //        //EachPrice = SumValues(saleProduct,prd),
        //        EachDiscount = ApplyDezPercDiscount(SumValues(saleProduct,prd))
        //    };

        //    return saleTotalDisc;
        //}

        //public ProductDTO DiscountBeteween_10_20_Products2(List<Product> saleProduct,string prd)
        //{
        //    ProductDTO sale = new ProductDTO
        //    {
        //        EachPrice = SumValues(saleProduct, prd),
        //        EachDiscount = ApplyTwentyPercDiscount(SumValues(saleProduct, prd))                
        //    };

        //    return sale;
        //}


        //public Sale DiscountAboveFourProducts(List<Product> saleProduct)
        //{
        //    bool identical = true;
        //    string beforeKind = saleProduct[0].Kind;

        //    for (int i = 1; i < saleProduct.Count; i++)
        //    {
        //        if (beforeKind != saleProduct[i].Kind)
        //        {
        //            identical = false;
        //            break;
        //        }
        //    }

        //    if (identical)
        //    {
        //        totalValue = SumValues(saleProduct);
        //        discount = ApplyDezPercDiscount(totalValue);
        //    }
        //    totalValue = SumValues(saleProduct);
        //    discount = ApplyDezPercDiscount(totalValue);

        //    var saleTotalDisc = new Sale
        //    {
        //        FinalTotal = totalValue,
        //        FinalDiscount = discount
        //    };

        //    return saleTotalDisc;
        //}


        //public Sale DiscountBeteween_10_20_Products(List<Product> saleProduct)
        //{
        //    string beforeKind = saleProduct[0].Kind;
        //    int countItems = 0;

        //    for (int i = 1; i < saleProduct.Count; i++)
        //    {
        //        if (beforeKind == saleProduct[i].Kind)
        //        {
        //            countItems++;
        //        }
        //    }
        //    if (countItems >= 10 && countItems <= 20)
        //    {
        //        totalValue = SumValues(saleProduct);
        //        discount = ApplyTwentyPercDiscount(totalValue);
        //    }

        //    Sale sale = new Sale
        //    {
        //         FinalDiscount = discount,
        //         FinalTotal = totalValue
        //    };

        //    return sale;           
        //}


        //public decimal SumValues(List<Product> saleProduct, string prd)
        //{
        //    decimal totalValue = 0;

        //    foreach (var product in saleProduct)
        //    {
        //        if (prd == product.Kind)
        //        {
        //            totalValue += product.Price;
        //        }
        //    }
        //    return totalValue;
        //}


    }
}
