using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CaseStudy.Application.Authentication;
using CaseStudy.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaseStudy.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _productService;

        public ProductController(ILogger<ProductController> logger, IProductServices productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("{productId:Guid}")]
        public async Task<ProductResponse> GetProductAsync([FromRoute] Guid productId)
        {
            return await _productService.GetProductAsync(productId);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductDTO product)
        {
            var productId = await _productService.CreateProductAsync(product);
            return new ObjectResult(productId) { StatusCode = (int)HttpStatusCode.Created };
        }
    }
}