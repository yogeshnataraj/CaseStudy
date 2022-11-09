using CaseStudy.Application.Authentication;
using CaseStudy.Application.Interfaces;
using CaseStudy.Domain.Exceptions;
using CaseStudy.Domain.Interfaces;
using CaseStudy.Domain.ProjectAggregate.Data;
using Microsoft.Extensions.Caching.Memory;

namespace CaseStudy.Application.Services
{
    public class ProductServices : IProductServices
    {
        private const string colorKey = "Colors";
        private const string sizekey = "Sizes";

        private readonly IProductRepository _productRepository;
        private readonly IMemoryCache _memory;
        private readonly IRestClient _client;

        public ProductServices(IProductRepository productRepository, IRestClient client, IMemoryCache memory)
        {
            _productRepository = productRepository;
            _memory = memory;
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
                throw new ProducNotFoundException();

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

            var listcolor = default(List<Domain.ProjectAggregate.Data.Color>);
            listcolor = _memory.Get<List<Domain.ProjectAggregate.Data.Color>>(colorKey);
            if (listcolor is null)
            {
                listcolor = await _client.GetColors();
                _memory.Set<List<Domain.ProjectAggregate.Data.Color>>(colorKey, listcolor);
            }

            var listsize = default(List<Domain.ProjectAggregate.Data.Size>);
            listsize = _memory.Get<List<Domain.ProjectAggregate.Data.Size>>(sizekey);
            if (listsize is null)
            {
                listsize = await _client.GetSizes();
                _memory.Set<List<Domain.ProjectAggregate.Data.Size>>(sizekey, listsize);
            }

            //Get Articles and Colors 

            //Add Articles and color obj
            productDto.Articles = productModel.Articals.Select(t => new Article
            {
                ArticleId = t.ArticalId,
                ColourId = t.ColorId,
                ArticleName = $"{productModel.ProductName.ToString()} - {listcolor.Find(a => a.ColorId == t.ColorId).colourCode}",
                ColourCode = listcolor.Find(a => a.ColorId == t.ColorId).colourCode,
                ColourName = listcolor.Find(a => a.ColorId == t.ColorId).colorName
            }).ToList();

            productDto.Sizes = listsize.Where(t => t.SizeId == productModel.SizeScaleId).Select(s => new Sizes()
            {
                SizeId = s.SizeId,
                SizeName = s.SizeName
            }).ToList();

            return productDto;
        }
    }
}