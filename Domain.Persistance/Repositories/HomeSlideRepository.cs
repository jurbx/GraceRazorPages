using Domain.Generics.Persistance;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistance.Repositories
{
    public class HomeSlideRepository : Repository<HomeSlide, ProgramDbContext>, IHomeSlideRepository
    {
        public HomeSlideRepository(IDbContextFactory<ProgramDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
