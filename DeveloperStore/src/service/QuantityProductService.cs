using DeveloperStore.src.Domain;
using DeveloperStore.src.service.@interface;

namespace DeveloperStore.src.service
{
    public class QuantityProductService : IQuantityProductService
    {
        public Sale CountProduct(List<Product> products)
        {
            DiscountService discountService = new DiscountService();

            int count = 0;
            Sale valuesSale = new Sale();

            List<string> kPrd = new List<string>();
            kPrd.Add(products[0].Kind.ToString());

            for (int j = 0; j < products.Count; j++)
            {
                for (int i = 0; i < kPrd.Count; i++)
                {
                    if (!kPrd.Contains(products[j].Kind))
                    {
                        kPrd.Add(products[j].Kind);
                    }
                }
            }
            foreach (var item in kPrd)
            {
                count = products.Count(p => p.Kind == item);
                valuesSale = count switch
                {
                    < 4 => discountService.DiscountBelowFourProducts(products),
                    > 4 and < 10 => discountService.DiscountAboveFourProducts(products),
                    >= 10 and <= 20 => discountService.DiscountBeteween_10_20_Products(products),
                };
            }
            return valuesSale;
        }

    }
}
