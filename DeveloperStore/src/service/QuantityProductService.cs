using DeveloperStore.src.Domain;
using DeveloperStore.src.service.@interface;

namespace DeveloperStore.src.service
{
    public class QuantityProductService : IQuantityProductService
    {
        private IDiscountService _discountService;

        public QuantityProductService(IDiscountService discountService) { 
            _discountService = discountService;
        }
        public Sale CountProduct(List<Product> products)
        {            
            // TO FINISH


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
                   // < 4 => _discountService.DiscountBelowFourProducts(products),
                   // > 4 and < 10 => _discountService.DiscountAboveFourProducts(products),
                   // >= 10 and <= 20 => _discountService.DiscountBeteween_10_20_Products(products),
                };
            }
            return valuesSale;
        }

    }
}
