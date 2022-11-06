using CaseStudy.Domain.ProjectAggregate.Data;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.Data;

public class AppDbContext :  DbContext  
{
        public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
			
        }

        public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Artical> Articals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);            			
		}
}