namespace DeveloperStore.src.Application.service
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
            decimal totalValueDiscount = totalValue * Percent / 100;
            return totalValue - totalValueDiscount;
        }

    }
}
