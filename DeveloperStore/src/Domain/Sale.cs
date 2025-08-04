namespace DeveloperStore.src.Domain
{
    public class Sale
    {
        public int SaleNumber { get; set; }
        public string Customer { get; set; }
        public int Quantities { get; set; }
        public double Discount { get; set; }
        public bool Cancelled { get; set; }
        public Product Product { get; set; }
    }
}
