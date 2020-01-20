using System;
using System.Collections.Generic;
using ProductCatalog.Domain.Models;

namespace ProductCatalog.Domain.Interfaces
{
    public interface IProductCatalogRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(Guid id);
        void SaveProduct(Product product);
        void DeleteProduct(Guid id);

        IEnumerable<ProductOption> GetProductOptions(Guid productId);
        ProductOption GetProductOption(Guid productId, Guid id);
        void SaveProductOption(ProductOption productOption);
        void DeleteProductOption(Guid id);
    }
}