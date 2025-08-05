using DeveloperStore.src.Domain;

namespace DeveloperStore.src.service.@interface
{
    public interface ISearchProductService
    {
        Task<List<Sale>> GetAllSale();
    }
}
