using ProductCatalog.Domain.Interfaces;
using ProductCatalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Infrastructure.Data
{
    public class ProductCatalogRepository : IProductCatalogRepository
    {
        ProductCatalogContext _productCatalogContext;

        public ProductCatalogRepository(ProductCatalogContext productCatalogContext)
        {
            _productCatalogContext = productCatalogContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productCatalogContext.Products.ToList();
        }

        public Product GetProduct(Guid id)
        {
            return _productCatalogContext.Products.FirstOrDefault(r => r.Id == id);
        }

        public void SaveProduct(Product product)
        {
            if (_productCatalogContext.Products.Any(r=>r.Id == product.Id))
            {
                _productCatalogContext.Update(product);
            }
            else
            {
                _productCatalogContext.Add(product);
            }

            _productCatalogContext.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var product = _productCatalogContext.Products.FirstOrDefault(r => r.Id == id);
            var productOptions = _productCatalogContext.ProductOptions.Where(r => r.ProductId == id);

            _productCatalogContext.ProductOptions.RemoveRange(productOptions);

            _productCatalogContext.Products.Remove(product);
            _productCatalogContext.SaveChanges();
        }

        public IEnumerable<ProductOption> GetProductOptions(Guid productId)
        {
            return _productCatalogContext.ProductOptions.Where(r => r.ProductId == productId);
        }

        public ProductOption GetProductOption(Guid productId, Guid id)
        {
            return _productCatalogContext.ProductOptions.FirstOrDefault(r => r.ProductId == productId && r.Id == id);
        }

        public void SaveProductOption(ProductOption productOption)
        {
            if (_productCatalogContext.Products.Any(r => r.Id == productOption.Id))
            {
                _productCatalogContext.Update(productOption);
            }
            else
            {
                _productCatalogContext.Add(productOption);
            }

            _productCatalogContext.SaveChanges();
        }

        public void DeleteProductOption(Guid id)
        {
            var productOption = _productCatalogContext.ProductOptions.FirstOrDefault(r => r.Id == id);

            _productCatalogContext.ProductOptions.Remove(productOption);
            _productCatalogContext.SaveChanges();
        }
    }
}