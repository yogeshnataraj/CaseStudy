using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Application.Authentication;
using CaseStudy.Application.Interfaces;
using CaseStudy.Domain.Interfaces;
using CaseStudy.Domain.ProjectAggregate.Data;

namespace CaseStudy.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Guid> CreateProductAsync(ProductDTO product)
        {
            var productModel = new Product
            {
                ProductId = product.ProductId,
                ChennalId = product.ChannelId,
                SizeScaleId = product.SizeScaleId,
                Year = product.ProductYear,
                Articals = product.Articles.Select(t => new Artical
                {
                    ArticalId = t.ArticleId,
                    ColorId = t.ColourId
                }).ToList(),
            };

            await _productRepository.AddProduct(productModel);

            return productModel.ProductId;
        }

        public async Task<ProductResponse> GetProductAsync(Guid productId)
        {
            var productModel = await _productRepository.GetProducts(productId);

            var productDto = new ProductResponse
            {
                
            };

            return productDto;
        }        
    }   
}