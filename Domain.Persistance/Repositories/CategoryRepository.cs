using Domain.Generics.Persistance;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistance.Repositories
{
    public class CategoryRepository : Repository<Category, ProgramDbContext>, ICategoryRepository
    {
        public CategoryRepository(IDbContextFactory<ProgramDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
