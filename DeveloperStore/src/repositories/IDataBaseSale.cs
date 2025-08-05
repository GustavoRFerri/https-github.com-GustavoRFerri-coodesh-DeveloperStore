using DeveloperStore.src.Domain;

namespace DeveloperStore.src.repositories
{
    public interface IDataBaseSale
    {
        Task<List<Sale>> GetSale();
        void Input(Sale sale);
        Task<Sale> UpDate(string id, decimal disc);
        Task<Sale> SaleCancelled(string id);
        Task<Sale> Delete(string id);
    }
}
