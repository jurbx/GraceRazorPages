using Domain.Generics.Persistance;

namespace Domain.Generics.Services
{
    public interface IService<Model> where Model : Entity
    {
        Task<List<Model>> GetAllAsync();
        Task<Model> GetByIdAsync(Guid? id);
        Task UpdateAsync(Model model);
        Task CreateAsync(Model model);
        Task DeleteAsync(Guid? id);
    }
}
