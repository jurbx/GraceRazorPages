using Domain.Generics.Persistance;
using Domain.Persistance.Entities.Entities;

namespace Domain.Persistance.Contracts.Repositories
{
    public interface IColorRepository : IRepository<Color>
    {
        Task<IEnumerable<Color>> GetByProductIdAsync(Guid? productId);
    }
}
