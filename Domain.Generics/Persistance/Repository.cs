using Microsoft.EntityFrameworkCore;

namespace Domain.Generics.Persistance
{
    public class Repository<Model> : IRepository<Model> where Model : Entity
    {
        readonly DbContext _context;
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

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<List<Model>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Model> GetByIdAsync(Guid? id)
        {
            return await dbSet.Where(entity => entity.Id == id).SingleAsync();
        }

        public async Task CreateAsync(Model model)
        {
            if (model != null)
                _context.Add(model);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Model model)
        {
           _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid? id)
        {
            var entity = await GetByIdAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
