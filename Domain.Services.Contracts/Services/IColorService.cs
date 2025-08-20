using Domain.Generics.Services;
using Domain.Persistance.Entities.Entities;

namespace Domain.Services.Contracts.Services
{
    public interface IColorService : IService<Color>
    {
        Task<IEnumerable<Color>> GetByProductIdAsync(Guid? productId);
    }
}
