using System.Diagnostics;
using System.Drawing;
using System.Runtime.Serialization;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Application.Authentication;
using CaseStudy.Application.Interfaces;
using CaseStudy.Domain.Interfaces;
using CaseStudy.Domain.ProjectAggregate.Data;
using CaseStudy.Domain.Infra;
using System.Text.Json;

namespace CaseStudy.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IRestClient _client;

        public ProductServices(IProductRepository productRepository, IRestClient client)
        {
            _productRepository = productRepository;
            _client = client;
        }
        public async Task<Guid> CreateProductAsync(ProductDTO product)
        {
            var productModel = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
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

            if (productModel is null)
                throw new Exception("the particular product not found");

            var productDto = new ProductResponse
            {
                ProductId = productModel.ProductId,
                ProductName = productModel.ProductName,
                ProductCode = productModel.ProductCode,
                SizeScaleId = productModel.SizeScaleId,
                CreateDate = productModel.CreateDate,
                CreatedBy = Guid.NewGuid().ToString(),
                ChannelId = productModel.ChennalId,
            };

            //Get Articles and Colors 
            var articles = await _client.GetColors();

            //Add Articles and color obj
            productDto.Articles = productModel.Articals.Select(t => new Article
            {
                ArticleId = t.ArticalId,
                ColourId = t.ColorId,
                ArticleName = $"{productModel.ProductName.ToString()} - {articles.Find(a => a.ColorId == t.ColorId).colourCode}",
                ColourCode = articles.Find(a => a.ColorId == t.ColorId).colourCode,
                ColourName = articles.Find(a => a.ColorId == t.ColorId).colorName
            }).ToList();

            //Get Size 
            var sizes = await _client.GetSizes();

            productDto.Sizes = sizes.Where(t => t.SizeId == productModel.SizeScaleId).Select(s => new Sizes()
            {
                SizeId = s.SizeId,
                SizeName = s.SizeName
            }).ToList();

            return productDto;
        }
    }
}