namespace Domain.Generics.Persistance
{
    public interface IRepository<Model> where Model : Entity
    {
        public Task<List<Model>> GetAllAsync();
        public Task<Model> GetByIdAsync(Guid? id);
        public Task UpdateAsync(Model model);
        public Task CreateAsync(Model model);
        public Task DeleteAsync(Guid? id);
    }
}
