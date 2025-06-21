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

        public Task<List<Model>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<Model> GetByIdAsync(Guid? id)
        {
            return repository.GetByIdAsync(id);
        }

        public Task CreateAsync(Model model)
        {
            return repository.CreateAsync(model);
        }

        public Task UpdateAsync(Model model)
        {
            return repository.UpdateAsync(model);
        }

        public Task DeleteAsync(Guid? id)
        {
            return repository.DeleteAsync(id);
        }
    }
}
