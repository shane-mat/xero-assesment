using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Domain.Interfaces;
using ProductCatalog.Domain.Models;

namespace RefactorThis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductCatalogRepository _productCatalogRepository;

        public ProductController(IProductCatalogRepository productCatalogRepository)
        {
            _productCatalogRepository = productCatalogRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productCatalogRepository.GetProducts();
        }

        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return _productCatalogRepository.GetProduct(id);
        }

        [HttpPost]
        public void Post(Product product)
        {
            _productCatalogRepository.SaveProduct(product);
        }

        [HttpPut("{id}")]
        public void Update(Guid id, Product product)
        {
            _productCatalogRepository.SaveProduct(product);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _productCatalogRepository.DeleteProduct(id);
        }

        [HttpGet("{productId}/options")]
        public IEnumerable<ProductOption> GetOptions(Guid productId)
        {
            return _productCatalogRepository.GetProductOptions(productId);
        }

        [HttpGet("{productId}/options/{id}")]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            return _productCatalogRepository.GetProductOption(productId, id);
        }

        [HttpPost("{productId}/options")]
        public void CreateOption(Guid productId, ProductOption option)
        {
            _productCatalogRepository.SaveProductOption(option);
        }

        [HttpPut("{productId}/options/{id}")]
        public void UpdateOption(Guid id, ProductOption option)
        {
            _productCatalogRepository.SaveProductOption(option);
        }

        [HttpDelete("{productId}/options/{id}")]
        public void DeleteOption(Guid id)
        {
            _productCatalogRepository.DeleteProductOption(id);
        }
    }
}