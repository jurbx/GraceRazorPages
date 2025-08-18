using Domain.Generics.Persistance;
using Domain.Persistance.Entities.Entities;

namespace Domain.Persistance.Contracts.Repositories
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<IEnumerable<Image>> GetByEntityId(Guid? id);
        Task DeleteByFilepathAsync(string filepath);
    }
}
