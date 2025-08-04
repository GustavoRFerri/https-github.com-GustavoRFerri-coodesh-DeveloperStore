using DeveloperStore.src.Domain;

namespace DeveloperStore.src.service
{
    public class DiscountService
    {

        decimal discount = 0;


        public decimal DiscountAboveFourProducts(List<Product> saleProduct)
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
                decimal totalValue = SumValues(saleProduct);
                discount = ApplyDezPercDiscount(totalValue);
            }

            return discount;
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

    }
}
