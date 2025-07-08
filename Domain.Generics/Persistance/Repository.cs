using Microsoft.EntityFrameworkCore;

namespace Domain.Generics.Persistance
{
    public class Repository<Model, IDbContext> : IRepository<Model> where Model : Entity where IDbContext : DbContext
    {
        readonly DbContext _context;
        readonly IDbContextFactory<IDbContext> _dbContextFactory;

        private DbSet<Model> theDbSet;
        protected DbSet<Model> dbSet
        {
            get
            {
                if (theDbSet == null)
                    theDbSet = _context.Set<Model>();

                return theDbSet;
            }
        }

        public Repository(IDbContextFactory<IDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _context = dbContextFactory.CreateDbContext();
        }

        public async Task<List<Model>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Model> GetByIdAsync(Guid? id)
        {
            return await dbSet.Where(entity => entity.Id == id).SingleOrDefaultAsync();
        }

        public async Task CreateAsync(Model model)
        {
            if (model != null)
            {
                model.CreatedOn = DateTime.Now;
                _context.Add(model);
            }
               
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Model model)
        {
            _context.ChangeTracker.Clear();
            model.UpdatedOn = DateTime.Now;
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid? id)
        {
            using (var ctx = _dbContextFactory.CreateDbContext())
            {
                var _dbSet = ctx.Set<Model>();
                var entity = _dbSet.Where(model => model.Id == id).First();
                ctx.Remove(entity);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
