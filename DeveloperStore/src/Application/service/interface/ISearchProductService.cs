using DeveloperStore.src.Domain.entities;

namespace DeveloperStore.src.Application.service.@interface
{
    public interface ISearchProductService
    {
        Task<List<Sale>> GetAllSale();
    }
}
