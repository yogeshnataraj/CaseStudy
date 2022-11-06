using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Application.Authentication;
using CaseStudy.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaseStudy.Api.Controllers
{
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _productService;

        public ProductController(ILogger<ProductController> logger, IProductServices productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("{guid: productId}")]
        public async Task<ProductResponse> GetProductAsync([FromQuery] Guid productId)
        {
            return await _productService.GetProductAsync(productId);
        }

        [HttpPost]
        public async Task<Guid> CreateProductAsync([FromBody] ProductDTO product)
        {
            return await _productService.CreateProductAsync(product);
        }
    }
}