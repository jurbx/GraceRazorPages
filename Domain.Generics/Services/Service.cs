using Domain.Generics.Persistance;

namespace Domain.Generics.Services
{
    public class Service<Model> : IService<Model> where Model : Entity
    {
        protected IRepository<Model> repository;
        public Service(IRepository<Model> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<List<Model>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public virtual async Task<Model> GetByIdAsync(Guid? id)
        {
            return await repository.GetByIdAsync(id);
        }

        public virtual async Task CreateAsync(Model model)
        {
            await repository.CreateAsync(model);
        }

        public virtual async Task UpdateAsync(Model model)
        {
            await repository.UpdateAsync(model);
        }

        public virtual async Task DeleteAsync(Guid? id)
        {
            await repository.DeleteAsync(id);
        }
    }
}
