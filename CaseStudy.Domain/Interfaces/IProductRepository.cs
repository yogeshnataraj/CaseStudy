using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Domain.ProjectAggregate.Data;

namespace CaseStudy.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProducts(Guid productId);
        Task<Product> AddProduct(Product product);
    }
}