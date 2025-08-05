using DeveloperStore.src.Domain;

namespace DeveloperStore.src.service.@interface
{
    interface IQuantityProductService
    {
        public Sale CountProduct(List<Product> products);
    }
}
