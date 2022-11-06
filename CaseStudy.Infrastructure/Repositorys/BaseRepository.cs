using CaseStudy.Infrastructure.Data;

namespace CaseStudy.Infrastructure.Repositorys
{
    public abstract class BaseRepository 
    {
        public AppDbContext _dbContact;
        public BaseRepository(AppDbContext dbContact)
        {
            _dbContact = dbContact;
        }
    }
}