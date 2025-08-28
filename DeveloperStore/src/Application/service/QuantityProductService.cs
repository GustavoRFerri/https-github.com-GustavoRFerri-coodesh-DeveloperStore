using DeveloperStore.src.Application.Dto;
using DeveloperStore.src.Application.service.@interface;
using DeveloperStore.src.Domain.entities;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeveloperStore.src.Application.service
{
    public class QuantityProductService : IQuantityProductService
    {
        private IDiscountService _discountService;
        private readonly ILogger<QuantityProductService> _logger;


        public Sale CountProduct(List<Product> products, string name)
        {
            List<string> kindProd = new List<string>();
            kindProd.Add(products[0].Kind.ToString());

            for (int j = 0; j < products.Count; j++)
            {
                for (int i = 0; i < kindProd.Count; i++)
                {
                    if (!kindProd.Contains(products[j].Kind))
                    {
                        kindProd.Add(products[j].Kind);
                    }
                }
            }

            // To Calculate Discount
            List<ProductDTO> nLIst = ToCalculateDiscount(kindProd, products);

            // Create the new Sale
            Sale saleNew = new Sale();
            saleNew.Id = Guid.NewGuid();
            saleNew.ProductDTO = nLIst;
            saleNew.Customer = name;
            saleNew.DateTime = DateTime.Now;

            foreach (ProductDTO item in nLIst)
            {
                saleNew.FinalDiscount = saleNew.FinalDiscount + item.EachDiscount;
                saleNew.FinalTotal = saleNew.FinalTotal + item.EachPrice;
                saleNew.FinalQuantities = saleNew.FinalQuantities + item.EachQuantity;
            }

            string caminhoArquivo = "E:\\GUSTAVO\\Repository-Git\\DeveloperStore\\produto.json";
            string json = JsonSerializer.Serialize(saleNew, new JsonSerializerOptions { WriteIndented = true });

            var tete = JsonSerializer.Deserialize<Sale>(json);
            File.WriteAllText(caminhoArquivo, json);

            return saleNew;
        }

        public List<ProductDTO> ToCalculateDiscount(List<string> kPrd, List<Product> products)
        {
            try
            {
                int count = 0;
                decimal eachPrice = 0;
                List<ProductDTO> lPrdDto = new List<ProductDTO>();
                DiscountService _discountService = new DiscountService();

                foreach (var item in kPrd)
                {
                    count = products.Count(p => p.Kind == item);
                    if (count > 20)
                    {
                        eachPrice = products.Where(p => p.Kind.Contains(item)).Take(20).Sum(a => a.Price);
                        count = 20;
                    }
                    else
                    {
                        eachPrice = products.Where(p => p.Kind == item).Sum(p => p.Price);
                    }

                    decimal valueEachDiscount = _discountService.ApplyDiscount(count, eachPrice);

                    var productDTO = new ProductDTO
                    {
                        EachQuantity = count,
                        EachDiscount = valueEachDiscount,
                        Kind = item,
                        EachPrice = eachPrice
                    };
                    lPrdDto.Add(productDTO);
                }
                return lPrdDto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }    

    }
}
