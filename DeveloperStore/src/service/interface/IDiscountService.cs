using DeveloperStore.src.Domain;

namespace DeveloperStore.src.service.@interface
{
    public interface IDiscountService
    {
        Sale DiscountAboveFourProducts(List<Product> saleProduct);
        Sale DiscountBeteween_10_20_Products(List<Product> saleProduct);
        decimal SumValues(List<Product> saleProduct);
        decimal ApplyDezPercDiscount(decimal totalValue);
        decimal Apply20PercDiscount(decimal totalValue);
    }
}
