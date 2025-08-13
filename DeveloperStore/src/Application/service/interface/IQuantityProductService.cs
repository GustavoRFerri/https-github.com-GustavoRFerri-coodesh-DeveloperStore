using DeveloperStore.src.Domain.entities;

namespace DeveloperStore.src.Application.service.@interface
{
    public interface IQuantityProductService
    {
        Sale CountProduct(List<Product> products, string name);
    }
}
