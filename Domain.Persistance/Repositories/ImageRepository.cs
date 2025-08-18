using Domain.Generics.Persistance;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Domain.Persistance.Repositories
{
    public class ImageRepository : Repository<Image, ProgramDbContext>, IImageRepository
    {
        private readonly IDbContextFactory<ProgramDbContext> dbContextFactory;

        public ImageRepository(IDbContextFactory<ProgramDbContext> dbContextFactory) : base(dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Image>> GetByEntityId(Guid? entityId)
        {
            return await dbSet.Where(model => model.EntityId == entityId).ToListAsync();
        }

        public async Task DeleteByFilepathAsync(string filepath)
        {
            using (var ctx = dbContextFactory.CreateDbContext())
            {
                var _dbSet = ctx.Set<Image>();
                var img = _dbSet.Where(img => img.ImagePath == filepath).FirstOrDefault();
                if (img != null)
                {
                    ctx.Remove(img);
                    await ctx.SaveChangesAsync();
                }
            }
        }
    }
}
