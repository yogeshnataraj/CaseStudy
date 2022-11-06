using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Application.Authentication;
using CaseStudy.Domain.ProjectAggregate.Data;

namespace CaseStudy.Application.Interfaces
{
    public interface IProductServices
    {
        Task<ProductResponse> GetProductAsync(Guid productId);

        Task<Guid> CreateProductAsync(ProductDTO product);
    }
}