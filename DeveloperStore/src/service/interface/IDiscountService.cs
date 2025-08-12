using DeveloperStore.src.Domain;
using DeveloperStore.src.Domain.Dto;

namespace DeveloperStore.src.service.@interface
{
    public interface IDiscountService
    {
        // public decimal ApplyDezPercDiscount(decimal totalValue);
        //public decimal ApplyTwentyPercDiscount(decimal totalValue);
        decimal ApplyDiscount(int count, decimal eachPrice);        
        //ProductDTO DiscountAboveFourProducts2(List<Product> saleProduct, string prd);
        //ProductDTO DiscountBeteween_10_20_Products2(List<Product> saleProduct, string prd);
        //Sale DiscountAboveFourProducts(List<Product> saleProduct);
        //Sale DiscountBeteween_10_20_Products(List<Product> saleProduct);
        //decimal SumValues(List<Product> saleProduct, string prd);       
    }
}
