using Domain.Generics.Persistance;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistance.Repositories
{
    public class ImageRepository : Repository<Image, ProgramDbContext>, IImageRepository
    {
        public ImageRepository(IDbContextFactory<ProgramDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<IEnumerable<Image>> GetByEntityId(Guid? entityId)
        {
            return await dbSet.Where(model => model.EntityId == entityId).ToListAsync();
        }
    }
}
