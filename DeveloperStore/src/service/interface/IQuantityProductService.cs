using DeveloperStore.src.Domain;
using DeveloperStore.src.Domain.Dto;

namespace DeveloperStore.src.service.@interface
{
    public interface IQuantityProductService
    {
        Sale CountProduct(List<Product> products, string name);
    }
}
