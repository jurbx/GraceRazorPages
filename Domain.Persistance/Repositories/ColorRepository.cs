using Domain.Generics.Persistance;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistance.Repositories
{
    public class ColorRepository : Repository<Color, ProgramDbContext>, IColorRepository
    {
        public ColorRepository(IDbContextFactory<ProgramDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<IEnumerable<Color>> GetByProductIdAsync(Guid? productId)
        {
            return await dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}
