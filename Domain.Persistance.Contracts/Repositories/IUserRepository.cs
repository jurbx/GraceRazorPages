using Domain.Generics.Persistance;
using Domain.Persistance.Entities;

namespace Domain.Persistance.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    { }
}
