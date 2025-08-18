using Domain.Generics.Services;
using Domain.Persistance.Entities.Entities;

namespace Domain.Services.Contracts.Services
{
    public interface IImageService : IService<Image>
    {
        Task<IEnumerable<Image>> GetByEntityIdAsync(Guid? entityId);
        Task DeleteByFilepathAsync(string filepath);
    }
}
