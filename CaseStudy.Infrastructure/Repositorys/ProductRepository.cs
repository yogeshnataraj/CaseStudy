using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Domain.Interfaces;
using CaseStudy.Domain.ProjectAggregate.Data;
using CaseStudy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.Repositorys
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext dbContact) : base(dbContact)
        {

        }

        public async Task<Product> GetProducts(Guid productId)
        {
            //get data from the database
            var query = _dbContact.Products.AsQueryable();

            var product = await query.SingleOrDefaultAsync(t => t.ProductId == productId);

            return product;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _dbContact.AddAsync(product);
            await _dbContact.SaveChangesAsync();
            return product;
        }
    }
}